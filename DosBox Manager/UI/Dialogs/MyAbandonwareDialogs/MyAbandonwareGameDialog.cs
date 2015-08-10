using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Images;
using Helpers.Business;
using Helpers.Data.Objects.MyAbandonwareData;
using Helpers.Web;

namespace DosBox_Manager.UI.Dialogs.MyAbandonwareDialogs
{
    public partial class MyAbandonwareGameDialog : Form
    {

        #region "Declarations"
        private MyAbandonGameInfo _game = null;
        private MyAbandonware _helper = null;
        private Image _gameScreenshot = null;
        private AppManager _manager = null;
        #endregion

        #region "Constructor"
        public MyAbandonwareGameDialog(AppManager Manager, MyAbandonGameInfo game, MyAbandonware helper)
        {
            InitializeComponent();

            _manager = Manager;
            _game = game;
            _helper = helper;

            _manager.Translator.TranslateUI(_manager.AppSettings.Language, this.Name, this.Controls);

            CompileUI();
        }
        #endregion

        #region "Methods"
        private void CompileUI()
        {
            txtGameName.Text = _game.Title;
            txtYear.Text = _game.Year;
            txtReleasedIn.Text = _game.ReleasedIn;
            txtDescription.Text = _game.Description;
            txtDeveloper.Text = _game.Developer;
            txtDosBox.Text = _game.DosBoxVersion;
            txtDownloadSize.Text = _game.DownloadSize;
            txtGenre.Text = _game.Genre;
            txtPerspectives.Text = (_game.Perspectives != null) ? String.Join(", ", _game.Perspectives.ToArray()) : string.Empty;
            txtPublisher.Text = _game.Publisher;
            txtPlatform.Text = _game.Platform;
            txtThemes.Text = (_game.Themes != null) ? String.Join(", ", _game.Themes.ToArray()) : string.Empty;
            txtVote.Text = _game.Vote;

            SetupDownloadButton();

            screenshotsList.ImageURIs = _game.Screenshots;

        }

        private void SetupDownloadButton()
        {
            gameDownloader.DownloadURI = _game.DownloadLink;
            gameDownloader.DestinationFile = string.Format("{0}.zip", _game.Title);
            gameDownloader.Helper = _helper;

            gameDownloader.ButtonText = string.Format(_manager.Translator.GetTranslatedMessage(_manager.AppSettings.Language, 76, "Download Game {0}"), (_game.DownloadSize != string.Empty) ? string.Format("[{0}]", _game.DownloadSize) : string.Empty);
            gameDownloader.CompletedText = _manager.Translator.GetTranslatedMessage(_manager.AppSettings.Language, 77, "Download Completed!!!");
            gameDownloader.FolderSelectionText = _manager.Translator.GetTranslatedMessage(_manager.AppSettings.Language, 78, "Choose a folder where to download the game.");
        }
        #endregion

        #region "Controls Events Handling"
        private void screenshotsList_ScreenshotSelected(object sender, Image screenshot)
        {
            _gameScreenshot = screenshot;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.LightGray, 0, pctIcon.Top + pctIcon.Height + 1, pnlMain.Width, pctIcon.Top + pctIcon.Height + 1);
            e.Graphics.DrawLine(Pens.LightGray, 0, pnlMain.Height - 1, pnlMain.Width, pnlMain.Height - 1);
        }
        #endregion

    }
}
