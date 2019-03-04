using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public abstract class TabPageExtension : TabPage
    {
        int tabid;
        public int TabID
        {
            get
            {
                return tabid;
            }
        }
        static int tabCount = 1;
        public TabPageExtension()
        {
            InitialiseComponent();
            Text = "*newPage" +(tabid= tabCount++);
        }
        protected abstract void InitialiseComponent();
    }
}