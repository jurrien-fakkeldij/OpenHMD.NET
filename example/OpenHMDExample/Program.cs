using OpenHMDNet;
using System;
using System.Collections.Generic;

namespace OpenHMDExample
{
    class Program
    {
        static void Main(string[] args)
        {
            OpenHMD driver = new OpenHMD();
            driver.openContext();

            List<Device> devices = driver.getDevices();
            Device selectedDevice = null;

            foreach (Device dev in devices)
            {
                Console.WriteLine("Device: " + dev.Index);
                Console.WriteLine("  Vendor: " + dev.Vendor);
                Console.WriteLine("  Product: " + dev.Product);
                Console.WriteLine("  Path: " + dev.Path);

                selectedDevice = dev;
            }

            driver.openDevice(selectedDevice);

            Console.WriteLine("Horizontal Resolution: " + driver.getIntInformation(selectedDevice, OpenHMD.ohmd_int_value.OHMD_SCREEN_HORIZONTAL_RESOLUTION));
            Console.WriteLine("Vertical   Resolution: " + driver.getIntInformation(selectedDevice, OpenHMD.ohmd_int_value.OHMD_SCREEN_VERTICAL_RESOLUTION));

            Console.WriteLine("hsize: " + driver.getFloatInformation(selectedDevice, 1, OpenHMD.ohmd_float_value.OHMD_SCREEN_HORIZONTAL_SIZE)[0]);
            Console.WriteLine("vsize: " + driver.getFloatInformation(selectedDevice, 1, OpenHMD.ohmd_float_value.OHMD_SCREEN_VERTICAL_SIZE)[0]);
            Console.WriteLine("lens separation: " + driver.getFloatInformation(selectedDevice, 1, OpenHMD.ohmd_float_value.OHMD_LENS_HORIZONTAL_SEPARATION)[0]);
            Console.WriteLine("lens vcenter: " + driver.getFloatInformation(selectedDevice, 1, OpenHMD.ohmd_float_value.OHMD_LENS_VERTICAL_POSITION)[0]);
            Console.WriteLine("left eye fov: " + driver.getFloatInformation(selectedDevice, 1, OpenHMD.ohmd_float_value.OHMD_LEFT_EYE_FOV)[0]);
            Console.WriteLine("right eye fov: " + driver.getFloatInformation(selectedDevice, 1, OpenHMD.ohmd_float_value.OHMD_RIGHT_EYE_FOV)[0]);
            Console.WriteLine("left eye aspect: " + driver.getFloatInformation(selectedDevice, 1, OpenHMD.ohmd_float_value.OHMD_LEFT_EYE_ASPECT_RATIO)[0]);
            Console.WriteLine("right eye aspect: " + driver.getFloatInformation(selectedDevice, 1, OpenHMD.ohmd_float_value.OHMD_RIGHT_EYE_ASPECT_RATIO)[0]);

            float[] distortion = driver.getFloatInformation(selectedDevice, 6, OpenHMD.ohmd_float_value.OHMD_DISTORTION_K);
            Console.Write("distortion k: ");
            foreach (float fl in distortion)
                Console.Write(fl + " ");
            Console.Write("\r\n");

            for (int i = 0; i < 10; i++)
            {
                driver.update();
                float[] rotation = driver.getFloatInformation(selectedDevice, 4, OpenHMD.ohmd_float_value.OHMD_ROTATION_QUAT);

                Console.Write("rotation quat: ");
                foreach (float fl in rotation)
                    Console.Write(fl + " ");
                Console.Write("\r\n");
                System.Threading.Thread.Sleep(10);
            }

            driver.closeContext();

            Console.ReadLine();
        }
    }
    }
}
