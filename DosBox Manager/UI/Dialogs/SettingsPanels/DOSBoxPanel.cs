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
using Helpers.Configuration;
using Helpers.Dialogs;
using Helpers.Translation;
using Helpers.Data.Objects;
using DosBox_Manager.Business;

namespace DosBox_Manager.UI.Dialogs.SettingsPanels
{
    public partial class DOSBoxPanel : BaseSettingsPanel
    {

        #region "Declarations"
        private SettingsHelpers _helpers;
        private DialogsHelpers _dialogsHelpers;
        #endregion

        #region "Constructors"
        public DOSBoxPanel()
        {
            _flgInitiation = true;
            InitializeComponent();
            _helpers = new SettingsHelpers();
            _dialogsHelpers = new DialogsHelpers();
            _flgInitiation = false;
        }

        public DOSBoxPanel(AppManager manager, string PanelName)
            : base(manager, PanelName)
        {
            _flgInitiation = true;
            InitializeComponent();
            _helpers = new SettingsHelpers();
            _dialogsHelpers = new DialogsHelpers();
            CompileUI(_AppSettings);
            _flgInitiation = false;
        }
        #endregion

        #region "Private Methods"
        private void CompileUI(Helpers.Data.Objects.Settings AppSettings)
        {
            txtDosBoxExePath.Text = AppSettings.DosboxPath;
            txtDosBoxConfigFile.Text = AppSettings.DosboxDefaultConfFilePath;
            txtDosBoxLanguageFile.Text = AppSettings.DosboxDefaultLangFilePath;
            chkPortable.Checked = AppSettings.PortableMode;
        }
        #endregion

        #region "Controls Events"
        private void btnRescan_Click(object sender, EventArgs e)
        {
            txtDosBoxExePath.Text = _helpers.SearchDOSBox(_translator, _AppSettings, chkPortable.Checked);
            txtDosBoxConfigFile.Text = _helpers.SearchDOSBoxConf(txtDosBoxExePath.Text);
            txtDosBoxLanguageFile.Text = _helpers.SearchDOSBoxLang(txtDosBoxExePath.Text);
        }

        private void btnOpenGameEXE_Click(object sender, EventArgs e)
        {
            txtDosBoxExePath.Text = _dialogsHelpers.OpenFile(_translator.GetTranslatedMessage(_AppSettings.Language, 55, "Choose DOSBox Executable"), "dosbox.exe", _translator.GetTranslatedMessage(_AppSettings.Language, 2, "Application executable (*.exe)|*.exe"), string.Empty, txtDosBoxExePath.Text);
        }

        private void btnDosBoxConfig_Click(object sender, EventArgs e)
        {
            string translatedMessage1 = _translator.GetTranslatedMessage(_AppSettings.Language, 56, "Choose DOSBox configuration file");
            string translatedMessage2 = _translator.GetTranslatedMessage(_AppSettings.Language, 42, "DOSBox configuration file (*.conf)|*.conf;*.CONF");
            txtDosBoxConfigFile.Text = _dialogsHelpers.OpenFile(translatedMessage1, string.Empty, translatedMessage2, string.Empty, txtDosBoxConfigFile.Text);
        }

        private void btnDosBoxLanguage_Click(object sender, EventArgs e)
        {
            string translatedMessage1 = _translator.GetTranslatedMessage(_AppSettings.Language, 57, "Choose DOSBox language file");
            string translatedMessage2 = _translator.GetTranslatedMessage(_AppSettings.Language, 58, "DOSBox language files (*.lng)|*.lng|All files (*.*)|*.*");
            txtDosBoxLanguageFile.Text = _dialogsHelpers.OpenFile(translatedMessage1, string.Empty, translatedMessage2, string.Empty, txtDosBoxLanguageFile.Text);
        }

        private void txtDosBoxExePath_TextChanged(object sender, EventArgs e)
        {
            if (_flgInitiation)
                return;
            _AppSettings.DosboxPath = txtDosBoxExePath.Text;
        }

        private void txtDosBoxConfigFile_TextChanged(object sender, EventArgs e)
        {
            if (_flgInitiation)
                return;
            _AppSettings.DosboxDefaultConfFilePath = txtDosBoxConfigFile.Text;
        }

        private void txtDosBoxLanguageFile_TextChanged(object sender, EventArgs e)
        {
            if (_flgInitiation)
                return;
            _AppSettings.DosboxDefaultLangFilePath = txtDosBoxLanguageFile.Text;
        }

        private void chkPortable_CheckedChanged(object sender, EventArgs e)
        {
            if (_flgInitiation)
                return;
            _AppSettings.PortableMode = chkPortable.Checked;
        }
        #endregion
    }
}
