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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.TextBoxes
{
    public partial class NumericTextBox : TextBox
    {
        private string _currentValue = string.Empty;

        public NumericTextBox()
        {
            InitializeComponent();
        }

        public NumericTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Home || e.KeyCode == Keys.End || e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal))
            {
                if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
                    e.SuppressKeyPress = true;

            }

            _currentValue = this.Text;

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (Regex.IsMatch(this.Text, "^[+-]?[0-9]{1,3}(?:,?[0-9]{3})*(?:\\.[0-9]{2})?$"))
            {
                base.OnKeyUp(e);
            } else {
                this.Text = _currentValue ;
            }
        }
    }
}
