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
using Helpers.Data;
using Helpers.Dialogs;
using Helpers.Translation;
using Helpers.Data.Objects;

namespace DosBox_Manager.UI.Dialogs.SettingsPanels
{
    public partial class BehavioursPanel : BaseSettingsPanel
    {
        #region "Declarations"
        private DialogsHelpers _dialogsHelpers;
        private SettingsHelpers _helpers;
        private SettingsManager _SettingsDB;

        public delegate void LanguageChangedDelegate(object sender, Settings.Languages language);
        public event LanguageChangedDelegate LanguageChanged;
        #endregion

        #region "Constructors"
        public BehavioursPanel(SettingsManager SettingsDB)
        {
            InitializeComponent();
        }

        public BehavioursPanel(SettingsManager SettingsDB, TranslationsHelpers Translator, Settings AppSettings, string PanelName)
            : base(Translator, AppSettings, PanelName)
        {
            InitializeComponent();

            _flgInitiation = true;
            _helpers = new SettingsHelpers();
            _dialogsHelpers = new DialogsHelpers();
            _SettingsDB = SettingsDB;
            CompileUI(AppSettings);
            _flgInitiation = false;

        }
        #endregion

        #region "Private Methods"
        private void CompileUI(Settings AppSettings)
        {
            txtTextEditor.Text = AppSettings.ConfigEditorPath;
            txtAdditionalCommands.Text = AppSettings.ConfigEditorAdditionalParameters;
            chkRememberSize.Checked = AppSettings.RememberWindowSize;
            chkMenuBar.Checked = AppSettings.MenuBarVisible;
            chkStatusBar.Checked = AppSettings.StatusBarVisible;
            chkToolbar.Checked = AppSettings.ToolbarVisible;
            chkPromptGame.Checked = AppSettings.GameDeletePrompt;
            chkCategoryDelete.Checked = AppSettings.CategoryDeletePrompt;
            chkReload.Checked = AppSettings.ReloadLatestDB;
            chkToTrayOnPlay.Checked = AppSettings.ReduceToTrayOnPlay;
            cboLanguage.Items.Clear();
            cboLanguage.Items.Add(new ItemData(0, "English"));
            cboLanguage.Items.Add(new ItemData(1, "Italian"));
            cboLanguage.SelectedIndex = AppSettings.Language == Settings.Languages.English ? 0 : 1;
        }
        #endregion

        #region "Constrols Events"
        private void btnSearchTextEditor_Click(object sender, EventArgs e)
        {
            txtTextEditor.Text = _helpers.SearchCommonTextEditor();
        }

        private void btnTextEditor_Click(object sender, EventArgs e)
        {
            string translatedMessage1 = _translator.GetTranslatedMessage(_AppSettings.Language, 1, "Choose a text editor");
            string translatedMessage2 = _translator.GetTranslatedMessage(_AppSettings.Language, 2, "Application executable (*.exe)|*.exe");
            txtTextEditor.Text = _dialogsHelpers.OpenFile(translatedMessage1, string.Empty, translatedMessage2, string.Empty, txtTextEditor.Text);
        }

        private void txtTextEditor_TextChanged(object sender, EventArgs e)
        {
            if (_flgInitiation)
                return;
            
            _AppSettings.ConfigEditorPath = txtTextEditor.Text;
        }

        private void txtAdditionalCommands_TextChanged(object sender, EventArgs e)
        {
            if (_flgInitiation)
                return;

            _AppSettings.ConfigEditorAdditionalParameters = txtAdditionalCommands.Text;
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (_flgInitiation)
                return;

            _AppSettings.RememberWindowSize = chkRememberSize.Checked;
            _AppSettings.MenuBarVisible = chkMenuBar.Checked;
            _AppSettings.StatusBarVisible = chkStatusBar.Checked;
            _AppSettings.ToolbarVisible = chkToolbar.Checked;
            _AppSettings.CategoryDeletePrompt = chkCategoryDelete.Checked;
            _AppSettings.GameDeletePrompt = chkPromptGame.Checked;
            _AppSettings.ReloadLatestDB = chkReload.Checked;
            _AppSettings.ReduceToTrayOnPlay = chkToTrayOnPlay.Checked;
        }

        private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flgInitiation || cboLanguage.SelectedItem == null)
                return;

            _AppSettings.Language = ((ItemData)cboLanguage.SelectedItem).ID == 0 ? Settings.Languages.English : Settings.Languages.Italian;
            LanguageChanged(this, _AppSettings.Language);
        }

        private void btnEditTranslation_Click(object sender, EventArgs e)
        {
            TranslationsDialog translationsDialog = new TranslationsDialog(_translator);
            if (translationsDialog.ShowDialog() == DialogResult.OK)
            {
                _translator = translationsDialog.Translator;
                _SettingsDB.UpdateTranslations(_translator);
            }
            translationsDialog.Dispose();
        }
        #endregion
    }
}

public class ItemData
{
    private int _ID;
    private string _Name;

    public int ID
    {
        get
        {
            return this._ID;
        }
        set
        {
            this._ID = value;
        }
    }

    public string Name
    {
        get
        {
            return this._Name;
        }
        set
        {
            this._Name = value;
        }
    }

    public ItemData(int ID, string Name)
    {
        this._ID = ID;
        this._Name = Name;
    }

    public override string ToString()
    {
        return this._Name;
    }
}