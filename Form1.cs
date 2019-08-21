using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Reflection;

namespace ProfileBuster2 {
    public partial class ProfileBusterMainForm : Form {
        const string TITLE = "Profile Buster";
        /// <summary>
        /// List of Profiles with Date Modified and Orphaned properties.  Our main window picks up from this.
        /// </summary>
        private List<ProfileKey> ProfileList = new List<ProfileKey>();

        /// <summary>
        /// Machine name.
        /// </summary>
        private string SerialNumber;

        

        /// <summary>
        /// Initialization
        /// </summary>
        public ProfileBusterMainForm() {
            InitializeComponent();
            this.Text = string.Format("{0} v{1}", TITLE, Assembly.GetExecutingAssembly().GetName().Version.ToString());
            TextBoxSerialNumberInput.Text = Environment.MachineName;
            SerialNumber = Environment.MachineName;
            //Replace the following SNs for test beds if needed
            //TextBoxSerialNumberInput.Text = "2UA8202LQF";
            //SerialNumber = "2UA8202LQF";

            ListViewProfiles.ListViewItemSorter = new ListViewColumnSorter();

            // Populate our ListView
            GetProfileList();
        }

        /// <summary>
        /// Whenever anything happens, capitalize whatever text is in the Serial Number
        /// input field and remove any whitespace.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSerialNumberInput_Leave(object sender, EventArgs e) {
            // Capitalize SN for readability
            TextBoxSerialNumberInput.Text = TextBoxSerialNumberInput.Text.ToUpper();
            // Remove whitespace
            TextBoxSerialNumberInput.Text = Regex.Replace(TextBoxSerialNumberInput.Text, @"\s+", "");
        }

        /// <summary>
        /// When Get Profiles is clicked, search PC for all profiles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonGetProfiles_Click(object sender, EventArgs e) {
            LabelTextReadout.Text = "Searching for serial number " + SerialNumber + "....";
            SerialNumber = TextBoxSerialNumberInput.Text;
            
