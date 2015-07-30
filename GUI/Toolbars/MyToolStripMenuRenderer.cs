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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace GUI.Toolbars
{
    class MyToolStripMenuRenderer : ProfessionalColorTable
    {

        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Color.FromArgb(64, 64, 64);
            }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return Color.FromArgb(64, 64, 64);
            }
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                return Color.FromArgb(50, 50, 50);
            }
        }

        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return Color.FromArgb(50, 50, 50);
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Color.FromArgb(50, 50, 50);
            }
        }

        public override Color MenuBorder
        {
            get
            {
                return Color.Black;
            }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return Color.FromArgb(90, 90, 90);
            }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return Color.FromArgb(90, 90, 90);
            }
        }
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(64, 64, 64); }
        }

        public override Color MenuItemBorder  //added for changing the menu border
        {
            get { return Color.LightGray; }
        }

        public override Color ToolStripBorder
        {
            get { return Color.FromArgb(50, 50, 50);  }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return Color.FromArgb(50, 50, 50); }
        }

        public override Color ToolStripGradientBegin
        {
            get { return Color.FromArgb(64, 64, 64); }
        }

        public override Color ToolStripGradientEnd
        {
            get { return Color.FromArgb(64, 64, 64); }
        }

        public override Color ToolStripGradientMiddle
        {
            get { return Color.FromArgb(64, 64, 64); }
        }

        public override Color MenuStripGradientBegin
        {
            get
            {
                return Color.FromArgb(50, 50, 50);
            }
        }
        public override Color MenuStripGradientEnd
        {
            get
            {
                return Color.FromArgb(50, 50, 50);
            }
        }

        public override Color SeparatorDark
        {
            get
            {
                return Color.Black; 
            }
        }

        public override Color SeparatorLight
        {
            get
            {
                return Color.Gray;
            }
        }
    }
}
