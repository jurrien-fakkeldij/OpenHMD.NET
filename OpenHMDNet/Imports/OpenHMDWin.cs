using System;
using System.Runtime.InteropServices;

namespace OpenHMDNet
{
        public class OpenHMDWin
        {
        [DllImport("openhmd.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public IntPtr ohmd_ctx_create();

        [DllImport("openhmd.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public void ohmd_ctx_destroy(IntPtr ctxHandle);

        [DllImport("openhmd.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public string ohmd_ctx_get_error(IntPtr ctxHandle);

        [DllImport("openhmd.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public int ohmd_ctx_probe(IntPtr ctxHandle);

        [DllImport("openhmd.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public IntPtr ohmd_list_open_device(IntPtr ctxHandle, int deviceIndex);

        [DllImport("openhmd.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public IntPtr ohmd_list_gets(IntPtr ctxHandle, int deviceIndex, ohmd_string_value val);

        [DllImport("openhmd.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public int ohmd_device_geti(IntPtr device, ohmd_int_value val, out int out_value);

        [DllImport("openhmd.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public int ohmd_device_getf(IntPtr device, ohmd_float_value val, IntPtr out_value);

        [DllImport("openhmd.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern public void ohmd_ctx_update(IntPtr ctxHandle);
    }
}
