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
using DosBox_Manager.UI.Dialogs.TranslationsPanels;
using DosBox_Manager.UI.Dialogs.TranslationsPanels.Base;
using Helpers.Data.Objects.Translation;
using Helpers.Translation;

namespace DosBox_Manager.UI.Dialogs
{
    public partial class TranslationsDialog : Form
    {
        #region "Declarations"
        private TranslationsPanelsBase _translationPanel = (TranslationsPanelsBase)null;
        private TranslationsHelpers _translator;
        #endregion

        #region "Properties"
        public TranslationsHelpers Translator
        {
            get { return _translator; }
        }
        #endregion

        #region "Constructor"
        public TranslationsDialog(TranslationsHelpers Translator)
        {
            InitializeComponent();
            _translator = (TranslationsHelpers)Translator.Clone();
            LoadPanel(1);
        }
        #endregion

        #region "Controls Events"
        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.LightGray, 0, tableLayoutPanel.Height - 1, pnlMain.Width, tableLayoutPanel.Height - 1);
        }

        private void translationTabs_TabChanged(object sender, int index)
        {
            LoadPanel(index);
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region "Private Method"
        private void LoadPanel(int index)
        {
            pnlContainer.Controls.Clear();
            switch (index)
            {
                case 2:
                    _translationPanel = new MessagesPanel(_translator.MessagesTranslations, null);
                    break;
                default:
                    _translationPanel = new ComponentsPanel(null, _translator.ComponentsTranslations);
                    break;
            }
            pnlContainer.Controls.Add(_translationPanel);
            _translationPanel.Focus();
        }
        #endregion
    }
}
