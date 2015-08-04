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
using Helpers.Translation;
using Helpers.Data.Objects;
using DosBox_Manager.Business;

namespace DosBox_Manager.UI.Dialogs
{
    public partial class CategoryDialog : Form
    {
        #region "Declarations"
        private TranslationsHelpers _translator;
        private Settings _AppSettings;
        #endregion

        #region "Properties"
        public string CategoryName
        {
            get { return txtName.Text.Trim(); }
        }

        public string CategoryIcon
        {
            get { return txtIcon.Text.Trim(); }
        }
        #endregion

        #region "Constructors"
        public CategoryDialog(AppManager manager)
        {
            InitializeComponent();
            _translator = manager.Translator;
            _AppSettings = manager.AppSettings;
            this.Text = _translator.GetTranslatedMessage(_AppSettings.Language, 35, "Add New Category");
            _translator.TranslateUI(_AppSettings.Language, Name, Controls);
        }

        public CategoryDialog(Helpers.Data.Objects.Settings AppSettings, TranslationsHelpers translator, Category editCat)
        {
            InitializeComponent();
            _translator = translator;
            _AppSettings = AppSettings;
            this.Text = _translator.GetTranslatedMessage(_AppSettings.Language, 36, "Edit Category");
            _translator.TranslateUI(_AppSettings.Language, Name, Controls);
            PopulateForm(editCat);
        }
        #endregion

        #region "Private Methods"
        private void PopulateForm(Category editCat)
        {
            txtIcon.Text = editCat.Icon;
            txtName.Text = editCat.Name;
        }
        #endregion

        #region "Controls Events"
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.LightGray, 0, pnlMain.Height - 1, pnlMain.Width, pnlMain.Height - 1);
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = string.Empty;
            openFileDialog.Title = _translator.GetTranslatedMessage(_AppSettings.Language, 37, "Select Category Icon");
            openFileDialog.Filter = _translator.GetTranslatedMessage(_AppSettings.Language, 38, "All Supported Images|*.jpg;*.png;*.ico|Jpeg Images (*.jpg)|*.jpg|PNG Images (*.png)|*.png|Icons (*.ico)|*.ico");
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            txtIcon.Text = openFileDialog.FileName;
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            txtIcon.Text = string.Empty;
        }
        #endregion
    }
}