            // Populate our ListView
            GetProfileList();
        }


        /// <summary>
        /// Search through registry and C:\Users to find all instances of profile data.
        /// </summary>
        private void GetProfileList() {
            // Clear any garbage data
            ListViewProfiles.Items.Clear();
            
            ProfileList = new List<ProfileKey>();

            // Try to read data and catch any typos made in SN input field
            try {

                // Read all profile data in the registry

                // **IMPORTANT NOTE**
                // "OpenRemoteBaseKey" will occasionally throw an "UnauthorizedAccessException: Attempted to perform an unauthorized operation."
                // I have no idea why.
                using (RegistryKey key = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, SerialNumber).OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\ProfileList\")) {
                    foreach (string profile in key.GetSubKeyNames()) {
                        using (RegistryKey key2 = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, SerialNumber).OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\ProfileList\" + profile.ToString())) {
                            if (key2 != null && key2.GetValue("ProfileImagePath") != null) {
                                // Need to make sure key2 isn't null before we do this next check or it'll throw an error
                                if (key2.GetValue("ProfileImagePath").ToString().Contains(@"C:\Users")) {
                                    string tempName = key2.GetValue("ProfileImagePath").ToString().Split('\\').Last();
                                    // We don't want to blow up the local admin or HSCSUI profiles (ever? maybe an 'advanced' option for powerusers?)
                                    if (tempName != "HSCSUI" && tempName != "Administrator") {
                                        ProfileList.Add(new ProfileKey(tempName, @"Software\Microsoft\Windows NT\CurrentVersion\ProfileList\" + profile.ToString(), SerialNumber));
                                        Console.WriteLine(tempName);
                                    }
                                }
                            }
                        }
                    }
                }

                // Now we read all profile data in C:\Users
                string[] profiles = Directory.GetDirectories(@"\\" + SerialNumber + @"\C$\Users");
                List<ProfileKey> tempList = new List<ProfileKey>();
                foreach (string profile in profiles) {
                    bool tempFlag = true;
                    string tempName = profile.Split('\\').Last();

                    // I can't remember what tempFlag is supposed to do - something to do with dilineating orphaned and non-orphaned profiles.
                    foreach (ProfileKey item in ProfileList) {
                        if (tempName == item.ToString().ToUpper()) {
                            tempFlag = false;
                        } else if (tempName.ToUpper() != "HSCSUI" && tempName.ToUpper() != "ADMINISTRATOR") {
                            foreach (ProfileKey key in ProfileList) {
                                if (key.Name.ToUpper() == tempName.ToUpper()) {
                                    tempFlag = false;
                                }
                            }

                        }
                    }

                    if (tempFlag) {
                        tempList.Add(new ProfileKey(tempName, profile, true, SerialNumber));
                    }
                }

                // Add every profile found to main list.
                
                foreach (ProfileKey profile in tempList) {
                    ProfileList.Add(profile); // Adds the profile userID
                    
                }
                LabelTextReadout.Text = "Data gathered. Printing to screen...";
            } catch (IOException) {
                LabelTextReadout.Text = "No network path found. Are you sure you typed it properly?";
                return;
            } catch (UnauthorizedAccessException) {
                LabelTextReadout.Text = "Encountered that weird permissions issue that I can't seem to fix. Gonna have to do this manually. Sorry.";
                return;
            }

            // Finally, add all data we found to our main List View (ListViewProfiles)
            // Declare directory info to retrieve last modified data
            DirectoryInfo info;

            
            for (int j = 0; j < ProfileList.Count; j++) {
                // Commented out blocks don't work because ListView.Add seems to add stuff in a random order, WTF!?
                //ListViewProfiles.Items.Add(ProfileList[j].Name);
                info = new DirectoryInfo(ProfileList[j].DirectoryPath);
                //ListViewProfiles.Items[j].SubItems.Add(info.LastWriteTime.ToString());
                string[] row = { ProfileList[j].Name, info.LastWriteTime.ToString() };
                ListViewProfiles.Items.Add(new ListViewItem(row));
                
                // TODO: Add orphaned profile logic
            }
            LabelTextReadout.Text = "Done. Select profiles to burn.";
        }

        /// <summary>
        /// The fun part. Destroy all checked items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBurnIt_Click(object sender, EventArgs e) {
            Console.WriteLine("Burning it!");
            LabelTextReadout.Text = "Burning it!";
            foreach (ListViewItem item in ListViewProfiles.CheckedItems) {

                Console.WriteLine("deleting C:\\users\\" + item.Text);
                LabelTextReadout.Text = "Deleting C:\\users\\" + item.Text + "....";
                string[] files = Directory.GetDirectories(@"\\" + SerialNumber + @"\C$\Users");
                foreach (string file in files) {
                    if (file.ToUpper().Contains(item.Text.ToUpper())) {
                        DirectoryInfo dir = new DirectoryInfo(file);
                        if (dir.Exists) {
                            System.Diagnostics.ProcessStartInfo temp = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c " + @"rmdir /s/q \\" + SerialNumber + @"\C$\Users\" + item.Text);
                            //temp.UseShellExecute = false;
                            temp.CreateNoWindow = true;
                            temp.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            System.Diagnostics.Process.Start(temp);
                            LabelTextReadout.Text += " Deleting files, this will take a while. Grab a coffee.";
                            using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(temp)) {
                                process.WaitForExit();
                            }
                        }
                    }
                }

                RegistryKey BaseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, SerialNumber, RegistryView.Registry64);
                LabelTextReadout.Text = "Attempting to delete registry entries....";
                using (RegistryKey key = BaseKey.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\ProfileList", true)) {
                    foreach (string profile in key.GetSubKeyNames()) {
                        RegistryKey key2 = BaseKey.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\ProfileList\" + profile.ToString(), true);
                        using (key2) {
                            if (item.Text.ToString() == key2.GetValue("ProfileImagePath").ToString().Split('\\').Last()) {
                                Console.WriteLine("deleting " + item.Text + "....");
                                LabelTextReadout.Text = "Deleting " + item.Text + "....";
                                Console.WriteLine("attempting to delete " + key2.Name);
                                LabelTextReadout.Text = "Attempting to delete " + key2.Name;
                                key.DeleteSubKey(key2.Name.ToString().Split('\\').Last());
                            }
                        }
                    }
                }

                // This code doesn't appear to work.  When getting to folders like Cookies and Nethood, it errors out.
                // No amount of checking or setting permissions appears to work.
                //Directory.Delete(@"\\" + SerialNumber + @"\C$\Users\" + item.Text.ToString(), true);
                /*Console.WriteLine("deleting orphaned profile C:\\users\\" + item.Text.ToString().Split('.').First());
                if (item.Text.ToString().Contains(item.Text.ToString().Split('.').First()))
                    Directory.Delete(@"\\" + SerialNumber + @"\C$\Users\" + item.Text.ToString().Split('.').First());*/
                GetProfileList();
                Console.WriteLine("done??");
                LabelTextReadout.Text = "Done??";
            }
        }

        private int sortColumnIndex = -1;
        /// <summary>
        /// Sort using our custom sorter class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewProfiles_ColumnClick(object sender, ColumnClickEventArgs e) {
            // If we click on a different column, reset the sort order.
            if (e.Column != sortColumnIndex) {
                sortColumnIndex = e.Column;
                ListViewProfiles.Sorting = SortOrder.Ascending;
            } else {
                // If we click on the same column as last click, reverse the sort order.
                if (ListViewProfiles.Sorting == SortOrder.Ascending)
                    ListViewProfiles.Sorting = SortOrder.Descending;
                else
                    ListViewProfiles.Sorting = SortOrder.Ascending;
            }
            ListViewProfiles.Sort();
            ListViewProfiles.ListViewItemSorter = new ListViewColumnSorter(e.Column, ListViewProfiles.Sorting);
        }
  }
}
