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
using System.Drawing.Drawing2D;

namespace GUI.Boxes
{
    public partial class GameBox : UserControl
    {
        #region "Events Declarations"
        public delegate void BoxSelectedDelegate(object sender, int GameID);
        public event BoxSelectedDelegate BoxSelected;

        public delegate void BoxDoubleClickDelegate(object sender, int GameID);
        public event BoxDoubleClickDelegate BoxDoubleClick;
        #endregion

        private bool _isHover;
        private bool _isSelected;
        private string _GameName = string.Empty;
        private Image _GameImage = null;
        private int _GameID = 0;
        private Font _textFont = null;
        private bool _render3D = true;

        private int _maxNameLength = 25;

        public GameBox()
        {
            InitializeComponent();

            SetupUI();
        }

        public GameBox(bool Render3D)
        {
            InitializeComponent();

            SetupUI();

            _render3D = Render3D;
        }

        private void SetupUI()
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

            _isHover = false;
            _isSelected = false;
            _render3D = true;

            _textFont = new Font(this.Font.FontFamily, 11);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_render3D)
                RenderBox(e.Graphics, _GameName);
            else
                RenderFlat(e.Graphics, _GameName);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);

            this.Cursor = Cursors.Hand;
            _isHover = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.Cursor = Cursors.Default;
            _isHover = false;
            this.Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            _isSelected = true;

            if (BoxSelected!=null)
                BoxSelected(this, _GameID);

        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            _isSelected = true;

            if (BoxDoubleClick != null)
                BoxDoubleClick(this, _GameID);
        }

        #region "Rendering Routines"
        private void RenderBox(Graphics gr, String GameName)
        {
            gr.SmoothingMode = SmoothingMode.HighQuality;

            //Hover or Selected stroke
            if (_isHover || _isSelected)
            {
                GraphicsPath bounds = new GraphicsPath();
                bounds.AddLine(new Point(35, this.Height - 25), new Point(10, this.Height - 28));
                bounds.AddLine(new Point(10, this.Height - 28), new Point(10, 30));
                bounds.AddLine(new Point(10, 30), new Point(this.Width - 35, 17));
                bounds.AddLine(new Point(this.Width - 10, 20), new Point(this.Width - 35, 17));
                bounds.AddLine(new Point(this.Width - 10, 20), new Point(this.Width - 10, this.Height - 40));
                bounds.AddLine(new Point(this.Width - 10, this.Height - 40), new Point(35, this.Height - 25));

                if (_isHover)
                    gr.DrawPath(new Pen(Color.Yellow, 4), bounds);
                else
                    gr.DrawPath(new Pen(Color.Cyan, 4), bounds);

                bounds.Dispose();
            }

            //Left box side
            GraphicsPath side1 = new GraphicsPath();
            side1.AddLine(new Point(35, this.Height - 25), new Point(10, this.Height - 28));
            side1.AddLine(new Point(10, this.Height - 28), new Point(10, 30));
            side1.AddLine(new Point(10, 30), new Point(35, 33));
            side1.AddLine(new Point(35, 33), new Point(35, this.Height - 25));

            gr.FillPath(Brushes.LightGray, side1);
            gr.DrawPath(Pens.Gray, side1);

            side1.Dispose();

            //Front box side
            GraphicsPath side2 = new GraphicsPath();
            side2.AddLine(new Point(35, this.Height - 25), new Point(35, 33));
            side2.AddLine(new Point(35, 33), new Point(this.Width - 10, 20));
            side2.AddLine(new Point(this.Width - 10, 20), new Point(this.Width - 10, this.Height - 40));
            side2.AddLine(new Point(this.Width - 10, this.Height - 40), new Point(35, this.Height - 25));

            gr.FillPath(Brushes.LightGray, side2);

            //Drawing the image if available
            Point[] points = new Point[3];
            points[0] = new Point(35, 34);
            points[1] = new Point(this.Width - 10, 20);
            points[2] = new Point(35, this.Height - 25);

            if(_GameImage != null)
                gr.DrawImage(_GameImage, points);
            else
                gr.DrawImage(GUI.Properties.Resources.LogoAtari, points);

            //Now drawing the front side stroke
            gr.DrawPath(Pens.Gray, side2);

            side2.Dispose();

            //Top box side
            GraphicsPath side3 = new GraphicsPath();
            side3.AddLine(new Point(35, 33), new Point(this.Width - 10, 20));
            side3.AddLine(new Point(this.Width - 10, 20), new Point(this.Width - 35, 17));
            side3.AddLine(new Point(this.Width - 35, 17), new Point(10, 30));
            side3.AddLine(new Point(10, 30), new Point(35, 33));

            gr.FillPath(Brushes.LightGray, side3);
            gr.DrawPath(Pens.Gray, side3);

            side3.Dispose();

            //Game name on bottom
            GraphicsPath stringPath = new GraphicsPath();
            String NameToDisplay = _GameName;

            //Reducting game name to max of 18 chars
            if (NameToDisplay.Length > 18)
                NameToDisplay = NameToDisplay.Substring(0, _maxNameLength) + "...";

            SizeF measures = gr.MeasureString(NameToDisplay, _textFont);

            stringPath.AddString(NameToDisplay, this.Font.FontFamily, 0, 11, new Point((int)((this.Width / 2) - (measures.Width / 2) + 13), this.Height - 20), null);
            gr.FillPath(Brushes.White, stringPath);
            gr.DrawPath(Pens.LightGray, stringPath);

            stringPath.Dispose();
            
        }

        private void RenderFlat(Graphics gr, string _GameName)
        {
            gr.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle boxRect = new Rectangle(5, 5, this.Width - 8, this.Height - 30);

            //Game name on bottom
            GraphicsPath stringPath = new GraphicsPath();
            String NameToDisplay = _GameName;

            //Reducting game name to a given max 
            if (NameToDisplay.Length > _maxNameLength)
                NameToDisplay = NameToDisplay.Substring(0, _maxNameLength) + "...";

            SizeF measures = gr.MeasureString(NameToDisplay, _textFont);

            stringPath.AddString(NameToDisplay, this.Font.FontFamily, 0, 11, new Point((int)((this.Width / 2) - (measures.Width / 2) + 13), this.Height - 20), null);
            gr.FillPath(Brushes.White, stringPath);
            gr.DrawPath(Pens.LightGray, stringPath);

            stringPath.Dispose();

            //Preparing pen stroke
            Pen strokePen = null; 
            if (_isHover || _isSelected)
            {
                if (_isHover)
                    strokePen = new Pen(Color.Yellow, 4);
                else
                    strokePen = new Pen(Color.Cyan, 4);

            }
            else
            {
                strokePen = new Pen(Color.FromArgb(0,0,0,0), 1);
            }

            //Drawing the Rounded corner box with image
            if (_GameImage != null)
                DrawRoundedRectangle(gr, boxRect, 25, strokePen, Color.FromArgb(50, 50, 50), _GameImage);
            else
                DrawRoundedRectangle(gr, boxRect, 25, strokePen, Color.FromArgb(50, 50, 50), GUI.Properties.Resources.LogoAtari);

        }

        private void DrawRoundedRectangle(Graphics gfx, Rectangle Bounds, int CornerRadius, Pen DrawPen, Color FillColor, Image Cover)
        {
            gfx.SmoothingMode = SmoothingMode.HighQuality;

            int strokeOffset = Convert.ToInt32(Math.Ceiling(DrawPen.Width));
            Bounds = Rectangle.Inflate(Bounds, -strokeOffset, -strokeOffset);

            DrawPen.EndCap = DrawPen.StartCap = LineCap.Round;

            GraphicsPath gfxPath = new GraphicsPath();
            gfxPath.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            gfxPath.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            gfxPath.CloseAllFigures();

            gfx.FillPath(new SolidBrush(FillColor), gfxPath);

            //Drawing image
            if (Cover != null)
            {
                gfx.SetClip(gfxPath);
                gfx.DrawImage(Cover, Bounds);
            }

            gfx.DrawPath(DrawPen, gfxPath);
        }
        #endregion

        #region "Properties"
        public string GameName
        {
            get { return _GameName; }
            set 
            {
                if (_GameName != value)
                {
                    _GameName = value;
                    boxToolTip.SetToolTip(this, _GameName);
                    this.Invalidate();
                }
            }
        }

        public Image GameImage
        {
            get { return _GameImage; }
            set
            {
                if (_GameImage != value)
                {
                    _GameImage = value;
                    this.Invalidate();
                }
            }
        }

        public int GameID
        {
            get { return _GameID; }
            set { _GameID = value; }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set { 
                _isSelected = value;
                this.Invalidate();
            }
        }
        #endregion
    }
}
