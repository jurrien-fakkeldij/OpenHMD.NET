using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OpenHMDNet
{
    public class Utility
    {


        public static bool isLinux()
        {
            return true;
        }

        public enum currentPlatform
        {
            is_linux,
            is_windows,
            is_mac,
            is_unknown,
        }

        public static currentPlatform getCurrentPlatform()
        {
            string windir = Environment.GetEnvironmentVariable("windir");
            if (!string.IsNullOrEmpty(windir) && windir.Contains(@"\") && Directory.Exists(windir))
            {
                return currentPlatform.is_windows;
            }
            else if (File.Exists(@"/proc/sys/kernel/ostype"))
            {
                string osType = File.ReadAllText(@"/proc/sys/kernel/ostype");
                if (osType.StartsWith("Linux", StringComparison.OrdinalIgnoreCase))
                {
                    //Includes Android as well
                    return currentPlatform.is_linux;
                }
                else
                {
                    throw new CanNotFindPlatform(osType);
                }
            }
            else if (File.Exists(@"/System/Library/CoreServices/SystemVersion.plist"))
            {
                //Includes iOS as well
                return currentPlatform.is_mac;
            }
            else
            {
                throw new CanNotFindPlatform("Unknown Platform");
            }
        }
    }
}
