using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

using static OpenHMDNet.OpenHMDPlatform;

namespace OpenHMDNet
{
    public class OpenHMD
    {
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
