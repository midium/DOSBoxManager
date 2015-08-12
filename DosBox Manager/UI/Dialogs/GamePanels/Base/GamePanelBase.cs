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
