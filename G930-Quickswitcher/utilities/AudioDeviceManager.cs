using System;
using System.Collections.Generic;
using System.Linq;
using G930_Quickswitcher.model;

namespace G930_Quickswitcher.utilities
{
    /// <summary>
    /// Manages the operating system's audio devices by wrapping Dan Steven's AudioEndPointController (https://github.com/DanStevens/AudioEndPointController).
    /// </summary>
    class AudioDeviceManager
    {

        private static readonly string AUDIO_SERVICE_PATH = @"dependencies/EndPointController_forked.exe";
        private static readonly string SERVICE_OUTPUT_FORMAT = "%d|%ws";
        
        private readonly ProcessExecutor _processExecutor;

        public AudioDeviceManager()
        {
            _processExecutor = new ProcessExecutor(AUDIO_SERVICE_PATH);
        }

        private AudioDevice GetDevice(string deviceString)
        {
            if (!deviceString.Contains('|') || deviceString.Split('|').Length != 2)
            {
                throw new ArgumentException(string.Format("The supplied deviceString was invalid. Expected format: id|description. Found: '{0}'", deviceString));
            }
            string[] pieces = deviceString.Split('|');
            int deviceId = Convert.ToInt32(pieces[0]);
            string description = pieces[1];

            return new AudioDevice(deviceId, description);
        }

        /// <summary>
        /// Returns all connected audio devices.
        /// </summary>
        /// <returns>All connected audio devices</returns>
        public IList<AudioDevice> GetDevices()
        {
            IList<AudioDevice> devices = new List<AudioDevice>();
            string serviceResponse = _processExecutor.Query("-f " + SERVICE_OUTPUT_FORMAT);
            string[] deviceStrings = serviceResponse.Split('\n').Where(line => line.Length > 0).ToArray();
            Array.ForEach(deviceStrings, deviceString =>
            {
                devices.Add(GetDevice(deviceString));
            });
            return devices;
        }

        public void SetDeviceAsDefaultPlayback(AudioDevice audioDevice)
        {
            // TODO
        }

    }
}
