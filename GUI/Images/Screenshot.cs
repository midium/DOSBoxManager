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
using System.Drawing.Drawing2D;
using System.Threading;
using Helpers.Threading.Workers;

namespace GUI.Images
{
    public partial class Screenshot : Control
    {
        #region "Declarations"
        private string _imageUri;
        private Image _screenshot;
        private ImageDownloader downloader = null;
        private ProgressBar _progress = null;
        private Thread _thread = null;

        private bool _isSelected = false;
        private bool _isHover = false;
        private bool _renderSelection = true;

        #region "Events"
        #endregion
        #endregion

        #region "Constructors"
        public Screenshot()
        {
            InitializeComponent();

            SetupComponent();
        }

        public Screenshot(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            SetupComponent();
        }

        ~Screenshot()
        {
            if(downloader != null)
                RemoveDownloadHandlers(downloader);
        }
        #endregion

        #region "Properties"
        public bool RenderSelection
        {
            get { return _renderSelection; }
            set
            {
                _renderSelection = value;
                RenderScreenshot();
            }
        }

        public bool IsHover
        {
            get { return _isHover; }
            set
            {
                _isHover = value;
                RenderScreenshot();
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set 
            { 
                _isSelected = value;
                RenderScreenshot();
            }
        }

        public string ImageURI
        {
            get { return _imageUri; }
            set 
            {
                if (_imageUri != value)
                {
                    _imageUri = value;
                    _screenshot = null;

                    LoadScreenshot(value);
                }
            }
        }

        public Image ScreenshotImage
        {
            get { return _screenshot; }
            set 
            {
                if (_screenshot != value)
                {
                    _screenshot = value;
                    _imageUri = string.Empty;

                    LoadScreenshot(value);
                }
            }
        }
        #endregion

        #region "Methods"
        #region "Private"
        /// <summary>
        /// This routine setup the component in order to be the more responsive possible.
        /// </summary>
        private void SetupComponent()
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// This routine will cause the component to redraw itself.
        /// </summary>
        private void RenderScreenshot()
        {
            //Invalidating the component in order to raise the OnPaint event.
            this.Invalidate();
        }

        /// <summary>
        /// This routine actually render the screenshot inside the component. 
        /// In case it is not set the offline image is shown.
        /// </summary>
        /// <param name="gr">Graphics object where to draw the image</param>
        private void DrawScreenshot(Graphics gr)
        {

            SetupGraphics(gr);

            if (_screenshot != null)
            {
                gr.DrawImage(_screenshot, this.DisplayRectangle);
            }
            else
            {
                gr.DrawImage(GUI.Properties.Resources.offline, this.DisplayRectangle);
            }

            if (!(_isSelected || _isHover || (_progress != null && _progress.Visible)))
                DrawFog(gr, this.DisplayRectangle);
            else if(_isSelected && _renderSelection)
                DrawBorder(gr, this.DisplayRectangle);
        }

        private void DrawBorder(Graphics gr, Rectangle rectangle)
        {
            gr.DrawRectangle(new Pen(Color.Orange, 3), new Rectangle(0, 0, rectangle.Width - 1, rectangle.Height - 1));
        }

        private void DrawFog(Graphics gr, Rectangle rectangle)
        {
            gr.FillRectangle(new SolidBrush(Color.FromArgb(50, 255, 255, 255)), rectangle);
        }

        /// <summary>
        /// This routine setup the Graphics object with all needed properties
        /// </summary>
        /// <param name="gr">Graphics object to setup</param>
        private void SetupGraphics(Graphics gr)
        {
            gr.CompositingQuality = CompositingQuality.HighQuality;
        }
        #endregion

        #region "Public"
        /// <summary>
        /// This routine load the image from a web uri. 
        /// To achieve this it will start a thread in order to not block the application to continue working.
        /// </summary>
        /// <param name="ImageUri">The URI of the resource</param>
        public void LoadScreenshot(string ImageUri)
        {
            //_screenshot = null;
            _imageUri = ImageUri;
            
            //Here I create/start the thread to download the image
            downloader = new ImageDownloader(_imageUri);
            
            AddDownloadHandlers(downloader);

            _progress = new ProgressBar();
            _progress.Height = 10;
            _progress.Width = this.Width - 50;
            _progress.Top = (this.Height / 2) - 5;
            _progress.Left = (this.Width / 2) - (_progress.Width / 2);
            _progress.Style = ProgressBarStyle.Continuous;
            _progress.Minimum = 0;
            _progress.Maximum = 100;

            _progress.Visible = true;

            this.Controls.Add(_progress);

            _thread = new Thread(downloader.DoWork);
            _thread.Start();

        }

        private void RemoveDownloadHandlers(ImageDownloader downloader)
        {
            downloader.DownloadDataCompleted -= downloader_DownloadDataCompleted;
            downloader.DownloadProgressChanged -= downloader_DownloadProgressChanged;
        }

        private void AddDownloadHandlers(ImageDownloader downloader)
        {
            downloader.DownloadDataCompleted += downloader_DownloadDataCompleted;
            downloader.DownloadProgressChanged += downloader_DownloadProgressChanged;
        }

        void downloader_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                //Cross-thread error prevention
                Invoke(new EventHandler<System.Net.DownloadProgressChangedEventArgs>(downloader_DownloadProgressChanged), sender, e);

            }
            else
            {
                if (_progress != null)
                {
                    try
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            _progress.Value = e.ProgressPercentage;
                        });
                    }
                    catch (Exception)
                    {

                    }

                }

            }

        }

        void downloader_DownloadDataCompleted(object sender, System.IO.Stream ImageStream)
        {

            if (InvokeRequired)
            {
                //Cross-thread error prevention
                Invoke(new EventHandler<System.IO.Stream>(downloader_DownloadDataCompleted), sender, ImageStream);
                                
            }
            else
            {
                if (_progress != null)
                {
                    _progress.Visible = false;
                    _progress.Dispose();
                    this.Controls.Clear();

                    if (ImageStream == null)
                        _screenshot = null;
                    else
                        _screenshot = Image.FromStream(ImageStream);

                    RenderScreenshot();
                }

                downloader.Dispose();
                _thread = null;

            }

        }

        /// <summary>
        /// This routine will directly render the given image inside the component.
        /// </summary>
        /// <param name="Screenshot">The Image object to be rendered</param>
        public void LoadScreenshot(Image Screenshot)
        {
            _imageUri = string.Empty;
            _screenshot = Screenshot;

            RenderScreenshot();
        }

        /// <summary>
        /// This routine will refresh the image inside the component.
        /// </summary>
        public void RefreshControl()
        {
            RenderScreenshot();
        }
        #endregion

        #region "Override"
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawScreenshot(e.Graphics);

        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);

            _isHover = true;
            RenderScreenshot();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            _isHover = false;
            RenderScreenshot();
        }
        #endregion
        #endregion
    }
}
