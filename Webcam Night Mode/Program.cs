using System;
using AForge.Video.DirectShow;

namespace Webcam_Night_Mode
{
    class Program
    {
        static void Main(string[] args)
        {
            bool NightMode;
            string CameraNameInWindowsDeviceManager = "USB  Live  Camera";
            int NightExposureValue = -1;

            //Between 10PM and 4AM we activate night mode
            if (System.DateTime.Now.Hour >= 22 || System.DateTime.Now.Hour < 4)
                NightMode = true;
            else
                NightMode = false;


            var ListOfDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            VideoCaptureDevice Camera = null;
            for (int i = 0; i < ListOfDevices.Count; i++)
            {
                //Search For the usb device name
                if (ListOfDevices[i].Name == CameraNameInWindowsDeviceManager)
                {
                    Camera = new VideoCaptureDevice(ListOfDevices[i].MonikerString);
                }
            }

            if (Camera == null)
            {
                Console.WriteLine("Error: Could not find device " + CameraNameInWindowsDeviceManager);
                Console.WriteLine("Press Any Key to exit");
                Console.ReadKey();
            }

            if (NightMode)
                Camera.SetCameraProperty(CameraControlProperty.Exposure, NightExposureValue, CameraControlFlags.Manual);
            else
                Camera.SetCameraProperty(CameraControlProperty.Exposure, -1, CameraControlFlags.Auto);
        }
    }
}
