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
using DosBox_Manager.UI.Dialogs.SettingsPanels.Base;
using Helpers.Dialogs;
using Helpers.Translation;
using Helpers.Data.Objects;
using DosBox_Manager.Business;

namespace DosBox_Manager.UI.Dialogs.SettingsPanels
{
    public partial class GamesPanel : BaseSettingsPanel
    {

        #region "Declarations"
        private DialogsHelpers _dialogsHelpers;
        #endregion

        #region "Constructors"
        public GamesPanel()
        {
            _flgInitiation = true;
            InitializeComponent();
            _dialogsHelpers = new DialogsHelpers();
            _flgInitiation = false;
        }

        public GamesPanel(AppManager manager, string PanelName)
            : base(manager, PanelName)
        {
            _flgInitiation = true;
            InitializeComponent();
            _dialogsHelpers = new DialogsHelpers();
            CompileUI(_AppSettings);
            _flgInitiation = false;
        }
        #endregion

        #region "Private Methods"
        private void CompileUI(Helpers.Data.Objects.Settings AppSettings)
        {
            txtDefaultGamesFolder.Text = AppSettings.GamesDefaultDir;
            txtDefaultImagesFolder.Text = AppSettings.CDsDefaultDir;
            txtAdditionalCommands.Text = AppSettings.GamesAdditionalCommands;
            chkNoConsole.Checked = AppSettings.GamesNoConsole;
            chkQuitOnExit.Checked = AppSettings.GamesQuitOnExit;
            chkFullscreen.Checked = AppSettings.GamesInFullScreen;
            chk3DBox.Checked = AppSettings.BoxRendered;
        }
        #endregion

        #region "Controls Events"
        private void btnDefaultGamesFolder_Click(object sender, EventArgs e)
        {
            txtDefaultGamesFolder.Text = _dialogsHelpers.OpenFolder(_translator.GetTranslatedMessage(_AppSettings.Language, 60, "Choose default games repository folder"), txtDefaultGamesFolder.Text, true, txtDefaultGamesFolder.Text);
        }

        private void btnDefaultImagesFolder_Click(object sender, EventArgs e)
        {
            txtDefaultImagesFolder.Text = _dialogsHelpers.OpenFolder(_translator.GetTranslatedMessage(_AppSettings.Language, 61, "Choose default images repository folder"), txtDefaultImagesFolder.Text, true, txtDefaultImagesFolder.Text);
        }

        private void txtDefaultGamesFolder_TextChanged(object sender, EventArgs e)
        {
            if (_flgInitiation)
                return;
            _AppSettings.GamesDefaultDir = txtDefaultGamesFolder.Text;
        }

        private void txtDefaultImagesFolder_TextChanged(object sender, EventArgs e)
        {
            if (_flgInitiation)
                return;
            _AppSettings.CDsDefaultDir = txtDefaultImagesFolder.Text;
        }

        private void txtAdditionalCommands_TextChanged(object sender, EventArgs e)
        {
            if (_flgInitiation)
                return;
            _AppSettings.GamesAdditionalCommands = txtAdditionalCommands.Text;
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (_flgInitiation)
                return;
            _AppSettings.GamesNoConsole = chkNoConsole.Checked;
            _AppSettings.GamesInFullScreen = chkFullscreen.Checked;
            _AppSettings.GamesQuitOnExit = chkQuitOnExit.Checked;
            _AppSettings.BoxRendered = chk3DBox.Checked;
        }
        #endregion

    }
}
