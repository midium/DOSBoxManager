using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Tabs.Base;

namespace GUI.Tabs
{
    public partial class GameTabs : TabsBase
    {
        #region "Constuctors"
        public GameTabs():base()
        {
            InitializeComponent();

            InitializeButtonsDictionary();
        }
        #endregion

        #region "Method Override"
        public override void InitializeButtonsDictionary()
        {
            _buttons = new Dictionary<string, int>();

            _currentIndex = 1;
            _buttons.Add(infoTab.Name, 1);
            _buttons.Add(dosboxTab.Name, 2);

            infoTab.CheckedChanged += tabButton_CheckedChanged;
            dosboxTab.CheckedChanged += tabButton_CheckedChanged;
        }
        #endregion
    }
}
