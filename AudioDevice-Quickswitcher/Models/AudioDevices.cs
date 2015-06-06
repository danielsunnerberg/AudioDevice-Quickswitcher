using System.Collections.Generic;
using System.Xml.Serialization;

namespace AudioDevice_Quickswitcher.Models
{
    /// <summary>
    /// A wrapper class for AudioDevice to allow serialization of multiple instances.
    /// </summary>
    [XmlRoot("devices")]
    public class AudioDevices
    {
        [XmlElement("device")]
        public List<AudioDevice> Devices { get; set; }

        public AudioDevices()
        {
            Devices = new List<AudioDevice>();
        }
    }
}
