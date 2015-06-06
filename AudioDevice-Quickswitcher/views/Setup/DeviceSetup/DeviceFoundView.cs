using System;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.Models;

namespace AudioDevice_Quickswitcher.Views.Setup.DeviceSetup
{
    public partial class DeviceFoundView : Form
    {

        private readonly ContinueDelegate _continueDelegate;
        private readonly RestartDelegate _restartDelegate;

        public DeviceFoundView(AudioDevice deviceFound, ContinueDelegate continueDelegate, RestartDelegate restartDelegate)
        {
            _continueDelegate = continueDelegate;
            _restartDelegate = restartDelegate;

            InitializeComponent();
            detailsLabel.Text += deviceFound.FriendlyName;
        }

        public delegate void ContinueDelegate();
        public delegate void RestartDelegate();

        private void continueButton_Click(object sender, EventArgs e)
        {
            _continueDelegate();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            _restartDelegate();
        }
    }
}
