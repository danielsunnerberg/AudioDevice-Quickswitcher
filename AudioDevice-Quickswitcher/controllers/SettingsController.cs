using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.views;

namespace AudioDevice_Quickswitcher.controllers
{
    class SettingsController : Controller, ISetupListener
    {
        public SettingsController()
        {
            view = new SettingsView(this);
        }

        public void SetupDevices()
        {
            view.Hide();
            new SetupController().DisplayFirstStep();
        }

        public void SetupKeybinds()
        {
            throw new NotImplementedException();
        }

        public void ShouldStartAutomatically(bool status)
        {
            throw new NotImplementedException();
        }
    }
}
