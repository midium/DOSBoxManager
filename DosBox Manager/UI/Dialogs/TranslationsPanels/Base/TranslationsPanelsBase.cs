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
using Helpers.Data.Objects.Translation;

namespace DosBox_Manager.UI.Dialogs.TranslationsPanels.Base
{
    public partial class TranslationsPanelsBase : UserControl
    {
        #region "Declarations"
        protected Dictionary<int, MessageTranslation> _messages;
        protected Dictionary<string, ComponentTranslation> _components;
        #endregion

        #region "Properties"
        public Dictionary<int, MessageTranslation> Messages
        {
            get { return _messages; }
        }

        public Dictionary<string, ComponentTranslation> Components
        {
            get { return _components; }
        }
        #endregion

        #region "Constructors"
        public TranslationsPanelsBase()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public TranslationsPanelsBase(Dictionary<int, MessageTranslation> Messages, Dictionary<string, ComponentTranslation> Components)
        {
            InitializeComponent();
            _messages = Messages;
            _components = Components;
            this.Dock = DockStyle.Fill;
        }
        #endregion

        #region "Virtual Routines"
        public virtual void InitGrid()
        {
        }

        public virtual void GridStyling()
        {
            dgvTranslations.RowHeadersWidth = 20;
            dgvTranslations.AllowUserToAddRows = false;
            dgvTranslations.AllowUserToDeleteRows = false;
            dgvTranslations.AllowUserToOrderColumns = false;
            dgvTranslations.AllowUserToResizeColumns = false;
            dgvTranslations.AllowUserToResizeRows = false;
            dgvTranslations.ForeColor = Color.Black;
        }

        public virtual void UpdateUI()
        {
        }
        #endregion
    }
}
