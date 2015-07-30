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
using DosBox_Manager.UI.Dialogs.TranslationsPanels.Base;
using Helpers.Data.Objects.Translation;

namespace DosBox_Manager.UI.Dialogs.TranslationsPanels
{
    public partial class ComponentsPanel : TranslationsPanelsBase
    {
        #region "Constructors"
        public ComponentsPanel()
        {
            InitializeComponent();
        }

        public ComponentsPanel(Dictionary<int, MessageTranslation> Messages, Dictionary<string, ComponentTranslation> Components)
            : base(Messages, Components)
        {
            InitializeComponent();
            UpdateUI();
        }
        #endregion

        #region "Methods Override"
        public override void UpdateUI()
        {
            lblPanelTitle.Text = "Available Translatable Components:";

            if (_components == null)
                return;

            InitGrid();

            foreach (ComponentTranslation componentTranslation in _components.Values)
                dgvTranslations.Rows.Add(componentTranslation.ID, componentTranslation.ParentForm, 
                                         componentTranslation.ComponentName, componentTranslation.English, 
                                         componentTranslation.Italian, componentTranslation.EnglishTooltip, 
                                         componentTranslation.ItalianTooltip);
        }

        public override void InitGrid()
        {
            dgvTranslations.Rows.Clear();
            dgvTranslations.Columns.Clear();
            dgvTranslations.AutoGenerateColumns = false;
            dgvTranslations.CellEndEdit += new DataGridViewCellEventHandler(dgvTranslations_CellEndEdit);
            GridStyling();
            DataGridViewColumn dataGridViewColumn1 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn1.Name = "id";
            dataGridViewColumn1.HeaderText = "ID";
            dataGridViewColumn1.Visible = false;
            DataGridViewColumn dataGridViewColumn2 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn2.Name = "form";
            dataGridViewColumn2.HeaderText = "Form";
            dataGridViewColumn2.ReadOnly = true;
            dataGridViewColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewColumn dataGridViewColumn3 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn3.Name = "component";
            dataGridViewColumn3.HeaderText = "Component";
            dataGridViewColumn3.ReadOnly = true;
            dataGridViewColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewColumn dataGridViewColumn4 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn4.Name = "english";
            dataGridViewColumn4.HeaderText = "English";
            dataGridViewColumn4.Visible = true;
            dataGridViewColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewColumn dataGridViewColumn5 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn5.Name = "italian";
            dataGridViewColumn5.HeaderText = "Italian";
            dataGridViewColumn5.Visible = true;
            dataGridViewColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewColumn dataGridViewColumn6 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn6.Name = "englishTT";
            dataGridViewColumn6.HeaderText = "English ToolTip";
            dataGridViewColumn6.Visible = true;
            dataGridViewColumn6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewColumn dataGridViewColumn7 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn7.Name = "italianTT";
            dataGridViewColumn7.HeaderText = "Italian ToolTip";
            dataGridViewColumn7.Visible = true;
            dataGridViewColumn7.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTranslations.Columns.Add(dataGridViewColumn1);
            dgvTranslations.Columns.Add(dataGridViewColumn2);
            dgvTranslations.Columns.Add(dataGridViewColumn3);
            dgvTranslations.Columns.Add(dataGridViewColumn4);
            dgvTranslations.Columns.Add(dataGridViewColumn5);
            dgvTranslations.Columns.Add(dataGridViewColumn6);
            dgvTranslations.Columns.Add(dataGridViewColumn7);
        }
        #endregion

        #region "Control Events"
        private void dgvTranslations_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string key = dgvTranslations.Rows[e.RowIndex].Cells[1].Value.ToString() + dgvTranslations.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (!_components.ContainsKey(key))
                return;

            string newTranslation = dgvTranslations.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            _components[key].Changed = true;

            switch (e.ColumnIndex)
            {
                case 3:
                    _components[key].English = newTranslation;
                    break;
                case 4:
                    _components[key].Italian = newTranslation;
                    break;
                case 5:
                    _components[key].EnglishTooltip = newTranslation;
                    break;
                case 6:
                    _components[key].ItalianTooltip = newTranslation;
                    break;
            }
        }
        #endregion
    }
}
