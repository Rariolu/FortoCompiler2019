using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public abstract class TabPageExtension : TabPage
    {
        bool everChanged = false;
        public bool EverChanged
        {
            get
            {
                return everChanged;
            }
        }
        bool prevSaved = false;
        public bool PrevSaved
        {
            get
            {
                return prevSaved;
            }
        }
        string filePath = "";
        public string FilePath
        {
            get
            {
                return filePath;
            }
            protected set
            {
                filePath = value;
                prevSaved = true;
                everChanged = true;
            }
        }
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
            filePath = "newPage" + (tabid = tabCount++);
            Text = "*"+filePath;
        }
        public TabPageExtension(string file) : this()
        {
            if (File.Exists(file))
            {
                FilePath = file;
                Text = file;
            }
        }
        public void ChangeHappened()
        {
            everChanged = true;
        }
        List<object> additionalParams = new List<object>();
        public void AddParam(object obj)
        {
            additionalParams.Add(obj);
        }
        public object[] AdditionalParams()
        {
            return additionalParams.ToArray();
        }
        protected abstract void InitialiseComponent();
        public abstract void Save();
        public abstract void SaveAs(string file);
        public abstract string DialogFilter();
        public abstract bool UnChanged();
    }
}