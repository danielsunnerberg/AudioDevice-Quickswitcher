using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.model;
using AudioDevice_Quickswitcher.utilities;
using AudioDevice_Quickswitcher.utilities.keyboardHook;

namespace AudioDevice_Quickswitcher.controllers
{
    /// <summary>
    /// Responsible for listening to keyboard events and, when required, change to the proper audio device.
    /// </summary>
    class DeviceSwitchController
    {
        private readonly AudioDeviceManager _audioDeviceManager;
        private readonly KeyboardHook _hook = new KeyboardHook();

        public DeviceSwitchController(AudioDeviceManager audioDeviceManager)
        {
            _audioDeviceManager = audioDeviceManager;
        }

        public void ListenForSwitchRequest()
        {
            // TODO support others
            ModifierKeys modifierKeys = ModifierKeys.Control | ModifierKeys.Alt;
            Keys hotKey = Keys.F12;

            _hook.KeyPressed += HotKeyPressed;
            _hook.RegisterHotKey(modifierKeys, hotKey);
        }

        public void HotKeyPressed(object sender, KeyPressedEventArgs e)
        {
            SwitchAudioDevice();
        }

        private void SwitchAudioDevice()
        {
            string defaultDeviceId = ChosenAudioDevices.Default.originalDefaultDeviceId;
            string alternateDeviceId = ChosenAudioDevices.Default.alternateDefaultDeviceId;

            if (defaultDeviceId == null || alternateDeviceId == null)
            {
                ShowErrorDialog("Found no stored audio devices", "Found no stored audio devices. You must run the setup before being able to switch between devices.");
                return;
            }

            IList<AudioDevice> devices = _audioDeviceManager.GetDevices();
            AudioDevice audioDevice = devices.FirstOrDefault(d => (d.DeviceId == defaultDeviceId || d.DeviceId == alternateDeviceId) && !d.IsDefault);
            if (audioDevice == null)
            {
                ShowErrorDialog("Failed to switch between audio devices", "Failed to switch between audio devices. Make sure the devices selected during setup are connected.\nIf this problem persists, try re-running the setup.");
                return;
            }

            _audioDeviceManager.SetDeviceAsDefault(audioDevice);
        }

        private void ShowErrorDialog(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
