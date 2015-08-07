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
            string path = _dialogsHelpers.OpenFolder("Choose a folder where to download the game.", string.Empty, true, string.Empty);
            
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
