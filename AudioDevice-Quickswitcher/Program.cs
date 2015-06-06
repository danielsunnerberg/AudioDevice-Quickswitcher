using System;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.controllers;
using AudioDevice_Quickswitcher.utilities;

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

            AudioDeviceManager audioDeviceManager = new AudioDeviceManager(@"dependencies/EndPointController_forked.exe");

            var deviceSwitchController = new DeviceSwitchController(audioDeviceManager);
            deviceSwitchController.ListenForSwitchRequest();

            var settingsController = new SettingsController(audioDeviceManager);
            settingsController.ShowOnFirstRun();
            Application.Run(settingsController.View);
        }
    }

}
