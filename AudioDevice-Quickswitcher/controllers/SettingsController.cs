using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.views;

namespace AudioDevice_Quickswitcher.controllers
{
    class SettingsController : ISetupListener
    {

        private SettingsView settingsView;

        public void ShowView()
        {
            settingsView = new SettingsView(this);
            Application.Run(settingsView);
        }

        public void SetupDevices()
        {
            settingsView.Hide();
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
