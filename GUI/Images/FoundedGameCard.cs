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
using Helpers.Data.Objects.MyAbandonwareData;

namespace GUI.Images
{
    public partial class FoundedGameCard : UserControl
    {
        #region "Declarations"
        private MyAbandonGameFound _gameData;

        private bool _isSelected = false;
        private bool _isHover = false;

        #region "Events"
        public delegate void FoundedGameCardDoubleClickDelegate(object sender);
        public event FoundedGameCardDoubleClickDelegate FoundedGameCardDoubleClick;

        public delegate void FoundedGameCardClickDelegate(object sender);
        public event FoundedGameCardClickDelegate FoundedGameCardClick;
        #endregion
        #endregion

        #region "Constructors"
        public FoundedGameCard()
        {
            InitializeComponent();
            SetupComponent();
        }

        public FoundedGameCard(MyAbandonGameFound GameData)
        {
            InitializeComponent();
            SetupComponent();

            _gameData = GameData;
            RenderUI();
        }

        ~FoundedGameCard()
        {
            this.MouseEnter -= items_mouseenter;
            lblGameName.MouseEnter -= items_mouseenter;
            lblYear.MouseEnter -= items_mouseenter;
            lblPlatform.MouseEnter -= items_mouseenter;

            this.MouseLeave -= items_mouseleave;
            lblGameName.MouseLeave -= items_mouseleave;
            lblYear.MouseLeave -= items_mouseleave;
            lblPlatform.MouseLeave -= items_mouseleave;

            this.Click -= items_click;
            lblGameName.Click -= items_click;
            lblYear.Click -= items_click;
            lblPlatform.Click -= items_click;
            screenshot.Click -= items_click;

            this.DoubleClick -= items_doubleclick;
            lblGameName.DoubleClick -= items_doubleclick;
            lblYear.DoubleClick -= items_doubleclick;
            lblPlatform.DoubleClick -= items_doubleclick;
            screenshot.DoubleClick -= items_doubleclick;
     
        }
        #endregion

        #region "Propeties"
        public MyAbandonGameFound GameData
        {
            get { return _gameData; }
            set
            {
                _gameData = value;
                RenderUI();
            }
        }

        public bool IsHover
        {
            get { return _isHover; }
            set
            {
                _isHover = value;
                this.Invalidate();
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                screenshot.IsSelected = _isSelected;
                this.Invalidate();
            }
        }
        #endregion

        #region "Methods"
        #region "Public"
        #endregion

        #region "Private"
        private void RenderUI()
        {
            if (_gameData != null)
            {
                lblGameName.Text = _gameData.Title.Replace("&","&&");
                lblYear.Text = _gameData.Year.Replace("&", "&&");
                lblPlatform.Text = _gameData.Platform.Replace("&", "&&");

                screenshot.LoadScreenshot(_gameData.CoverUri);
            }
            else
            {
                lblGameName.Text = string.Empty;
                lblYear.Text = string.Empty;
                lblPlatform.Text = string.Empty;
            }
        }

        private void SetupComponent()
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            this.Cursor = Cursors.Hand;

            screenshot.RenderSelection = false;

            this.MouseEnter += items_mouseenter;
            lblGameName.MouseEnter += items_mouseenter;
            lblYear.MouseEnter += items_mouseenter;
            lblPlatform.MouseEnter += items_mouseenter;

            this.MouseLeave += items_mouseleave;
            lblGameName.MouseLeave += items_mouseleave;
            lblYear.MouseLeave += items_mouseleave;
            lblPlatform.MouseLeave += items_mouseleave;

            this.Click += items_click;
            lblGameName.Click += items_click;
            lblYear.Click += items_click;
            lblPlatform.Click += items_click;
            screenshot.Click += items_click;

            this.DoubleClick += items_doubleclick;
            lblGameName.DoubleClick += items_doubleclick;
            lblYear.DoubleClick += items_doubleclick;
            lblPlatform.DoubleClick += items_doubleclick;
            screenshot.DoubleClick += items_doubleclick;

        }

        private void items_doubleclick(object sender, EventArgs e)
        {
            if (FoundedGameCardDoubleClick!=null)
                FoundedGameCardDoubleClick(this);
        }

        private void items_click(object sender, EventArgs e)
        {
            if (FoundedGameCardClick != null)
                FoundedGameCardClick(this);
        }

        private void items_mouseleave(object sender, EventArgs e)
        {
            screenshot.IsHover = false;
            _isHover = false;
            this.Invalidate();

        }

        private void items_mouseenter(object sender, EventArgs e)
        {
            screenshot.IsHover = true;
            _isHover = true;
            this.Invalidate();

        }
        #endregion

        #region "Component Override"
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!_isHover && !_isSelected)
                e.Graphics.DrawLine(Pens.Gray, 0, this.Height - 1, this.Width, this.Height - 1);
            else if (_isHover)
                e.Graphics.DrawLine(Pens.Orange, 0, this.Height - 1, this.Width, this.Height - 1);
            else
                e.Graphics.DrawLine(new Pen(Color.Cyan, 2), 0, this.Height - 1, this.Width, this.Height - 1);
        }
        #endregion
        #endregion
    }
}
