using System;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.controllers;
using AudioDevice_Quickswitcher.controllers.setup;

namespace AudioDevice_Quickswitcher
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

            //new SetupController().DisplayFirstStep();
            new SettingsController().ShowView();
        }
    }
}
