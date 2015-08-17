using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DosBox_Manager.UI.Dialogs.GamePanels;
using DosBox_Manager.UI.Dialogs.GamePanels.Base;
using Helpers.Business;
using Helpers.Data.Objects;
using Helpers.Dialogs;

namespace DosBox_Manager.UI.Dialogs
{
    public partial class GameDialog : Form
    {
        #region "Declarations"
        private GamePanelBase _gamePanel = null;
        private AppManager _manager = null;
        private Game _game = null;
        private DialogsHelpers _dialogsHelpers = null;
        private Dictionary<String, Category> _cats = null;
        #endregion

        #region "Constructors"
        public GameDialog(AppManager Manager, Game GameData, bool isEditing)
        {
            InitializeComponent();
            _manager = Manager;
            _game = (Game)GameData.Clone();
            _dialogsHelpers = new DialogsHelpers();
            _manager.Translator.TranslateUI(_manager.AppSettings.Language, this.Name, this.Controls);
            _cats = _manager.DB.GetAllCategories();
            LoadPanel(1);
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.LightGray, 0, pnlMain.Height - 1, pnlMain.Width, pnlMain.Height - 1);
        }
        #endregion

        #region "Control Events Handling"
        private void gameTabs_TabChanged(object sender, int index)
        {
            LoadPanel(index);
        }
        #endregion

        #region "Properties"
        public Game GameData
        {
            get { return _game; }
            set { _game = value; }
        }

        public Dictionary<String, Category> Cats
        {
            get { return _cats; }
        }
        #endregion

        #region "Private Method"
        private void LoadPanel(int index)
        {
            pnlMain.Controls.Clear();
            switch (index)
            {
                case 2:
                    _gamePanel = new GameSetupPanel(_manager, _dialogsHelpers, _game);
                    break;
                default:
                    _gamePanel = new GameInfoPanel(_manager, _dialogsHelpers, _game, _cats);
                    break;
            }

            if (_gamePanel == null)
                return;

            _manager.Translator.TranslateUI(_manager.AppSettings.Language, this.Name, _gamePanel.Controls);

            pnlMain.Controls.Add(_gamePanel);
            _gamePanel.Focus();
        }
        #endregion


    }
}
