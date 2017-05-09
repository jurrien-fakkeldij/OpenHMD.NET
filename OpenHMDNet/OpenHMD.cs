using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenHMDNet
{
    public class OpenHMD
    {
        #region OpenHMDDll Imports
        public class OpenHMDWin
        {
            [DllImport("libopenhmd.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern public IntPtr ohmd_ctx_create();

            [DllImport("libopenhmd.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern public void ohmd_ctx_destroy(IntPtr ctxHandle);

            [DllImport("libopenhmd.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern public string ohmd_ctx_get_error(IntPtr ctxHandle);

            [DllImport("libopenhmd.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern public int ohmd_ctx_probe(IntPtr ctxHandle);

            [DllImport("libopenhmd.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern public IntPtr ohmd_list_open_device(IntPtr ctxHandle, int deviceIndex);

            [DllImport("libopenhmd.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern public IntPtr ohmd_list_gets(IntPtr ctxHandle, int deviceIndex, ohmd_string_value val);

            [DllImport("libopenhmd.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern public int ohmd_device_geti(IntPtr device, ohmd_int_value val, out int out_value);

            [DllImport("libopenhmd.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern public int ohmd_device_getf(IntPtr device, ohmd_float_value val, IntPtr out_value);

            [DllImport("libopenhmd.dll", CallingConvention = CallingConvention.Cdecl)]
            static extern public void ohmd_ctx_update(IntPtr ctxHandle);
        }

        public class OpenHMDLin
        {
            [DllImport("libopenhmd.so", CallingConvention = CallingConvention.Cdecl)]
            static extern public IntPtr ohmd_ctx_create();

            [DllImport("libopenhmd.so", CallingConvention = CallingConvention.Cdecl)]
            static extern public void ohmd_ctx_destroy(IntPtr ctxHandle);

            [DllImport("libopenhmd.so", CallingConvention = CallingConvention.Cdecl)]
            static extern public string ohmd_ctx_get_error(IntPtr ctxHandle);

            [DllImport("libopenhmd.so", CallingConvention = CallingConvention.Cdecl)]
            static extern public int ohmd_ctx_probe(IntPtr ctxHandle);

            [DllImport("libopenhmd.so", CallingConvention = CallingConvention.Cdecl)]
            static extern public IntPtr ohmd_list_open_device(IntPtr ctxHandle, int deviceIndex);

            [DllImport("libopenhmd.so", CallingConvention = CallingConvention.Cdecl)]
            static extern public IntPtr ohmd_list_gets(IntPtr ctxHandle, int deviceIndex, ohmd_string_value val);

            [DllImport("libopenhmd.so", CallingConvention = CallingConvention.Cdecl)]
            static extern public int ohmd_device_geti(IntPtr device, ohmd_int_value val, out int out_value);

            [DllImport("libopenhmd.so", CallingConvention = CallingConvention.Cdecl)]
            static extern public int ohmd_device_getf(IntPtr device, ohmd_float_value val, IntPtr out_value);

            [DllImport("libopenhmd.so", CallingConvention = CallingConvention.Cdecl)]
            static extern public void ohmd_ctx_update(IntPtr ctxHandle);
        }

        static private IntPtr ohmd_ctx_create()
        {
            if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_windows)
            {
                return OpenHMDWin.ohmd_ctx_create();
            }
            else if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_linux)
            {
                return OpenHMDLin.ohmd_ctx_create();
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static private void ohmd_ctx_destroy(IntPtr ctxHandle)
        {
            if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_windows)
            {
                OpenHMDWin.ohmd_ctx_destroy(ctxHandle);
            }
            else if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_linux)
            {
                OpenHMDLin.ohmd_ctx_destroy(ctxHandle);
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static private string ohmd_ctx_get_error(IntPtr ctxHandle)
        {
            if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_windows)
            {
                return OpenHMDWin.ohmd_ctx_get_error(ctxHandle);
            }
            else if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_linux)
            {
                return OpenHMDLin.ohmd_ctx_get_error(ctxHandle);
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static private int ohmd_ctx_probe(IntPtr ctxHandle)
        {
            if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_windows)
            {
                return OpenHMDWin.ohmd_ctx_probe(ctxHandle);
            }
            else if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_linux)
            {
                return OpenHMDLin.ohmd_ctx_probe(ctxHandle);
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static private IntPtr ohmd_list_open_device(IntPtr ctxHandle, int deviceIndex)
        {
            if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_windows)
            {
                return OpenHMDWin.ohmd_list_open_device(ctxHandle, deviceIndex);
            }
            else if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_linux)
            {
                return OpenHMDLin.ohmd_list_open_device(ctxHandle, deviceIndex);
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static private IntPtr ohmd_list_gets(IntPtr ctxHandle, int deviceIndex, ohmd_string_value val)
        {
            if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_windows)
            {
                return OpenHMDWin.ohmd_list_gets(ctxHandle, deviceIndex, val);
            }
            else if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_linux)
            {
                return OpenHMDLin.ohmd_list_gets(ctxHandle, deviceIndex, val);
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static private int ohmd_device_geti(IntPtr device, ohmd_int_value val)
        {
            if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_windows)
            {
                //abstract opgeschreven.
                int out_value;
                if (OpenHMDLin.ohmd_device_geti(device, val, out out_value) >= 0)
                    return out_value;
            }
            else if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_linux)
            {
                //abstract opgeschreven.
                int out_value;
                if (OpenHMDLin.ohmd_device_geti(device, val, out out_value) >= 0)
                    return out_value;
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static private int ohmd_device_getf(IntPtr device, ohmd_float_value val, IntPtr out_value)
        {
            if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_windows)
            {
                return OpenHMDWin.ohmd_device_getf(device, val, out_value);
            }
            else if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_linux)
            {
                return OpenHMDLin.ohmd_device_getf(device, val, out_value);
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }

        static private void ohmd_ctx_update(IntPtr ctxHandle)
        {
            if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_windows)
            {
                OpenHMDWin.ohmd_ctx_update(ctxHandle);
            }
            else if (Utility.getCurrentPlatform() == Utility.currentPlatform.is_linux)
            {
                OpenHMDLin.ohmd_ctx_update(ctxHandle);
            }
            throw new Exception("Critical error, please check if the OpenHMD library is loaded correctly.");
        }


        /** Return status codes, used for all functions that can return an error. */
        public enum ohmd_status
        {
            OHMD_S_OK = 0,
            OHMD_S_UNKNOWN_ERROR = -1,
            OHMD_S_INVALID_PARAMETER = -2,

            /** OHMD_S_USER_RESERVED and below can be used for user purposes, such as errors within ohmd wrappers, etc. */
            OHMD_S_USER_RESERVED = -16384,
        }

        /** A collection of string value information types used for getting information with ohmd_list_gets(). */
        public enum ohmd_string_value
        {
            OHMD_VENDOR = 0,
            OHMD_PRODUCT = 1,
            OHMD_PATH = 2,
        }

        /** A collection of float value information types used for getting and setting information with 
         ohmd_device_getf() and ohmd_device_setf(). */
        public enum ohmd_float_value
        {
            /** float[4], get - Absolute rotation of the device, in space, as a quaternion. */
            OHMD_ROTATION_QUAT = 1,

            /** float[16], get - A "ready to use" OpenGL style 4x4 matrix with a modelview matrix for the 
             left eye of the HMD. */
            OHMD_LEFT_EYE_GL_MODELVIEW_MATRIX = 2,

            /** float[16], get - A "ready to use" OpenGL style 4x4 matrix with a modelview matrix for the 
             right eye of the HMD. */
            OHMD_RIGHT_EYE_GL_MODELVIEW_MATRIX = 3,

            /** float[16], get - A "ready to use" OpenGL style 4x4 matrix with a projection matrix for the 
             left eye of the HMD. */
            OHMD_LEFT_EYE_GL_PROJECTION_MATRIX = 4,
            /** float[16], get - A "ready to use" OpenGL style 4x4 matrix with a projection matrix for the 
             right eye of the HMD. */
            OHMD_RIGHT_EYE_GL_PROJECTION_MATRIX = 5,

            /** float[3], get - A 3-D vector representing the absolute position of the device, in space. */
            OHMD_POSITION_VECTOR = 6,

            /** float[1], get - Physical width of the device screen, in centimeters. */
            OHMD_SCREEN_HORIZONTAL_SIZE = 7,
            /** float[1], get - Physical height of the device screen, in centimeters. */
            OHMD_SCREEN_VERTICAL_SIZE = 8,

            /** float[1], get - Physical speration of the device lenses, in centimeters. */
            OHMD_LENS_HORIZONTAL_SEPARATION = 9,
            /** float[1], get - Physical vertical position of the lenses, in centimeters. */
            OHMD_LENS_VERTICAL_POSITION = 10,

            /** float[1], get - Physical field of view for the left eye, in degrees. */
            OHMD_LEFT_EYE_FOV = 11,
            /** float[1], get - Physical display aspect ratio for the left eye screen. */
            OHMD_LEFT_EYE_ASPECT_RATIO = 12,
            /** float[1], get - Physical field of view for the left right, in degrees. */
            OHMD_RIGHT_EYE_FOV = 13,
            /** float[1], get
                  Physical display aspect ratio for the right eye screen. */
            OHMD_RIGHT_EYE_ASPECT_RATIO = 14,

            /** float[1], get/set - Physical interpupilary distance of the user, in centimeters. */
            OHMD_EYE_IPD = 15,

            /** float[1], get/set - Z-far value for the projection matrix calculations, i.e. drawing distance. */
            OHMD_PROJECTION_ZFAR = 16,
            /** float[1], get/set - Z-near value for the projection matrix calculations, i.e. close clipping 
             distance. */
            OHMD_PROJECTION_ZNEAR = 17,

            /** float[6], get - Device specifc distortion value. */
            OHMD_DISTORTION_K = 18,

        }

        /** A collection of int value information types used for getting information with ohmd_device_geti()*/
        public enum ohmd_int_value
        {
            /** int[1], get
                  Physical horizontal resolution of the device screen. */
            OHMD_SCREEN_HORIZONTAL_RESOLUTION = 0,
            /** int[1], get
                  Physical vertical resolution of the device screen. */
            OHMD_SCREEN_VERTICAL_RESOLUTION = 1,

        }
        #endregion OpenHMDDll Imports

        IntPtr openHMDContext = IntPtr.Zero;
        SortedList<int, IntPtr> openedDevices = new SortedList<int, IntPtr>();

        public OpenHMD(){}

        /// <summary>
        /// Opens the context for the OpenHMD driver, so we can use this for the rest of the application.
        /// </summary>
        public void openContext()
        {
            if( openHMDContext != IntPtr.Zero)
            {
                throw new OpenHMDContextAlreadyOpened("There is already a context specified, no need to open a new one.");
            }

            try
            {
                openHMDContext = ohmd_ctx_create();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on Startup." + e.ToString());
            }
        }

        /// <summary>
        /// Gets the list of devices found by the OpenHMD driver with Vendor, Product and Path information.
        /// </summary>
        /// <returns>List of Devices found by the OpenHMD driver.</returns>
        public List<Device> getDevices()
        {
            List<Device> lDevices = new List<Device>();
            if (openHMDContext == IntPtr.Zero)
                openContext();

            int num_devices = ohmd_ctx_probe(openHMDContext);
            if (num_devices < 0)
            {
                Console.WriteLine(String.Format("failed to probe devices : {0}", ohmd_ctx_get_error(openHMDContext)));
            }

            Console.WriteLine(String.Format("num devices:  {0}", num_devices));

            for (int i = 0; i < num_devices; i++)
            {
                string vendor = Marshal.PtrToStringAnsi(ohmd_list_gets(openHMDContext, i, ohmd_string_value.OHMD_VENDOR));
                string product = Marshal.PtrToStringAnsi(ohmd_list_gets(openHMDContext, i, ohmd_string_value.OHMD_PRODUCT));
                string path = Marshal.PtrToStringAnsi(ohmd_list_gets(openHMDContext, i, ohmd_string_value.OHMD_PATH));
                lDevices.Add(new Device(i, vendor, product, path));
            }

            return lDevices;
        }

        /// <summary>
        /// Opens a device for use by the OpenHMD driver and the application.
        /// </summary>
        /// <param name="device">The device you want to open.</param>
        public void openDevice(Device device)
        {
            if (openHMDContext == IntPtr.Zero)
                openContext();

            if(openedDevices.ContainsKey(device.Index))
            {
                throw new OpenHMDDeviceAlreadyOpened(String.Format("The device with id: {0} has already been opened before and can be used.", device.Index));
            }

            IntPtr hmd = ohmd_list_open_device(openHMDContext, 0);
            if (hmd == null)
            {
                Console.WriteLine(String.Format("failed to open device: {0}", ohmd_ctx_get_error(openHMDContext)));
                return;
            }
            openedDevices.Add(device.Index, hmd);
        }

        /// <summary>
        /// Gets integer information from the device.
        /// </summary>
        /// <param name="device">The opened device you want information from.</param>
        /// <param name="informationType">Enum value for what kind of information is needed.</param>
        /// <returns>Returns an integer corresponding to the informationType which is requested.</returns>
        public int getIntInformation(Device device, ohmd_int_value informationType)
        {
            if(!openedDevices.ContainsKey(device.Index))
            {
                throw new DeviceNotOpenedException(String.Format("Device with index {0} and name {1} is not yet openend. Please open first.", device.Index, device.Product));
            }
            IntPtr hmd = openedDevices[device.Index];
            int output = ohmd_device_geti(hmd, informationType);

            return output;
        }

        /// <summary>
        /// Gets float information from a device.
        /// </summary>
        /// <param name="device">The opened device you want information from.</param>
        /// <param name="arrayLength">Length of the array information you want.</param>
        /// <param name="informationType">Enum value for what kind of information is needed.</param>
        /// <returns>Returns an array of floats where the length is defined by arrayLength which is requested.</returns>
        public float[] getFloatInformation(Device device, int arrayLength, ohmd_float_value informationType)
        {

            if (!openedDevices.ContainsKey(device.Index))
            {
                throw new DeviceNotOpenedException(String.Format("Device with index {0} and name {1} is not yet openend. Please open first.", device.Index, device.Product));
            }
            IntPtr hmd = openedDevices[device.Index];

            float[] result = new float[arrayLength];
            
            //Allocate the result memory, otherwise memory gets corrupted on read / write.
            var gch = GCHandle.Alloc(result, GCHandleType.Pinned);
            IntPtr f = gch.AddrOfPinnedObject();

            //Get the actual value.
            ohmd_device_getf(hmd, informationType, f);

            //Copy the returned IntPtr to the result array.
            Marshal.Copy(f, result, 0, arrayLength);

            //Free the memory.
            gch.Free();
            return result;
        }

        /// <summary>
        /// Updates all the sensor information from the driver. Needs to be called every update.
        /// </summary>
        public void update()
        {
            if (openHMDContext == IntPtr.Zero)
                openContext();

            ohmd_ctx_update(openHMDContext);
        }

        /// <summary>
        /// Closes the context to the driver and cleans up.
        /// </summary>
        public void closeContext()
        {
            try
            {
                if (openHMDContext != IntPtr.Zero)
                    ohmd_ctx_destroy(openHMDContext);
                else
                    throw new NoOpenHMDContextSpecifiedException("There is no correct openhmd context loaded.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception on Shutdown. " + e.ToString());
            }
        }
    }
}
