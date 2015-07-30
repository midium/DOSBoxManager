/*
 * DOSBox Manager : .NET front-end for DOSBox
 * Copyright (C) 2015 MiDiUm Software
 * 
 * This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with this program.
 * If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Tabs.Base
{
    public partial class TabsBase : UserControl
    {

        #region "Declarations"
        public delegate void TabChangedDelegate(object sender, int index);
        public event TabChangedDelegate TabChanged;

        protected Dictionary<string, int> _buttons;
        protected int _currentIndex;
        #endregion

        #region "Constructor"
        public TabsBase()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

        }
        #endregion

        #region "Must Override Methods"
        public virtual void InitializeButtonsDictionary() { }
        #endregion

        #region "Tab Buttons"
        protected void tabButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;

            if (_buttons.ContainsKey(btn.Name))
            {
                if (_buttons[btn.Name] != _currentIndex)
                {
                    _currentIndex = _buttons[btn.Name];
                    TabChanged(this, _currentIndex);
                }
            }
        }
        #endregion
    }
}
