using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioDevice_Quickswitcher.utilities.keyboardHook
{
    public partial class KeyboardHookView : Form
    {
        private readonly KeyboardHook _hook = new KeyboardHook();
        private readonly IKeyboardListener _listener;

        public KeyboardHookView(IKeyboardListener listener, ModifierKeys modifierKeys, Keys key)
        {
            _listener = listener;

            InitializeComponent();

            _hook.KeyPressed += hook_KeyPressed;
            _hook.RegisterHotKey(modifierKeys, key);
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            _listener.HotKeyPressed();
        }

        private void KeyboardHookView_Load(object sender, EventArgs e)
        {

        }

    }
}
