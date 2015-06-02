using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.model;
using AudioDevice_Quickswitcher.utilities;
using AudioDevice_Quickswitcher.utilities.keyboardHook;

namespace AudioDevice_Quickswitcher.controllers
{
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
            //view = new KeyboardHookView(this, modifierKeys, hotKey);

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

            // TODO process error when no matching device is found
            AudioDevice audioDevice = devices.First(d => (d.DeviceId == defaultDeviceId || d.DeviceId == alternateDeviceId) && !d.IsDefault);
            _audioDeviceManager.SetDeviceAsDefault(audioDevice);
        }

    }
}
