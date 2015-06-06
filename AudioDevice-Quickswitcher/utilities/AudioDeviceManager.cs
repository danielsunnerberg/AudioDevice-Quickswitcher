﻿using System;
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

        /// <summary>
        /// Creates a new audio device manager, wrapping the AudioEndPointController executable found at the specified path. 
        /// </summary>
        /// <param name="audioEndPointControllerPath">Path to AudioEndPointController executable</param>
        public AudioDeviceManager(string audioEndPointControllerPath)
        {
            _processExecutor = new ProcessExecutor(audioEndPointControllerPath);
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

        /// <summary>
        /// Sets the specified audio device as the system default.
        /// </summary>
        /// <param name="audioDevice">Device to be set as system default</param>
        public void SetDeviceAsDefault(AudioDevice audioDevice)
        {
            _processExecutor.Start(string.Format(" {0}", audioDevice.Index));
        }
    }
}