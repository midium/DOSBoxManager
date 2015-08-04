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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.MessageBoxes
{
    #region "Enums"
    public enum MessageBoxDialogButtons
    {
        YesNo,
        OkCancel,
        CommitCancel,
        Ok
    };

    public enum MessageBoxDialogIcon
    {
        Information,
        Question,
        Warning,
        Error,
        Fatal
    };

    public enum MessageBoxDialogResult
    {
        Yes,
        Ok,
        Commit,
        No,
        Cancel
    };
    #endregion

    public partial class CustomMessageBox : Form
    {
        
        #region "Declarations"
        private readonly string _description;
        private readonly string _title;
        private readonly MessageBoxDialogButtons _buttons;
        private readonly MessageBoxDialogIcon _icon;

        private MessageBoxDialogResult _result;
        #endregion

        #region "Properties"
        public MessageBoxDialogResult Result
        {
            get { return _result; }
        }

        public bool AskAgain
        {
            get { return chkAskAgain.Checked; }
        }
        #endregion

        #region "Constructor"
        public CustomMessageBox(string Body, string Title, MessageBoxDialogButtons buttons, MessageBoxDialogIcon icon, bool ShowAskAgain, bool AskAgain)
        {
            InitializeComponent();

            _title = Title;
            _description = Body;
            _buttons = buttons;
            _icon = icon;

            chkAskAgain.Checked = AskAgain;
            chkAskAgain.Visible = ShowAskAgain;

            Populate();

        }
        #endregion

        #region "UI Generator"
        void Populate(){

            //Title of the dialog
            this.Text = _title;

            //Internal title and description
            lblTitle.Text = _title;
            lblBody.Text = _description;

            //Icons
            switch(_icon){
                case MessageBoxDialogIcon.Error:
                    pctImage.Image = GUI.Properties.Resources.error_round;
                    break;

                case MessageBoxDialogIcon.Warning:
                    pctImage.Image = GUI.Properties.Resources.alert_round;
                    break;

                case MessageBoxDialogIcon.Information:
                    pctImage.Image = GUI.Properties.Resources.info_round;
                    break;

                case MessageBoxDialogIcon.Question:
                    pctImage.Image = GUI.Properties.Resources.question_round;
                    break;

                case MessageBoxDialogIcon.Fatal:
                    pctImage.Image = GUI.Properties.Resources.critical_round;
                    break;

            }

            //Buttons
            switch(_buttons){

                case MessageBoxDialogButtons.Ok:

                    btnOK.Text = "Ok";

                    btnCancel.Visible = false;

                    btnOK.Tag = MessageBoxDialogResult.Ok;
                    btnOK.DialogResult = DialogResult.OK;
                    break;

                case MessageBoxDialogButtons.OkCancel:

                    btnOK.Text = "Ok";
                    btnCancel.Text = "Cancel";

                    btnOK.Tag = MessageBoxDialogResult.Ok;
                    btnOK.DialogResult = DialogResult.OK;
                    btnCancel.Tag = MessageBoxDialogResult.Cancel;
                    btnCancel.DialogResult = DialogResult.Cancel;
                    break;

                case MessageBoxDialogButtons.YesNo:

                    btnOK.Text = "Yes";
                    btnCancel.Text = "No";

                    btnOK.Tag = MessageBoxDialogResult.Yes;
                    btnOK.DialogResult = DialogResult.Yes;
                    btnCancel.Tag = MessageBoxDialogResult.No;
                    btnCancel.DialogResult = DialogResult.No;
                    break;

                case MessageBoxDialogButtons.CommitCancel:

                    btnOK.Text = "Commit";
                    btnCancel.Text = "Cancel";

                    btnOK.Tag = MessageBoxDialogResult.Commit;
                    btnOK.DialogResult = DialogResult.OK;
                    btnCancel.Tag = MessageBoxDialogResult.Cancel;
                    btnCancel.DialogResult = DialogResult.Cancel;
                    break;

            }
        }
        #endregion

        #region "Form Controls Events Handling"
        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine( Pens.LightGray, 0, 0, this.Width, 0);
            e.Graphics.DrawLine(Pens.LightGray, 0, pnlContent.Height - 1, this.Width, pnlContent.Height - 1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _result = (MessageBoxDialogResult)btnOK.Tag;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _result = (MessageBoxDialogResult)btnCancel.Tag;
            this.Close();
        }
        #endregion
    }
}
