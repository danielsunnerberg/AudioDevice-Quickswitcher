using System.Windows.Forms;
using AudioDevice_Quickswitcher.Controllers.Setup;
using AudioDevice_Quickswitcher.utilities;
using AudioDevice_Quickswitcher.views;
using Microsoft.Win32;

namespace AudioDevice_Quickswitcher.controllers
{
    /// <summary>
    /// Responsible for managing the application's settings.
    /// </summary>
    class SettingsController : ViewController<SettingsView>, ISetupListener
    {
        private readonly AudioDeviceManager _audioDeviceManager;
        private readonly RegistryKey _autostartRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        /// <summary>
        /// Creates a new settings controller which will locate and identify audio devices by the specified audio device manager.
        /// </summary>
        /// <param name="audioDeviceManager"></param>
        public SettingsController(AudioDeviceManager audioDeviceManager)
        {
            _audioDeviceManager = audioDeviceManager;
            bool autorunEnabled = _autostartRegistryKey.GetValue("ApplicationName") != null;
            View = new SettingsView(autorunEnabled, this);
        }

        /// <summary>
        /// Show the settings-window when the program is being run for the first time.
        /// </summary>
        public void ShowOnFirstRun()
        {
            var chosenAudioDevices = ChosenAudioDevices.Default;
            bool isFirstRun = chosenAudioDevices.alternateDefaultDeviceId.Length == 0 || chosenAudioDevices.originalDefaultDeviceId.Length == 0;
            if (isFirstRun)
            {
                View.MaximizeFromTray();                
            }
        }

        /// <summary>
        /// Display the setup devices-wizard.
        /// </summary>
        public void SetupDevices()
        {
            new DeviceSetupController(_audioDeviceManager).DisplayFirstStep();
        }

        /// <summary>
        /// Displays the setup keybinds-wizard.
        /// </summary>
        public void SetupKeybinds()
        {
            MessageBox.Show("Not yet implemented. Use CTRL+ALT+F12.");
        }

        /// <summary>
        /// Sets whether the application should start automatically upon boot or not. 
        /// </summary>
        /// <param name="status">whether the application should start automatically upon boot or not</param>
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
