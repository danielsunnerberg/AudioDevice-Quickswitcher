using System;
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

            // We want the program to remain completely hidden by default, except for the icon in the tray bar
            WindowState = FormWindowState.Minimized;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            ShowInTaskbar = false;
        }

        private void setupDevices_Click(object sender, EventArgs e)
        {
            _listener.SetupDevices();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ShowInTaskbar = true;
            Show();
        }

    }
}
