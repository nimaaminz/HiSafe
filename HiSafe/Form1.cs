using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiSafeCore;


namespace HiSafe
{
    public delegate void graph_del(Bitmap g_bitmap);
    public partial class Form1 : Form
    {
        private CameraInterface camera;
        private MotionDetect md_process;
        private int FPS_counter = 0;
        private Timer PerSecTimer;

        private bool frame_show_checker = false;
        private bool DB_CONNECTED;

        private string mysql_string_connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=hisafe_db;";

        DataBaseMySqlClass databasse_comm;



        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PerSecTimer = new Timer();
            PerSecTimer.Interval = 1000;
            PerSecTimer.Tick += PerSecTimer_Tick; ;
            camera = new CameraInterface();


            foreach (var item_cam in camera.search_camera())
            {
                ComboBoxCamera.Items.Add(item_cam.Name);
            }
            if (ComboBoxCamera.Items.Count != 0) ComboBoxCamera.SelectedIndex = 0;

            databasse_comm = new DataBaseMySqlClass(mysql_string_connection);


            start();
        }

        private void PerSecTimer_Tick(object sender, EventArgs e)
        {
            main_picbox.fps_counter = FPS_counter;
            if (!frame_show_checker) main_picbox.Invalidate();
            FPS_counter = 0;
        }

        private void start()
        {
            if (camera.start_camera(camera.cams_connected_list()[ComboBoxCamera.SelectedIndex]))
            {
                //camera.frame_recieve_isr += Camera_frame_recieve_isr;
                log_lbl.Text = "Done";
                // after start : 
                setting_btn.Location = StartBtn.Location;
                StartBtn.Visible = false;
                //----after camera start-----
                md_process = new MotionDetect(camera);
                md_process.proccess_event += Md_process_proccess_event; ;
                md_process.detect_motion_event += Md_process_detect_motion_event;


                PerSecTimer.Start();
                graph_timer.Start();
                data_reader.Start();
            }
            else
                log_lbl.Text = "Faild";
        }



        int motion_detect_count = 0;

        private void Md_process_detect_motion_event()
        {
            motion_detect_count++;
            if (motion_detect_count > 10)
            {
                //MessageBox.Show(motion_detect_count.ToString());
                // on detectin , database communication should be here 
                if (DB_CONNECTED)
                    databasse_comm.add_record((Bitmap)main_picbox.BackgroundImage);

                motion_detect_count = 0;
            }
        }

        private void Md_process_proccess_event(IntPtr buffer, int length)
        {
            if (frame_show_checker)
                main_picbox.buffer_to_bitmap(buffer, length);
            FPS_counter++;


        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            camera.disconnect();
        }

        private void setting_btn_Click(object sender, EventArgs e)
        {
            camera.get_camera_propreties(this.Handle);
        }

        private void graph_timer_Tick(object sender, EventArgs e)
        {
            //Image old = graph_picturebox.Image;
            hiSafeGraphPerformance._performance_checker = md_process.pchecker;
            hiSafeGraphPerformance.Invalidate();

        }

        private void data_reader_Tick(object sender, EventArgs e)
        {
            hiSafeAverageColors1._average_bytes = md_process.averages;
            hiSafeAverageColors1.Invalidate();
        }

        private void frame_show_CheckedChanged(object sender, EventArgs e)
        {
            frame_show_checker = frame_show.Checked ? true : false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetDetectsImagesFromDBFrom _last_img_form = new GetDetectsImagesFromDBFrom();
            _last_img_form.ByteToBitmap(databasse_comm.last_detection_image());
            _last_img_form.Show();
        }

        /*
         
                THIS TIMER WILL CHECK CONNECTION OF DATABASE AND IF NOT 
                CONNECTED WIL RECONNECT THE DB
         
         */

