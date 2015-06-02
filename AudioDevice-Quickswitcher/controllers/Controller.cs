using System.Windows.Forms;

namespace AudioDevice_Quickswitcher.controllers
{
    public abstract class Controller
    {
        public Form View { get; protected set; }
    }
}
