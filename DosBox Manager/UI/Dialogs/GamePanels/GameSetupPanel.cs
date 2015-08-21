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
using DosBox_Manager.UI.Dialogs.GamePanels.Base;
using Helpers.Translation;
using Helpers.Data.Objects;
using Helpers.Dialogs;
using System.IO;
using Helpers.Business;

namespace DosBox_Manager.UI.Dialogs.GamePanels
{
    public partial class GameSetupPanel : GamePanelBase
    {
        #region "Declarations"
        #endregion

        #region "Constructors"
        public GameSetupPanel():base()
        {
            InitializeComponent();
        }

        public GameSetupPanel(AppManager Manager, DialogsHelpers DialogsHelpers, Game GameData)
            : base(Manager, DialogsHelpers, GameData)
        {
            InitializeComponent();

            InitializePanel();
        }
        #endregion

        #region "Methods"
        #region "Private"
        private void InitializePanel()
        {
            txtAdditionalCommands.Text = _game.AdditionalCommands;
            txtCDImage.Text = _game.CDPath;
            txtGameConfigurationFile.Text = _game.DBConfigPath;
            txtGameExe.Text = _game.DOSExePath;
            txtGameSetupExe.Text = _game.SetupExePath;
            txtMountDirectory.Text = _game.Directory;
            chkFullscreen.Checked = _game.InFullScreen;
            chkNoConfig.Checked = _game.NoConfig;
            chkNoConsole.Checked = _game.NoConsole;
            chkQuitOnExit.Checked = _game.QuitOnExit;
            rdbMountFloppy.Checked = _game.MountAsFloppy;
            rdbUseIOCTL.Checked = _game.UseIOCTL;

            if (!_game.MountAsFloppy && !_game.UseIOCTL)
                rdbNone.Checked = true;

            txtCDImage_TextChanged(this, null);
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
            else if (_game.ImagePath != string.Empty && File.Exists(_game.ImagePath))
                str = Directory.GetParent(_game.ImagePath).FullName;
            else if (txtGameConfigurationFile.Text != string.Empty && Directory.Exists(Directory.GetParent(txtGameConfigurationFile.Text).FullName))
                str = Directory.GetParent(txtGameConfigurationFile.Text).FullName;
            else if (_settings.GamesDefaultDir != string.Empty && Directory.Exists(_settings.GamesDefaultDir))
                str = _settings.GamesDefaultDir;
            return str;
        }
        #endregion

        #region "Controls Events Handling"
        private void btnOpenGameEXE_Click(object sender, EventArgs e)
        {
            string translatedMessage1 = _translator.GetTranslatedMessage(_settings.Language, 43, "Choose Game Executable");
            string translatedMessage2 = _translator.GetTranslatedMessage(_settings.Language, 44, "All Executables|*.exe;*.com;*.bat");
            txtGameExe.Text = _dialogsHelpers.OpenFile(translatedMessage1, string.Empty, translatedMessage2, string.Empty, txtGameExe.Text);

            _game.DOSExePath = txtGameExe.Text.Trim();

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

            _game.DOSExePath = txtGameExe.Text.Trim();
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

            _game.Directory = txtMountDirectory.Text.Trim();
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

            _game.CDPath = txtCDImage.Text.Trim();
            if (File.Exists(_game.CDPath))
                _game.IsCDImage = true;
            else
                _game.IsCDImage = false;

        }
        
        private void btnChooseMountDirectory_Click(object sender, EventArgs e)
        {
            txtMountDirectory.Text = _dialogsHelpers.OpenFolder(_translator.GetTranslatedMessage(_settings.Language, 45, "Select game directory to be mounted as C:"), string.Empty, true, txtMountDirectory.Text);

            _game.Directory = txtMountDirectory.Text.Trim();
        }

