using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AForge;
using AForge.Video.DirectShow;
using AForge.Vision;
using AForge.Vision.Motion;

//using Emgu.CV;
//using Emgu.CV.Face;

namespace HiSafeCore
{

    public delegate void OnFrameResieve(Bitmap frame);  // the delegate that will invoke by Camera interface on new frame 

    public delegate void OnFrameProccess(Bitmap frame); // the delage that will invoke by MotionDetect class 

    public class FrameDetails
    {


        public Color[] average_frame = new Color[16];

        public void get_av(Bitmap current_frame)
        {
            // width = 320 | height = 240       4 | 4 



            //--------------------------------------------------------------------------------


            int _width_counter = 80, _height_counter = 60;
            Graphics graphics = Graphics.FromImage(current_frame);
            Pen pen = new Pen(Color.DarkOrange);
            Random random = new Random();
            int _w_counter = 0, _h_counter = 0;

            while (_h_counter < _height_counter)
            {

                while (_w_counter < _width_counter)
                {
                    //graphics.DrawLine(new Pen(Color.FromArgb(random.Next())), _w_counter, _h_counter, _width_counter, _height_counter);
                    //graphics.DrawLine(new Pen(Color.FromArgb(random.Next())), _w_counter, _h_counter, _width_counter, _h_counter);

                    graphics.DrawLine(new Pen(Color.FromArgb(random.Next())), _w_counter, _h_counter, _width_counter, _h_counter);


                    _w_counter += 80;
                    if (_width_counter < 320) _width_counter += 80; ;
                    graphics.DrawLine(new Pen(Color.FromArgb(random.Next())), _w_counter, _h_counter, _w_counter, _height_counter);
                }
                _w_counter = 0;
                _width_counter = 80;
                _h_counter += 60;
                if (_height_counter < 240) _height_counter += 60; ;

            }


        }


        public Color average(Color[] _colors, int _len = 4800)
        {
            int r = 0, g = 0, b = 0, i;
            //-------------------------------------------------
            for (i = 0; i < _len; i++)
            {
                r += _colors[i].R;
                g += _colors[i].G;
                b += _colors[i].B;
            }
            if (i != 0)
            {
                r = r / i;
                b = b / i;
                g = g / i;
            }
            //-------------------------------------------------
            return Color.FromArgb(r, g, b);
        }
    }


    public class CameraInterface
    {
        private Bitmap frame;


        public FilterInfoCollection Af_device_collection;
        public List<FilterInfo> AF_devices = new List<FilterInfo>();

        private VideoCaptureDevice device;

        public event OnFrameResieve frame_recieve_isr;

        public void set_exposure()
        {
            device.SetCameraProperty(CameraControlProperty.Exposure, -7, CameraControlFlags.Manual);
        }

        public void get_camera_propreties(IntPtr hndl)
        {
            device.DisplayPropertyPage(hndl);
        }

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
            frame = eventArgs.Frame;
            frame_recieve_isr?.Invoke(frame);
            if (frame != null) frame.Dispose();
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




    public class MotionDetect
    {

        CameraInterface camera;
        public event OnFrameProccess proccess_event;
        public int interlock_new_frame;
        public bool interlock_boolean = false;
        public PerformanceChecker pchecker;
        public MotionDetect(CameraInterface _camera)
        {
            camera = _camera;
            camera.frame_recieve_isr += Camera_frame_recieve_isr;

            pchecker = new PerformanceChecker(300);
        }

        //320 * 240 pixel | 
        // 80 * 60 | 
        private void Camera_frame_recieve_isr(Bitmap frame)
        {
            if (interlock_boolean)
            {
                interlock_new_frame++;
                return;
            }
            interlock_boolean = true;

            //pchecker.start();

            extract(frame);
            proccess_event?.Invoke(frame);

            //pchecker.stop();
            interlock_boolean = false;
        }

        public byte[] averages = new byte[16];

        public void extract(Bitmap _frame)
        {
            Rectangle rec = new Rectangle(0, 0, 320, 240);
            int depth = Bitmap.GetPixelFormatSize(_frame.PixelFormat);
            int step = depth / 8;
            byte index_box = 0;
            BitmapData bitmap_data = _frame.LockBits(rec, ImageLockMode.ReadWrite, _frame.PixelFormat);
            IntPtr start_address = bitmap_data.Scan0;
            int _width_counter = 80, _height_counter = 60;
            int _w_counter = 0, _h_counter = 0;
                pchecker.start();
            while (_h_counter < _height_counter)
            {
                while (_w_counter < _width_counter)
                {

                    // get each box pixels 

                    //byte[] box_color = new byte[4800];
                    int index = 0;
                    int sum = 0;
                    for (int i_y = _h_counter; i_y <= _height_counter; i_y++)
                    {
                        for (int j_x = _w_counter; j_x <= _width_counter; j_x++)
                        {
                            int i = ((i_y * 320) + j_x) * step;
                            sum += Marshal.ReadByte(start_address + (i + 2));
                            index++;
                        }
                    }
                    // Average the current byte 

                    averages[index_box] = (byte)(sum / 4800);

                    index_box++;
                    _w_counter += 80;
                    if (_width_counter < 320) _width_counter += 80; ;
                }
                _w_counter = 0;
                _width_counter = 80;
                _h_counter += 60;
                if (_height_counter < 240) _height_counter += 60; ;
            }
            pchecker.stop();

            _frame.UnlockBits(bitmap_data);

        }

        int sum_average;

        public void average()
        {


        }

    }


    public class PerformanceChecker
    {
        Stopwatch sw = new Stopwatch();
        public double[] result;
        public int count;
        public int counter;
        public PerformanceChecker(int _count)
        {
            count = _count;
            result = new double[_count];
            counter = 0;
        }

        public void start()
        {
            sw.Reset();
            sw.Start();
        }
        public void stop()
        {
            sw.Stop();
            if (counter >= count) counter = 0;
            result[counter++] = (double)sw.Elapsed.Ticks / (Stopwatch.Frequency / 1000);
        }
        public void lap()
        {
            result[counter++] = sw.Elapsed.Ticks / (Stopwatch.Frequency / 1000);
            if (counter >= count) counter = 0;
        }
    }







}
