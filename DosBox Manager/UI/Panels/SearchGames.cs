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
using DosBox_Manager.UI.Panels.Base;
using Helpers.Data;
using DosBox_Manager.UI.Panels.PanelsEventArgs;
using Helpers.Translation;
using Helpers.Data.Objects;
using DosBox_Manager.Business;

namespace DosBox_Manager.UI.Panels
{
    public partial class SearchGames : GamesPanelsBase
    {

        #region "Events Declarations"
        public delegate void SearchCommittedDelegate(object sender, SearchEventArgs e);
        public event SearchCommittedDelegate SearchCommitted;
        #endregion

        #region "Constructors"
        public SearchGames(AppManager manager)
            : base(manager)
        {
            InitializeComponent();
            txtTitle.Focus();

            pnlSearch.KeyDown += panel_KeyDown;
        }

        public SearchGames(AppManager manager, List<Category> cats)
            : base(manager, null, cats)
        {
            InitializeComponent();
            UpdateUI();
            txtTitle.Focus();

            pnlSearch.KeyDown += panel_KeyDown;
        }
        #endregion

        #region "Private Methods"
        public override void UpdateUI()
        {
            FillUpCategoriesCombo();
        }

        private void FillUpCategoriesCombo()
        {
            cboCategories.Items.Clear();
            if (_cats == null)
                return;

            cboCategories.Items.Add(new Category(-100, _translator.GetTranslatedMessage(_settings.Language, 75, "All Categories"), null, false, false));

            foreach (object obj in _cats)
                cboCategories.Items.Add(obj);

            cboCategories.SelectedIndex = 0;
        }
        #endregion

        #region "Control Events"
        private void pnlSearch_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Gray, 0, lblSearchTitle.Top + lblSearchTitle.Height + 1, Width, lblSearchTitle.Top + lblSearchTitle.Height + 1);
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            SearchCommitted(this, new SearchEventArgs(txtTitle.Text.Trim(), txtYear.Text.Trim(), txtDeveloper.Text.Trim(), ((Category)cboCategories.SelectedItem).ID));
        }

        private void panel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            btnCommit_Click(this, null);
        }
        #endregion
    }
}
