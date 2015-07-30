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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DosBox_Manager.UI.Dialogs;
using DosBox_Manager.UI.Panels;
using DosBox_Manager.UI.Panels.PanelsEventArgs;
using GUI.Menus.MenuStripRenderer;
using GUI.MessageBoxes;
using GUI.Tabs;
using GUI.Toolbars;
using Helpers.Apps;
using Helpers.Data;
using Helpers.Data.Objects;
using Helpers.IO;
using Helpers.Translation;

namespace DosBox_Manager
{
    public partial class MainForm : Form
    {
        #region "Declarations"
        private Settings _AppSettings = null;
        private DOSBoxHelpers _DosBoxHelper = null;
        private FileHelpers _fileHelper = null;
        private bool _flgRecentAdded = false;
        private bool _flgMoveToAdded = false;
        private Dictionary<string, RecentDatabase> _recentDBs = null;
        private TranslationsHelpers _translator = null;
        private CategoryGames catGames = null;
        private Database _DB;
        private SettingsManager _SettingsDB;
        private int _SelectedCategory;
        private bool _flgLoading;
        private int _SelectedGame;
        private ContextMenuStrip cms;
        private ToolStripMenuItem MenuBar_cms;
        private ToolStripMenuItem ToolBar_cms;
        private ToolStripMenuItem StatusBar_cms;
        #endregion

        public MainForm()
        {
            _flgLoading = true;
            InitializeComponent();
            InitializeStyle();
            InitializeGUIEventsHandlers();
            _SettingsDB = new SettingsManager("settings.dbm");
            _translator = new TranslationsHelpers(_SettingsDB.LoadMessagesTranslations(), _SettingsDB.LoadComponentsTranslations());
            _AppSettings = _SettingsDB.LoadSettings();
            _recentDBs = _SettingsDB.LoadRecentDatabases();
            _DB = new Database();
            _DosBoxHelper = new DOSBoxHelpers();
            _fileHelper = new FileHelpers();
            SetupUI();
            _SelectedCategory = -1;
            _SelectedGame = -1;
            EnableMenus(false);
            if (_AppSettings.ReloadLatestDB && (_recentDBs != null && _recentDBs.Count > 0))
                OpenRecentDatabase(Enumerable.First<KeyValuePair<string, RecentDatabase>>((IEnumerable<KeyValuePair<string, RecentDatabase>>)_recentDBs).Value.DBPath, false);

            _flgLoading = false;
        }

        #region "Private Helping Methods"
        private bool CheckConnection()
        {
            if (_DB.ConnectionStatus == ConnectionState.Closed)
                return true;
            CustomMessageBox customMessageBox = new CustomMessageBox(_translator.GetTranslatedMessage(_AppSettings.Language, 12, "It seems there is another connection already open, you need to close it to continue.") + "\n" + _translator.GetTranslatedMessage(_AppSettings.Language, 13, "Do you want to close the connection and continue?"), _translator.GetTranslatedMessage(_AppSettings.Language, 8, "Attention"), MessageBoxDialogButtons.YesNo, MessageBoxDialogIcon.Question, false, false);
            customMessageBox.ShowDialog();
            if (customMessageBox.Result != MessageBoxDialogResult.Yes)
                return false;
            _DB.Disconnect();
            return true;
        }

        private void CloseApplication()
        {
            if (this._DB != null)
                this._DB.Disconnect();
            Application.Exit();
        }

        private void OpenSettingsDialog()
        {
            SettingsDialog settingsDialog = new SettingsDialog(_SettingsDB, _translator, _AppSettings);
            if (settingsDialog.ShowDialog() == DialogResult.OK)
            {
                _AppSettings = settingsDialog.AppSettings;
                _SettingsDB.SaveSettings(_AppSettings);
                SetupUI();
                UpdateStatusBar();
                LoadCategoryGames(_SelectedCategory);
            }
            settingsDialog.Dispose();
        }

        private void AboutDialog()
        {
            AboutDBM about = new AboutDBM();
            about.ShowDialog();
            about.Dispose();
        }

        private void OpenDatabase()
        {
            if (!CheckConnection())
                return;
            openFileDialog.Title = _translator.GetTranslatedMessage(_AppSettings.Language, 14, "Open an existing DOSBox Manager database");
            openFileDialog.FileName = "";
            openFileDialog.Filter = _translator.GetTranslatedMessage(_AppSettings.Language, 15, "DOSBox Manager Database (*.dbm)|*.dbm");
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            if (!_DB.Connect(openFileDialog.FileName))
            {
                CustomMessageBox customMessageBox = new CustomMessageBox(_translator.GetTranslatedMessage(_AppSettings.Language, 6, "It has not been possible to open the database!"), _translator.GetTranslatedMessage(_AppSettings.Language, 30, "Warning"), MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Warning, false, false);
                customMessageBox.ShowDialog();
                customMessageBox.Dispose();
            }
            else
            {
                if (_SettingsDB.AddToRecentDatabases(openFileDialog.FileName))
                {
                    _recentDBs = _SettingsDB.LoadRecentDatabases();
                    AddRecentDBs();
                }
                UpdateStatusBar();
                EnableMenus(true);
                RefreshCategories();
            }
        }

