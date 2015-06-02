using System;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.utilities.keyboardHook;

namespace AudioDevice_Quickswitcher.controllers
{
    class DeviceSwitchController : Controller, IKeyboardListener
    {
        public void ListenForSwitchRequest()
        {
            ModifierKeys modifierKeys = ModifierKeys.Control | ModifierKeys.Alt;
            Keys hotKey = Keys.F12;
            view = new KeyboardHookView(this, modifierKeys, hotKey);

            view.WindowState = FormWindowState.Minimized;
            view.ShowInTaskbar = false;
        }

        public void HotKeyPressed()
        {
            Console.WriteLine("Hotkey pressed");
        }
    }
}
