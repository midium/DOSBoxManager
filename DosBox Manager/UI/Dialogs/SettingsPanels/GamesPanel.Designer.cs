using System.Drawing;
using System.Windows.Forms;
using DosBox_Manager.UI.Dialogs.SettingsPanels.Base;
namespace DosBox_Manager.UI.Dialogs.SettingsPanels
{
    partial class GamesPanel : BaseSettingsPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button btnDefaultGamesFolder;
        private TextBox txtDefaultGamesFolder;
        private Label lblDefaultGamesFolder;
        private Button btnDefaultImagesFolder;
        private TextBox txtDefaultImagesFolder;
        private Label lblDefaultCDPath;
        private TextBox txtAdditionalCommands;
        private Label lblAdditionalDosBoxCommands;
        private Panel pnlOtherOptions;
        private CheckBox chkQuitOnExit;
        private CheckBox chkFullscreen;
        private CheckBox chkNoConsole;
        private Label lblOtherNewGameOptions;
        private CheckBox chk3DBox;


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
            this.btnDefaultGamesFolder = new System.Windows.Forms.Button();
            this.txtDefaultGamesFolder = new System.Windows.Forms.TextBox();
            this.lblDefaultGamesFolder = new System.Windows.Forms.Label();
            this.btnDefaultImagesFolder = new System.Windows.Forms.Button();
            this.txtDefaultImagesFolder = new System.Windows.Forms.TextBox();
            this.lblDefaultCDPath = new System.Windows.Forms.Label();
            this.txtAdditionalCommands = new System.Windows.Forms.TextBox();
            this.lblAdditionalDosBoxCommands = new System.Windows.Forms.Label();
            this.pnlOtherOptions = new System.Windows.Forms.Panel();
            this.chkQuitOnExit = new System.Windows.Forms.CheckBox();
            this.chkFullscreen = new System.Windows.Forms.CheckBox();
            this.chkNoConsole = new System.Windows.Forms.CheckBox();
            this.lblOtherNewGameOptions = new System.Windows.Forms.Label();
            this.chk3DBox = new System.Windows.Forms.CheckBox();
            this.pnlOtherOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDefaultGamesFolder
            // 
            this.btnDefaultGamesFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefaultGamesFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDefaultGamesFolder.Image = global::DosBox_Manager.Properties.Resources.folder_search;
            this.btnDefaultGamesFolder.Location = new System.Drawing.Point(812, 53);
            this.btnDefaultGamesFolder.Name = "btnDefaultGamesFolder";
            this.btnDefaultGamesFolder.Size = new System.Drawing.Size(24, 24);
            this.btnDefaultGamesFolder.TabIndex = 17;
            this.btnDefaultGamesFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDefaultGamesFolder.UseVisualStyleBackColor = true;
            this.btnDefaultGamesFolder.Click += new System.EventHandler(this.btnDefaultGamesFolder_Click);
            // 
            // txtDefaultGamesFolder
            // 
            this.txtDefaultGamesFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefaultGamesFolder.Location = new System.Drawing.Point(6, 54);
            this.txtDefaultGamesFolder.Name = "txtDefaultGamesFolder";
            this.txtDefaultGamesFolder.Size = new System.Drawing.Size(800, 22);
            this.txtDefaultGamesFolder.TabIndex = 16;
            this.txtDefaultGamesFolder.TextChanged += new System.EventHandler(this.txtDefaultGamesFolder_TextChanged);
            // 
            // lblDefaultGamesFolder
            // 
            this.lblDefaultGamesFolder.AutoSize = true;
            this.lblDefaultGamesFolder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefaultGamesFolder.Location = new System.Drawing.Point(3, 38);
            this.lblDefaultGamesFolder.Name = "lblDefaultGamesFolder";
            this.lblDefaultGamesFolder.Size = new System.Drawing.Size(260, 13);
            this.lblDefaultGamesFolder.TabIndex = 15;
            this.lblDefaultGamesFolder.Text = "Default folder to open when looking for a game:";
            // 
            // btnDefaultImagesFolder
            // 
            this.btnDefaultImagesFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefaultImagesFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDefaultImagesFolder.Image = global::DosBox_Manager.Properties.Resources.folder_search;
            this.btnDefaultImagesFolder.Location = new System.Drawing.Point(812, 94);
            this.btnDefaultImagesFolder.Name = "btnDefaultImagesFolder";
            this.btnDefaultImagesFolder.Size = new System.Drawing.Size(24, 24);
            this.btnDefaultImagesFolder.TabIndex = 20;
            this.btnDefaultImagesFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDefaultImagesFolder.UseVisualStyleBackColor = true;
            this.btnDefaultImagesFolder.Click += new System.EventHandler(this.btnDefaultImagesFolder_Click);
            // 
            // txtDefaultImagesFolder
            // 
            this.txtDefaultImagesFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefaultImagesFolder.Location = new System.Drawing.Point(6, 95);
            this.txtDefaultImagesFolder.Name = "txtDefaultImagesFolder";
            this.txtDefaultImagesFolder.Size = new System.Drawing.Size(800, 22);
            this.txtDefaultImagesFolder.TabIndex = 19;
            this.txtDefaultImagesFolder.TextChanged += new System.EventHandler(this.txtDefaultImagesFolder_TextChanged);
            // 
            // lblDefaultCDPath
            // 
            this.lblDefaultCDPath.AutoSize = true;
            this.lblDefaultCDPath.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefaultCDPath.Location = new System.Drawing.Point(3, 79);
            this.lblDefaultCDPath.Name = "lblDefaultCDPath";
            this.lblDefaultCDPath.Size = new System.Drawing.Size(399, 13);
            this.lblDefaultCDPath.TabIndex = 18;
            this.lblDefaultCDPath.Text = "Default folder to open when looking for image file (such as CD image files):";
            // 
            // txtAdditionalCommands
            // 
            this.txtAdditionalCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdditionalCommands.Location = new System.Drawing.Point(6, 136);
            this.txtAdditionalCommands.Name = "txtAdditionalCommands";
            this.txtAdditionalCommands.Size = new System.Drawing.Size(800, 22);
            this.txtAdditionalCommands.TabIndex = 22;
            this.txtAdditionalCommands.TextChanged += new System.EventHandler(this.txtAdditionalCommands_TextChanged);
            // 
            // lblAdditionalDosBoxCommands
            // 
            this.lblAdditionalDosBoxCommands.AutoSize = true;
            this.lblAdditionalDosBoxCommands.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdditionalDosBoxCommands.Location = new System.Drawing.Point(3, 120);
            this.lblAdditionalDosBoxCommands.Name = "lblAdditionalDosBoxCommands";
            this.lblAdditionalDosBoxCommands.Size = new System.Drawing.Size(357, 13);
            this.lblAdditionalDosBoxCommands.TabIndex = 21;
            this.lblAdditionalDosBoxCommands.Text = "Additional DOSBox commands for each new game (-c \"command\"):";
            // 
            // pnlOtherOptions
            // 
            this.pnlOtherOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOtherOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOtherOptions.Controls.Add(this.chkQuitOnExit);
            this.pnlOtherOptions.Controls.Add(this.chkFullscreen);
            this.pnlOtherOptions.Controls.Add(this.chkNoConsole);
            this.pnlOtherOptions.Controls.Add(this.lblOtherNewGameOptions);
            this.pnlOtherOptions.Location = new System.Drawing.Point(6, 164);
            this.pnlOtherOptions.Name = "pnlOtherOptions";
            this.pnlOtherOptions.Size = new System.Drawing.Size(800, 52);
            this.pnlOtherOptions.TabIndex = 32;
            // 
            // chkQuitOnExit
            // 
            this.chkQuitOnExit.AutoSize = true;
            this.chkQuitOnExit.Location = new System.Drawing.Point(284, 21);
            this.chkQuitOnExit.Name = "chkQuitOnExit";
            this.chkQuitOnExit.Size = new System.Drawing.Size(89, 17);
            this.chkQuitOnExit.TabIndex = 3;
            this.chkQuitOnExit.Text = "Quit On Exit";
            this.chkQuitOnExit.UseVisualStyleBackColor = true;
            this.chkQuitOnExit.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkFullscreen
            // 
            this.chkFullscreen.AutoSize = true;
            this.chkFullscreen.Location = new System.Drawing.Point(181, 21);
            this.chkFullscreen.Name = "chkFullscreen";
            this.chkFullscreen.Size = new System.Drawing.Size(78, 17);
            this.chkFullscreen.TabIndex = 2;
            this.chkFullscreen.Text = "Fullscreen";
            this.chkFullscreen.UseVisualStyleBackColor = true;
            this.chkFullscreen.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // chkNoConsole
            // 
            this.chkNoConsole.AutoSize = true;
            this.chkNoConsole.Location = new System.Drawing.Point(64, 21);
            this.chkNoConsole.Name = "chkNoConsole";
            this.chkNoConsole.Size = new System.Drawing.Size(86, 17);
            this.chkNoConsole.TabIndex = 1;
            this.chkNoConsole.Text = "No Console";
            this.chkNoConsole.UseVisualStyleBackColor = true;
            this.chkNoConsole.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // lblOtherNewGameOptions
            // 
            this.lblOtherNewGameOptions.AutoSize = true;
            this.lblOtherNewGameOptions.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtherNewGameOptions.Location = new System.Drawing.Point(0, 1);
            this.lblOtherNewGameOptions.Name = "lblOtherNewGameOptions";
            this.lblOtherNewGameOptions.Size = new System.Drawing.Size(180, 13);
            this.lblOtherNewGameOptions.TabIndex = 0;
            this.lblOtherNewGameOptions.Text = "Other options for each new game";
            // 
            // chk3DBox
            // 
            this.chk3DBox.AutoSize = true;
            this.chk3DBox.Location = new System.Drawing.Point(6, 222);
            this.chk3DBox.Name = "chk3DBox";
            this.chk3DBox.Size = new System.Drawing.Size(139, 17);
            this.chk3DBox.TabIndex = 33;
            this.chk3DBox.Text = "Render 3D Games Box";
            this.chk3DBox.UseVisualStyleBackColor = true;
            this.chk3DBox.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // GamesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.chk3DBox);
            this.Controls.Add(this.pnlOtherOptions);
            this.Controls.Add(this.txtAdditionalCommands);
            this.Controls.Add(this.lblAdditionalDosBoxCommands);
            this.Controls.Add(this.btnDefaultImagesFolder);
            this.Controls.Add(this.txtDefaultImagesFolder);
            this.Controls.Add(this.lblDefaultCDPath);
            this.Controls.Add(this.btnDefaultGamesFolder);
            this.Controls.Add(this.txtDefaultGamesFolder);
            this.Controls.Add(this.lblDefaultGamesFolder);
            this.Name = "GamesPanel";
            this.Size = new System.Drawing.Size(841, 862);
            this.pnlOtherOptions.ResumeLayout(false);
            this.pnlOtherOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
