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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers.Dialogs;
using Helpers.Data.Objects;
using Helpers.Translation;
using System.IO;

namespace DosBox_Manager.UI.Dialogs
{
    public partial class GameDialog : Form
    {
        #region "Declarations"
        private string _GameImage;
        private DialogsHelpers _dialogsHelpers;
        private Settings _AppSettings;
        private Game _game;
        private TranslationsHelpers _translator;
        #endregion

        #region "Properties"
        public Game GameData
        {
            get { return _game; }
        }
        #endregion

        #region "Constructor"
        public GameDialog(TranslationsHelpers translator, Settings AppSettings, Game game, bool isEditing)
        {
            InitializeComponent();
            _translator = translator;
            _translator.TranslateUI(AppSettings.Language, Name, Controls);
            Text = isEditing ? _translator.GetTranslatedMessage(AppSettings.Language, 39, "Edit Game") : _translator.GetTranslatedMessage(AppSettings.Language, 40, "Add Game");
            _GameImage = game.ImagePath;
            _dialogsHelpers = new DialogsHelpers();
            _AppSettings = AppSettings;
            _game = game;
            if (!isEditing)
                return;
            CompileUI();
        }     
        #endregion

        #region "Private Methods"
        private void CompileUI()
        {
            txtTitle.Text = _game.Title;
            txtYear.Text = _game.Year.ToString();
            txtDeveloper.Text = _game.Developer;
            _GameImage = _game.ImagePath;
            ShowCoverImage();
            txtGameExe.Text = _game.DOSExePath;
            txtGameConfigurationFile.Text = _game.DBConfigPath;
            txtMountDirectory.Text = _game.Directory;
            txtGameSetupExe.Text = _game.SetupExePath;
            chkNoConfig.Checked = _game.NoConfig;
            txtCDImage.Text = _game.CDPath;
            rdbUseIOCTL.Checked = _game.UseIOCTL;
            rdbMountFloppy.Checked = _game.MountAsFloppy;
            txtAdditionalCommands.Text = _game.AdditionalCommands;
            chkFullscreen.Checked = _game.InFullScreen;
            chkNoConsole.Checked = _game.NoConsole;
            chkQuitOnExit.Checked = _game.QuitOnExit;
        }

        private void ShowCoverImage()
        {
            Bitmap bitmap = new Bitmap(pctCover.Width, pctCover.Height);
            Graphics graphics = Graphics.FromImage((Image)bitmap);
            graphics.DrawImage(Image.FromFile(_GameImage), new Rectangle(0, 0, pctCover.Width, pctCover.Height));
            pctCover.Image = (Image)bitmap;
            graphics.Dispose();
        }

        private string SearchInitialDirectory()
        {
            string str = string.Empty;
            if (txtGameExe.Text != string.Empty && Directory.Exists(Directory.GetParent(txtGameExe.Text).FullName))
                str = Directory.GetParent(txtGameExe.Text).FullName;
            else if (txtMountDirectory.Text != string.Empty && Directory.Exists(txtMountDirectory.Text))
                str = txtMountDirectory.Text;
            else if (txtGameSetupExe.Text != string.Empty && Directory.Exists(Directory.GetParent(txtGameSetupExe.Text).FullName))
                str = Directory.GetParent(txtGameSetupExe.Text).FullName;
            else if (_GameImage != string.Empty && File.Exists(_GameImage))
                str = Directory.GetParent(_GameImage).FullName;
            else if (txtGameConfigurationFile.Text != string.Empty && Directory.Exists(Directory.GetParent(txtGameConfigurationFile.Text).FullName))
                str = Directory.GetParent(txtGameConfigurationFile.Text).FullName;
            else if (_AppSettings.GamesDefaultDir != string.Empty && Directory.Exists(_AppSettings.GamesDefaultDir))
                str = _AppSettings.GamesDefaultDir;
            return str;
        }
        #endregion

