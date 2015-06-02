namespace AudioDevice_Quickswitcher.views
{
    public interface ISetupListener
    {
        void SetupDevices();
        void SetupKeybinds();
        void ShouldStartAutomatically(bool status);
        void ExitProgram();
    }
}
