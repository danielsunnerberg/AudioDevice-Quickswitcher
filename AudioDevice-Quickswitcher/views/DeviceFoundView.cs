using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioDevice_Quickswitcher.model;

namespace AudioDevice_Quickswitcher.views
{
    public partial class DeviceFoundView : Form
    {
        public DeviceFoundView(AudioDevice deviceFound)
        {
            InitializeComponent();
            detailsLabel.Text += deviceFound.Details;
        }
    }
}
