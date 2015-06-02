using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioDevice_Quickswitcher.views
{
    public interface ISetupListener
    {
        void SetupDevices();
        void SetupKeybinds();
        void ShouldStartAutomatically(bool status);
    }
}
