using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiSafe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Process.GetCurrentProcess().ProcessorAffinity = (IntPtr)0x0003;
                                                                            //
                                                                            //          CPU AFFINITY HEX CODE HERE : 
                                                                            //          0x0001                           1
                                                                            //          0x0002                           2
                                                                            //          0x0003                           1 or 2
                                                                            //          0x0004                           3
                                                                            //          0x0005                           1 or 3
                                                                            //          0x0007                           1, 2, or 3
                                                                            //          0x000F                           1, 2, 3, or 4
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Form1());
        }
    }
}
