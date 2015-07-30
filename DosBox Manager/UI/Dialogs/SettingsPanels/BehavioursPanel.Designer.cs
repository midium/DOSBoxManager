using System.Drawing;
using System.Windows.Forms;
using DosBox_Manager.UI.Dialogs.SettingsPanels.Base;
namespace DosBox_Manager.UI.Dialogs.SettingsPanels
{
    partial class BehavioursPanel : BaseSettingsPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TextBox txtAdditionalCommands;
        private Label lblEditorAdditionalCommands;
        private TextBox txtTextEditor;
        private Label lblTextEditor;
        private Button btnTextEditor;
        private Button btnSearchTextEditor;
        private CheckBox chkRememberSize;
        private Panel pnlShowOptions;
        private CheckBox chkStatusBar;
        private CheckBox chkToolbar;
        private CheckBox chkMenuBar;
        private Label lblShow;
        private Panel pnlPromptOptions;
        private CheckBox chkPromptGame;
        private CheckBox chkCategoryDelete;
        private Label lblPromptBefore;
        private ComboBox cboLanguage;
        private Label lblLanguage;
        private CheckBox chkReload;
        private Button btnEditTranslation;
        private CheckBox chkToTrayOnPlay;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEditTranslation = new System.Windows.Forms.Button();
            this.btnSearchTextEditor = new System.Windows.Forms.Button();
            this.btnTextEditor = new System.Windows.Forms.Button();
            this.chkReload = new System.Windows.Forms.CheckBox();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.pnlPromptOptions = new System.Windows.Forms.Panel();
            this.chkPromptGame = new System.Windows.Forms.CheckBox();
            this.chkCategoryDelete = new System.Windows.Forms.CheckBox();
            this.lblPromptBefore = new System.Windows.Forms.Label();
            this.pnlShowOptions = new System.Windows.Forms.Panel();
            this.chkStatusBar = new System.Windows.Forms.CheckBox();
            this.chkToolbar = new System.Windows.Forms.CheckBox();
            this.chkMenuBar = new System.Windows.Forms.CheckBox();
            this.lblShow = new System.Windows.Forms.Label();
            this.chkRememberSize = new System.Windows.Forms.CheckBox();
            this.txtAdditionalCommands = new System.Windows.Forms.TextBox();
            this.lblEditorAdditionalCommands = new System.Windows.Forms.Label();
            this.txtTextEditor = new System.Windows.Forms.TextBox();
            this.lblTextEditor = new System.Windows.Forms.Label();
            this.chkToTrayOnPlay = new System.Windows.Forms.CheckBox();
            this.pnlPromptOptions.SuspendLayout();
            this.pnlShowOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEditTranslation
            // 
            this.btnEditTranslation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditTranslation.Image = global::DosBox_Manager.Properties.Resources.comment_edit;
            this.btnEditTranslation.Location = new System.Drawing.Point(199, 357);
            this.btnEditTranslation.Name = "btnEditTranslation";
            this.btnEditTranslation.Size = new System.Drawing.Size(24, 24);
            this.btnEditTranslation.TabIndex = 39;
            this.btnEditTranslation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditTranslation.UseVisualStyleBackColor = true;
            this.btnEditTranslation.Click += new System.EventHandler(this.btnEditTranslation_Click);
            // 
            // btnSearchTextEditor
            // 
            this.btnSearchTextEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchTextEditor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchTextEditor.Image = global::DosBox_Manager.Properties.Resources.drive_magnify;
            this.btnSearchTextEditor.Location = new System.Drawing.Point(811, 66);
            this.btnSearchTextEditor.Name = "btnSearchTextEditor";
            this.btnSearchTextEditor.Size = new System.Drawing.Size(24, 24);
            this.btnSearchTextEditor.TabIndex = 28;
            this.btnSearchTextEditor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchTextEditor.UseVisualStyleBackColor = true;
            this.btnSearchTextEditor.Click += new System.EventHandler(this.btnSearchTextEditor_Click);
            // 
            // btnTextEditor
            // 
            this.btnTextEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTextEditor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTextEditor.Image = global::DosBox_Manager.Properties.Resources.magnifier;
            this.btnTextEditor.Location = new System.Drawing.Point(811, 39);
            this.btnTextEditor.Name = "btnTextEditor";
            this.btnTextEditor.Size = new System.Drawing.Size(24, 24);
            this.btnTextEditor.TabIndex = 25;
            this.btnTextEditor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTextEditor.UseVisualStyleBackColor = true;
            this.btnTextEditor.Click += new System.EventHandler(this.btnTextEditor_Click);
            // 
            // chkReload
            // 
            this.chkReload.AutoSize = true;
            this.chkReload.Location = new System.Drawing.Point(282, 123);
            this.chkReload.Name = "chkReload";
            this.chkReload.Size = new System.Drawing.Size(200, 17);
            this.chkReload.TabIndex = 38;
            this.chkReload.Text = "Start with latest opened database";
            this.chkReload.UseVisualStyleBackColor = true;
            this.chkReload.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // cboLanguage
            // 
            this.cboLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboLanguage.ForeColor = System.Drawing.Color.White;
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Location = new System.Drawing.Point(74, 358);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(119, 21);
            this.cboLanguage.TabIndex = 35;
            this.cboLanguage.SelectedIndexChanged += new System.EventHandler(this.cboLanguage_SelectedIndexChanged);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(7, 361);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(61, 13);
            this.lblLanguage.TabIndex = 36;
            this.lblLanguage.Text = "Language:";
            // 
            // pnlPromptOptions
            // 
            this.pnlPromptOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPromptOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPromptOptions.Controls.Add(this.chkPromptGame);
            this.pnlPromptOptions.Controls.Add(this.chkCategoryDelete);
            this.pnlPromptOptions.Controls.Add(this.lblPromptBefore);
            this.pnlPromptOptions.Location = new System.Drawing.Point(6, 275);
            this.pnlPromptOptions.Name = "pnlPromptOptions";
            this.pnlPromptOptions.Size = new System.Drawing.Size(799, 77);
            this.pnlPromptOptions.TabIndex = 34;
            // 
            // chkPromptGame
            // 
            this.chkPromptGame.AutoSize = true;
            this.chkPromptGame.Location = new System.Drawing.Point(60, 45);
            this.chkPromptGame.Name = "chkPromptGame";
            this.chkPromptGame.Size = new System.Drawing.Size(110, 17);
            this.chkPromptGame.TabIndex = 2;
            this.chkPromptGame.Text = "Deleting a game";
            this.chkPromptGame.UseVisualStyleBackColor = true;
            this.chkPromptGame.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkCategoryDelete
            // 
            this.chkCategoryDelete.AutoSize = true;
            this.chkCategoryDelete.Location = new System.Drawing.Point(60, 22);
            this.chkCategoryDelete.Name = "chkCategoryDelete";
            this.chkCategoryDelete.Size = new System.Drawing.Size(126, 17);
            this.chkCategoryDelete.TabIndex = 1;
            this.chkCategoryDelete.Text = "Deleting a category";
            this.chkCategoryDelete.UseVisualStyleBackColor = true;
            this.chkCategoryDelete.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // lblPromptBefore
            // 
            this.lblPromptBefore.AutoSize = true;
            this.lblPromptBefore.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromptBefore.Location = new System.Drawing.Point(0, 1);
            this.lblPromptBefore.Name = "lblPromptBefore";
            this.lblPromptBefore.Size = new System.Drawing.Size(90, 13);
            this.lblPromptBefore.TabIndex = 0;
            this.lblPromptBefore.Text = "Prompt before...";
            // 
            // pnlShowOptions
            // 
            this.pnlShowOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlShowOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShowOptions.Controls.Add(this.chkStatusBar);
            this.pnlShowOptions.Controls.Add(this.chkToolbar);
            this.pnlShowOptions.Controls.Add(this.chkMenuBar);
            this.pnlShowOptions.Controls.Add(this.lblShow);
            this.pnlShowOptions.Location = new System.Drawing.Point(6, 169);
            this.pnlShowOptions.Name = "pnlShowOptions";
            this.pnlShowOptions.Size = new System.Drawing.Size(799, 100);
            this.pnlShowOptions.TabIndex = 33;
            // 
            // chkStatusBar
            // 
            this.chkStatusBar.AutoSize = true;
            this.chkStatusBar.Location = new System.Drawing.Point(60, 68);
            this.chkStatusBar.Name = "chkStatusBar";
            this.chkStatusBar.Size = new System.Drawing.Size(78, 17);
            this.chkStatusBar.TabIndex = 3;
            this.chkStatusBar.Text = "Status Bar";
            this.chkStatusBar.UseVisualStyleBackColor = true;
            this.chkStatusBar.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkToolbar
            // 
            this.chkToolbar.AutoSize = true;
            this.chkToolbar.Location = new System.Drawing.Point(60, 45);
            this.chkToolbar.Name = "chkToolbar";
            this.chkToolbar.Size = new System.Drawing.Size(65, 17);
            this.chkToolbar.TabIndex = 2;
            this.chkToolbar.Text = "Toolbar";
            this.chkToolbar.UseVisualStyleBackColor = true;
            this.chkToolbar.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkMenuBar
            // 
            this.chkMenuBar.AutoSize = true;
            this.chkMenuBar.Location = new System.Drawing.Point(60, 22);
            this.chkMenuBar.Name = "chkMenuBar";
            this.chkMenuBar.Size = new System.Drawing.Size(76, 17);
            this.chkMenuBar.TabIndex = 1;
            this.chkMenuBar.Text = "Menu Bar";
            this.chkMenuBar.UseVisualStyleBackColor = true;
            this.chkMenuBar.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // lblShow
            // 
            this.lblShow.AutoSize = true;
            this.lblShow.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShow.Location = new System.Drawing.Point(0, 1);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(44, 13);
            this.lblShow.TabIndex = 0;
            this.lblShow.Text = "Show...";
            // 
            // chkRememberSize
            // 
            this.chkRememberSize.AutoSize = true;
            this.chkRememberSize.Location = new System.Drawing.Point(6, 123);
            this.chkRememberSize.Name = "chkRememberSize";
            this.chkRememberSize.Size = new System.Drawing.Size(147, 17);
            this.chkRememberSize.TabIndex = 29;
            this.chkRememberSize.Text = "Remember window size";
            this.chkRememberSize.UseVisualStyleBackColor = true;
            this.chkRememberSize.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // txtAdditionalCommands
            // 
            this.txtAdditionalCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdditionalCommands.Location = new System.Drawing.Point(6, 95);
            this.txtAdditionalCommands.Name = "txtAdditionalCommands";
            this.txtAdditionalCommands.Size = new System.Drawing.Size(799, 22);
            this.txtAdditionalCommands.TabIndex = 27;
            this.txtAdditionalCommands.TextChanged += new System.EventHandler(this.txtAdditionalCommands_TextChanged);
            // 
            // lblEditorAdditionalCommands
            // 
            this.lblEditorAdditionalCommands.AutoSize = true;
            this.lblEditorAdditionalCommands.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditorAdditionalCommands.Location = new System.Drawing.Point(3, 79);
            this.lblEditorAdditionalCommands.Name = "lblEditorAdditionalCommands";
            this.lblEditorAdditionalCommands.Size = new System.Drawing.Size(296, 13);
            this.lblEditorAdditionalCommands.TabIndex = 26;
            this.lblEditorAdditionalCommands.Text = "Additional parameters to use with the editor (optional):";
            // 
            // txtTextEditor
            // 
            this.txtTextEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextEditor.Location = new System.Drawing.Point(6, 54);
            this.txtTextEditor.Name = "txtTextEditor";
            this.txtTextEditor.Size = new System.Drawing.Size(799, 22);
            this.txtTextEditor.TabIndex = 24;
            this.txtTextEditor.TextChanged += new System.EventHandler(this.txtTextEditor_TextChanged);
            // 
            // lblTextEditor
            // 
            this.lblTextEditor.AutoSize = true;
            this.lblTextEditor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextEditor.Location = new System.Drawing.Point(3, 38);
            this.lblTextEditor.Name = "lblTextEditor";
            this.lblTextEditor.Size = new System.Drawing.Size(364, 13);
            this.lblTextEditor.TabIndex = 23;
            this.lblTextEditor.Text = "Open DOSBox configuration file with the following editor (optional):";
            // 
            // chkToTrayOnPlay
            // 
            this.chkToTrayOnPlay.AutoSize = true;
            this.chkToTrayOnPlay.Location = new System.Drawing.Point(6, 146);
            this.chkToTrayOnPlay.Name = "chkToTrayOnPlay";
            this.chkToTrayOnPlay.Size = new System.Drawing.Size(181, 17);
            this.chkToTrayOnPlay.TabIndex = 40;
            this.chkToTrayOnPlay.Text = "Minimize to Tray while playing";
            this.chkToTrayOnPlay.UseVisualStyleBackColor = true;
            this.chkToTrayOnPlay.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // BehavioursPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkToTrayOnPlay);
            this.Controls.Add(this.btnEditTranslation);
            this.Controls.Add(this.chkReload);
            this.Controls.Add(this.cboLanguage);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.pnlPromptOptions);
            this.Controls.Add(this.pnlShowOptions);
            this.Controls.Add(this.chkRememberSize);
            this.Controls.Add(this.btnSearchTextEditor);
            this.Controls.Add(this.txtAdditionalCommands);
            this.Controls.Add(this.lblEditorAdditionalCommands);
            this.Controls.Add(this.btnTextEditor);
            this.Controls.Add(this.txtTextEditor);
            this.Controls.Add(this.lblTextEditor);
            this.Name = "BehavioursPanel";
            this.Size = new System.Drawing.Size(841, 862);
            this.pnlPromptOptions.ResumeLayout(false);
            this.pnlPromptOptions.PerformLayout();
            this.pnlShowOptions.ResumeLayout(false);
            this.pnlShowOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
