using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiVoice
{
    public partial class Form1 : Form
    {

        private NaHiVoice nim_voice;

        private bool RECORDING = false;
        private bool REFREASH_FQ = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            nim_voice = new NaHiVoice();

            nim_voice.OnDataRecording += Nim_voice_OnDataRecording1;

            NimXAdudio nimXAdudio = new NimXAdudio();

        }



        /*
                    -   -   -   -   -
            RECORDING EVENTS WHEN USER PRESS F4 KEY
                    -   -   -   -   -
        */

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4 && !RECORDING)
            {
                RECORDING = true;
                nim_voice.start_recording();
                btn_recorder.Text = ". . .";
            }

            if (e.KeyCode== Keys.F3 &&  RECORDING)
            {
                nim_voice.pause_recording();
                btn_recorder.Text = "Start";
                RECORDING = false;
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            //if (RECORDING)
            //{
            //    nim_voice.pause_recording();
            //    btn_recorder.Text = "Start";
            //    RECORDING = false;
            //}
            base.OnKeyUp(e);
        }


        private void Nim_voice_OnDataRecording1(data_voice e)
        {
            pb_eqo.buffer = e._buffer;
            pb_fft_type.__DATA_TYPE = EqoPicturebox.DATA_TYPE.MAX32;
            pb_fft_type.Max32 = e.max_volume;
            pb_fft_type.Invalidate();
            REFREASH_FQ = true;
        }

        private void timer_voice_freq_Tick(object sender, EventArgs e)
        {
            if (REFREASH_FQ)
            {
                REFREASH_FQ = false;
                pb_eqo.Invalidate();
                //pb_fft_type.Invalidate();
            }

        }

        private void btn_record_Click(object sender, EventArgs e)
        {

        }

        private void pb_eqo_Click(object sender, EventArgs e)
        {

        }


        private void nimaColorPicker1_MouseMove(object sender, MouseEventArgs e)
        {
            if (nimaColorPicker1.OnPeek)
            {
                pb_eqo.color = nimaColorPicker1.selected;
            }
        }
    }






    public class EqoPicturebox : PictureBox
    {
        public enum DATA_TYPE
        {
            RAW_WAVE,
            MAX32,
        }

        public DATA_TYPE __DATA_TYPE = DATA_TYPE.RAW_WAVE;

        public byte[] buffer;
        private bool INNER_LOCKER = false;
        public float max32 = 0;
        private int last_max32_index = 0;
        public float Max32
        {
            set
            {
                if(max32_arr.Count < this.Width)
                {
                    max32_arr.Add(value);
                    last_max32_index++ ;
                    return ; 
                }
                last_max32_index = last_max32_index < (this.Width-1) ? last_max32_index+1 : 0; 
                max32_arr[last_max32_index] = value;
            }
        }
        private float last_location_X = 0;
        private float last_location_Y = 0;
        public Color color = Color.Green;
        private List<float> max32_arr = null;

        public EqoPicturebox()
        {
            this.Image = new Bitmap(this.Width, this.Height);
            max32_arr = new List<float>(this.Width);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            //if (!INNER_LOCKER)
            switch (__DATA_TYPE)
            {
                case DATA_TYPE.RAW_WAVE:
                    if (buffer != null)
                    {
                        if (buffer.Length > 1000)
                        {
                            INNER_LOCKER = true;

                            for (int i = 1; i < this.Width - 1; i += 1)
                            {
                                pe.Graphics.DrawLine(new Pen(color, 1), i - 1, buffer[i - 1], i, buffer[i]);
                                pe.Graphics.DrawLine(new Pen(color, 1), i, buffer[i], i + 1, buffer[i + 1]);
                            }
                            //INNER_LOCKER = false;
                        }
                    }
                    break;
                case DATA_TYPE.MAX32:

                    int w = 10, h = 1;

                    for (int i = 0; i < max32_arr.Count; i++)
                    {
                           
                        for (int j = 0; j < max32_arr[i] / 10; j++)
                        //for (int j = 0; j < max32_arr[i] / 10000000; j++)
                            {
                            RectangleF rec = new RectangleF(i, Height - j, w, h);
                            pe.Graphics.FillRectangle(new SolidBrush(color), rec); 

                        }
                    }
                    pe.Graphics.DrawLine(new Pen(Color.FromArgb(110, 110, 110), 1), last_max32_index, 0, last_max32_index, this.Height);
                    break;
                default:
                    break;
            }


            base.OnPaint(pe);
        }
    }


    public class NimaColorPicker : PictureBox
    {
        public Color selected = Color.White;
        public bool OnPeek = false;
        protected override void OnMouseEnter(EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (OnPeek && ((e.X > 0 && e.X < Width) && (e.Y > 0 && e.Y < Height)))
            {
                Bitmap b = (Bitmap)this.Image;

                Color c = b.GetPixel(e.X, e.Y);
                if (c.R > 0 && c.G > 0 && c.B > 0)
                {
                    selected = c;
                }
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            OnPeek = true;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            OnPeek = false;

            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.Cursor = Cursors.Default;
            base.OnMouseLeave(e);
        }


    }


}
