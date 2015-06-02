using System;
using System.Windows.Forms;

namespace AudioDevice_Quickswitcher.views
{
    public partial class SettingsView : Form
    {
        private readonly ISetupListener _listener;

        public SettingsView(bool autorunEnabled, ISetupListener listener)
        {
            _listener = listener;
            InitializeComponent();

            automaticStartupCheckbox.Checked = autorunEnabled;

            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add("Settings", (sender, args) => MaximizeFromTray());
            contextMenu.MenuItems.Add("Exit", (sender, args) => listener.ExitProgram());
            notifyIcon.ContextMenu = contextMenu;

            // We want the program to remain completely hidden by default, except for the icon in the tray bar
            HideToTray();
        }

        public void HideToTray()
        {
            WindowState = FormWindowState.Minimized;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            ShowInTaskbar = false;
            Opacity = 0;
        }

        public void MaximizeFromTray()
        {
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ShowInTaskbar = true;
            Opacity = 100;
            Show();
        }

        private void setupDevices_Click(object sender, EventArgs e)
        {
            _listener.SetupDevices();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MaximizeFromTray();
        }

        private void automaticStartupCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            _listener.ShouldStartAutomatically(automaticStartupCheckbox.Checked);
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                return;
            }

            HideToTray();
            e.Cancel = true;
        }

        private void setupKeyBinds_Click(object sender, EventArgs e)
        {
            _listener.SetupKeybinds();
        }

    }
}
