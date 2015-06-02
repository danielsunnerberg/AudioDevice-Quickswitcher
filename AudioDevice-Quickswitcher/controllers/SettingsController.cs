using System;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.utilities;
using AudioDevice_Quickswitcher.views;
using Microsoft.Win32;

namespace AudioDevice_Quickswitcher.controllers
{
    class SettingsController : Controller, ISetupListener
    {

        private readonly AudioDeviceManager _audioDeviceManager;
        private readonly RegistryKey _autostartRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        private new readonly SettingsView View;

        public SettingsController(AudioDeviceManager audioDeviceManager)
        {
            _audioDeviceManager = audioDeviceManager;
            bool autorunEnabled = _autostartRegistryKey.GetValue("ApplicationName") != null;
            View = new SettingsView(autorunEnabled, this);
        }

        public void ShowOnFirstRun()
        {
            var chosenAudioDevices = ChosenAudioDevices.Default;
            bool isFirstRun = chosenAudioDevices.alternateDefaultDeviceId.Length == 0 || chosenAudioDevices.originalDefaultDeviceId.Length == 0;
            if (isFirstRun)
            {
                View.MaximizeFromTray();                
            }
        }

        public void SetupDevices()
        {
            new SetupController(_audioDeviceManager).DisplayFirstStep();
        }

        public void SetupKeybinds()
        {
            MessageBox.Show("Not yet implemented. Use CTRL+ALT+F12.");
        }

        public void ShouldStartAutomatically(bool status)
        {
            ChangeAutoStartStatus(status);
        }

        private void ChangeAutoStartStatus(bool status)
        {
            if (status)
            {
                _autostartRegistryKey.SetValue("ApplicationName", Application.ExecutablePath);
            }
            else
            {
                _autostartRegistryKey.DeleteValue("ApplicationName");
            }
        }

        public void ExitProgram()
        {
            Application.Exit();
        }

    }
}
