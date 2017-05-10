using System;
using static OpenHMDNet.Utility;

namespace OpenHMDNet
{
    public class OpenHMDPlatform {
        static public IntPtr ohmd_ctx_create()
        {
            if (getCurrentPlatform() == Platform.WINDOWS)
            {
                return OpenHMDWin.ohmd_ctx_create();
            }
            else if (getCurrentPlatform() == Platform.LINUX)
            {
                return OpenHMDLin.ohmd_ctx_create();
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static public void ohmd_ctx_destroy(IntPtr ctxHandle)
        {
            if (getCurrentPlatform() == Platform.WINDOWS)
            {
                OpenHMDWin.ohmd_ctx_destroy(ctxHandle);
            }
            else if (getCurrentPlatform() == Platform.LINUX)
            {
                OpenHMDLin.ohmd_ctx_destroy(ctxHandle);
            }
            else
            {
                throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
            }
        }

        static public string ohmd_ctx_get_error(IntPtr ctxHandle)
        {
            if (getCurrentPlatform() == Platform.WINDOWS)
            {
                return OpenHMDWin.ohmd_ctx_get_error(ctxHandle);
            }
            else if (getCurrentPlatform() == Platform.LINUX)
            {
                return OpenHMDLin.ohmd_ctx_get_error(ctxHandle);
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static public int ohmd_ctx_probe(IntPtr ctxHandle)
        {
            if (getCurrentPlatform() == Platform.WINDOWS)
            {
                return OpenHMDWin.ohmd_ctx_probe(ctxHandle);
            }
            else if (getCurrentPlatform() == Platform.LINUX)
            {
                return OpenHMDLin.ohmd_ctx_probe(ctxHandle);
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static public IntPtr ohmd_list_open_device(IntPtr ctxHandle, int deviceIndex)
        {
            if (getCurrentPlatform() == Platform.WINDOWS)
            {
                return OpenHMDWin.ohmd_list_open_device(ctxHandle, deviceIndex);
            }
            else if (getCurrentPlatform() == Platform.LINUX)
            {
                return OpenHMDLin.ohmd_list_open_device(ctxHandle, deviceIndex);
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static public IntPtr ohmd_list_gets(IntPtr ctxHandle, int deviceIndex, ohmd_string_value val)
        {
            if (getCurrentPlatform() == Platform.WINDOWS)
            {
                return OpenHMDWin.ohmd_list_gets(ctxHandle, deviceIndex, val);
            }
            else if (getCurrentPlatform() == Platform.LINUX)
            {
                return OpenHMDLin.ohmd_list_gets(ctxHandle, deviceIndex, val);
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static public int ohmd_device_geti(IntPtr device, ohmd_int_value val)
        {
            if (getCurrentPlatform() == Platform.WINDOWS)
            {
                int out_value;
                if (OpenHMDWin.ohmd_device_geti(device, val, out out_value) >= 0)
                    return out_value;
            }
            else if (getCurrentPlatform() == Platform.LINUX)
            {
                int out_value;
                if (OpenHMDLin.ohmd_device_geti(device, val, out out_value) >= 0)
                    return out_value;
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static public int ohmd_device_getf(IntPtr device, ohmd_float_value val, IntPtr out_value)
        {
            if (getCurrentPlatform() == Platform.WINDOWS)
            {
                return OpenHMDWin.ohmd_device_getf(device, val, out_value);
            }
            else if (getCurrentPlatform() == Platform.LINUX)
            {
                return OpenHMDLin.ohmd_device_getf(device, val, out_value);
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static public void ohmd_ctx_update(IntPtr ctxHandle)
        {
            if (getCurrentPlatform() == Platform.WINDOWS)
            {
                OpenHMDWin.ohmd_ctx_update(ctxHandle);
            }
            else if (getCurrentPlatform() == Platform.LINUX)
            {
                OpenHMDLin.ohmd_ctx_update(ctxHandle);
            }
            else
            {
                throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
            }
        }
    }
}