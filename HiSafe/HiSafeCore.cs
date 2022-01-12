using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AForge;
using AForge.Video.DirectShow;
using MySql.Data.MySqlClient;


//using Emgu.CV;
//using Emgu.CV.Face;

namespace HiSafeCore
{

    public delegate void OnFrameResieve(IntPtr buffer, int length, double time_stamp);  // the delegate that will invoke by Camera interface on new frame 

    public delegate void OnFrameProccess(IntPtr buffer, int length); // the delage that will invoke by MotionDetect class 


    public delegate void OnDetectAvrg(); // when new frame is different with average this vent should be invoke 
                                         // then the UI will count he time per frame that this method call and when 
                                         // the count getting out of a spesific range should do the next things and 
                                         // on that moment mean an object coming in frame 


    public class CameraInterface
    {


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
            frame_recieve_isr?.Invoke(eventArgs.Buffer, eventArgs.BufferLen, eventArgs.sample_time);
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
        public event OnDetectAvrg detect_motion_event;
        public int interlock_new_frame;
        public bool interlock_boolean = false;
        public PerformanceChecker pchecker;
        public MotionDetect(CameraInterface _camera)
        {
            camera = _camera;
            camera.frame_recieve_isr += Camera_frame_recieve_isr;
            pchecker = new PerformanceChecker(300);
        }


        private byte[] _buffer_camera_coming_data = new byte[230400]; // the coming frame is 320 * 240 and then the data array will be size in : 240*320*3(RGB)

        //320 * 240 pixel | 
        // 80 * 60 | 
        //private void Camera_frame_recieve_isr(Bitmap frame)
        private void Camera_frame_recieve_isr(IntPtr buffer, int length, double time_stamp)
        {
            if (interlock_boolean)
            {
                interlock_new_frame++;
                return;
            }
            interlock_boolean = true;

            //pchecker.start();
            Marshal.Copy(buffer, _buffer_camera_coming_data, 0, length);  // copy incoming buffer to the data array 
            Array.Copy(averages, old_average, averages.Length);
            extract();
            if (dispute()) detect_motion_event.Invoke();
            proccess_event?.Invoke(buffer, length);

            ////pchecker.stop();
            interlock_boolean = false;
        }

        public byte[] old_average = new byte[16];
        public byte[] averages = new byte[16];

        private void extract()
        {
            pchecker.start();
            //int step = Bitmap.GetPixelFormatSize(_frame.PixelFormat) / 8;
            int step = 3;
            byte index_box = 0;
            //BitmapData bitmap_data = _frame.LockBits(new Rectangle(0, 0, 320, 240), ImageLockMode.ReadWrite, _frame.PixelFormat);
            //IntPtr start_address = ;
            //IntPtr start_address = bitmap_data.Scan0;
            int _width_counter = 80, _height_counter = 60;
            int _w_counter = 0, _h_counter = 0;
            while (_h_counter < _height_counter)
            {
                while (_w_counter < _width_counter)
                {
                    int index = 0;
                    int sum = 0;
                    for (int i_y = _h_counter; i_y < _height_counter; i_y += 2)
                    {
                        for (int j_x = _w_counter; j_x < _width_counter; j_x += 2)
                        {
                            int i = ((i_y * 320) + j_x) * step;
                            sum += _buffer_camera_coming_data[i + 2]; // the red one 
                            index++;
                        }
                    }
                    // Average the current byte 
                    averages[index_box] = (byte)(sum / 1200);

                    index_box++;
                    _w_counter += 80;
                    if (_width_counter < 320) _width_counter += 80;
                }
                _w_counter = 0;
                _width_counter = 80;
                _h_counter += 60;
                if (_height_counter < 240) _height_counter += 60;
            }

            //_frame.UnlockBits(bitmap_data);
            pchecker.stop();

        }

        private bool dispute()
        {
            bool detection = false;

            for (int i = 0; i < 16; i++)
            {
                if (Math.Abs(averages[i] - old_average[i]) > 10)
                    detection |= true;
            }

            return detection;
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


    public class DataBaseMySqlClass
    {

        public static string mysql_connection_string;

        private static MySqlConnection connection;
        private static MySqlCommand cmd;                        // MySql command

        public static string table_name = "motion_detect_images";                 // THIS SHOULD CHANGE ON COMBO BOX MODEL SELECT CHANGE AND 
                                                                                  // WHEN THIS STRING CHANGE , THE PROGTAM READ/WRITE FROM 
                                                                                  // DIFFERENC TABLE


        private static int date_now;


        public static bool ConenctionStatus { get { return connection.State == System.Data.ConnectionState.Open ? true : false; } }


        public bool HostConnectionStatusDB { get { return connection.State == System.Data.ConnectionState.Open ? true : false; } }

        public DataBaseMySqlClass(string _mysql_connection_string)
        {// call it when you want to connect to the database
            mysql_connection_string = _mysql_connection_string;
            connection = new MySqlConnection(mysql_connection_string);
            // calculate the date 
            // . . . 
            string _date_str = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            date_now = int.Parse(_date_str);

        }

        public DataBaseMySqlClass()
        {
            // call for add or remove or ,, not for connection , 
        }


        private bool INTER_LOCK_CONNECTION = false;

        public bool conenctDB()
        {
            if (INTER_LOCK_CONNECTION) return false;

            INTER_LOCK_CONNECTION = true ; 

            Task.Run(() =>
            {


                //connection.

                try
                {

                    if (connection != null)
                        connection.Open();

                    INTER_LOCK_CONNECTION = false;
                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {
                    INTER_LOCK_CONNECTION = false;
                }

            });

            return connection.State == System.Data.ConnectionState.Open ? true : false;
        }

        public bool Disconenct()
        {
            connection.Close();
            return connection.State == System.Data.ConnectionState.Closed ? true : false;
        }

        public void add_record(Bitmap _image)
        {
            if (_image == null) return;
            int unix_time = (int)((DateTime.UtcNow.Ticks - new DateTime(1970, 1, 1).Ticks) / TimeSpan.TicksPerSecond);

            //  image to byte array 
            MemoryStream _mem_image = new MemoryStream();
            _image.Save(_mem_image, ImageFormat.Jpeg);
            byte[] _pic_array = new byte[_mem_image.Length];
            _mem_image.Position = 0;
            _mem_image.Read(_pic_array, 0, _pic_array.Length);


            cmd = new MySqlCommand("INSERT INTO " + table_name + "(ID , Image , Date_Time) VALUES (@id,@image,@date );", connection);
            cmd.Parameters.AddWithValue("@id", unix_time);
            cmd.Parameters.AddWithValue("@image", _pic_array);
            cmd.Parameters.AddWithValue("@date", date_now);

            cmd.ExecuteNonQuery();


        }

        public byte[] last_detection_image()
        {

            if (connection.State != System.Data.ConnectionState.Open) return null; // sql connection error;

            MySqlConnection _connection = new MySqlConnection(mysql_connection_string);
            _connection.Open();

            byte[] image_data = new byte[10000];

            string query = "SELECT Image FROM  " + table_name + " ORDER BY ID DESC LIMIT 1 ; "; // query

            MySqlCommand _cmd = new MySqlCommand(query, _connection);
            MySqlDataReader _data_reader = _cmd.ExecuteReader();

            if (_data_reader.Read())
            {
                long test = _data_reader.GetBytes(0, 0, image_data, 0, image_data.Length);
            }

            _connection.Close();
            return image_data;
        }



    }



}
