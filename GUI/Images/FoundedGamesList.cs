using Helpers.Data.Objects.MyAbandonwareData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Scrollbar;
using System.Drawing;

namespace GUI.Images
{
    public partial class FoundedGamesList : Panel
    {
        #region "Declarations"
        private List<FoundedGameCard> _gameCards = null;
        private List<MyAbandonGameFound> _games = null;

        private int _countItems = 0;
        private int _currentlySelected = 0;

        private ScrollBarEx scroller;

        #region "Events"
        public delegate void GameSelectedDelegate(object sender, MyAbandonGameFound game);
        public event GameSelectedDelegate GameSelected;

        public delegate void GameDoubleClickDelegate(object sender, MyAbandonGameFound game);
        public event GameDoubleClickDelegate GameDoubleClick;
        #endregion
        #endregion

        #region "Properties"
        public List<MyAbandonGameFound> Games
        {
            get { return _games; }
            set
            {
                _games = value;
                InitializeControls();
            }
        }
        #endregion

        #region "Constructors"
        public FoundedGamesList()
        {
            InitializeComponent();

            SetupComponent();
        }

        public FoundedGamesList(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            SetupComponent();
        }

        public FoundedGamesList(List<MyAbandonGameFound> Games)
        {
            InitializeComponent();

            SetupComponent();

            _games = Games;

            InitializeControls();
        }
        #endregion

        #region "Methods"
        #region "Private"
        private void SetupComponent()
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }

        private void InitializeControls()
        {
            if (_games != null)
            {
                if (_gameCards == null)
                    _gameCards = new List<FoundedGameCard>();

                this.Clear();

                _countItems = 0;
                foreach (MyAbandonGameFound game in _games)
                {
                    FoundedGameCard card = new FoundedGameCard();
                    SetupCard(card);
                    card.GameData = game;
                    card.Tag = _countItems;
                    card.IsSelected = (_countItems == 0);
                    card.Visible = true;
                   
                    _currentlySelected = 0;

                    this.Controls.Add(card);
                    _gameCards.Add(card);

                    _countItems++;
                }

                //Now checking if it is necessary to add the scrollbar
                if ((_gameCards.Count * 150) > this.Height)
                {
                    scroller = new ScrollBarEx();
                    scroller.BringToFront();
                    scroller.Orientation = ScrollBarOrientation.Vertical;
                    scroller.BorderColor = Color.FromArgb(64, 64, 64);
                    scroller.Dock = DockStyle.Right;
                    scroller.Visible = true;
                    scroller.Maximum = (_gameCards.Count - 1) * 85;
                    scroller.Scroll += scroller_Scroll;
                    this.MouseWheel += cards_MouseWheel;
                    this.Controls.Add(scroller);
                }
                else if (scroller != null)
                {
                    scroller.Scroll -= scroller_Scroll;
                    scroller.Dispose();
                    scroller = null;
                }
            }
        }

        private void SetupCard(FoundedGameCard card)
        {
            card.Width = this.Width - 22;
            card.Height = 85;
            card.Top = _countItems * 85;

            card.MouseEnter += card_MouseEnter;
            card.FoundedGameCardClick += card_FoundedGameCardClick;
            card.FoundedGameCardDoubleClick += card_FoundedGameCardDoubleClick;
        }

        #endregion

        #region "Public"
        public void Clear()
        {
            if (_gameCards != null)
                _gameCards.Clear();

            foreach (FoundedGameCard card in this.Controls)
            {
                card.MouseEnter -= card_MouseEnter;
                card.FoundedGameCardClick -= card_FoundedGameCardClick;
            }

            this.Controls.Clear();

        }
        #endregion
        #endregion

        #region "Control Events Handling"
        private void cards_MouseWheel(object sender, MouseEventArgs e)
        {
            if (scroller == null)
                return;
            if (scroller.Value - e.Delta < scroller.Minimum)
                scroller.Value = scroller.Minimum;
            else if (scroller.Value - e.Delta > scroller.Maximum)
                scroller.Value = scroller.Maximum;
            else
                scroller.Value -= e.Delta;
        }

        private void scroller_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue == -1)
                return;

            foreach (Control c in this.Controls)
                c.Top -= (e.NewValue - e.OldValue);

        }

        void card_FoundedGameCardClick(object sender)
        {
            FoundedGameCard fgc = (FoundedGameCard)sender;

            if (GameSelected != null)
                GameSelected(this, fgc.GameData);

            if (Convert.ToInt32(fgc.Tag) != _currentlySelected)
            {
                _gameCards[_currentlySelected].IsSelected = false;
                fgc.IsSelected = true;
                _currentlySelected = Convert.ToInt32(fgc.Tag);
            }
        }

        void card_FoundedGameCardDoubleClick(object sender)
        {
            FoundedGameCard fgc = (FoundedGameCard)sender;

            if (GameDoubleClick != null)
                GameDoubleClick(this, fgc.GameData);

            if (Convert.ToInt32(fgc.Tag) != _currentlySelected)
            {
                _gameCards[_currentlySelected].IsSelected = false;
                fgc.IsSelected = true;
                _currentlySelected = Convert.ToInt32(fgc.Tag);
            }
        }

        void card_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }
        #endregion
    }
}
