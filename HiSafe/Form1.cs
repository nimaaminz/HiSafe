using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HiSafe
{
    public partial class Form1 : Form
    {
        private CameraInterface camera;
        private int FPS_counter = 0;
        private Timer PerSecTimer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Size = new Size(370, 350);
            FPS_label.Parent = main_cam_picbox ; 
            main_cam_picbox.Image = new Bitmap(320, 240);


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
            FPS_label.Text = "FPS : " + FPS_counter.ToString();
            FPS_counter = 0 ;
        }

        private void start()
        {
            if (camera.start_camera(camera.cams_connected_list()[ComboBoxCamera.SelectedIndex]))
            {
                camera.frame_recieve_isr += Camera_frame_recieve_isr;
                log_lbl.Text = "Done";
                // after start : 
                setting_btn.Location = StartBtn.Location;
                StartBtn.Visible = false;
                PerSecTimer.Start();

            }
            else
                log_lbl.Text = "Faild";
        }

        private void Camera_frame_recieve_isr(Bitmap frame)
        {
            Bitmap old_bitmap;
            old_bitmap = (Bitmap)main_cam_picbox.Image;
            main_cam_picbox.Image = (Bitmap)frame.Clone();
            if (old_bitmap != null) old_bitmap.Dispose();
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
    }
}
