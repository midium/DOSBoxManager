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
using DosBox_Manager.UI.Dialogs.SettingsPanels;
using DosBox_Manager.UI.Dialogs.SettingsPanels.Base;
using Helpers.Data;
using Helpers.Data.Objects;
using Helpers.Translation;

namespace DosBox_Manager.UI.Dialogs
{
    public partial class SettingsDialog : Form
    {
        #region "Declarations"
        private BaseSettingsPanel _tabPanel;
        private Settings _Settings;
        private SettingsManager _SettingsDB;
        private TranslationsHelpers _Translator;
        #endregion

        #region "Properties"
        public Settings AppSettings
        {
            get
            {
                return _Settings;
            }
        }
        #endregion

        #region "Constructor"
        public SettingsDialog(SettingsManager SettingsDB, TranslationsHelpers Translator, Settings AppSettings)
        {
            InitializeComponent();
            _Settings = (Settings)AppSettings.Clone();
            _SettingsDB = SettingsDB;
            _Translator = Translator;
            this.Text = _Translator.GetTranslatedMessage(_Settings.Language, 51, "Application Settings");
            _Translator.TranslateUI(_Settings.Language, Name, Controls);
            InitiateUI();
        }
        #endregion

        #region "Private Methods"
        private void InitiateUI()
        {
            _tabPanel = new DOSBoxPanel(_Translator, _Settings, _Translator.GetTranslatedMessage(_Settings.Language, 52, "DOSBox Settings"));
            LoadTabPanel(_tabPanel);
        }

        private void LoadTabPanel(BaseSettingsPanel tabPanel)
        {
            pnlContainer.Controls.Clear();
            if (tabPanel == null)
                return;

            _Translator.TranslateUI(_Settings.Language, Name, tabPanel.Controls);
            pnlContainer.Controls.Add(tabPanel);
        }
        #endregion

        #region "Control Events"
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.LightGray, 0, pnlMain.Height - 1, pnlMain.Width, pnlMain.Height - 1);
        }

        private void settingsTabs_TabChanged(object sender, int index)
        {
            string str = string.Empty;
            if (_tabPanel.GetType() == typeof(BehavioursPanel))
                ((BehavioursPanel)_tabPanel).LanguageChanged -= new BehavioursPanel.LanguageChangedDelegate(pnl_LanguageChanged);

            if (_tabPanel != null)
                _tabPanel.Dispose();

            switch (index)
            {
                case 1:
                    _tabPanel = new DOSBoxPanel(_Translator, _Settings, _Translator.GetTranslatedMessage(_Settings.Language, 52, "DOSBox Settings"));
                    break;

                case 2:
                    _tabPanel = new GamesPanel(_Translator, _Settings, _Translator.GetTranslatedMessage(_Settings.Language, 53, "Games Settings"));
                    break;

                case 3:
                    _tabPanel = new BehavioursPanel(_SettingsDB, _Translator, _Settings, _Translator.GetTranslatedMessage(_Settings.Language, 54, "Application Behaviours"));
                    ((BehavioursPanel)_tabPanel).LanguageChanged += new BehavioursPanel.LanguageChangedDelegate(pnl_LanguageChanged);
                    break;

                default:
                    _tabPanel = null;
                    break;
            }

            LoadTabPanel(_tabPanel);
        }

        private void pnl_LanguageChanged(object sender, Helpers.Data.Objects.Settings.Languages language)
        {
            if (_tabPanel == null)
                return;
            _Translator.TranslateUI(language, Name, _tabPanel.Controls);
            _tabPanel.PanelName = _Translator.GetTranslatedMessage(_Settings.Language, 54, "Application Behaviours");
        }
        #endregion
    }
}
