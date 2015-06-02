using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.model;
using AudioDevice_Quickswitcher.utilities;
using AudioDevice_Quickswitcher.utilities.keyboardHook;

namespace AudioDevice_Quickswitcher.controllers
{
    class DeviceSwitchController : Controller, IKeyboardListener
    {

        private readonly AudioDeviceManager _audioDeviceManager;

        public DeviceSwitchController(AudioDeviceManager audioDeviceManager)
        {
            _audioDeviceManager = audioDeviceManager;
        }

        public void ListenForSwitchRequest()
        {
            ModifierKeys modifierKeys = ModifierKeys.Control | ModifierKeys.Alt;
            Keys hotKey = Keys.F12;
            view = new KeyboardHookView(this, modifierKeys, hotKey);

            view.WindowState = FormWindowState.Minimized;
            view.ShowInTaskbar = false;
        }

        public void HotKeyPressed()
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
