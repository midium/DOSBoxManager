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
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomMessageBoxes.MessageBoxes;
using Helpers.Business;
using Helpers.Data.Objects.MyAbandonwareData;
using Helpers.Web;

namespace DosBox_Manager.UI.Dialogs.MyAbandonwareDialogs
{
    public partial class MyAbandonwareSearchDialog : Form
    {
        #region "Declarations"
        private MyAbandonware _scraper = null;
        private MyAbandonGameFound _selectedGame = null;
        private AppManager _manager;
        private MyAbandonGameInfo _game = null;
        private bool _allowGameDownload = false;
        private string _gameScreenshot = null;
        #endregion

        #region "Properties"
        public MyAbandonGameInfo GameData
        {
            get { return _game; }
        }

        public string GameScreenshot
        {
            get { return _gameScreenshot; }
        }
        #endregion

        #region "Constructors"
        public MyAbandonwareSearchDialog(AppManager Manager)
        {
            InitializeComponent();
            _allowGameDownload = true;
            btnSave.Visible = false;
            _manager = Manager;
            _manager.Translator.TranslateUI(_manager.AppSettings.Language, this.Name, this.Controls);

            _scraper = new MyAbandonware(Manager);
        }

        public MyAbandonwareSearchDialog(AppManager Manager, string SearchFor)
        {
            InitializeComponent();

            _allowGameDownload = false;

            btnSave.Visible = true;

            _manager = Manager;
            _manager.Translator.TranslateUI(_manager.AppSettings.Language, this.Name, this.Controls);

            _scraper = new MyAbandonware(Manager);

            txtGameName.Text = SearchFor;
        }
        #endregion

        #region "Private Methods"
        private void SearchGame()
        {
            if (txtGameName.Text.Trim() != string.Empty)
            {
                this.Cursor = Cursors.WaitCursor;

                List<MyAbandonGameFound> result = _scraper.SearchGames(txtGameName.Text.Trim().Replace("&",""));

                foundedGamesList.Clear();
                if (result != null)
                {
                    foundedGamesList.Games = result;
                }

                this.Cursor = Cursors.Default;
            }
        }

        private void LoadGameData(bool noDownload)
        {
            _game = _scraper.RetrieveGameData(_selectedGame.Uri);

            if (_game != null)
            {
                MyAbandonwareGameDialog gameData = new MyAbandonwareGameDialog(_manager, _game, _scraper, noDownload);
                gameData.ShowDialog();
                if (gameData.Screenshot != null)
                {
                    _gameScreenshot = Application.StartupPath + "\\tmp.img";
                    Bitmap bmp = new Bitmap(gameData.Screenshot);
                    bmp.Save(_gameScreenshot);
                    bmp.Dispose();
                }
                else
                    _gameScreenshot = string.Empty;
                gameData.Dispose();
            }
        }
        #endregion

        #region "Controls Events"
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.LightGray, 0, pctIcon.Top + pctIcon.Height + 1, pnlMain.Width, pctIcon.Top + pctIcon.Height + 1);
            e.Graphics.DrawLine(Pens.Gray, 0, txtGameName.Top + txtGameName.Height + 20, pnlMain.Width, txtGameName.Top + txtGameName.Height + 20);
            e.Graphics.DrawLine(Pens.LightGray, 0, pnlMain.Height - 1, pnlMain.Width, pnlMain.Height - 1);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SearchGame();
        }

        private void btnGameData_Click(object sender, EventArgs e)
        {
            LoadGameData(_allowGameDownload);
        }
        
        private void txtGameName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnFind_Click(null, null);
        }

        private void foundedGamesList_GameSelected(object sender, MyAbandonGameFound game)
        {
            _selectedGame = game;
        }

        private void foundedGamesList_GameDoubleClick(object sender, MyAbandonGameFound game)
        {
            _selectedGame = game;
            LoadGameData(_allowGameDownload);
        }

        private void MyAbandonwareSearchDialog_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            SearchGame();
        }

        private void btnGetGameData_Click(object sender, EventArgs e)
        {
            if(_selectedGame != null){
                if (_game == null || _game.GameURI != _selectedGame.Uri)
                {
                    _game = _scraper.RetrieveGameData(_selectedGame.Uri);

                    if (_game == null)
                        return;

                    //Retrieving first available screenshot
                    if (_game.Screenshots != null && _game.Screenshots.Count > 0)
                    {
                        _scraper.DownloadFileCompleted += _scraper_DownloadFileCompleted;
                        _scraper.DownloadMedia(_game.Screenshots[0], Application.StartupPath + "\\tmp.img");
                    }

                }
                else if( _game != null )
                {
                    CustomMessageBox cmb = new CustomMessageBox(_manager.Translator.GetTranslatedMessage(_manager.AppSettings.Language, 77, "Download Completed!!!"),
                                                                _manager.Translator.GetTranslatedMessage(_manager.AppSettings.Language, 59, "Information"),
                                                                MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Information, false, false);
                    cmb.ShowDialog();
                    cmb.Dispose();

                }

            }
        }

        void _scraper_DownloadFileCompleted(object sender, string DestinationFile)
        {
            try
            {
                if (File.Exists(Application.StartupPath + "\\tmp.img"))
                {
                    _gameScreenshot = Application.StartupPath + "\\tmp.img";

                    CustomMessageBox cmb = new CustomMessageBox(_manager.Translator.GetTranslatedMessage(_manager.AppSettings.Language, 77, "Download Completed!!!"),
                                                                _manager.Translator.GetTranslatedMessage(_manager.AppSettings.Language, 59, "Information"),
                                                                MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Information, false, false);
                    cmb.ShowDialog();
                    cmb.Dispose();

                }
                else
                    _gameScreenshot = string.Empty ;
            }
            catch (Exception)
            {
                _gameScreenshot = string.Empty;
            }
        }
        #endregion

    }
}
