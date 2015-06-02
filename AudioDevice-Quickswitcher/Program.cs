using System;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.controllers;

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

            var deviceSwitchController = new DeviceSwitchController();
            deviceSwitchController.ListenForSwitchRequest();

            var settingsController = new SettingsController();

            Application.Run(new MultipleForms(deviceSwitchController.view, settingsController.view));
        }
    }

    internal class MultipleForms : ApplicationContext
    {
        public MultipleForms(params Form[] forms)
        {
            foreach (var form in forms)
            {
                form.Show();
            }
        }
    }

}
