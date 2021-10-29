using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge;
using AForge.Video.DirectShow;

namespace HiSafe
{

    public delegate void OnFrameResieve(Bitmap frame);

    public class CameraInterface
    {
        private Bitmap frame;

        public FilterInfoCollection Af_device_collection;
        public List<FilterInfo> AF_devices = new List<FilterInfo>();

        private VideoCaptureDevice device;

        public event OnFrameResieve frame_recieve_isr;

        public List<FilterInfo> search_camera()
        {
            Af_device_collection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo item in Af_device_collection)
            {
                AF_devices.Add(item);
            }
            return AF_devices;
        }

        private VideoCapabilities create_camera_resulation(FilterInfo _device)
        {
            //device = new VideoCaptureDevice(_device.MonikerString);
            var VC = device.VideoCapabilities;
            VideoCapabilities GDR = null;
            int index = 0;
            foreach (var res in VC)
            {
                if (res.FrameSize.Width == 320 && res.FrameSize.Height == 240) GDR = VC[index];
                index++;
            }

            return GDR;
        }

        public List<FilterInfo> cams_connected_list()
        {
            return AF_devices;
        }

        public bool start_camera(FilterInfo _device)
        {
            if (device == null)
                device = new VideoCaptureDevice(_device.MonikerString);
            if (device.IsRunning == false)
            {

                device.NewFrame += Device_NewFrame;
                device.VideoResolution = create_camera_resulation(_device);

                device.Start();
            }

            return device != null ? (device.IsRunning == true ? true : false) : false;
        }


        private void Device_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            if (frame != null) frame.Dispose();

            lock (eventArgs)
            {
                frame = eventArgs.Frame;
            };
            frame_recieve_isr?.Invoke(frame);
        }

        public void disconnect()
        {

            if (device != null)    // Close the form and disconnect camera ! 
            {
                if (device.IsRunning == true)
                {
                    device.SignalToStop();
                    device = null;
                }
            }
        }
    }


}
