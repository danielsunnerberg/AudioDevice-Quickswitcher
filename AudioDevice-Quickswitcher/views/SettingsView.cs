using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioDevice_Quickswitcher.views
{
    public partial class SettingsView : Form
    {
        private readonly ISetupListener _listener;

        public SettingsView(ISetupListener listener)
        {
            _listener = listener;
            InitializeComponent();
        }

        private void setupDevices_Click(object sender, EventArgs e)
        {
            _listener.SetupDevices();
        }

    }
}
