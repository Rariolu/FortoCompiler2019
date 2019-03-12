using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public class NewTabControl : TabControl
    {
        public new TabPageExtension SelectedTab
        {
            get
            {
                return base.SelectedTab as TabPageExtension;
            }
        }
        public void SelectLastTab()
        {
            SelectedIndex = TabCount - 1;
        }
    }
}