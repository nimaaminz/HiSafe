using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave.Asio;
using NAudio.Wave;
using NAudio.Dsp;

//using SharpDX ;
//using SharpDX.XAudio2 ;
 using SharpDX;
 using SharpDX.DirectSound;
using System.IO;

namespace HiVoice
{

    public delegate void DataRecordingDEL(data_voice e);
    public delegate void PauseRecordingDEL(object e);

    public class NaHiVoice
    {
        private WaveIn wave;
        //private WaveOut wout;
        public WaveFileWriter waveFile = null;
        


        public event DataRecordingDEL OnDataRecording;

        public NaHiVoice()
        {
            wave = new WaveIn();
            wave.DataAvailable += Wave_DataAvailable;
            wave.RecordingStopped += Wave_RecordingStopped;

            wave.WaveFormat = new WaveFormat(44100, 1);
            
            if(File.Exists(@"C:\Temp\Test0001.wav"))
                waveFile = new WaveFileWriter(@"C:\Temp\Test0001.wav", wave.WaveFormat);
            else
            {
                //File.Create(@"C:\Temp\Test0001.wav") ;
                System.Windows.Forms.MessageBox.Show(@"Coudn't Found The C:\Temp");
            }
        }

        private void Wave_RecordingStopped(object sender, StoppedEventArgs e)
        {



        }

        private void Wave_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (OnDataRecording == null) return;

            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
            float max = 0;
            var buffer = new WaveBuffer(e.Buffer);

            // interpret as 32 bit floating point audio
            for (int index = 0; index < e.BytesRecorded / 4; index++)
            {
                var sample = buffer.ShortBuffer[index];

                // absolute value 
                //if (sample < 0) sample = sample;
                // is this the max value?
                if (sample > max) max = sample;
            }
            data_voice data;
            data._buffer = e.Buffer;
            data._buffer_ln = e.BytesRecorded; 
            data.max_volume = max;
            OnDataRecording.Invoke(data);


            Console.WriteLine(max);
        }



        public void start_recording()
        {
            try
            {
                wave.StartRecording();
            }
            catch (MmException m)
            {

                System.Windows.Forms.MessageBox.Show(m.Message);
            }
        }

        public void pause_recording()
        {
            wave.StopRecording();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\test.wave";
            //System.Windows.Forms.MessageBox.Show(path);

        }



    }

    public struct data_voice
    {
        public byte[] _buffer;
        public int _buffer_ln;
        public float max_volume ;
    }

    public class NimXAdudio
    {
        public NimXAdudio()
        {
            //int _count =  xaudio.DeviceCount ; 
            //XAudio2 xaudio = new XAudio2(XAudio2Version.Version29)

            //SharpDX.Multimedia.SoundStream
            SharpDX.DirectSound.DirectSound ds = new SharpDX.DirectSound.DirectSound();
            var devs = DirectSound.GetDevices();
            var devs_capture = DirectSoundCapture.GetDevices();
            
         }
        
    }
}
