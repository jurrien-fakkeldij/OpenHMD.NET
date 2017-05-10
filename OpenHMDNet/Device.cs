using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenHMDNet
{
    public class Device
    {
        public Device (int deviceIndex, string vendor, string product, string path)
        {
            Index = deviceIndex;
            Vendor = vendor;
            Product = product;
            Path = path;
        }

        public string Vendor { get; private set; }
        public string Product { get; private set; }
        public string Path { get; private set; }
        public int Index { get; private set; }
    }
}
