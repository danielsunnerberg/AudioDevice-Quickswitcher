using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using AudioDevice_Quickswitcher.model;

namespace AudioDevice_Quickswitcher.utilities
{
    /// <summary>
    /// Manages the operating system's audio devices by wrapping Dan Steven's AudioEndPointController (https://github.com/DanStevens/AudioEndPointController).
    /// </summary>
    internal class AudioDeviceManager
    {
        private static readonly string SERVICE_OUTPUT_FORMAT =
            @"<device><index>%d</index><friendlyName>%s</friendlyName><state>%d</state><default>%d</default><description>%s</description><interfaceFriendlyName>%s</interfaceFriendlyName><deviceId>%s</deviceId></device>";

        private readonly ProcessExecutor _processExecutor;

        public AudioDeviceManager(string endPointControllerPath)
        {
            _processExecutor = new ProcessExecutor(endPointControllerPath);
        }

        /// <summary>
        /// Returns all connected audio devices.
        /// </summary>
        /// <returns>All connected audio devices</returns>
        public IList<AudioDevice> GetDevices()
        {
            string serviceResponse = _processExecutor.Query("-f " + SERVICE_OUTPUT_FORMAT);
            string devicesXml = String.Format("<devices>{0}</devices>", serviceResponse);

            XmlSerializer serializer = new XmlSerializer(typeof (AudioDevices));
            var devicesWrapper = (AudioDevices) serializer.Deserialize(new StringReader(devicesXml));
            return devicesWrapper.Devices;
        }

        public void SetDeviceAsDefault(AudioDevice audioDevice)
        {
            _processExecutor.Start(string.Format(" {0}", audioDevice.Index));
        }
    }
}