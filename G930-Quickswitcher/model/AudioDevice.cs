namespace G930_Quickswitcher.model
{
    /// <summary>
    /// Represents an audio device in the operating system
    /// </summary>
    class AudioDevice
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

    }
}
