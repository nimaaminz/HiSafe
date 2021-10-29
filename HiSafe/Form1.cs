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

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //main_cam_picbox.Controls.Add(panel1);
            //panel1.Dock = DockStyle.Fill;
            //panel1.BackColor = Color.Transparent;
            main_cam_picbox.Image = new Bitmap(320, 240);

            camera = new CameraInterface();



            foreach (var item_cam in camera.search_camera())
            {
                ComboBoxCamera.Items.Add(item_cam.Name);
            }
            if (ComboBoxCamera.Items.Count != 0) ComboBoxCamera.SelectedIndex = 0;

            //start() ; 
        }

        private void start()
        {
            if (camera.start_camera(camera.cams_connected_list()[ComboBoxCamera.SelectedIndex]))
            {
                camera.frame_recieve_isr += Camera_frame_recieve_isr;
                log_lbl.Text = "Done";
            }
            else
                log_lbl.Text = "Faild";
        }

        private void Camera_frame_recieve_isr(Bitmap frame)
        {
            Bitmap old_bitmap ;
            old_bitmap = (Bitmap)main_cam_picbox.Image ;
            main_cam_picbox.Image = (Bitmap)frame.Clone();
            if (old_bitmap != null) old_bitmap.Dispose();

        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            camera.disconnect() ; 
        }
    }
}
