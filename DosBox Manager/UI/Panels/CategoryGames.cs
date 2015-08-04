﻿/*
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
using GUI.Scrollbar;
using Helpers.Data.Objects;
using Helpers.Translation;
using GUI.Boxes;
using GUI.Menus.MenuStripRenderer;
using DosBox_Manager.Business;

namespace DosBox_Manager.UI.Panels
{
    public partial class CategoryGames : GamesPanelsBase
    {
        #region "Declarations"
        private ContextMenuStrip cms;
        private ToolStripMenuItem edit_game_cms;
        private ToolStripMenuItem delete_game_cms;
        private ToolStripMenuItem run_game_cms;
        private ToolStripMenuItem move_to_cat;
        private int _previousGameID;
        private ScrollBarEx scroller;
        #endregion

        #region "Events Declarations"
        public delegate void BoxChangedSelectionDelegate(object sender, int GameID, int PreviousGameID);
        public event BoxChangedSelectionDelegate BoxChangedSelection;

        public delegate void BoxDoubleClickDelegate(object sender, int GameID);
        public event BoxDoubleClickDelegate BoxDoubleClick;

        public delegate void BoxEditClickDelegate(object sender, int GameID);
        public event BoxEditClickDelegate BoxEditClick;

        public delegate void BoxDeleteClickDelegate(object sender, int GameID);
        public event BoxDeleteClickDelegate BoxDeleteClick;

        public delegate void BoxRunClickDelegate(object sender, int GameID);
        public event BoxRunClickDelegate BoxRunClick;

        public delegate void BoxMoveToCategoryDelegate(object sender, int GameID, int CategoryID);
        public event BoxMoveToCategoryDelegate BoxMoveToCategory;
        #endregion

        #region "Properties"
        public override List<Category> Categories
        {
            set
            {
                if (_cats == value)
                    return;
                _cats = value;
                UpdateUI();
            }
        }
        #endregion

        #region "Constructors / Distructors"
        public CategoryGames(AppManager manager)
            : base(manager)
        {
            InitializeComponent();
            _previousGameID = -1;
            scroller = null;
        }

        public CategoryGames(AppManager manager, List<Game> games, List<Category> cats)
            : base(manager, games, cats)
        {
            InitializeComponent();
            _previousGameID = -1;
            scroller = null;
            UpdateUI();
        }

        ~CategoryGames()
        {
            if (edit_game_cms != null)
            {
                edit_game_cms.Click -= new EventHandler(edit_game_cms_Click);
                edit_game_cms.Dispose();
            }
            if (delete_game_cms != null)
            {
                delete_game_cms.Click -= new EventHandler(delete_game_cms_Click);
                delete_game_cms.Dispose();
            }
            if (run_game_cms != null)
            {
                run_game_cms.Click -= new EventHandler(run_game_cms_Click);
                run_game_cms.Dispose();
            }
            if (cms == null)
                return;
            cms.Dispose();
        }
        #endregion

        #region "Methods Override"
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateUI();
        }

        public override void UpdateUI()
        {
            Controls.Clear();
            int num1 = (Width - 20) / 100;
            int num2 = Height / 150;
            int num3 = 0;
            int num4 = 0;
            if (_games == null || _games.Count <= 0)
                return;
            int num5 = 0;
            foreach (Game game in _games)
            {
                GameBox gameBox = new GameBox(_settings.BoxRendered);
                gameBox.BoxSelected += new GameBox.BoxSelectedDelegate(Box_BoxSelected);
                gameBox.BoxDoubleClick += new GameBox.BoxDoubleClickDelegate(Box_BoxDoubleClick);
                gameBox.ContextMenuStrip = CreateGameContextMenu(game.ID);
                gameBox.GameName = game.Title;
                int num6 = game.ImagePath == null ? 0 : (!(game.ImagePath == string.Empty) ? 1 : 0);
                gameBox.GameImage = num6 != 0 ? Image.FromFile(game.ImagePath) : (Image)null;
                gameBox.GameID = game.ID;
                gameBox.Top = num3 * 150 + (num3 == 0 ? 0 : 5);
                gameBox.Left = num5;
                num5 += gameBox.Width;
                this.Controls.Add((Control)gameBox);
                ++num4;
                if (num4 >= num1)
                {
                    num4 = 0;
                    ++num3;
                    num5 = 0;
                }
            }
            if (num3 + 1 > num2)
            {
                scroller = new ScrollBarEx();
                scroller.Orientation = ScrollBarOrientation.Vertical;
                scroller.BorderColor = Color.FromArgb(64, 64, 64);
                scroller.Dock = DockStyle.Right;
                scroller.Visible = true;
                scroller.Maximum = num2 * 150;
                scroller.Scroll += new ScrollEventHandler(scroller_Scroll);
                MouseWheel += new MouseEventHandler(CategoryGames_MouseWheel);
                this.Controls.Add((Control)scroller);
            }
            else if (scroller != null)
            {
                scroller.Scroll -= new ScrollEventHandler(scroller_Scroll);
                scroller.Dispose();
                scroller = (ScrollBarEx)null;
            }
            this.Focus();
        }
        #endregion

        #region "Controls Events"
        private void CategoryGames_MouseWheel(object sender, MouseEventArgs e)
        {
            if (scroller == null)
                return;
            if (scroller.Value + e.Delta < scroller.Minimum)
                scroller.Value = scroller.Minimum;
            else if (scroller.Value + e.Delta > scroller.Maximum)
                scroller.Value = scroller.Maximum;
            else
                scroller.Value += e.Delta;
        }

        private void scroller_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue == -1)
                return;
            MoveUI(e.NewValue - e.OldValue);
        }
        #endregion

        #region "Public Methods"
        public void CleanSelectedBox(int SkipGameID)
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(GameBox))
                {
                    GameBox gameBox = (GameBox)control;
                    if (SkipGameID != -1)
                    {
                        if (gameBox.GameID != SkipGameID)
                            gameBox.IsSelected = false;
                    }
                    else
                        gameBox.IsSelected = false;
                }
            }
        }
        #endregion

        #region "Box Events"
        public void Box_BoxSelected(object sender, int GameID)
        {
            if (BoxChangedSelection == null || _previousGameID == GameID)
                return;
            CleanSelectedBox(GameID);
            BoxChangedSelection(this, GameID, _previousGameID);
            _previousGameID = GameID;
        }

        private void Box_BoxDoubleClick(object sender, int GameID)
        {
            if (BoxDoubleClick == null)
                return;
            CleanSelectedBox(GameID);
            BoxDoubleClick(this, GameID);
            _previousGameID = GameID;
        }
        #endregion

        #region "Private Methods"
        private void MoveUI(int delta)
        {
            foreach (Control control in this.Controls)
                control.Top -= delta;
        }

        private ContextMenuStrip CreateGameContextMenu(int GameID)
        {
            cms = new ContextMenuStrip();
            cms.BackColor = Color.FromArgb(50, 50, 50);
            cms.RenderMode = ToolStripRenderMode.Professional;
            cms.Renderer = (ToolStripRenderer)new ToolStripProfessionalRenderer((ProfessionalColorTable)new MyMenuRenderer());
            edit_game_cms = new ToolStripMenuItem(_translator.GetTranslatedMessage(_settings.Language, 39, "Edit Game"), DosBox_Manager.Properties.Resources.controller_edit);
            delete_game_cms = new ToolStripMenuItem(_translator.GetTranslatedMessage(_settings.Language, 62, "Delete Game"), DosBox_Manager.Properties.Resources.controller_delete);
            run_game_cms = new ToolStripMenuItem(_translator.GetTranslatedMessage(_settings.Language, 23, "Run Game"), DosBox_Manager.Properties.Resources.control_play_blue);
            edit_game_cms.Click += new EventHandler(edit_game_cms_Click);
            edit_game_cms.Tag = GameID.ToString();
            edit_game_cms.ForeColor = Color.White;
            delete_game_cms.Click += new EventHandler(delete_game_cms_Click);
            delete_game_cms.Tag = GameID.ToString();
            delete_game_cms.ForeColor = Color.White;
            run_game_cms.Click += new EventHandler(run_game_cms_Click);
            run_game_cms.Tag = GameID.ToString();
            run_game_cms.ForeColor = Color.White;
            cms.Items.Add((ToolStripItem)edit_game_cms);
            cms.Items.Add((ToolStripItem)delete_game_cms);
            cms.Items.Add((ToolStripItem)run_game_cms);
            cms.Items.Add((ToolStripItem)new ToolStripSeparator());
            move_to_cat = new ToolStripMenuItem(_translator.GetTranslatedMessage(_settings.Language, 63, "Move to Category..."));
            move_to_cat.BackColor = Color.FromArgb(50, 50, 50);
            move_to_cat.ForeColor = Color.White;
            move_to_cat.Tag = GameID.ToString();
            move_to_cat.Image = DosBox_Manager.Properties.Resources.brick_go;
            ToolStripMenuItem[] toolStripMenuItemArray = new ToolStripMenuItem[_cats.Count];
            for (int index = 0; index < _cats.Count; ++index)
            {
                toolStripMenuItemArray[index] = new ToolStripMenuItem();
                toolStripMenuItemArray[index].Name = "move_to_" + _cats[index].Name;
                toolStripMenuItemArray[index].Text = _cats[index].Name;
                toolStripMenuItemArray[index].Tag = GameID.ToString() + "|" + _cats[index].ID.ToString();
                toolStripMenuItemArray[index].BackColor = Color.FromArgb(50, 50, 50);
                toolStripMenuItemArray[index].ForeColor = Color.White;
                toolStripMenuItemArray[index].Image = _cats[index].Icon != string.Empty ? Image.FromFile(_cats[index].Icon) : (Image)null;
                toolStripMenuItemArray[index].Click += new EventHandler(move_to_cat_Click);
            }
            move_to_cat.DropDownItems.AddRange((ToolStripItem[])toolStripMenuItemArray);
            cms.Items.Add((ToolStripItem)move_to_cat);
            return cms;
        }
        #endregion

        #region "Context Menu Events"
        private void move_to_cat_Click(object sender, EventArgs e)
        {
            if (BoxMoveToCategory == null)
                return;
            string[] strArray = ((ToolStripItem)sender).Tag.ToString().Split('|');
            BoxMoveToCategory(this, Convert.ToInt32(strArray[0]), Convert.ToInt32(strArray[1]));
        }

        private void run_game_cms_Click(object sender, EventArgs e)
        {
            if (BoxRunClick == null)
                return;
            BoxRunClick(this, Convert.ToInt32(((ToolStripItem)sender).Tag));
        }

        private void delete_game_cms_Click(object sender, EventArgs e)
        {
            if (BoxDeleteClick == null)
                return;
            BoxDeleteClick(this, Convert.ToInt32(((ToolStripItem)sender).Tag));
        }

        private void edit_game_cms_Click(object sender, EventArgs e)
        {
            if (BoxEditClick == null)
                return;
            BoxEditClick(this, Convert.ToInt32(((ToolStripItem)sender).Tag));
        }
        #endregion

    }
}