        private void btnGameSetupEXE_Click(object sender, EventArgs e)
        {
            string translatedMessage1 = _translator.GetTranslatedMessage(_settings.Language, 46, "Choose Game Setup Executable");
            string translatedMessage2 = _translator.GetTranslatedMessage(_settings.Language, 44, "All Executables|*.exe;*.com;*.bat");
            txtGameSetupExe.Text = _dialogsHelpers.OpenFile(translatedMessage1, string.Empty, translatedMessage2, string.Empty, txtGameSetupExe.Text);

            _game.SetupExePath = txtGameSetupExe.Text.Trim();
        }

        private void txtGameSetupExe_TextChanged(object sender, EventArgs e)
        {
            _game.SetupExePath = txtGameSetupExe.Text.Trim();
        }

        private void btnCustomConfig_Click(object sender, EventArgs e)
        {
            string InitialDirectory = !_settings.PortableMode ? (!(txtGameConfigurationFile.Text != string.Empty) || !Directory.Exists(Directory.GetParent(txtGameConfigurationFile.Text).FullName) ? SearchInitialDirectory() : Directory.GetParent(txtGameConfigurationFile.Text).FullName) : Application.StartupPath;
            string translatedMessage1 = _translator.GetTranslatedMessage(_settings.Language, 47, "Select Custom Game Configuration File");
            string translatedMessage2 = _translator.GetTranslatedMessage(_settings.Language, 42, "DOSBox configuration file (*.conf)|*.conf;*.CONF");
            txtGameConfigurationFile.Text = _dialogsHelpers.OpenFile(translatedMessage1, string.Empty, translatedMessage2, InitialDirectory, txtGameConfigurationFile.Text);

            _game.DBConfigPath = txtGameConfigurationFile.Text.Trim();
        }

        private void txtGameConfigurationFile_TextChanged(object sender, EventArgs e)
        {
            _game.DBConfigPath = txtGameConfigurationFile.Text.Trim();
        }
        
        private void btnCDImage_Click(object sender, EventArgs e)
        {
            string InitialDirectory = !_settings.PortableMode ? (!(_settings.CDsDefaultDir != string.Empty) || !Directory.Exists(_settings.CDsDefaultDir) ? SearchInitialDirectory() : _settings.CDsDefaultDir) : Application.StartupPath;
            string translatedMessage1 = _translator.GetTranslatedMessage(_settings.Language, 48, "Choose CD Image to be mounted as D:");
            string translatedMessage2 = _translator.GetTranslatedMessage(_settings.Language, 49, "DOSBox compatible CD images (*.bin;*.cue;*.iso;*.img)|*.bin;*.cue;*.iso;*.img;*.BIN;*.CUE;*.ISO;*.IMG");
            txtCDImage.Text = _dialogsHelpers.OpenFile(translatedMessage1, string.Empty, translatedMessage2, InitialDirectory, txtCDImage.Text);

            _game.CDPath = txtCDImage.Text.Trim();
            if (File.Exists(_game.CDPath))
                _game.IsCDImage = true;
            else
                _game.IsCDImage = false;

        }

        private void btnCDFolder_Click(object sender, EventArgs e)
        {
            txtCDImage.Text = _dialogsHelpers.OpenFolder(_translator.GetTranslatedMessage(_settings.Language, 50, "Choose Folder to be mounted as D:"), string.Empty, false, txtCDImage.Text);

            _game.CDPath = txtCDImage.Text.Trim();
            if (File.Exists(_game.CDPath))
                _game.IsCDImage = true;
            else
                _game.IsCDImage = false;

        }

        private void txtAdditionalCommands_TextChanged(object sender, EventArgs e)
        {
            _game.AdditionalCommands = txtAdditionalCommands.Text.Trim();
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            _game.NoConfig = chkNoConfig.Checked;
            _game.NoConsole = chkNoConsole.Checked;
            _game.InFullScreen = chkFullscreen.Checked;
            _game.QuitOnExit = chkQuitOnExit.Checked;
        }

        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            _game.UseIOCTL = rdbUseIOCTL.Checked;
            _game.MountAsFloppy = rdbMountFloppy.Checked;
        }

        #endregion
        
        #region "Public"
        #endregion
        #endregion
    }
}
