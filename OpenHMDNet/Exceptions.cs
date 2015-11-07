using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHMDNet
{
    public class NoOpenHMDContextSpecifiedException : Exception
    {
        public NoOpenHMDContextSpecifiedException(string message) : base(message) { }
    }

    public class OpenHMDContextAlreadyOpened : Exception
    {
        public OpenHMDContextAlreadyOpened(string message) : base(message) { }
    }

    public class OpenHMDDeviceAlreadyOpened : Exception
    {
        public OpenHMDDeviceAlreadyOpened(string message) : base(message) { }
    }

    public class DeviceNotOpenedException : Exception
    {
        public DeviceNotOpenedException(string message) : base(message) { }
    }
}
