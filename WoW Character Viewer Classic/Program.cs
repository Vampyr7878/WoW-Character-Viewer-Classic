using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WoW_Character_Viewer_Classic
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SharpGLForm());
        }
    }
}