        private void timer_database_Tick(object sender, EventArgs e)
        {
            if (!DB_CONNECTED)
            {


                if (databasse_comm.conenctDB())
                {

                    DB_CONNECTED = true;
                    db_staus_lbl.Text = "Database connected in localhost:80 ,  name  :hisafe_db";
                    db_staus_lbl.ForeColor = Color.DarkGreen;

                }


            }
            else
            {
                if(databasse_comm.HostConnectionStatusDB==false)
                {
                    DB_CONNECTED = false ;
                    db_staus_lbl.Text = "Database down";
                    db_staus_lbl.ForeColor = Color.DarkRed;
                }
            }
        }
    }

    public class HiSafePictureBox : PictureBox
    {
        public int fps_counter;

        public HiSafePictureBox()
        {
            this.Image = new Bitmap(320, 240);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            int _width_counter = 80, _height_counter = 60;
            int _w_counter = 0, _h_counter = 0;
            while (_h_counter < _height_counter)
            {
                while (_w_counter < _width_counter)
                {

                    if (_h_counter != 0)
                        pe.Graphics.DrawLine(new Pen(Color.Gray), _w_counter, _h_counter, _width_counter, _h_counter);

                    _w_counter += 80;
                    pe.Graphics.DrawLine(new Pen(Color.Gray), _w_counter, _h_counter, _w_counter, _height_counter);
                    if (_width_counter < 320) _width_counter += 80;
                }
                _w_counter = 0;
                _width_counter = 80;
                _h_counter += 60;
                if (_height_counter < 240) _height_counter += 60;
            }

            pe.Graphics.DrawString("FPS : " + fps_counter, new Font("Arial", 12, FontStyle.Bold), Brushes.DarkGreen, new Point(5, 5));
            base.OnPaint(pe);
        }


        public unsafe void buffer_to_bitmap(IntPtr buffer_ptr, int buffer_length, int width = 320, int height = 240)
        {


            //System.Drawing.Bitmap image =(Bitmap)Bitmap.FromStream(new UnmanagedMemoryStream((byte*)buffer.ToPointer(),bufferLen)) ;
            System.Drawing.Bitmap image = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            // lock bitmap data
            BitmapData imageData = image.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,
                image.PixelFormat);

            // copy image data
            int srcStride = imageData.Stride;
            int dstStride = imageData.Stride;

            byte* dst = (byte*)imageData.Scan0.ToPointer() + dstStride * (height - 1);
            byte* src = (byte*)buffer_ptr.ToPointer();

            for (int y = 0; y < height; y++)
            {
                memcpy(dst, src, srcStride);
                dst -= dstStride;
                src += srcStride;
            }

            // unlock bitmap data
            image.UnlockBits(imageData);

            this.BackgroundImage = image;
            this.Invalidate();
        }

        [DllImport("ntdll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int memcpy(byte* dst, byte* src, int count);
    }


    public class HiSafeAverageColors : PictureBox
    {

        public byte[] _average_bytes = new byte[16];

        public HiSafeAverageColors()
        {
            this.Image = new Bitmap(320, 240);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            int _width_counter = 80, _height_counter = 60;
            int _w_counter = 0, _h_counter = 0;
            byte index_box = 0;

            while (_h_counter < _height_counter)
            {
                while (_w_counter < _width_counter)
                {
                    Color saturation = Color.FromArgb(_average_bytes[index_box], _average_bytes[index_box], _average_bytes[index_box]);
                    pe.Graphics.FillRectangle(new SolidBrush(saturation), new Rectangle(_w_counter, _h_counter, _width_counter, _height_counter));


                    _w_counter += 80;
                    index_box++;
                    if (_width_counter < 320) _width_counter += 80;
                }
                _w_counter = 0;
                _width_counter = 80;
                _h_counter += 60;
                if (_height_counter < 240) _height_counter += 60;
            }

            base.OnPaint(pe);
        }

    }


    public class HiSafeGraphPerformance : PictureBox
    {

        public PerformanceChecker _performance_checker;

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (_performance_checker != null)
            {
                Font drawFont = new Font("Arial", 8);
                int height = 240;
                SolidBrush drawBrush = new SolidBrush(Color.Gray);
                int max_value = 10;
                int grid_count = 5;
                int graph_width = _performance_checker.count;
                for (int j = 0; j < max_value; j += max_value / grid_count)
                {
                    int grid_line_y = height - (j * height) / max_value;

                    if (j > 0)
                    {
                        pe.Graphics.DrawLine(new Pen(Color.Gray), 0, grid_line_y, graph_width, grid_line_y);
                        pe.Graphics.DrawString(j.ToString(), drawFont, drawBrush, new Point(5, grid_line_y - Font.Height - 2));
                    }
                }

                float average_time_sum = 0;

                for (int i = 1; i < _performance_checker.count - 1; i++)
                {
                    long _yr = Math.Abs(height - (int)((_performance_checker.result[i - 1] * (height)) / max_value));
                    long _yr2 = Math.Abs(height - (int)((_performance_checker.result[i] * (height)) / max_value));
                    average_time_sum += (float)_performance_checker.result[i];
                    pe.Graphics.DrawLine(new Pen(Color.Red), i - 1, _yr, i, _yr2);
                }


                pe.Graphics.DrawLine(new Pen(Color.Green), _performance_checker.counter, 0, _performance_checker.counter, height);

                drawBrush.Color = Color.Transparent;
                pe.Graphics.FillRectangle(drawBrush, 100, 10, 100, 30);
                drawBrush.Color = Color.Red;
                pe.Graphics.DrawString("Average Time: " + ((average_time_sum / _performance_checker.count)).ToString("0.00"), drawFont, drawBrush, new Point(100, 30 - Font.Height - 2));


            }
            base.OnPaint(pe);
        }




    }

}
