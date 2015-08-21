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
using Helpers.Web;
using Helpers.Dialogs;

namespace GUI.Buttons
{
    public partial class GameDownloader : UserControl
    {
        #region "Declarations"
        private string _downloadURI;
        private string _destinationFile;
        private string _buttonText = "Download Game";
        private string _completedText = "Download Completed!!!";
        private string _folderSelectionText = "Choose a folder where to download the game.";

        private MyAbandonware _helper = null;
        private DialogsHelpers _dialogsHelpers = null;


        #region "Events"
        #endregion
        #endregion

        #region "Properties"
        public string CompletedText
        {
            get { return _completedText; }
            set
            {
                _completedText = value;
                lblStatus.Text = _completedText;
            }
        }

        public string FolderSelectionText
        {
            get { return _folderSelectionText; }
            set
            {
                _folderSelectionText = value;
            }
        }

        public string DownloadURI
        {
            get { return _downloadURI; }
            set
            {
                _downloadURI = value;
                EnableDownload();
            }
        }

        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                SetupDownloadButton();
            }
        }

        public string DestinationFile
        {
            get { return _destinationFile; }
            set
            {
                _destinationFile = value;
                EnableDownload();
            }
        }

        public MyAbandonware Helper
        {
            get { return _helper; }
            set
            {
                if (value == null)
                    RemoveDownloadHandlers();

                _helper = value;
                AddDownloadHandlers();
                EnableDownload();
            }
        }
        #endregion

        #region "Constructor"
        public GameDownloader()
        {
            InitializeComponent();
            _helper = null;
            _dialogsHelpers = new DialogsHelpers();
            SetupDownloadButton();
        }

        public GameDownloader(MyAbandonware Helper, string DownloadURI, string DestinationFile)
        {
            _helper = Helper;
            _downloadURI = DownloadURI;
            _destinationFile = DestinationFile;
            _dialogsHelpers = new DialogsHelpers();

            EnableDownload();
            AddDownloadHandlers();
        }

        ~GameDownloader()
        {
            RemoveDownloadHandlers();
            _dialogsHelpers = null;
        }
        #endregion

        #region "Methods"
        #region "Public"
        #endregion

        #region "Private"
        private void SetupDownloadButton()
        {
            EnableDownload();
            btnDownloadGame.Text = _buttonText;
        }

        private void EnableDownload()
        {
            if (_helper != null && _downloadURI != string.Empty && _destinationFile != string.Empty)
                btnDownloadGame.Enabled = true;
            else
                btnDownloadGame.Enabled = false;
        }

        private void AddDownloadHandlers()
        {
            if (_helper != null)
            {
                _helper.DownloadFileCompleted += _helper_DownloadFileCompleted;
                _helper.DownloadProgressChanged += _helper_DownloadProgressChanged;
            }
        }

        private void RemoveDownloadHandlers()
        {
            if (_helper != null)
            {
                _helper.DownloadFileCompleted -= _helper_DownloadFileCompleted;
                _helper.DownloadProgressChanged -= _helper_DownloadProgressChanged;
            }
        }
        #endregion
        #endregion

        #region "Controls Events Handling"
        private void btnDownloadGame_Click(object sender, EventArgs e)
        {
            string path = _dialogsHelpers.OpenFolder(_folderSelectionText, string.Empty, true, string.Empty);

            if (path == string.Empty)
                return;
            
            lblStatus.Visible = false;
            pgbDownload.Visible = true;
            pgbDownload.Value = 0;

            _helper.DownloadMedia(_downloadURI , string.Format("{0}\\{1}",path, _destinationFile));

        }
        #endregion

        #region "Download events handling"
        void _helper_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                //Cross-thread error prevention
                if(!this.IsDisposed)
                    Invoke(new EventHandler<System.Net.DownloadProgressChangedEventArgs>(_helper_DownloadProgressChanged), sender, e);

            }
            else
            {
                if (pgbDownload != null)
                {
                    try
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            pgbDownload.Value = e.ProgressPercentage;
                        });
                    }
                    catch (Exception)
                    {

                    }
                }

            }
        }

        void _helper_DownloadFileCompleted(object sender, string DestinationFile)
        {
            if (InvokeRequired)
            {
                //Cross-thread error prevention
                if (!this.IsDisposed)
                    Invoke(new EventHandler<string>(_helper_DownloadFileCompleted), sender, DestinationFile);

            }
            else
            {
                if (pgbDownload != null)
                    pgbDownload.Visible = false;

                if (lblStatus != null)
                    lblStatus.Visible = true;

            }
        }
        #endregion
    }
}
