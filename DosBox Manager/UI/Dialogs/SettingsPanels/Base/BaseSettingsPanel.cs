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

namespace DosBox_Manager.UI.Dialogs.SettingsPanels.Base
{
    public partial class BaseSettingsPanel : UserControl
    {
        #region "Declarations"
        protected TranslationsHelpers _translator;
        protected Settings _AppSettings;
        private string _PanelName;
        protected bool _flgInitiation;
        #endregion

        #region "Properties"
        public string PanelName
        {
            get
            {
                return this._PanelName;
            }
            set
            {
                this._PanelName = value;
                this.Invalidate();
            }
        }   
        #endregion

        #region "Constructors"
        public BaseSettingsPanel()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public BaseSettingsPanel(AppManager manager, string PanelName)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            _AppSettings = manager.AppSettings;
            _translator = manager.Translator;
            this.PanelName = PanelName;
        }
        #endregion

        #region "Routines Override"
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Font font = new Font(this.Font.FontFamily, 16f, FontStyle.Italic);
            SizeF sizeF = e.Graphics.MeasureString(this._PanelName, font);
            e.Graphics.DrawString(_PanelName, font, Brushes.White, new RectangleF((float)(this.Width / 2) - sizeF.Width / 2f, 0.0f, (float)(this.Width / 2) + sizeF.Width / 2f, 30f));
            e.Graphics.DrawLine(new Pen(Color.FromArgb(100, 100, 100)), 0, 30, this.Width, 30);
        }
        #endregion
    }
}
