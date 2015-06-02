using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.model;
using AudioDevice_Quickswitcher.utilities;
using AudioDevice_Quickswitcher.views;

namespace AudioDevice_Quickswitcher.controllers
{
    class SetupController : Controller, IDeviceDisconnectedListener
    {
        private readonly AudioDeviceManager _audioDeviceManager;
        private readonly Timer _reconnectTimer = new Timer();

        private IList<AudioDevice> _preConnectAudioDevices;
        private AudioDevice _detectedAudioDevice;

        private Form _currentView;

        public SetupController(AudioDeviceManager audioDeviceManager)
        {
            _audioDeviceManager = audioDeviceManager;
            _reconnectTimer.Tick += ListenForReconnect;
            _reconnectTimer.Interval = 300;
        }

        public void DisplayFirstStep()
        {
            ChangeView(new DisconnectDeviceView(this));
        }

        private void ChangeView(Form newForm)
        {
            if (_currentView != null)
            {
                _currentView.Hide();
            }
            _currentView = newForm;
            _currentView.Show();
        }

        public void DeviceDisconnected()
        {
            _preConnectAudioDevices = _audioDeviceManager.GetDevices();
            _reconnectTimer.Start();

            ChangeView(new ReconnectDeviceView());
        }

        private void ListenForReconnect(object sender, EventArgs eventArgs)
        {
            IList<AudioDevice> connectedDevices = _audioDeviceManager.GetDevices();
            if (_preConnectAudioDevices.Count != connectedDevices.Count)
            {
                // A new device has been connected, it's the one we're searching for
                _detectedAudioDevice = connectedDevices.Except(_preConnectAudioDevices).First();
                _reconnectTimer.Stop();

                DeviceFound();
            }
        }

        private void DeviceFound()
        {
            ChangeView(new DeviceFoundView(_detectedAudioDevice, SaveFoundDevice, DisplayFirstStep));
        }

        private void SaveFoundDevice()
        {
            AudioDevice originalDefaultDevice = _preConnectAudioDevices.First(d => d.IsDefault);

            ChosenAudioDevices.Default.originalDefaultDeviceId = originalDefaultDevice.DeviceId;
            ChosenAudioDevices.Default.alternateDefaultDeviceId = _detectedAudioDevice.DeviceId;
            ChosenAudioDevices.Default.Save();

            _currentView.Hide();
        }

    }
}
