using System;
using System.IO;

namespace OpenHMDNet
{
    public class Utility
    {
        public static bool isLinux()
        {
            return true;
        }

        public enum Platform
        {
            LINUX,
            WINDOWS,
            MAC,
            UNKNOWN,
        }

        public static Platform getCurrentPlatform()
        {
            string windir = Environment.GetEnvironmentVariable("windir");
            if (!string.IsNullOrEmpty(windir) && windir.Contains(@"\") && Directory.Exists(windir))
            {
                return Platform.WINDOWS;
            }
            else if (File.Exists(@"/proc/sys/kernel/ostype"))
            {
                string osType = File.ReadAllText(@"/proc/sys/kernel/ostype");
                if (osType.StartsWith("Linux", StringComparison.OrdinalIgnoreCase))
                {
                    //Includes Android as well
                    return Platform.LINUX;
                }
                else
                {
                    throw new CanNotFindPlatform(osType);
                }
            }
            else if (File.Exists(@"/System/Library/CoreServices/SystemVersion.plist"))
            {
                //Includes iOS as well
                return Platform.MAC;
            }
            else
            {
                throw new CanNotFindPlatform("Unknown Platform");
            }
        }
    }
}
