using System;
using System.Windows.Forms;
using G930_Quickswitcher.controllers.setup;

namespace G930_Quickswitcher
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

            new SetupController();
        }
    }
}
