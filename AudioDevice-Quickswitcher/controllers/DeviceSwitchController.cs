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
            IList<AudioDevice> devices = _audioDeviceManager.GetDevices();
            string defaultDeviceId = ChosenAudioDevices.Default.originalDefaultDeviceId;
            string alternateDeviceId = ChosenAudioDevices.Default.alternateDefaultDeviceId;
            AudioDevice audioDevice = devices.FirstOrDefault(d => (d.DeviceId == defaultDeviceId || d.DeviceId == alternateDeviceId) && !d.IsDefault);

            if (defaultDeviceId == null || alternateDeviceId == null || audioDevice == null)
            {
                MessageBox.Show("Failed to change default audio device. Try re-running the setup.", "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _audioDeviceManager.SetDeviceAsDefault(audioDevice);
        }

    }
}
