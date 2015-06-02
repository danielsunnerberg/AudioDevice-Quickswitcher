using System;

namespace AudioDevice_Quickswitcher.model
{
    /// <summary>
    /// Represents an audio device in the operating system
    /// </summary>
    public class AudioDevice
    {

        /// <summary>
        /// The devices internal id.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// A string including the friendly name, driver name and such.
        /// </summary>
        public string Details { get; private set; }

        public AudioDevice(int id, string details)
        {
            Id = id;
            Details = details;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", Id, Details);
        }

        protected bool Equals(AudioDevice other)
        {
            return Id == other.Id && string.Equals(Details, other.Details);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AudioDevice) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id*397) ^ Details.GetHashCode();
            }
        }
    }
}
