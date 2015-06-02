using System;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.utilities.keyboardHook;

namespace AudioDevice_Quickswitcher.controllers
{
    class DeviceSwitchController : IKeyboardListener
    {
        public void ListenForSwitchRequest()
        {
            ModifierKeys modifierKeys = ModifierKeys.Control | ModifierKeys.Alt;
            Keys hotKey = Keys.F12;

            var keyboardHookView = new KeyboardHookView(this, modifierKeys, hotKey);
            Application.Run(keyboardHookView);
        }

        public void HotKeyPressed()
        {
            Console.WriteLine("Hotkey pressed");
        }
    }
}
