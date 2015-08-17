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
using GUI.Menus.MenuStripRenderer;
using Helpers.Business;

namespace GUI.Tabs
{
    public partial class CategoriesTabs : UserControl
    {
        #region "Declarations"
        public delegate void TabChangedDelegate(object sender, int CategoryID, int PreviousID);
        public event TabChangedDelegate TabChanged;

        public delegate void SearchSelectedDelegate(object sender);
        public event SearchSelectedDelegate SearchSelected;

        private Dictionary<int, RadioButton> _tabs = null;
        protected int _currentID;

        private AppManager _manager = null;

        //Control Setup
        private int _TabHeight = 30;
        private ContentAlignment _TabImageAlign = ContentAlignment.MiddleLeft;
        private ContentAlignment _TabTextAlign = ContentAlignment.MiddleRight;
        private Pen _TabBorderColor = Pens.Gray;
        private Color _TabForeColor = Color.White;
        private Color _TabBackgroundColor = Color.FromArgb(50, 50, 50);
        private Color _TabHoverColor = Color.FromArgb(64, 64, 64);

        //Context menu
        private ContextMenuStrip cms;
        private ToolStripMenuItem new_cat_cms;
        private ToolStripMenuItem edit_cat_cms;
        private ToolStripMenuItem delete_cat_cms;

        #region "Event Declaration"
        public delegate void CategoryEditClickDelegate(object sender, int CategoryID);
        public event CategoryEditClickDelegate CategoryEditClick;

        public delegate void CategoryDeleteClickDelegate(object sender, int CategoryID);
        public event CategoryDeleteClickDelegate CategoryDeleteClick;

        public delegate void CategoryCreateClickDelegate(object sender);
        public event CategoryCreateClickDelegate CategoryCreateClick;
        #endregion
        #endregion

        #region "Context Menu Creation"
        private ContextMenuStrip CreateGameContextMenu(int CategoryID)
        {
            cms = new ContextMenuStrip();
            cms.BackColor = Color.FromArgb(50, 50, 50);
            cms.RenderMode = ToolStripRenderMode.Professional;
            cms.Renderer = (ToolStripRenderer)new ToolStripProfessionalRenderer(new MyMenuRenderer());
            if (_manager != null)
            {
                edit_cat_cms = new ToolStripMenuItem(_manager.Translator.GetTranslatedMessage(_manager.AppSettings.Language, 36, "Edit Category"), GUI.Properties.Resources.brick_edit);
                delete_cat_cms = new ToolStripMenuItem(_manager.Translator.GetTranslatedMessage(_manager.AppSettings.Language, 79, "Delete Category"), Properties.Resources.brick_delete);
                new_cat_cms = new ToolStripMenuItem(_manager.Translator.GetTranslatedMessage(_manager.AppSettings.Language, 35, " Add New Category"), Properties.Resources.brick_add);
            }
            else
            {
                edit_cat_cms = new ToolStripMenuItem("Edit Category", GUI.Properties.Resources.brick_edit );
                delete_cat_cms = new ToolStripMenuItem("Delete Category", GUI.Properties.Resources.brick_delete);
                new_cat_cms = new ToolStripMenuItem("Add New Category", GUI.Properties.Resources.brick_add);
            }
            edit_cat_cms.Click += new EventHandler(edit_cat_cms_Click);
            edit_cat_cms.Tag = CategoryID.ToString();
            edit_cat_cms.ForeColor = Color.White;
            delete_cat_cms.Click += new EventHandler(delete_cat_cms_Click);
            delete_cat_cms.Tag = CategoryID.ToString();
            delete_cat_cms.ForeColor = Color.White;
            new_cat_cms.Click += new EventHandler(new_cat_cms_Click);
            new_cat_cms.Tag = CategoryID.ToString();
            new_cat_cms.ForeColor = Color.White;
            cms.Items.Add((ToolStripItem)new_cat_cms);
            cms.Items.Add((ToolStripItem)edit_cat_cms);
            cms.Items.Add((ToolStripItem)delete_cat_cms);

            return cms;
        }

        private void new_cat_cms_Click(object sender, EventArgs e)
        {
            if (CategoryCreateClick != null)
                CategoryCreateClick(this);
        }

        private void delete_cat_cms_Click(object sender, EventArgs e)
        {
            if (CategoryDeleteClick != null)
                CategoryDeleteClick(this, Convert.ToInt32(((ToolStripItem)sender).Tag));
        }

        private void edit_cat_cms_Click(object sender, EventArgs e)
        {
            if (CategoryEditClick != null)
                CategoryEditClick(this, Convert.ToInt32(((ToolStripItem)sender).Tag));
        }
        #endregion

        #region "Constructor"
        public CategoriesTabs()
        {
            InitializeComponent();

            _TabHeight = 30;
            _TabImageAlign = ContentAlignment.MiddleLeft;
            _TabTextAlign = ContentAlignment.MiddleRight;

            _currentID = -1;
            _tabs = new Dictionary<int, RadioButton>();

            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

        }
        #endregion

        #region "Public Methods"
        public void RefreshTabs()
        {
            SetupUI();
        }

        public void ClearTabs()
        {
            if (_tabs != null)
            {
                _tabs.Clear();
                this.Controls.Clear();
            }
        }

        public void AddTab(int TabID, string TabText, Image TabIcon, bool isSearch = false)
        {
            if (_tabs.ContainsKey(TabID))
            {
                //Key already set, not possible
                throw new Exception("There is already a tab with the same ID!");
            }
            else
            {
                //Key does not exist, add it
                _tabs.Add(TabID, CreateTabItem(TabID, TabText, TabIcon, isSearch));

                SetupUI();
            }

        }

