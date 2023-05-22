
 namespace AForge.Video.DirectShow
 {
    using System;


    public enum VideoProcAmpProperty
    {

       Brightness = 0,

        Contrast,

        Hue,

        Saturation,

         Sharpness,

       Gamma,

         ColorEnable,


        WhiteBalance,

        BacklightCompensation,

         Gain
    }

    [Flags]
    public enum VideoProcAmpFlags
   {

        None = 0x0,

       Auto = 0x0001,

       Manual = 0x0002
   }
 }