        #region "Controls Events"
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.LightGray, 0, pnlMain.Height - 1, pnlMain.Width, pnlMain.Height - 1);
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            string translatedMessage1 = _translator.GetTranslatedMessage(_AppSettings.Language, 41, "Choose Game Cover Image");
            string translatedMessage2 = _translator.GetTranslatedMessage(_AppSettings.Language, 38, "All Supported Images|*.jpg;*.png;*.bmp|JPEG Images (*.jpg)|*.jpg|PNG Images (*.png)|*.png|Bitmap Images (*.bmp)|*.bmp");
            _GameImage = _dialogsHelpers.OpenFile(translatedMessage1, string.Empty, translatedMessage2, string.Empty, _GameImage);
            if (_GameImage != string.Empty)
                ShowCoverImage();
            else
                pctCover.Image = null;
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            _GameImage = string.Empty;
            pctCover.Image = null;
        }


        private void btnOpenGameEXE_Click(object sender, EventArgs e)
        {
            string translatedMessage1 = _translator.GetTranslatedMessage(_AppSettings.Language, 43, "Choose Game Executable");
            string translatedMessage2 = _translator.GetTranslatedMessage(_AppSettings.Language, 44, "All Executables|*.exe;*.com;*.bat");
            txtGameExe.Text = _dialogsHelpers.OpenFile(translatedMessage1, string.Empty, translatedMessage2, string.Empty, txtGameExe.Text);
        }

        private void btnChooseMountDirectory_Click(object sender, EventArgs e)
        {
            txtMountDirectory.Text = _dialogsHelpers.OpenFolder(_translator.GetTranslatedMessage(_AppSettings.Language, 45, "Select game directory to be mounted as C:"), string.Empty, true, txtMountDirectory.Text);
        }

        private void btnGameSetupEXE_Click(object sender, EventArgs e)
        {
            string translatedMessage1 = _translator.GetTranslatedMessage(_AppSettings.Language, 46, "Choose Game Setup Executable");
            string translatedMessage2 = _translator.GetTranslatedMessage(_AppSettings.Language, 44, "All Executables|*.exe;*.com;*.bat");
            txtGameSetupExe.Text = _dialogsHelpers.OpenFile(translatedMessage1, string.Empty, translatedMessage2, string.Empty, txtGameSetupExe.Text);
        }

        private void btnCustomConfig_Click(object sender, EventArgs e)
        {
            string InitialDirectory = !_AppSettings.PortableMode ? (!(txtGameConfigurationFile.Text != string.Empty) || !Directory.Exists(Directory.GetParent(txtGameConfigurationFile.Text).FullName) ? SearchInitialDirectory() : Directory.GetParent(txtGameConfigurationFile.Text).FullName) : Application.StartupPath;
            string translatedMessage1 = _translator.GetTranslatedMessage(_AppSettings.Language, 47, "Select Custom Game Configuration File");
            string translatedMessage2 = _translator.GetTranslatedMessage(_AppSettings.Language, 42, "DOSBox configuration file (*.conf)|*.conf;*.CONF");
            txtGameConfigurationFile.Text = _dialogsHelpers.OpenFile(translatedMessage1, string.Empty, translatedMessage2, InitialDirectory, txtGameConfigurationFile.Text);
        }

        private void btnCDImage_Click(object sender, EventArgs e)
        {
            string InitialDirectory = !_AppSettings.PortableMode ? (!(_AppSettings.CDsDefaultDir != string.Empty) || !Directory.Exists(_AppSettings.CDsDefaultDir) ? SearchInitialDirectory() : _AppSettings.CDsDefaultDir) : Application.StartupPath;
            string translatedMessage1 = _translator.GetTranslatedMessage(_AppSettings.Language, 48, "Choose CD Image to be mounted as D:");
            string translatedMessage2 = _translator.GetTranslatedMessage(_AppSettings.Language, 49, "DOSBox compatible CD images (*.bin;*.cue;*.iso;*.img)|*.bin;*.cue;*.iso;*.img;*.BIN;*.CUE;*.ISO;*.IMG");
            txtCDImage.Text = _dialogsHelpers.OpenFile(translatedMessage1, string.Empty, translatedMessage2, InitialDirectory, txtCDImage.Text);
        }

        private void btnCDFolder_Click(object sender, EventArgs e)
        {
            txtCDImage.Text = _dialogsHelpers.OpenFolder(_translator.GetTranslatedMessage(_AppSettings.Language, 50, "Choose Folder to be mounted as D:"), string.Empty, false, txtCDImage.Text);
        }

        private void txtGameExe_TextChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (txtGameExe.Text == string.Empty)
                flag = true;
            else if (File.Exists(txtGameExe.Text))
                txtMountDirectory.Text = Directory.GetParent(txtGameExe.Text).FullName;
            txtMountDirectory.Enabled = flag;
            btnChooseMountDirectory.Enabled = flag;
            lblMountDirectory.Enabled = flag;
        }

        private void txtMountDirectory_TextChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (txtMountDirectory.Text != string.Empty)
            {
                if (txtGameExe.Text != string.Empty)
                {
                    if (Directory.GetParent(txtGameExe.Text).FullName != txtMountDirectory.Text)
                        txtGameExe.Text = string.Empty;
                    else
                        flag = true;
                }
                else
                    txtGameExe.Text = string.Empty;
            }
            else
                flag = true;
            txtGameExe.Enabled = flag;
            btnOpenGameEXE.Enabled = flag;
            lblGameExe.Enabled = flag;
        }

        private void txtCDImage_TextChanged(object sender, EventArgs e)
        {
            if (txtCDImage.Text == string.Empty)
            {
                pnlMountingOptions.Enabled = false;
            }
            else
            {
                pnlMountingOptions.Enabled = true;
                if (!File.Exists(txtCDImage.Text))
                {
                    rdbUseIOCTL.Enabled = true;
                    rdbMountFloppy.Enabled = false;
                }
                else
                {
                    rdbUseIOCTL.Enabled = false;
                    rdbMountFloppy.Enabled = true;
                }
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            _game.Title = txtTitle.Text.Trim();
            _game.Year = txtYear.Text.Trim() == string.Empty ? 0 : Convert.ToInt32(txtYear.Text.Trim());
            _game.Developer = txtDeveloper.Text.Trim();
            _game.ImagePath = _GameImage;
            _game.DOSExePath = txtGameExe.Text.Trim();
            _game.Directory = txtMountDirectory.Text.Trim();
            _game.SetupExePath = txtGameSetupExe.Text.Trim();
            _game.DBConfigPath = txtGameConfigurationFile.Text.Trim();
            _game.NoConfig = chkNoConfig.Checked;
            _game.CDPath = txtCDImage.Text.Trim();
            _game.UseIOCTL = rdbUseIOCTL.Checked;
            _game.MountAsFloppy = rdbMountFloppy.Checked;
            _game.AdditionalCommands = txtAdditionalCommands.Text.Trim();
            _game.NoConsole = chkNoConsole.Checked;
            _game.InFullScreen = chkFullscreen.Checked;
            _game.QuitOnExit = chkQuitOnExit.Checked;
            if (File.Exists(_game.CDPath))
                _game.IsCDImage = true;
            else
                _game.IsCDImage = false;
        }
        #endregion
    }
}
