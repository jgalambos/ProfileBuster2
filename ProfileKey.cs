using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileBuster2 {

    //ProfileKey is where we store our registry keys for profiles. It keeps track of the path of the registry key,
    // the path of the accompanying directory in C:\users, and the name (corresponding to the user's domain ID.)
    class ProfileKey {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsOrphaned { get; set; }
        public string DirectoryPath { get; set; }

        public ProfileKey(string name, string path, string SerialNumber) {
            Name = name;
            Path = path;
            IsOrphaned = false;
            DirectoryPath = @"\\" + SerialNumber + @"\C$\Users\" + name;
        }

        public ProfileKey(string name, string path, bool isorphaned, string SerialNumber) {
            Name = name;
            Path = path;
            IsOrphaned = isorphaned;
            DirectoryPath = @"\\" + SerialNumber + @"\C$\Users\" + name;
        }
    }
}