        private void CreateDatabase()
        {
            if (_DB == null)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox(_translator.GetTranslatedMessage(_AppSettings.Language, 16, "There are problems with the database connector, this feature can't be used at the moment."), _translator.GetTranslatedMessage(_AppSettings.Language, 28, "Error"), MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Error, false, false);
                customMessageBox.ShowDialog();
                customMessageBox.Dispose();
            }
            else
            {
                if (!CheckConnection())
                    return;
                saveFileDialog.Title = _translator.GetTranslatedMessage(_AppSettings.Language, 17, "Create a new DOSBox Manager database");
                saveFileDialog.FileName = "";
                saveFileDialog.Filter = _translator.GetTranslatedMessage(_AppSettings.Language, 15, "DOSBox Manager Database (*.dbm)|*.dbm");
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!_DB.CreateDB(saveFileDialog.FileName))
                    {
                        CustomMessageBox customMessageBox = new CustomMessageBox(_translator.GetTranslatedMessage(_AppSettings.Language, 18, "It has not been possible to create the database!"), _translator.GetTranslatedMessage(_AppSettings.Language, 28, "Error"), MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Error, false, false);
                        customMessageBox.ShowDialog();
                        customMessageBox.Dispose();
                    }
                    else
                    {
                        if (_SettingsDB.AddToRecentDatabases(saveFileDialog.FileName))
                        {
                            _recentDBs = _SettingsDB.LoadRecentDatabases();
                            AddRecentDBs();
                        }
                        UpdateStatusBar();
                        RefreshCategories();
                        EnableMenus(true);
                    }
                }
            }
        }

        private void DisconnectDatabase()
        {
            if (_DB == null || _DB.ConnectionStatus == ConnectionState.Closed)
                return;
            _DB.Disconnect();
            EnableMenus(false);
            categoriesTabs.ClearTabs();
            RemoveGamesPanelHandlers();
            pnlGames.Controls.Clear();
            UpdateStatusBar();
        }

        private void NewCategory()
        {
            CategoryDialog categoryDialog = new CategoryDialog(_AppSettings, _translator);
            if (categoryDialog.ShowDialog() != DialogResult.OK || !_DB.AddCategory(categoryDialog.CategoryName, categoryDialog.CategoryIcon))
                return;
            RefreshCategories();
            UpdateStatusBar();
        }

        private void EditCategory()
        {
            Category category = _DB.GetCategory(_SelectedCategory);
            CategoryDialog categoryDialog = new CategoryDialog(_AppSettings, _translator, category);
            if (categoryDialog.ShowDialog() == DialogResult.OK && _DB.EditCategory(category.ID, categoryDialog.CategoryName, categoryDialog.CategoryIcon))
                RefreshCategories();
        }

        private void DeleteCategory()
        {
            Category category = _DB.GetCategory(_SelectedCategory);
            string Body = string.Format(_translator.GetTranslatedMessage(_AppSettings.Language, 19, "You are about to remove the {0} category."), (object)category.Name) + "\n" + _translator.GetTranslatedMessage(_AppSettings.Language, 20, "This will also remove all the games of the category.") + "\n" + _translator.GetTranslatedMessage(_AppSettings.Language, 21, "Are you sure you want to continue?");
            string translatedMessage = _translator.GetTranslatedMessage(_AppSettings.Language, 8, "Attention");
            if (_AppSettings.CategoryDeletePrompt)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox(Body, translatedMessage, MessageBoxDialogButtons.YesNo, MessageBoxDialogIcon.Warning, true, true);
                customMessageBox.ShowDialog();
                if (customMessageBox.Result == MessageBoxDialogResult.Yes && _DB.RemoveCategory(category.ID))
                {
                    RefreshCategories();
                    UpdateStatusBar();
                }
                if (!customMessageBox.AskAgain)
                {
                    _AppSettings.CategoryDeletePrompt = false;
                    _SettingsDB.SaveSettings(_AppSettings);
                }
                customMessageBox.Dispose();
            }
            else if (_DB.RemoveCategory(category.ID))
            {
                RefreshCategories();
                UpdateStatusBar();
            }
        }

        private void NewGame()
        {
            OpenGameDialog(new Game()
            {
                CategoryID = _SelectedCategory
            }, false);
        }

        private void AddMovetoCategoryMenu(List<Category> categories)
        {
            if (categories == null || categories.Count <= 0)
                return;
            if (_flgMoveToAdded)
            {
                moveToCategoryToolStripMenuItem.DropDownItems.Clear();
                tsbMoveToCategory.DropDownItems.Clear();
            }
            else
                _flgMoveToAdded = true;
            foreach (Category category in categories)
            {
                ToolStripItemCollection dropDownItems1 = moveToCategoryToolStripMenuItem.DropDownItems;
                int id = category.ID;
                ToolStripMenuItem toolStripMenuItem1 = CreateToolStripMenuItem(id.ToString(), category.Name, category.Icon == string.Empty ? (Image)null : Image.FromFile(category.Icon), new EventHandler(MoveToCategory_Click));
                dropDownItems1.Add((ToolStripItem)toolStripMenuItem1);
                ToolStripItemCollection dropDownItems2 = tsbMoveToCategory.DropDownItems;
                id = category.ID;
                ToolStripMenuItem toolStripMenuItem2 = CreateToolStripMenuItem(id.ToString(), category.Name, category.Icon == string.Empty ? (Image)null : Image.FromFile(category.Icon), new EventHandler(MoveToCategory_Click));
                dropDownItems2.Add((ToolStripItem)toolStripMenuItem2);
            }
        }

        private ToolStripMenuItem CreateToolStripMenuItem(string Name, string Text, Image Icon, EventHandler handler)
        {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Name = Name;
            toolStripMenuItem.Text = Text;
            toolStripMenuItem.ForeColor = Color.White;
            toolStripMenuItem.Image = Icon;
            toolStripMenuItem.Click += handler;
            return toolStripMenuItem;
        }

        private void MoveGameToCategory(int GameID, int CategoryID)
        {
            if (GameID == -1 || CategoryID == -1 || !_DB.MoveGameToCategory(GameID, CategoryID))
                return;
            LoadCategoryGames(_SelectedCategory);
        }

        private void RunGame(int GameID)
        {
            if (GameID == -1)
                return;
            Game gamesFromId = _DB.GetGamesFromID(GameID);
            string str = _DosBoxHelper.BuildArgs(false, gamesFromId, _AppSettings);
            if (str == null)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox(_translator.GetTranslatedMessage(_AppSettings.Language, 22, "DOSBox cannot be run (was it removed?)!"), _translator.GetTranslatedMessage(_AppSettings.Language, 23, "Run Game"), MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Error, false, false);
                customMessageBox.ShowDialog();
                customMessageBox.Dispose();
            }
            else
            {
                if (_AppSettings.ReduceToTrayOnPlay)
                {
                    notifyIcon.Visible = true;
                    notifyIcon.BalloonTipText = _translator.GetTranslatedMessage(_AppSettings.Language, 73, "DOSBox Manager is still running and will raise back once closing the game.");
                    notifyIcon.BalloonTipTitle = "DOSBox Manager";
                    notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon.ShowBalloonTip(500);
                    Hide();
                }
                Process process = new Process();
                process.StartInfo.WorkingDirectory = gamesFromId.Directory != string.Empty ? gamesFromId.Directory : _fileHelper.ExtractFilePath(gamesFromId.DOSExePath);
                process.StartInfo.FileName = _AppSettings.DosboxPath;
                process.StartInfo.Arguments = str;
                process.Start();
                process.WaitForExit();
                if (_AppSettings.ReduceToTrayOnPlay)
                {
                    notifyIcon.Visible = false;
                    Show();
                }
            }
        }

        private void OpenGameDialog(Game game, bool isEditing)
        {
            GameDialog gameDialog = new GameDialog(_translator, _AppSettings, game, isEditing);
            if (gameDialog.ShowDialog() != DialogResult.OK)
                return;
            game = gameDialog.GameData;
            if (_DB.SaveGame(game))
            {
                LoadCategoryGames(_SelectedCategory);
                UpdateStatusBar();
            }
            else
            {
                CustomMessageBox customMessageBox = new CustomMessageBox(_translator.GetTranslatedMessage(_AppSettings.Language, 24, "An issue raised while saving the game."), _translator.GetTranslatedMessage(_AppSettings.Language, 28, "Error"), MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Error, false, false);
                customMessageBox.ShowDialog();
                customMessageBox.Dispose();
            }
        }

        private void EditGame(int GameID)
        {
            try
            {
                Game gamesFromId = _DB.GetGamesFromID(GameID);
                if (gamesFromId == null)
                {
                    CustomMessageBox customMessageBox = new CustomMessageBox(_translator.GetTranslatedMessage(_AppSettings.Language, 25, "It is not possible to retrieve the information of the selected event!"), _translator.GetTranslatedMessage(_AppSettings.Language, 28, "Error"), MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Error, false, false);
                    customMessageBox.ShowDialog();
                    customMessageBox.Dispose();
                }
                else
                    OpenGameDialog(gamesFromId, true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void MakeGameConfigurationFile()
        {
            if (_SelectedGame == -1)
                return;
            Game gamesFromId = _DB.GetGamesFromID(_SelectedGame);
            if (_DosBoxHelper.MakeGamesConfiguration(_translator, _AppSettings, gamesFromId))
                _DB.SaveGame(gamesFromId);
        }

        private void EditGameConfigurationFile()
        {
            if (_SelectedGame == -1)
                return;
            if (_AppSettings.ConfigEditorPath != string.Empty)
            {
                if (File.Exists(_AppSettings.ConfigEditorPath))
                {
                    Process.Start(_AppSettings.ConfigEditorPath, _DB.GetGamesFromID(_SelectedGame).DBConfigPath + " " + _AppSettings.ConfigEditorAdditionalParameters);
                }
                else
                {
                    CustomMessageBox customMessageBox = new CustomMessageBox(_translator.GetTranslatedMessage(_AppSettings.Language, 26, "The application can't find the text editor set in the application configuration.") + "\n" + _translator.GetTranslatedMessage(_AppSettings.Language, 27, "Please amend the application settings to continue."), _translator.GetTranslatedMessage(_AppSettings.Language, 28, "Error"), MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Error, false, false);
                    customMessageBox.ShowDialog();
                    customMessageBox.Dispose();
                }
            }
            else
            {
                CustomMessageBox customMessageBox = new CustomMessageBox(_translator.GetTranslatedMessage(_AppSettings.Language, 29, "The text editor has not been set in the configuration file.") + "\n" + _translator.GetTranslatedMessage(_AppSettings.Language, 27, "Please amend the application settings to continue."), _translator.GetTranslatedMessage(_AppSettings.Language, 30, "Warning"), MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Warning, false, false);
                customMessageBox.ShowDialog();
                customMessageBox.Dispose();
            }
        }

        private void DeleteGame(int GameID)
        {
            string Body = _translator.GetTranslatedMessage(_AppSettings.Language, 31, "The text editor has not been set in the configuration file.") + "\n" + _translator.GetTranslatedMessage(_AppSettings.Language, 21, "Are you sure you want to continue?");
            string translatedMessage = _translator.GetTranslatedMessage(_AppSettings.Language, 8, "Attention");
            if (_AppSettings.GameDeletePrompt)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox(Body, translatedMessage, MessageBoxDialogButtons.YesNo, MessageBoxDialogIcon.Question, true, true);
                customMessageBox.ShowDialog();
                if (customMessageBox.Result == MessageBoxDialogResult.Yes)
                {
                    try
                    {
                        if (_DB.RemoveGame(GameID))
                        {
                            LoadCategoryGames(_SelectedCategory);
                            UpdateStatusBar();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                if (!customMessageBox.AskAgain)
                {
                    _AppSettings.GameDeletePrompt = false;
                    _SettingsDB.SaveSettings(_AppSettings);
                }
                customMessageBox.Dispose();
            }
            else if (_DB.RemoveGame(GameID))
            {
                LoadCategoryGames(_SelectedCategory);
                UpdateStatusBar();
            }
        }

        private void LoadFoundedGames(SearchEventArgs args)
        {
            RemoveGamesPanelHandlers();
            List<Game> games = _DB.SearchGames(args.Title, args.Year, args.Developer, args.CategoryID);
            List<Category> allCategories = _DB.GetAllCategories();
            if (catGames != null)
                catGames.Dispose();
            if (games != null)
            {
                catGames = new CategoryGames(_translator, _AppSettings, games, allCategories);
                catGames.BoxChangedSelection += new CategoryGames.BoxChangedSelectionDelegate(CategoryGame_BoxChangedSelection);
                catGames.BoxDoubleClick += new CategoryGames.BoxDoubleClickDelegate(CategoryGame_BoxDoubleClick);
                catGames.BoxEditClick += new CategoryGames.BoxEditClickDelegate(CategoryGame_BoxEditClick);
                catGames.BoxDeleteClick += new CategoryGames.BoxDeleteClickDelegate(CategoryGame_BoxDeleteClick);
                catGames.BoxRunClick += new CategoryGames.BoxRunClickDelegate(CategoryGame_BoxRunClick);
                catGames.BoxMoveToCategory += new CategoryGames.BoxMoveToCategoryDelegate(CategoryGame_BoxMoveToCategory);
            }
            else
                catGames = (CategoryGames)null;
            _SelectedGame = -1;
            pnlGames.Controls.Clear();
            pnlGames.Controls.Add((Control)catGames);
            if (games == null)
            {
                EnableGamesCommands(true, false);
                CustomMessageBox customMessageBox = new CustomMessageBox("No games found which satisfy the specified search parameters.", "Warning", MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Warning, false, false);
                customMessageBox.ShowDialog();
                customMessageBox.Dispose();
            }
            else
                EnableGamesCommands(true, true);
        }

        private void LoadCategoryGames(int CategoryID)
        {
            RemoveGamesPanelHandlers();
            List<Game> gamesForCategory = _DB.GetAllGamesForCategory(CategoryID);
            List<Category> allCategories = _DB.GetAllCategories();
            if (catGames != null)
                catGames.Dispose();
            catGames = new CategoryGames(_translator, _AppSettings, gamesForCategory, allCategories);
            catGames.BoxChangedSelection += new CategoryGames.BoxChangedSelectionDelegate(CategoryGame_BoxChangedSelection);
            catGames.BoxDoubleClick += new CategoryGames.BoxDoubleClickDelegate(CategoryGame_BoxDoubleClick);
            catGames.BoxEditClick += new CategoryGames.BoxEditClickDelegate(CategoryGame_BoxEditClick);
            catGames.BoxDeleteClick += new CategoryGames.BoxDeleteClickDelegate(CategoryGame_BoxDeleteClick);
            catGames.BoxRunClick += new CategoryGames.BoxRunClickDelegate(CategoryGame_BoxRunClick);
            catGames.BoxMoveToCategory += new CategoryGames.BoxMoveToCategoryDelegate(CategoryGame_BoxMoveToCategory);
            _SelectedGame = -1;
            pnlGames.Controls.Clear();
            pnlGames.Controls.Add((Control)catGames);
            if (gamesForCategory == null)
                EnableGamesCommands(true, false);
            else
                EnableGamesCommands(true, true);
        }

        private void RemoveGamesPanelHandlers()
        {
            if (pnlGames.Controls.Count <= 0)
                return;
            if (pnlGames.Controls[0].GetType() == typeof(CategoryGames))
            {
                ((CategoryGames)pnlGames.Controls[0]).BoxChangedSelection -= new CategoryGames.BoxChangedSelectionDelegate(CategoryGame_BoxChangedSelection);
                ((CategoryGames)pnlGames.Controls[0]).BoxDoubleClick -= new CategoryGames.BoxDoubleClickDelegate(CategoryGame_BoxDoubleClick);
                ((CategoryGames)pnlGames.Controls[0]).BoxEditClick -= new CategoryGames.BoxEditClickDelegate(CategoryGame_BoxEditClick);
                ((CategoryGames)pnlGames.Controls[0]).BoxDeleteClick -= new CategoryGames.BoxDeleteClickDelegate(CategoryGame_BoxDeleteClick);
                ((CategoryGames)pnlGames.Controls[0]).BoxRunClick -= new CategoryGames.BoxRunClickDelegate(CategoryGame_BoxRunClick);
                ((CategoryGames)pnlGames.Controls[0]).BoxMoveToCategory -= new CategoryGames.BoxMoveToCategoryDelegate(CategoryGame_BoxMoveToCategory);
            }
            else if (!(pnlGames.Controls[0].GetType() == typeof(SearchGames)))
            { }
        }

        private void RefreshCategories()
        {
            List<Category> allCategories = _DB.GetAllCategories();
            if (catGames != null)
                catGames.Categories = allCategories;
            categoriesTabs.ClearTabs();
            EnableGamesCommands(false, false);
            if (allCategories == null)
                return;
            int num = -1;
            foreach (Category category in allCategories)
            {
                Image TabIcon = category.Icon == string.Empty ? null : Image.FromFile(category.Icon);
                categoriesTabs.AddTab(category.ID, category.Name, TabIcon, false);
                if (category.IsSelected)
                    num = category.ID;
            }
            categoriesTabs.AddTab(-100, _translator.GetTranslatedMessage(_AppSettings.Language, 74, "Search Games"), DosBox_Manager.Properties.Resources.magnifier, true);
            categoriesTabs.SelectTab(num == -1 ? allCategories[0].ID : num);
            AddMovetoCategoryMenu(allCategories);
        }
        #endregion

        #region "Private Initializing Methods"
        private void UpdateStatusBar()
        {
            statusStrip.Items.Clear();
            AddStatusBarDB(_DB.DBName);
            AddStatusBarCategoriesCount(_DB.GetCategoriesCount());
            AddStatusBarGamesCount(_DB.GetTotalGamesCount());
        }

        private void AddStatusBarGamesCount(int GamesCount)
        {
            ToolStripLabel toolStripLabel = new ToolStripLabel(string.Format(_translator.GetTranslatedMessage(_AppSettings.Language, 32, "Available Games: {0}"), (object)GamesCount), DosBox_Manager.Properties.Resources.game_monitor);
            toolStripLabel.ForeColor = Color.White;
            statusStrip.Items.Add((ToolStripItem)toolStripLabel);
        }

        private void AddStatusBarDB(string DBName)
        {
            ToolStripLabel toolStripLabel = new ToolStripLabel(string.Format(_translator.GetTranslatedMessage(_AppSettings.Language, 33, "Database: {0}"), (object)DBName), DosBox_Manager.Properties.Resources.database);
            toolStripLabel.ForeColor = Color.White;
            statusStrip.Items.Add((ToolStripItem)toolStripLabel);
        }

        private void AddStatusBarCategoriesCount(int CatsCount)
        {
            ToolStripLabel toolStripLabel = new ToolStripLabel(string.Format(_translator.GetTranslatedMessage(_AppSettings.Language, 34, "Available Categories: {0}"), (object)CatsCount), DosBox_Manager.Properties.Resources.brick);
            toolStripLabel.ForeColor = Color.White;
            statusStrip.Items.Add((ToolStripItem)toolStripLabel);
        }

        private void InitializeGUIEventsHandlers()
        {
            categoriesTabs.TabChanged += new CategoriesTabs.TabChangedDelegate(categoriesTabs_TabChanged);
        }

        private void SetupUI()
        {
            if (_AppSettings.AppFullscreen)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.Width = _AppSettings.AppWidth;
                this.Height = _AppSettings.AppHeight;
            }
            menuStrip.Visible = _AppSettings.MenuBarVisible;
            toolStrip.Visible = _AppSettings.ToolbarVisible;
            statusStrip.Visible = _AppSettings.StatusBarVisible;
            AddRecentDBs();
            InitializeStripsContextMenu();
            _translator.TranslateUI(_AppSettings.Language, this.Name, this.Controls);
        }

        private void InitializeStripsContextMenu()
        {
            cms = new ContextMenuStrip();
            MenuBar_cms = new ToolStripMenuItem(_translator.GetTranslatedMessage(_AppSettings.Language, 3, "Show Menu bar"));
            ToolBar_cms = new ToolStripMenuItem(_translator.GetTranslatedMessage(_AppSettings.Language, 4, "Show Toolbar"));
            StatusBar_cms = new ToolStripMenuItem(_translator.GetTranslatedMessage(_AppSettings.Language, 5, "Show Status bar"));
            MenuBar_cms.Click += new EventHandler(MenuBar_CMS_Click);
            ToolBar_cms.Click += new EventHandler(ToolBar_CMS_Click);
            StatusBar_cms.Click += new EventHandler(StatusBar_CMS_Click);
            MenuBar_cms.Checked = _AppSettings.MenuBarVisible;
            ToolBar_cms.Checked = _AppSettings.ToolbarVisible;
            StatusBar_cms.Checked = _AppSettings.StatusBarVisible;
            cms.Items.Add((ToolStripItem)MenuBar_cms);
            cms.Items.Add((ToolStripItem)ToolBar_cms);
            cms.Items.Add((ToolStripItem)StatusBar_cms);
            menuStrip.ContextMenuStrip = cms;
            toolStrip.ContextMenuStrip = cms;
            statusStrip.ContextMenuStrip = cms;
        }

        private void EnableDBCommands(bool enabled)
        {
            closeDatabaseToolStripMenuItem.Enabled = enabled;
            openDatabaseToolStripMenuItem.Enabled = !enabled;
            createDatabaseToolStripMenuItem.Enabled = !enabled;
            tsbAddDatabase.Enabled = !enabled;
            tsbOpenDatabase.Enabled = !enabled;
            tsbDisconnectDatabase.Enabled = enabled;
        }

        private void EnableMenus(bool enabled)
        {
            EnableDBCommands(enabled);
            EnableCategoriesCommands(enabled);
            EnableGamesCommands(enabled, enabled);
        }

        private void EnableCategoriesCommands(bool enabled)
        {
            categoriesToolStripMenuItem.Enabled = enabled;
            tsbNewCategory.Enabled = enabled;
            tsbEditCategory.Enabled = enabled;
            tsbDeleteCategory.Enabled = enabled;
        }

        private void EnableGamesCommands(bool addEnabled, bool enabled)
        {
            if (_SelectedGame != -1)
            {
                editGameToolStripMenuItem.Enabled = enabled;
                deleteGameToolStripMenuItem.Enabled = enabled;
                runGameToolStripMenuItem.Enabled = enabled;
                editGameConfigurationToolStripMenuItem.Enabled = enabled;
                makeGameConfigurationToolStripMenuItem.Enabled = enabled;
                moveToCategoryToolStripMenuItem.Enabled = enabled;
                tsbEditGame.Enabled = enabled;
                tsbDeleteGame.Enabled = enabled;
                tsbRunGame.Enabled = enabled;
                tsbGameConfig.Enabled = enabled;
                tsbMakeGameConfigFile.Enabled = enabled;
                tsbMoveToCategory.Enabled = enabled;
            }
            else
            {
                editGameToolStripMenuItem.Enabled = false;
                deleteGameToolStripMenuItem.Enabled = false;
                runGameToolStripMenuItem.Enabled = false;
                editGameConfigurationToolStripMenuItem.Enabled = false;
                makeGameConfigurationToolStripMenuItem.Enabled = false;
                moveToCategoryToolStripMenuItem.Enabled = false;
                tsbEditGame.Enabled = false;
                tsbDeleteGame.Enabled = false;
                tsbRunGame.Enabled = false;
                tsbGameConfig.Enabled = false;
                tsbMakeGameConfigFile.Enabled = false;
                tsbMoveToCategory.Enabled = false;
            }
            addGameToolStripMenuItem.Enabled = addEnabled;
            tsbAddGame.Enabled = addEnabled;
            if (!addEnabled && !enabled)
                gamesToolStripMenuItem.Enabled = false;
            else
                gamesToolStripMenuItem.Enabled = addEnabled;
        }

        private void InitializeStyle()
        {
            menuStrip.RenderMode = ToolStripRenderMode.Professional;
            menuStrip.Renderer = new ToolStripProfessionalRenderer(new MyMenuRenderer());
            toolStrip.Renderer = new MyToolStripRenderer();
            categoriesTabs.TabTextAlign = ContentAlignment.MiddleCenter;
        }
        #endregion

        #region "Recent Database Handling"
        private void RecentDatabaseItemClickHandler(object sender, EventArgs e)
        {
            string text = ((ToolStripItem)sender).Text;
            if (_DB != null && _DB.ConnectionStatus == ConnectionState.Open)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox(_translator.GetTranslatedMessage(_AppSettings.Language, 9, "You are already connected to another database.") + "\n" + _translator.GetTranslatedMessage(_AppSettings.Language, 11, "Do you want to close the previous database and open the selected one?"), _translator.GetTranslatedMessage(_AppSettings.Language, 8, "Attention"), MessageBoxDialogButtons.YesNo, MessageBoxDialogIcon.Question, false, false);
                customMessageBox.ShowDialog();
                if (customMessageBox.Result == MessageBoxDialogResult.Yes)
                    OpenRecentDatabase(text, true);
                customMessageBox.Dispose();
            }
            else
                OpenRecentDatabase(text, false);
        }

        private void OpenRecentDatabase(string dbPath, bool closePreviousConnection)
        {
            if (!File.Exists(dbPath))
            {
                CustomMessageBox customMessageBox = new CustomMessageBox(_translator.GetTranslatedMessage(_AppSettings.Language, 7, "We are not able to find the selected database inside this computer.") + "\n" + _translator.GetTranslatedMessage(_AppSettings.Language, 10, "Do you want to remove it from the list?"), _translator.GetTranslatedMessage(_AppSettings.Language, 8, "Attention"), MessageBoxDialogButtons.YesNo, MessageBoxDialogIcon.Question, false, false);
                customMessageBox.ShowDialog();
                if (customMessageBox.Result == MessageBoxDialogResult.Yes)
                {
                    MessageBox.Show("TO BE IMPLEMENTED");
                }
                customMessageBox.Dispose();
            }
            else
            {
                if (closePreviousConnection)
                    _DB.Disconnect();
                if (!_DB.Connect(dbPath))
                {
                    CustomMessageBox customMessageBox = new CustomMessageBox(_translator.GetTranslatedMessage(_AppSettings.Language, 6, "It has not been possible to open the database!"), _translator.GetTranslatedMessage(_AppSettings.Language, 30, "Warning"), MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Warning, false, false);
                    customMessageBox.ShowDialog();
                    customMessageBox.Dispose();
                }
                else
                {
                    _SettingsDB.AddToRecentDatabases(dbPath);
                    UpdateStatusBar();
                    EnableMenus(true);
                    RefreshCategories();
                }
            }
        }

        private void AddRecentDBs()
        {
            if (_recentDBs == null || _recentDBs.Count <= 0)
                return;
            int index1 = 4;
            if (_flgRecentAdded)
            {
                fileToolStripMenuItem.DropDownItems.RemoveAt(index1);
                for (int index2 = 0; index2 < _recentDBs.Count; ++index2)
                    fileToolStripMenuItem.DropDownItems.RemoveAt(index1);
            }
            else
                _flgRecentAdded = true;
            fileToolStripMenuItem.DropDownItems.Insert(index1, (ToolStripItem)new ToolStripSeparator());
            foreach (RecentDatabase recentDatabase in _recentDBs.Values)
                fileToolStripMenuItem.DropDownItems.Insert(index1, (ToolStripItem)CreateToolStripMenuItem("recentDB" + recentDatabase.ID.ToString(), recentDatabase.DBPath, DosBox_Manager.Properties.Resources.database_refresh, new EventHandler(RecentDatabaseItemClickHandler)));
        }
        #endregion

        #region "Events Handling"
        #region "Toolstrip Menu Items"
        private void createDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDatabase();
        }

        private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDatabase();
        }

        private void closeDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisconnectDatabase();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettingsDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseApplication();
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCategory();
        }

        private void editCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCategory();
        }

        private void deleteCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCategory();
        }

        private void addGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void editGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditGame(_SelectedGame);
        }

        private void runGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunGame(_SelectedGame);
        }

        private void deleteGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteGame(_SelectedGame);
        }

        private void makeGameConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeGameConfigurationFile();
        }

        private void editGameConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditGameConfigurationFile();
        }
        #endregion

        #region "Toolbar Items"
        private void tsbAddDatabase_Click(object sender, EventArgs e)
        {
            CreateDatabase();
        }

        private void tsbOpenDatabase_Click(object sender, EventArgs e)
        {
            OpenDatabase();
        }

        private void tsbDisconnectDatabase_Click(object sender, EventArgs e)
        {
            DisconnectDatabase();
        }

        private void tsbNewCategory_Click(object sender, EventArgs e)
        {
            NewCategory();
        }

        private void tsbEditCategory_Click(object sender, EventArgs e)
        {
            EditCategory();
        }

        private void tsbDeleteCategory_Click(object sender, EventArgs e)
        {
            DeleteCategory();
        }

        private void tsbRunGame_Click(object sender, EventArgs e)
        {
            RunGame(_SelectedGame);
        }

        private void tsbAddGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void tsbEditGame_Click(object sender, EventArgs e)
        {
            EditGame(_SelectedGame);
        }

        private void tsbGameConfig_Click(object sender, EventArgs e)
        {
            EditGameConfigurationFile();
        }

        private void tsbMakeGameConfigFile_Click(object sender, EventArgs e)
        {
            MakeGameConfigurationFile();
        }

        private void tsbDeleteGame_Click(object sender, EventArgs e)
        {
            DeleteGame(_SelectedGame);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseApplication();
        }

        private void tsbSettings_Click(object sender, EventArgs e)
        {
            OpenSettingsDialog();
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            AboutDialog();
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _SettingsDB.SaveSettings(_AppSettings);
            _SettingsDB.Disconnect();
            _DB.Disconnect();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (_flgLoading)
                return;
            if (WindowState == FormWindowState.Maximized)
            {
                _AppSettings.AppFullscreen = true;
            }
            else
            {
                _AppSettings.AppFullscreen = false;
                _AppSettings.AppWidth = Width;
                _AppSettings.AppHeight = Height;
            }
        }

        private void statusStrip_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Gray, 0, 0, statusStrip.Width, 0);
        }

        private void CategoryGame_BoxMoveToCategory(object sender, int GameID, int CategoryID)
        {
            MoveGameToCategory(GameID, CategoryID);
        }

        private void CategoryGame_BoxRunClick(object sender, int GameID)
        {
            RunGame(GameID);
        }

        private void CategoryGame_BoxDeleteClick(object sender, int GameID)
        {
            DeleteGame(GameID);
        }

        private void CategoryGame_BoxEditClick(object sender, int GameID)
        {
            EditGame(GameID);
        }

        private void CategoryGame_BoxDoubleClick(object sender, int GameID)
        {
            _SelectedGame = GameID;
            EnableGamesCommands(true, true);
            RunGame(_SelectedGame);
        }

        private void CategoryGame_BoxChangedSelection(object sender, int GameID, int PreviousGameID)
        {
            _SelectedGame = GameID;
            EnableGamesCommands(true, true);
        }

        private void categoriesTabs_TabChanged(object sender, int CategoryID, int PreviousID)
        {
            if (_SelectedCategory == CategoryID)
                return;
            EnableCategoriesCommands(true);
            tableLayoutPanel.RowStyles[1].Height = 0.0f;
            _SelectedCategory = CategoryID;
            _DB.SwitchExpandedStatus(PreviousID, CategoryID);
            LoadCategoryGames(_SelectedCategory);
        }

        private void categoriesTabs_SearchSelected(object sender)
        {
            EnableGamesCommands(false, false);
            EnableCategoriesCommands(false);
            RemoveGamesPanelHandlers();
            _SelectedCategory = -1;
            SearchGames searchGamesPanel = new SearchGames(_translator, _AppSettings, _DB.GetAllCategories());
            searchGamesPanel.SearchCommitted += new SearchGames.SearchCommittedDelegate(search_SearchCommitted);
            pnlGames.Controls.Clear();
            tableLayoutPanel.RowStyles[1].Height = 160f;
            pnlSearch.Controls.Clear();
            pnlSearch.Controls.Add(searchGamesPanel);
        }

        private void search_SearchCommitted(object sender, SearchEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            LoadFoundedGames(e);
            Cursor = Cursors.Default;
        }

        private void MoveToCategory_Click(object sender, EventArgs e)
        {
            if (_SelectedGame == -1)
                return;
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            if (toolStripMenuItem != null)
                MoveGameToCategory(_SelectedGame, Convert.ToInt32(toolStripMenuItem.Name));
        }

        private void MenuBar_CMS_Click(object sender, EventArgs e)
        {
            if (menuStrip.Visible)
            {
                MenuBar_cms.Checked = false;
                menuStrip.Visible = false;
            }
            else
            {
                MenuBar_cms.Checked = true;
                menuStrip.Visible = true;
            }
            _AppSettings.MenuBarVisible = menuStrip.Visible;
        }

        private void ToolBar_CMS_Click(object sender, EventArgs e)
        {
            if (toolStrip.Visible)
            {
                ToolBar_cms.Checked = false;
                toolStrip.Visible = false;
            }
            else
            {
                ToolBar_cms.Checked = true;
                toolStrip.Visible = true;
            }
            _AppSettings.ToolbarVisible = toolStrip.Visible;
        }

        private void StatusBar_CMS_Click(object sender, EventArgs e)
        {
            if (statusStrip.Visible)
            {
                StatusBar_cms.Checked = false;
                statusStrip.Visible = false;
            }
            else
            {
                StatusBar_cms.Checked = true;
                statusStrip.Visible = true;
            }
            _AppSettings.StatusBarVisible = statusStrip.Visible;
        }
        #endregion
    }
}
