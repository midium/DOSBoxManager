using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DosBox_Manager.UI.Dialogs.GamePanels.Base;
using Helpers.Translation;
using Helpers.Data.Objects;
using Helpers.Dialogs;
using Helpers.Business;
using System.IO;
using CustomMessageBoxes.MessageBoxes;
using DosBox_Manager.UI.Dialogs.MyAbandonwareDialogs;
using Helpers.Data.Objects.MyAbandonwareData;

namespace DosBox_Manager.UI.Dialogs.GamePanels
{
    public partial class GameInfoPanel : GamePanelBase
    {
        #region "Declarations"
        #endregion

        #region "Constructors"
        public GameInfoPanel():base()
        {
            InitializeComponent();
        }

        public GameInfoPanel(AppManager Manager, DialogsHelpers DialogsHelpers, Game GameData):base(Manager,DialogsHelpers,GameData)
        {
            InitializeComponent();

            InitializePanel();
        }
        #endregion

        #region "Methods"
        #region "Private"
        private void InitializePanel()
        {
            txtTitle.Text = _game.Title;
            txtDeveloper.Text = _game.Developer;
            txtYear.Text = (_game.Year.ToString() == "0") ? string.Empty : _game.Year.ToString();
            ShowCoverImage();

            List<Category> cats = _manager.DB.GetAllCategories();
            cboCategory.Items.Clear();
            int counter = 0;
            int selectedIndex = 0;
            foreach (Category cat in cats)
            {
                cboCategory.Items.Add(cat);

                if (cat.ID == _game.CategoryID)
                    selectedIndex = counter;

                counter++;
            }
            cboCategory.SelectedIndex = selectedIndex;

            txtPlatform.Text = _game.Platform;
            txtThemes.Text = _game.Themes;
            txtReleasedIn.Text = _game.ReleasedIn;
            txtPublisher.Text = _game.Publisher;
            txtPerspectives.Text = _game.Perspectives;
            txtDosBox.Text = _game.DosboxVersion;
            txtVote.Text = _game.Vote;
            txtDescription.Text = _game.Description;

        }

        private void ShowCoverImage()
        {
            if (_game.ImagePath != string.Empty && File.Exists(_game.ImagePath))
            {
                Bitmap bitmap = new Bitmap(pctCover.Width, pctCover.Height);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.DrawImage(Image.FromFile(_game.ImagePath), new Rectangle(0, 0, pctCover.Width, pctCover.Height));
                pctCover.Image = bitmap;
                graphics.Dispose();
            }
            else
            {
                pctCover.Image = null;

                if (!File.Exists(_game.ImagePath))
                    _game.ImagePath = string.Empty;
                
            }
        }

        #endregion

        #region "Controls Events Handling"
        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            string translatedMessage1 = _translator.GetTranslatedMessage(_settings.Language, 41, "Choose Game Cover Image");
            string translatedMessage2 = _translator.GetTranslatedMessage(_settings.Language, 38, "All Supported Images|*.jpg;*.png;*.bmp|JPEG Images (*.jpg)|*.jpg|PNG Images (*.png)|*.png|Bitmap Images (*.bmp)|*.bmp");
            _game.ImagePath = _dialogsHelpers.OpenFile(translatedMessage1, string.Empty, translatedMessage2, string.Empty, _game.ImagePath);
            ShowCoverImage();

        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            _game.ImagePath = string.Empty;
            ShowCoverImage();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            _game.Title = txtTitle.Text.Trim();
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            _game.Year = Convert.ToInt32(txtYear.Text.Trim());
        }

        private void txtDeveloper_TextChanged(object sender, EventArgs e)
        {
            _game.Developer = txtDeveloper.Text.Trim();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedItem != null)
                _game.CategoryID = ((Category)cboCategory.SelectedItem).ID;
        }

        private void txtPlatform_TextChanged(object sender, EventArgs e)
        {
            _game.Platform = txtPlatform.Text.Trim();
        }

        private void txtReleasedIn_TextChanged(object sender, EventArgs e)
        {
            _game.ReleasedIn = txtReleasedIn.Text.Trim();
        }

        private void txtPublisher_TextChanged(object sender, EventArgs e)
        {
            _game.Publisher = txtPublisher.Text.Trim();
        }

        private void txtThemes_TextChanged(object sender, EventArgs e)
        {
            _game.Themes = txtThemes.Text.Trim();
        }

        private void txtPerspectives_TextChanged(object sender, EventArgs e)
        {
            _game.Perspectives = txtPerspectives.Text.Trim();
        }

        private void txtDosBox_TextChanged(object sender, EventArgs e)
        {
            _game.DosboxVersion = txtDosBox.Text.Trim();
        }

        private void txtVote_TextChanged(object sender, EventArgs e)
        {
            _game.Vote = txtVote.Text.Trim();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            _game.Description = txtDescription.Text.Trim();
        }
        #endregion

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MyAbandonwareSearchDialog msd = new MyAbandonwareSearchDialog(_manager, _game.Title);
            if (msd.ShowDialog() == DialogResult.OK)
            {
                MyAbandonGameInfo gameData = msd.GameData;

                _game.Title = gameData.Title;
                _game.Description = gameData.Description;
                _game.Developer = gameData.Developer;
                _game.Perspectives = (gameData.Perspectives == null) ? string.Empty : string.Join(",", gameData.Perspectives);
                _game.Platform = gameData.Platform;
                _game.Publisher = gameData.Publisher;
                _game.ReleasedIn = gameData.ReleasedIn;
                _game.Themes = (gameData.Themes == null) ? string.Empty : string.Join(",", gameData.Themes);
                _game.Vote = gameData.Vote.ToString();
                _game.Year = Convert.ToInt32(gameData.Year);

                InitializePanel();
                
            }
            msd.Dispose();
        }

        #region "Public"
        #endregion
        #endregion
    }
}
