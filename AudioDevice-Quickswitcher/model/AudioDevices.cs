using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AudioDevice_Quickswitcher.model
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
