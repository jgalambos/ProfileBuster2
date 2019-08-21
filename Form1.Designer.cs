namespace ProfileBuster2 {
    partial class ProfileBusterMainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileBusterMainForm));
            this.PanelTopContainer = new System.Windows.Forms.Panel();
            this.ButtonGetProfiles = new System.Windows.Forms.Button();
            this.TextBoxSerialNumberInput = new System.Windows.Forms.TextBox();
            this.LabelSN = new System.Windows.Forms.Label();
            this.PanelListViewContainer = new System.Windows.Forms.Panel();
            this.ListViewProfiles = new System.Windows.Forms.ListView();
            this.ColumnProfiles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnDateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PanelBottomContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonBurnIt = new System.Windows.Forms.Button();
            this.PanelBottomText = new System.Windows.Forms.Panel();
            this.LabelTextReadout = new System.Windows.Forms.Label();
            this.PanelTopContainer.SuspendLayout();
            this.PanelListViewContainer.SuspendLayout();
            this.PanelBottomContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelBottomText.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTopContainer
            // 
            this.PanelTopContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelTopContainer.Controls.Add(this.ButtonGetProfiles);
            this.PanelTopContainer.Controls.Add(this.TextBoxSerialNumberInput);
            this.PanelTopContainer.Controls.Add(this.LabelSN);
            this.PanelTopContainer.Location = new System.Drawing.Point(13, 13);
            this.PanelTopContainer.Name = "PanelTopContainer";
            this.PanelTopContainer.Size = new System.Drawing.Size(775, 55);
            this.PanelTopContainer.TabIndex = 1;
            // 
            // ButtonGetProfiles
            // 
            this.ButtonGetProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonGetProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonGetProfiles.Location = new System.Drawing.Point(546, 4);
            this.ButtonGetProfiles.Name = "ButtonGetProfiles";
            this.ButtonGetProfiles.Size = new System.Drawing.Size(226, 38);
            this.ButtonGetProfiles.TabIndex = 2;
            this.ButtonGetProfiles.Text = "Get Profiles";
            this.ButtonGetProfiles.UseVisualStyleBackColor = true;
            this.ButtonGetProfiles.Click += new System.EventHandler(this.ButtonGetProfiles_Click);
            // 
            // TextBoxSerialNumberInput
            // 
            this.TextBoxSerialNumberInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxSerialNumberInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxSerialNumberInput.Location = new System.Drawing.Point(204, 4);
            this.TextBoxSerialNumberInput.Name = "TextBoxSerialNumberInput";
            this.TextBoxSerialNumberInput.Size = new System.Drawing.Size(335, 38);
            this.TextBoxSerialNumberInput.TabIndex = 1;
            this.TextBoxSerialNumberInput.Leave += new System.EventHandler(this.TextBoxSerialNumberInput_Leave);
            // 
            // LabelSN
            // 
            this.LabelSN.AutoSize = true;
            this.LabelSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSN.Location = new System.Drawing.Point(4, 4);
            this.LabelSN.Name = "LabelSN";
            this.LabelSN.Size = new System.Drawing.Size(194, 31);
            this.LabelSN.TabIndex = 0;
            this.LabelSN.Text = "Serial Number:";
            // 
            // PanelListViewContainer
            // 
            this.PanelListViewContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelListViewContainer.Controls.Add(this.ListViewProfiles);
            this.PanelListViewContainer.Location = new System.Drawing.Point(12, 74);
            this.PanelListViewContainer.Name = "PanelListViewContainer";
            this.PanelListViewContainer.Size = new System.Drawing.Size(776, 300);
            this.PanelListViewContainer.TabIndex = 2;
            // 
            // ListViewProfiles
            // 
            this.ListViewProfiles.AllowColumnReorder = true;
            this.ListViewProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewProfiles.CheckBoxes = true;
            this.ListViewProfiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnProfiles,
            this.ColumnDateModified});
            this.ListViewProfiles.Location = new System.Drawing.Point(3, 3);
            this.ListViewProfiles.Name = "ListViewProfiles";
            this.ListViewProfiles.Size = new System.Drawing.Size(767, 294);
            this.ListViewProfiles.TabIndex = 0;
            this.ListViewProfiles.UseCompatibleStateImageBehavior = false;
            this.ListViewProfiles.View = System.Windows.Forms.View.Details;
            this.ListViewProfiles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewProfiles_ColumnClick);
            // 
            // ColumnProfiles
            // 
            this.ColumnProfiles.Text = "Profile List";
            this.ColumnProfiles.Width = 107;
            // 
            // ColumnDateModified
            // 
            this.ColumnDateModified.Text = "Last Modified";
            this.ColumnDateModified.Width = 129;
            // 
            // PanelBottomContainer
            // 
            this.PanelBottomContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelBottomContainer.Controls.Add(this.panel1);
            this.PanelBottomContainer.Controls.Add(this.PanelBottomText);
            this.PanelBottomContainer.Location = new System.Drawing.Point(12, 380);
            this.PanelBottomContainer.Name = "PanelBottomContainer";
            this.PanelBottomContainer.Size = new System.Drawing.Size(776, 58);
            this.PanelBottomContainer.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ButtonBurnIt);
            this.panel1.Location = new System.Drawing.Point(647, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 51);
            this.panel1.TabIndex = 2;
            // 
            // ButtonBurnIt
            // 
            this.ButtonBurnIt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonBurnIt.Location = new System.Drawing.Point(3, 0);
            this.ButtonBurnIt.Name = "ButtonBurnIt";
            this.ButtonBurnIt.Size = new System.Drawing.Size(120, 48);
            this.ButtonBurnIt.TabIndex = 0;
            this.ButtonBurnIt.Text = "Burn It!";
            this.ButtonBurnIt.UseVisualStyleBackColor = true;
            this.ButtonBurnIt.Click += new System.EventHandler(this.ButtonBurnIt_Click);
            // 
            // PanelBottomText
            // 
            this.PanelBottomText.Controls.Add(this.LabelTextReadout);
            this.PanelBottomText.Location = new System.Drawing.Point(4, 4);
            this.PanelBottomText.Name = "PanelBottomText";
            this.PanelBottomText.Size = new System.Drawing.Size(634, 51);
            this.PanelBottomText.TabIndex = 1;
            // 
            // LabelTextReadout
            // 
            this.LabelTextReadout.AutoSize = true;
            this.LabelTextReadout.Location = new System.Drawing.Point(4, 17);
            this.LabelTextReadout.Name = "LabelTextReadout";
            this.LabelTextReadout.Size = new System.Drawing.Size(96, 13);
            this.LabelTextReadout.TabIndex = 0;
            this.LabelTextReadout.Text = "Blood for Freedom!";
            // 
            // ProfileBusterMainForm
            // 
            this.AcceptButton = this.ButtonGetProfiles;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelBottomContainer);
            this.Controls.Add(this.PanelListViewContainer);
            this.Controls.Add(this.PanelTopContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProfileBusterMainForm";
            this.Text = "SPEARS SHALL BE SHAKEN, SHIELDS SHALL BE SPLINTERED";
            this.PanelTopContainer.ResumeLayout(false);
            this.PanelTopContainer.PerformLayout();
            this.PanelListViewContainer.ResumeLayout(false);
            this.PanelBottomContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.PanelBottomText.ResumeLayout(false);
            this.PanelBottomText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelTopContainer;
        private System.Windows.Forms.Panel PanelListViewContainer;
        private System.Windows.Forms.ListView ListViewProfiles;
        private System.Windows.Forms.Panel PanelBottomContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ButtonBurnIt;
        private System.Windows.Forms.Panel PanelBottomText;
        private System.Windows.Forms.Label LabelTextReadout;
        private System.Windows.Forms.Label LabelSN;
        private System.Windows.Forms.TextBox TextBoxSerialNumberInput;
        private System.Windows.Forms.Button ButtonGetProfiles;
        private System.Windows.Forms.ColumnHeader ColumnProfiles;
        private System.Windows.Forms.ColumnHeader ColumnDateModified;
    }
}

