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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Scrollbar;

namespace GUI.Images
{
    public partial class ScreenshotsList : Panel
    {
        #region "Declarations"
        private List<string> _imageURIs = null;
        private List<Screenshot> _screenshots = null;

        private int _countItems = 0;
        private int _currentlySelected = 0;

        private ScrollBarEx scroller;

        #region "Events"
        public delegate void ScreenshotSelectedDelegate(object sender, Image screenshot);
        public event ScreenshotSelectedDelegate ScreenshotSelected;
        #endregion
        #endregion
        
        #region "Constructors"
        public ScreenshotsList()
        {
            InitializeComponent();

            SetupComponent();
        }

        public ScreenshotsList(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            SetupComponent();
        }

        public ScreenshotsList(List<string> ImageURIs)
        {
            InitializeComponent();

            SetupComponent();

            _imageURIs = ImageURIs;

            InitializeControls();
        }
        #endregion

        #region "Methods"
        #region "Public"
        public void AddScreenshot(string ImageURI)
        {
            AppendScreenshotControl(ImageURI);
        }

        public void AddScreenshot(Screenshot screenshot)
        {
            _screenshots.Add(screenshot);
            AppendScreenshotControl(screenshot);
        }
        #endregion

        #region "Private"
        private void SetupComponent()
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }

        private void InitializeControls()
        {
            if (_imageURIs != null)
            {
                this.Controls.Clear();
                if(_screenshots == null)
                    _screenshots = new List<Screenshot>();
                _screenshots.Clear();

                _countItems = 0;
                foreach (string uri in _imageURIs)
                {
                    Screenshot screenshot = new Screenshot();
                    SetupScreenshot(screenshot);
                    screenshot.LoadScreenshot(uri);
                    screenshot.IsSelected = (_countItems == 0);
                    screenshot.Tag = _countItems;

                    this.Controls.Add(screenshot);
                    _screenshots.Add(screenshot);

                    _countItems++;
                }

                //As defaulting to select the first element I also raise selection event after first init
                _currentlySelected = 0;
                if (ScreenshotSelected != null)
                    ScreenshotSelected(this, _screenshots[0].ScreenshotImage);

                //Now checking if it is necessary to add the scrollbar
                if ((_screenshots.Count * 150) > this.Height)
                {
                    scroller = new ScrollBarEx();
                    scroller.BringToFront();
                    scroller.Orientation = ScrollBarOrientation.Vertical;
                    scroller.BorderColor = Color.FromArgb(64, 64, 64);
                    scroller.Dock = DockStyle.Right;
                    scroller.Visible = true;
                    scroller.Maximum = (_screenshots.Count - 1) * 150;
                    scroller.Scroll += scroller_Scroll;
                    this.MouseWheel += screenshot_MouseWheel;
                    this.Controls.Add(scroller);
                }
                else if (scroller != null)
                {
                    scroller.Scroll -= scroller_Scroll;
                    scroller.Dispose();
                    scroller = null;
                }
            }
        }

        private void AppendScreenshotControl(string ImageURI)
        {
            _countItems++;

            Screenshot screenshot = new Screenshot();
            SetupScreenshot(screenshot);
            screenshot.LoadScreenshot(ImageURI);

            this.Controls.Add(screenshot);
        }

        private void AppendScreenshotControl(Screenshot screenshot)
        {
            _countItems++;

            SetupScreenshot(screenshot);

            this.Controls.Add(screenshot);
        }

        private void SetupScreenshot(Screenshot screenshot)
        {
            screenshot.Width = this.Width - 22;
            screenshot.Height = 150;
            screenshot.Top = _countItems * 150;
            screenshot.IsSelected = false;
            screenshot.MouseEnter += screenshot_MouseEnter;
            screenshot.Click += screenshot_Click;
        }

        #endregion
        #endregion

        #region "Properties"
        public List<string> ImageURIs
        {
            get { return _imageURIs; }
            set
            {
                if (_imageURIs != value)
                {
                    _imageURIs = value;
                    InitializeControls();
                }
            }
        }
        #endregion

        #region "Events Handling"
        private void screenshot_MouseWheel(object sender, MouseEventArgs e)
        {
            if (scroller == null)
                return;
            if (scroller.Value - e.Delta < scroller.Minimum)
                scroller.Value = scroller.Minimum;
            else if (scroller.Value - e.Delta > scroller.Maximum)
                scroller.Value = scroller.Maximum;
            else
                scroller.Value -= e.Delta;
        }

        private void scroller_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue == -1)
                return;

            foreach (Control c in this.Controls)
                c.Top -= (e.NewValue - e.OldValue);

        }

        private void screenshot_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }

        void screenshot_Click(object sender, EventArgs e)
        {
            Screenshot clicked = (Screenshot)sender;

            if(ScreenshotSelected != null)
                ScreenshotSelected(this, clicked.ScreenshotImage);

            if (Convert.ToInt32(clicked.Tag) != _currentlySelected)
            {
                _screenshots[_currentlySelected].IsSelected = false;
                clicked.IsSelected = true;
                _currentlySelected = Convert.ToInt32(clicked.Tag);
            }
                
        }

        #endregion

    }
}
