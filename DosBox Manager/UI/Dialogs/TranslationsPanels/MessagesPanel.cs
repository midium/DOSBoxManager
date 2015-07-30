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
    public partial class MessagesPanel : TranslationsPanelsBase
    {
        #region "Constructors"
        public MessagesPanel()
        {
            InitializeComponent();
        }

        public MessagesPanel(Dictionary<int, MessageTranslation> Messages, Dictionary<string, ComponentTranslation> Components)
            : base(Messages, Components)
        {
            InitializeComponent();
            UpdateUI();
        }
        #endregion

        #region "Methods Override"
        public override void UpdateUI()
        {
            lblPanelTitle.Text = "Available Translatable Messages:";
            if (_messages == null)
                return;

            InitGrid();

            foreach (MessageTranslation messageTranslation in _messages.Values)
                dgvTranslations.Rows.Add(messageTranslation.ID, messageTranslation.English, 
                                         messageTranslation.Italian);
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
            dataGridViewColumn2.Name = "english";
            dataGridViewColumn2.HeaderText = "English";
            dataGridViewColumn2.Visible = true;
            dataGridViewColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewColumn dataGridViewColumn3 = (DataGridViewColumn)new DataGridViewTextBoxColumn();
            dataGridViewColumn3.Name = "italian";
            dataGridViewColumn3.HeaderText = "Italian";
            dataGridViewColumn3.Visible = true;
            dataGridViewColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTranslations.Columns.Add(dataGridViewColumn1);
            dgvTranslations.Columns.Add(dataGridViewColumn2);
            dgvTranslations.Columns.Add(dataGridViewColumn3);
        }
        #endregion

        #region "Controls Events"
        private void dgvTranslations_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int key = Convert.ToInt32(dgvTranslations.Rows[e.RowIndex].Cells[0].Value);
            if (!_messages.ContainsKey(key))
                return;

            string str = dgvTranslations.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            _messages[key].Changed = true;
            switch (e.ColumnIndex)
            {
                case 1:
                    _messages[key].English = str;
                    break;
                case 2:
                    _messages[key].Italian = str;
                    break;
            }
        }
        #endregion
    }
}
