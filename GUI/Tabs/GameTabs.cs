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
