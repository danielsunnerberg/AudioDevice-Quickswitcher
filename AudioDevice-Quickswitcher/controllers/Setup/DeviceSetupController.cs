using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.controllers;
using AudioDevice_Quickswitcher.Models;
using AudioDevice_Quickswitcher.utilities;
using AudioDevice_Quickswitcher.Views.Setup.DeviceSetup;

namespace AudioDevice_Quickswitcher.Controllers.Setup
{
    /// <summary>
    /// Responsible for identifying the devices which the user will switch between.
    /// </summary>
    class DeviceSetupController : ViewController<Form>, IDeviceDisconnectedListener
    {
        private readonly AudioDeviceManager _audioDeviceManager;
        private readonly Timer _reconnectTimer = new Timer();

        private IList<AudioDevice> _preConnectAudioDevices;
        private AudioDevice _detectedAudioDevice;

        /// <summary>
        /// Creates a new device setup controller which will identify audio devices using the specified instance.
        /// </summary>
        /// <param name="audioDeviceManager">manager which the controller will use to identify audio devices</param>
        public DeviceSetupController(AudioDeviceManager audioDeviceManager)
        {
            _audioDeviceManager = audioDeviceManager;
            _reconnectTimer.Tick += ListenForReconnect;
            _reconnectTimer.Interval = 300;
        }

        /// <summary>
        /// Displays the wizard's first step.
        /// </summary>
        public void DisplayFirstStep()
        {
            ChangeView(new DisconnectDeviceView(this));
        }

        private void ChangeView(Form newForm)
        {
            if (View != null)
            {
                View.Hide();
            }
            View = newForm;
            View.Show();
        }

        /// <summary>
        /// Callback for when the user has disconnected the device and is ready to proceed.
        /// </summary>
        public void DeviceDisconnected()
        {
            _preConnectAudioDevices = _audioDeviceManager.GetDevices();
            _reconnectTimer.Start();

            var reconnectDeviceView = new ReconnectDeviceView();
            reconnectDeviceView.FormClosed += CancelWizard;
            ChangeView(reconnectDeviceView);
        }

        private void CancelWizard(object sender = null, FormClosedEventArgs formClosedEventArgs = null)
        {
            _reconnectTimer.Stop();
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
            ChangeView(new DeviceFoundView(_detectedAudioDevice, SaveFoundDevice, RestartWizard));
        }

        private void RestartWizard()
        {
            CancelWizard();
            DisplayFirstStep();
        }

        private void SaveFoundDevice()
        {
            AudioDevice originalDefaultDevice = _preConnectAudioDevices.First(d => d.IsDefault);

            ChosenAudioDevices.Default.originalDefaultDeviceId = originalDefaultDevice.DeviceId;
            ChosenAudioDevices.Default.alternateDefaultDeviceId = _detectedAudioDevice.DeviceId;
            ChosenAudioDevices.Default.Save();

            View.Hide();
        }

    }
}