        public void RemoveTab(int TabID)
        {
            if (_tabs.ContainsKey(TabID))
            {
                _tabs.Remove(TabID);

                SetupUI();
            }
            else
            {
                throw new Exception("There is no tab with the given ID!");
            }
        }

        public void SelectTab(int TabID)
        {
            foreach (int itm in _tabs.Keys)
            {
                if (TabID == itm)
                {
                    _tabs[itm].Checked = true;
                    break;
                }
            }
        }
        #endregion

        #region "Tab Events Handling"
        private void tabButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (_currentID.ToString() != rdb.Name)
            {
                if (TabChanged != null)
                {
                    TabChanged(this, Convert.ToInt32(rdb.Name), _currentID);
                }
                _currentID = Convert.ToInt32(rdb.Name);
            }
        }
        #endregion

        #region "Private Methods"
        private void SetupUI()
        {
            int index = 0;
            this.Controls.Clear();

            foreach (RadioButton itm in _tabs.Values)
            {
                itm.Left = 0;
                itm.Top = (itm.Tag.ToString() == "1") ? this.Height - _TabHeight - 1 : (index * _TabHeight) - (index * 1);
                itm.Width = this.Width;

                if (itm.Tag.ToString() == string.Empty || itm.Tag.ToString() == "0")
                {
                    itm.CheckedChanged += tabButton_CheckedChanged;
                    itm.Anchor = AnchorStyles.Left & AnchorStyles.Top & AnchorStyles.Right;
                } 
                else
                {
                    itm.CheckedChanged += Search_CheckedChanged;
                    itm.Anchor = AnchorStyles.Left & AnchorStyles.Bottom & AnchorStyles.Right;
                }
                this.Controls.Add(itm);
                index++;
            }
        }

        private void Search_CheckedChanged(object sender, EventArgs e)
        {
            _currentID = -100;
            if (SearchSelected != null)
                SearchSelected(this);
        }

        private void UpdateUI()
        {
            if (_tabs != null)
            {
                int index = 0;
                foreach (RadioButton itm in _tabs.Values)
                {
                    itm.Left = 0;
                    itm.Top = (itm.Tag.ToString() == "1") ? this.Height - _TabHeight - 1 : ((index * _TabHeight) - (index * 1));
                    itm.Width = this.Width;
                    itm.TextAlign = TabTextAlign;

                    itm.Anchor = (itm.Tag.ToString() == "1") ? AnchorStyles.Left & AnchorStyles.Bottom : AnchorStyles.Left & AnchorStyles.Top;

                    itm.ImageAlign = TabImageAlign;
                    index++;
                }
            }
        }

        private RadioButton CreateTabItem(int TabID, string TabText, Image TabIcon, bool isSearch = false)
        {
            RadioButton btn = new RadioButton();
            SetButtonStyle(btn);

            btn.Text = TabText;
            btn.Image = TabIcon;
            btn.Name = TabID.ToString();
            btn.Tag = (isSearch) ? "1" : "0";

            if (!isSearch)
                btn.ContextMenuStrip = CreateGameContextMenu(TabID);

            return btn;
        }

        private void SetButtonStyle(RadioButton btn)
        {
            btn.BackColor = _TabBackgroundColor;
            btn.ForeColor = _TabForeColor;
            btn.Anchor = AnchorStyles.Top & AnchorStyles.Bottom & AnchorStyles.Left;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Appearance = Appearance.Button;
            btn.ImageAlign = _TabImageAlign;
            btn.TextAlign = _TabTextAlign;
            btn.Size = new Size(this.Width-2, _TabHeight);
            btn.AllowDrop = base.AllowDrop;
            btn.Cursor = Cursors.Hand;

            btn.Paint += btn_Paint;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateUI();
        }

        private void btn_Paint(object sender, PaintEventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            e.Graphics.DrawRectangle(_TabBorderColor, new Rectangle(0, 0, btn.Width - 1, btn.Height - 1));

        }
        #endregion

        #region "Properties"
        public AppManager Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }

        public int Count
        {
            get
            {
                return _tabs.Count;
            }
            set
            {
            }
        }

        public bool HasChildren
        {
            get
            {
                return (_tabs.Count > 0);
            }
            set
            {
            }
        }

        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }
            set
            {
                base.AllowDrop = value;

                UpdateUI();
            }
        }

        public RadioButton SelectedTab
        {
            get
            {
                foreach (RadioButton itm in _tabs.Values)
                {
                    if (itm.Checked) return itm;
                }

                return null;
            }
            set
            {

            }
        }

        public int TabHeight
        {
            get { return _TabHeight; }
            set
            {
                if (value != _TabHeight)
                {
                    _TabHeight = value;
                    UpdateUI();
                }
            }
        }

        public ContentAlignment TabImageAlign
        {
            get { return _TabImageAlign; }
            set
            {
                if (value != _TabImageAlign)
                {
                    _TabImageAlign = value;
                    UpdateUI();
                }
            }
        }

        public ContentAlignment TabTextAlign
        {
            get { return _TabTextAlign; }
            set
            {
                if (value != _TabTextAlign)
                {
                    _TabTextAlign = value;
                    UpdateUI();
                }
            }
        }

        public Pen TabBorderColor
        {
            get { return _TabBorderColor; }
            set { 
                _TabBorderColor = value;
                this.Invalidate();
            }
        }

        public Color TabBackgroundColor
        {
            get { return _TabBackgroundColor; }
            set { 
                _TabBackgroundColor = value;
                this.Invalidate();
            }
        }

        public Color TabHoverColor
        {
            get { return _TabHoverColor; }
            set
            {
                _TabHoverColor = value;
                this.Invalidate();
            }
        }

        public Color TabForeColor
        {
            get { return _TabForeColor; }
            set
            {
                _TabForeColor = value;
                this.Invalidate();
            }
        }
        #endregion
    }
}
