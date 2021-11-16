using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public event graph_del graph_return;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //this.Size = new Size(370, 350);
            graph_picturebox.Image = new Bitmap(graph_picturebox.Width, graph_picturebox.Height);
            graph_return += Form1_graph_return; ;


            PerSecTimer = new Timer();
            PerSecTimer.Interval = 1000;
            PerSecTimer.Tick += PerSecTimer_Tick; ;
            camera = new CameraInterface();


            foreach (var item_cam in camera.search_camera())
            {
                ComboBoxCamera.Items.Add(item_cam.Name);
            }
            if (ComboBoxCamera.Items.Count != 0) ComboBoxCamera.SelectedIndex = 0;

            start();
        }


        private void PerSecTimer_Tick(object sender, EventArgs e)
        {
            main_picbox.fps_counter = FPS_counter;
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
                md_process.proccess_event += Camera_frame_recieve_isr;


                PerSecTimer.Start();
                graph_timer.Start();
                data_reader.Start();
            }
            else
                log_lbl.Text = "Faild";
        }

        private void Camera_frame_recieve_isr(Bitmap frame)
        {
            Bitmap old_image = (Bitmap)main_picbox.BackgroundImage;
            main_picbox.BackgroundImage = (Bitmap)frame.Clone();
            if (old_image != null) old_image.Dispose();
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
            graph_update(new Bitmap(320, 240));

        }

        private void graph_update(Bitmap _b)
        {
            Bitmap _graph = (Bitmap)_b.Clone();
            Graphics graphics = Graphics.FromImage(_graph);
            if (_b != null)
                _b.Dispose();

            //if (old != null) old.Dispose();
            Font drawFont = new Font("Arial", 8);
            int height = 240;
            SolidBrush drawBrush = new SolidBrush(Color.Gray);
            int max_value = 10;
            int grid_count = 5;
            int graph_width = md_process.pchecker.count;
            for (int j = 0; j < max_value; j += max_value / grid_count)
            {
                int grid_line_y = height - (j * height) / max_value;

                if (j > 0)
                {
                    graphics.DrawLine(new Pen(Color.Gray), 0, grid_line_y, graph_width, grid_line_y);
                    graphics.DrawString(j.ToString(), drawFont, drawBrush, new Point(5, grid_line_y - Font.Height - 2));
                }
            }


            for (int i = 1; i < md_process.pchecker.count - 1; i++)
            {
                long _yr = Math.Abs(height - (int)((md_process.pchecker.result[i - 1] * (height)) / max_value));
                long _yr2 = Math.Abs(height - (int)((md_process.pchecker.result[i] * (height)) / max_value));
                graphics.DrawLine(new Pen(Color.Red), i - 1, _yr, i, _yr2);
            }
            graphics.DrawLine(new Pen(Color.Green), md_process.pchecker.counter, 0, md_process.pchecker.counter, height);

            drawBrush.Dispose();
            drawFont.Dispose();
            //graphics.Dispose();
            graph_return?.Invoke(_graph);

        }
        private void Form1_graph_return(Bitmap g_bitmap)
        {
            lock (graph_picturebox)
            {
                Image _image = graph_picturebox.Image;
                graph_picturebox.Image = (Bitmap)g_bitmap.Clone();
                g_bitmap.Dispose();
                if (_image != null)
                    _image.Dispose();
            }
        }

        private void data_reader_Tick(object sender, EventArgs e)
        {
            hiSafeAverageColors1._average_bytes = md_process.averages;
            hiSafeAverageColors1.Invalidate() ; 
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
                    Color saturation = Color.FromArgb(_average_bytes[index_box] , _average_bytes[index_box] , _average_bytes[index_box]) ; 
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


}
