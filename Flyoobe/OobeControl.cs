using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyoobe
{
    public partial class OobeControl : UserControl
    {
        public Panel ContentPanel => panelContent;
        public Panel SidebarPanel => panelNav;
        public OobeControl()
        {
            InitializeComponent();
        }
    }
}
