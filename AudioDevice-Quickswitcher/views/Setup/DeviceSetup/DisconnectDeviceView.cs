using System;
using System.Windows.Forms;

namespace AudioDevice_Quickswitcher.views.DeviceSetup
{
    public partial class DisconnectDeviceView : Form
    {

        private readonly IDeviceDisconnectedListener _listener;

        public DisconnectDeviceView(IDeviceDisconnectedListener listener)
        {
            InitializeComponent();
            _listener = listener;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            _listener.DeviceDisconnected();
        }

    }
}
