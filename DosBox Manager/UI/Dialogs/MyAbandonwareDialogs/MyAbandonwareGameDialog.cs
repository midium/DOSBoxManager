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
using Helpers.Data.Objects.MyAbandonwareData;
using Helpers.Web;

namespace DosBox_Manager.UI.Dialogs.MyAbandonwareDialogs
{
    public partial class MyAbandonwareGameDialog : Form
    {

        #region "Declarations"
        MyAbandonGameInfo _game = null;
        MyAbandonware _helper = null;
        #endregion

        #region "Constructor"
        public MyAbandonwareGameDialog(MyAbandonGameInfo game, MyAbandonware helper)
        {
            InitializeComponent();

            _game = game;
            _helper = helper;

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
            txtThemes.Text = (_game.Themes != null) ? String.Join(", ", _game.Themes.ToArray()) : string.Empty;
            txtVote.Text = _game.Vote;

            if (_game.Screenshots != null)
            {
                int i = 0;
                foreach (string uri in _game.Screenshots)
                {
                    Stream screen = _helper.DownloadMediaStream(uri);
                    PictureBox pct = new PictureBox();
                    pct.Image = Image.FromStream(screen);
                    pct.Width = pnlScreenshots.Width;
                    pct.Height = 150;
                    pct.Top = i*150;
                    pct.SizeMode = PictureBoxSizeMode.StretchImage;

                    pnlScreenshots.Controls.Add(pct);

                    i++;
                }
            }
            
        }
        #endregion

        #region "Controls Events Handling"
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.LightGray, 0, pctIcon.Top + pctIcon.Height + 1, pnlMain.Width, pctIcon.Top + pctIcon.Height + 1);
            e.Graphics.DrawLine(Pens.LightGray, 0, pnlMain.Height - 1, pnlMain.Width, pnlMain.Height - 1);
        }
        #endregion
    }
}
