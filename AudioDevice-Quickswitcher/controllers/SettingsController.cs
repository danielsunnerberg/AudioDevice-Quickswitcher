using System;
using AudioDevice_Quickswitcher.utilities;
using AudioDevice_Quickswitcher.views;

namespace AudioDevice_Quickswitcher.controllers
{
    class SettingsController : Controller, ISetupListener
    {

        private readonly AudioDeviceManager _audioDeviceManager;

        public SettingsController(AudioDeviceManager audioDeviceManager)
        {
            _audioDeviceManager = audioDeviceManager;
            View = new SettingsView(this);
        }

        public void SetupDevices()
        {
            View.Hide();
            new SetupController(_audioDeviceManager).DisplayFirstStep();
        }

        public void SetupKeybinds()
        {
            throw new NotImplementedException();
        }

        public void ShouldStartAutomatically(bool status)
        {
            throw new NotImplementedException();
        }
    }
}
