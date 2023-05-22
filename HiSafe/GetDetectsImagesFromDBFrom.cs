using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiSafe
{
    public partial class GetDetectsImagesFromDBFrom : Form
    {
        public GetDetectsImagesFromDBFrom()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(320, 240);
        }

        private void GetDetectsImagesFromDBFrom_Load(object sender, EventArgs e)
        {

        }

        public void ByteToBitmap(byte[] _the_source)
        {
            if (_the_source == null) return;

            //Bitmap _image = (Bitmap)pictureBox1.Image;
                
            var ms = new MemoryStream(_the_source) ; 

            pictureBox1.Image = new Bitmap(ms)  ; 
            //BitmapData _img_lock = _image.LockBits(new Rectangle(0, 0, 320, 240), ImageLockMode.ReadWrite, _image.PixelFormat);


            //Marshal.Copy(_the_source, 0, _img_lock.Scan0, _the_source.Length);


            //_image.UnlockBits(_img_lock);

            //pictureBox1.Image = _image;


        }

        private void GetDetectsImagesFromDBFrom_VisibleChanged(object sender, EventArgs e)
        {
            // on show from Main UI 



        }
    }
}
