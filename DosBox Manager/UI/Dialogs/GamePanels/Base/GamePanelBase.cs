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
using Helpers.Translation;
using Helpers.Data.Objects;
using Helpers.Dialogs;
using Helpers.Business;

namespace DosBox_Manager.UI.Dialogs.GamePanels.Base
{
    public partial class GamePanelBase : UserControl
    {

        #region "Declarations"
        protected TranslationsHelpers _translator;
        protected Settings _settings;
        protected AppManager _manager;
        protected Game _game;
        protected DialogsHelpers _dialogsHelpers;
        protected bool _flgInitiation;
        #endregion

        #region "Constructors"
        public GamePanelBase()
        {
            InitializeComponent();
        }

        public GamePanelBase(AppManager Manager, DialogsHelpers DialogsHelpers, Game GameData)
        {
            InitializeComponent();
            _manager = Manager;
            _settings = _manager.AppSettings;
            _translator = _manager.Translator;
            _dialogsHelpers = DialogsHelpers;
            _game = GameData;
        }
        #endregion

    }
}
