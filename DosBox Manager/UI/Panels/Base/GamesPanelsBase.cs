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
using Helpers.Data.Objects;
using Helpers.Translation;
using DosBox_Manager.Business;

namespace DosBox_Manager.UI.Panels.Base
{
    public partial class GamesPanelsBase : UserControl
    {
        #region "Declarations"
        protected List<Game> _games;
        protected List<Category> _cats;
        protected TranslationsHelpers _translator;
        protected Settings _settings;
        #endregion

        #region "Properties"
        public virtual List<Category> Categories
        {
            set { _cats = value; }
        }
        #endregion

        #region "Constructors"
        public GamesPanelsBase()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            _settings = (Settings)null;
            _translator = (TranslationsHelpers)null;
        }

        public GamesPanelsBase(AppManager manager)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            _settings = manager.AppSettings;
            _translator = manager.Translator;
        }

        public GamesPanelsBase(AppManager manager, List<Game> games, List<Category> cats)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            _settings = manager.AppSettings;
            _translator = manager.Translator;
            _games = games;
            _cats = cats;
        }
        #endregion

        #region "Virtual Methods"
        public virtual void UpdateUI()
        {
        }
        #endregion
    }
}
