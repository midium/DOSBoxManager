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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GUI.Toolbars
{
    public class MyToolStripRenderer : ToolStripSystemRenderer
    {
        public MyToolStripRenderer() { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
                base.OnRenderButtonBackground(e);
            else
            {
                Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                e.Graphics.DrawRectangle(Pens.LightGray, rectangle);
            }
        }

        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            
            if (!e.Item.Selected)
                base.OnRenderSplitButtonBackground(e);
            else
            {
                e.ToolStrip.RenderMode = ToolStripRenderMode.Professional;
                e.ToolStrip.Renderer = new ToolStripProfessionalRenderer(new MyToolStripMenuRenderer());

                Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                e.Graphics.DrawRectangle(Pens.LightGray, rectangle);
                rectangle = new Rectangle(0, 0, e.Item.Size.Width - 13, e.Item.Size.Height - 1);
                e.Graphics.DrawRectangle(Pens.LightGray, rectangle);
            }
        }

    }
}
