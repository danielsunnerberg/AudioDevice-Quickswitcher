using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.controllers.setup;

namespace AudioDevice_Quickswitcher.views
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
