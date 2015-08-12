using DosBox_Manager.UI.Dialogs.GamePanels.Base;
namespace DosBox_Manager.UI.Dialogs.GamePanels
{
    partial class GameSetupPanel : GamePanelBase
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.txtAdditionalCommands = new System.Windows.Forms.TextBox();
            this.txtCDImage = new System.Windows.Forms.TextBox();
            this.txtGameConfigurationFile = new System.Windows.Forms.TextBox();
            this.txtGameSetupExe = new System.Windows.Forms.TextBox();
            this.txtMountDirectory = new System.Windows.Forms.TextBox();
            this.txtGameExe = new System.Windows.Forms.TextBox();
            this.pnlOtherOptions = new System.Windows.Forms.Panel();
            this.chkQuitOnExit = new System.Windows.Forms.CheckBox();
            this.chkFullscreen = new System.Windows.Forms.CheckBox();
            this.chkNoConsole = new System.Windows.Forms.CheckBox();
            this.lblOtherOptions = new System.Windows.Forms.Label();
            this.lblAdditionalCommands = new System.Windows.Forms.Label();
            this.pnlMountingOptions = new System.Windows.Forms.Panel();
            this.rdbNone = new System.Windows.Forms.RadioButton();
            this.rdbMountFloppy = new System.Windows.Forms.RadioButton();
            this.rdbUseIOCTL = new System.Windows.Forms.RadioButton();
            this.lblMountingOptions = new System.Windows.Forms.Label();
            this.lblCDImage = new System.Windows.Forms.Label();
            this.chkNoConfig = new System.Windows.Forms.CheckBox();
            this.lblCustomConfigLocation = new System.Windows.Forms.Label();
            this.lblGameSetupExe = new System.Windows.Forms.Label();
            this.lblMountDirectory = new System.Windows.Forms.Label();
            this.lblGameExe = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCDFolder = new System.Windows.Forms.Button();
            this.btnCDImage = new System.Windows.Forms.Button();
            this.btnCustomConfig = new System.Windows.Forms.Button();
            this.btnGameSetupEXE = new System.Windows.Forms.Button();
            this.btnChooseMountDirectory = new System.Windows.Forms.Button();
            this.btnOpenGameEXE = new System.Windows.Forms.Button();
            this.pnlOtherOptions.SuspendLayout();
            this.pnlMountingOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAdditionalCommands
            // 
            this.txtAdditionalCommands.Location = new System.Drawing.Point(12, 358);
            this.txtAdditionalCommands.Name = "txtAdditionalCommands";
            this.txtAdditionalCommands.Size = new System.Drawing.Size(410, 22);
            this.txtAdditionalCommands.TabIndex = 60;
            this.txtAdditionalCommands.TextChanged += new System.EventHandler(this.txtAdditionalCommands_TextChanged);
            // 
            // txtCDImage
            // 
            this.txtCDImage.Location = new System.Drawing.Point(12, 231);
            this.txtCDImage.Name = "txtCDImage";
            this.txtCDImage.Size = new System.Drawing.Size(410, 22);
            this.txtCDImage.TabIndex = 55;
            this.txtCDImage.TextChanged += new System.EventHandler(this.txtCDImage_TextChanged);
            // 
            // txtGameConfigurationFile
            // 
            this.txtGameConfigurationFile.Location = new System.Drawing.Point(12, 162);
            this.txtGameConfigurationFile.Name = "txtGameConfigurationFile";
            this.txtGameConfigurationFile.Size = new System.Drawing.Size(446, 22);
            this.txtGameConfigurationFile.TabIndex = 51;
            this.txtGameConfigurationFile.TextChanged += new System.EventHandler(this.txtGameConfigurationFile_TextChanged);
            // 
            // txtGameSetupExe
            // 
            this.txtGameSetupExe.Location = new System.Drawing.Point(12, 116);
            this.txtGameSetupExe.Name = "txtGameSetupExe";
            this.txtGameSetupExe.Size = new System.Drawing.Size(446, 22);
            this.txtGameSetupExe.TabIndex = 48;
            this.txtGameSetupExe.TextChanged += new System.EventHandler(this.txtGameSetupExe_TextChanged);
            // 
            // txtMountDirectory
            // 
            this.txtMountDirectory.Location = new System.Drawing.Point(12, 70);
            this.txtMountDirectory.Name = "txtMountDirectory";
            this.txtMountDirectory.Size = new System.Drawing.Size(446, 22);
            this.txtMountDirectory.TabIndex = 45;
            this.txtMountDirectory.TextChanged += new System.EventHandler(this.txtMountDirectory_TextChanged);
            // 
            // txtGameExe
            // 
            this.txtGameExe.Location = new System.Drawing.Point(12, 24);
            this.txtGameExe.Name = "txtGameExe";
            this.txtGameExe.Size = new System.Drawing.Size(446, 22);
            this.txtGameExe.TabIndex = 42;
            this.txtGameExe.TextChanged += new System.EventHandler(this.txtGameExe_TextChanged);
            // 
            // pnlOtherOptions
            // 
            this.pnlOtherOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOtherOptions.Controls.Add(this.chkQuitOnExit);
            this.pnlOtherOptions.Controls.Add(this.chkFullscreen);
            this.pnlOtherOptions.Controls.Add(this.chkNoConsole);
            this.pnlOtherOptions.Controls.Add(this.lblOtherOptions);
            this.pnlOtherOptions.Location = new System.Drawing.Point(12, 386);
            this.pnlOtherOptions.Name = "pnlOtherOptions";
            this.pnlOtherOptions.Size = new System.Drawing.Size(410, 52);
            this.pnlOtherOptions.TabIndex = 61;
            // 
            // chkQuitOnExit
            // 
            this.chkQuitOnExit.AutoSize = true;
            this.chkQuitOnExit.Location = new System.Drawing.Point(281, 21);
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
            this.chkFullscreen.Location = new System.Drawing.Point(173, 21);
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
            this.chkNoConsole.Location = new System.Drawing.Point(56, 21);
            this.chkNoConsole.Name = "chkNoConsole";
            this.chkNoConsole.Size = new System.Drawing.Size(86, 17);
            this.chkNoConsole.TabIndex = 1;
            this.chkNoConsole.Text = "No Console";
            this.chkNoConsole.UseVisualStyleBackColor = true;
            this.chkNoConsole.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // lblOtherOptions
            // 
            this.lblOtherOptions.AutoSize = true;
            this.lblOtherOptions.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtherOptions.Location = new System.Drawing.Point(0, 1);
            this.lblOtherOptions.Name = "lblOtherOptions";
            this.lblOtherOptions.Size = new System.Drawing.Size(79, 13);
            this.lblOtherOptions.TabIndex = 0;
            this.lblOtherOptions.Text = "Other Options";
            // 
            // lblAdditionalCommands
            // 
            this.lblAdditionalCommands.AutoSize = true;
            this.lblAdditionalCommands.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdditionalCommands.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAdditionalCommands.Location = new System.Drawing.Point(27, 342);
            this.lblAdditionalCommands.Name = "lblAdditionalCommands";
            this.lblAdditionalCommands.Size = new System.Drawing.Size(310, 13);
            this.lblAdditionalCommands.TabIndex = 59;
            this.lblAdditionalCommands.Text = "Additional DOSBox commands (-c \"command\") (optional):";
            this.lblAdditionalCommands.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlMountingOptions
            // 
            this.pnlMountingOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMountingOptions.Controls.Add(this.rdbNone);
            this.pnlMountingOptions.Controls.Add(this.rdbMountFloppy);
            this.pnlMountingOptions.Controls.Add(this.rdbUseIOCTL);
            this.pnlMountingOptions.Controls.Add(this.lblMountingOptions);
            this.pnlMountingOptions.Location = new System.Drawing.Point(12, 259);
            this.pnlMountingOptions.Name = "pnlMountingOptions";
            this.pnlMountingOptions.Size = new System.Drawing.Size(410, 75);
            this.pnlMountingOptions.TabIndex = 58;
            // 
            // rdbNone
            // 
            this.rdbNone.AutoSize = true;
            this.rdbNone.Location = new System.Drawing.Point(237, 23);
            this.rdbNone.Name = "rdbNone";
            this.rdbNone.Size = new System.Drawing.Size(53, 17);
            this.rdbNone.TabIndex = 3;
            this.rdbNone.TabStop = true;
            this.rdbNone.Text = "None";
            this.rdbNone.UseVisualStyleBackColor = true;
            // 
            // rdbMountFloppy
            // 
            this.rdbMountFloppy.AutoSize = true;
            this.rdbMountFloppy.Location = new System.Drawing.Point(14, 46);
            this.rdbMountFloppy.Name = "rdbMountFloppy";
            this.rdbMountFloppy.Size = new System.Drawing.Size(201, 17);
            this.rdbMountFloppy.TabIndex = 2;
            this.rdbMountFloppy.TabStop = true;
            this.rdbMountFloppy.Text = "Floppy disk image (mounted as A:)";
            this.rdbMountFloppy.UseVisualStyleBackColor = true;
            // 
            // rdbUseIOCTL
            // 
            this.rdbUseIOCTL.AutoSize = true;
            this.rdbUseIOCTL.Location = new System.Drawing.Point(14, 23);
            this.rdbUseIOCTL.Name = "rdbUseIOCTL";
            this.rdbUseIOCTL.Size = new System.Drawing.Size(155, 17);
            this.rdbUseIOCTL.TabIndex = 1;
            this.rdbUseIOCTL.TabStop = true;
            this.rdbUseIOCTL.Text = "Use IOCTL (for a CD drive)";
            this.rdbUseIOCTL.UseVisualStyleBackColor = true;
            this.rdbUseIOCTL.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // lblMountingOptions
            // 
            this.lblMountingOptions.AutoSize = true;
            this.lblMountingOptions.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMountingOptions.Location = new System.Drawing.Point(0, 1);
            this.lblMountingOptions.Name = "lblMountingOptions";
            this.lblMountingOptions.Size = new System.Drawing.Size(101, 13);
            this.lblMountingOptions.TabIndex = 0;
            this.lblMountingOptions.Text = "Mounting Options";
            // 
            // lblCDImage
            // 
            this.lblCDImage.AutoSize = true;
            this.lblCDImage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCDImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCDImage.Location = new System.Drawing.Point(27, 215);
            this.lblCDImage.Name = "lblCDImage";
            this.lblCDImage.Size = new System.Drawing.Size(276, 13);
            this.lblCDImage.TabIndex = 54;
            this.lblCDImage.Text = "CD image file or directory mounted as D: (optional):";
            this.lblCDImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkNoConfig
            // 
            this.chkNoConfig.AutoSize = true;
            this.chkNoConfig.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNoConfig.Location = new System.Drawing.Point(12, 190);
            this.chkNoConfig.Name = "chkNoConfig";
            this.chkNoConfig.Size = new System.Drawing.Size(390, 17);
            this.chkNoConfig.TabIndex = 53;
            this.chkNoConfig.Text = "No configuration file at all (may not work with DOSBox 0.73 or newer)";
            this.chkNoConfig.UseVisualStyleBackColor = true;
            this.chkNoConfig.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
            // 
            // lblCustomConfigLocation
            // 
            this.lblCustomConfigLocation.AutoSize = true;
            this.lblCustomConfigLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomConfigLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCustomConfigLocation.Location = new System.Drawing.Point(27, 146);
            this.lblCustomConfigLocation.Name = "lblCustomConfigLocation";
            this.lblCustomConfigLocation.Size = new System.Drawing.Size(224, 13);
            this.lblCustomConfigLocation.TabIndex = 50;
            this.lblCustomConfigLocation.Text = "Custom configuration location (optional):";
            this.lblCustomConfigLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGameSetupExe
            // 
            this.lblGameSetupExe.AutoSize = true;
            this.lblGameSetupExe.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameSetupExe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGameSetupExe.Location = new System.Drawing.Point(27, 100);
            this.lblGameSetupExe.Name = "lblGameSetupExe";
            this.lblGameSetupExe.Size = new System.Drawing.Size(231, 13);
            this.lblGameSetupExe.TabIndex = 47;
            this.lblGameSetupExe.Text = "Game setup executable location (optional):";
            this.lblGameSetupExe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMountDirectory
            // 
            this.lblMountDirectory.AutoSize = true;
            this.lblMountDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMountDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMountDirectory.Location = new System.Drawing.Point(27, 54);
            this.lblMountDirectory.Name = "lblMountDirectory";
            this.lblMountDirectory.Size = new System.Drawing.Size(190, 13);
            this.lblMountDirectory.TabIndex = 44;
            this.lblMountDirectory.Text = "Directory mounted as C: (optional):";
            this.lblMountDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGameExe
            // 
            this.lblGameExe.AutoSize = true;
            this.lblGameExe.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameExe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGameExe.Location = new System.Drawing.Point(28, 8);
            this.lblGameExe.Name = "lblGameExe";
            this.lblGameExe.Size = new System.Drawing.Size(356, 13);
            this.lblGameExe.TabIndex = 41;
            this.lblGameExe.Text = "Game executable location (optional if a directory is mounted as C:):";
            this.lblGameExe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = global::DosBox_Manager.Properties.Resources.application_osx_terminal;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(9, 337);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 22);
            this.label9.TabIndex = 67;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Image = global::DosBox_Manager.Properties.Resources.cd;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(9, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 22);
            this.label8.TabIndex = 66;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Image = global::DosBox_Manager.Properties.Resources.application_form;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(9, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 22);
            this.label7.TabIndex = 65;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Image = global::DosBox_Manager.Properties.Resources.installer_box;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(9, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 22);
            this.label6.TabIndex = 64;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = global::DosBox_Manager.Properties.Resources.folder;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(9, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 22);
            this.label5.TabIndex = 63;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = global::DosBox_Manager.Properties.Resources.application;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(9, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 22);
            this.label4.TabIndex = 62;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCDFolder
            // 
            this.btnCDFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCDFolder.Image = global::DosBox_Manager.Properties.Resources.folder_search;
            this.btnCDFolder.Location = new System.Drawing.Point(464, 227);
            this.btnCDFolder.Name = "btnCDFolder";
            this.btnCDFolder.Size = new System.Drawing.Size(30, 30);
            this.btnCDFolder.TabIndex = 57;
            this.btnCDFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCDFolder.UseVisualStyleBackColor = true;
            this.btnCDFolder.Click += new System.EventHandler(this.btnCDFolder_Click);
            // 
            // btnCDImage
            // 
            this.btnCDImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCDImage.Image = global::DosBox_Manager.Properties.Resources.magnifier;
            this.btnCDImage.Location = new System.Drawing.Point(428, 227);
            this.btnCDImage.Name = "btnCDImage";
            this.btnCDImage.Size = new System.Drawing.Size(30, 30);
            this.btnCDImage.TabIndex = 56;
            this.btnCDImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCDImage.UseVisualStyleBackColor = true;
            this.btnCDImage.Click += new System.EventHandler(this.btnCDImage_Click);
            // 
            // btnCustomConfig
            // 
            this.btnCustomConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomConfig.Image = global::DosBox_Manager.Properties.Resources.magnifier;
            this.btnCustomConfig.Location = new System.Drawing.Point(464, 158);
            this.btnCustomConfig.Name = "btnCustomConfig";
            this.btnCustomConfig.Size = new System.Drawing.Size(30, 30);
            this.btnCustomConfig.TabIndex = 52;
            this.btnCustomConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomConfig.UseVisualStyleBackColor = true;
            this.btnCustomConfig.Click += new System.EventHandler(this.btnCustomConfig_Click);
            // 
            // btnGameSetupEXE
            // 
            this.btnGameSetupEXE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGameSetupEXE.Image = global::DosBox_Manager.Properties.Resources.magnifier;
            this.btnGameSetupEXE.Location = new System.Drawing.Point(464, 112);
            this.btnGameSetupEXE.Name = "btnGameSetupEXE";
            this.btnGameSetupEXE.Size = new System.Drawing.Size(30, 30);
            this.btnGameSetupEXE.TabIndex = 49;
            this.btnGameSetupEXE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGameSetupEXE.UseVisualStyleBackColor = true;
            this.btnGameSetupEXE.Click += new System.EventHandler(this.btnGameSetupEXE_Click);
            // 
            // btnChooseMountDirectory
            // 
            this.btnChooseMountDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChooseMountDirectory.Image = global::DosBox_Manager.Properties.Resources.folder_search;
            this.btnChooseMountDirectory.Location = new System.Drawing.Point(464, 66);
            this.btnChooseMountDirectory.Name = "btnChooseMountDirectory";
            this.btnChooseMountDirectory.Size = new System.Drawing.Size(30, 30);
            this.btnChooseMountDirectory.TabIndex = 46;
            this.btnChooseMountDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChooseMountDirectory.UseVisualStyleBackColor = true;
            this.btnChooseMountDirectory.Click += new System.EventHandler(this.btnChooseMountDirectory_Click);
            // 
            // btnOpenGameEXE
            // 
            this.btnOpenGameEXE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenGameEXE.Image = global::DosBox_Manager.Properties.Resources.magnifier;
            this.btnOpenGameEXE.Location = new System.Drawing.Point(464, 20);
            this.btnOpenGameEXE.Name = "btnOpenGameEXE";
            this.btnOpenGameEXE.Size = new System.Drawing.Size(30, 30);
            this.btnOpenGameEXE.TabIndex = 43;
            this.btnOpenGameEXE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenGameEXE.UseVisualStyleBackColor = true;
            this.btnOpenGameEXE.Click += new System.EventHandler(this.btnOpenGameEXE_Click);
            // 
            // GameSetupPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtAdditionalCommands);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCDImage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtGameConfigurationFile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtGameSetupExe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMountDirectory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGameExe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pnlOtherOptions);
            this.Controls.Add(this.lblAdditionalCommands);
            this.Controls.Add(this.pnlMountingOptions);
            this.Controls.Add(this.btnCDFolder);
            this.Controls.Add(this.btnCDImage);
            this.Controls.Add(this.lblCDImage);
            this.Controls.Add(this.chkNoConfig);
            this.Controls.Add(this.btnCustomConfig);
            this.Controls.Add(this.lblCustomConfigLocation);
            this.Controls.Add(this.btnGameSetupEXE);
            this.Controls.Add(this.lblGameSetupExe);
            this.Controls.Add(this.btnChooseMountDirectory);
            this.Controls.Add(this.lblMountDirectory);
            this.Controls.Add(this.btnOpenGameEXE);
            this.Controls.Add(this.lblGameExe);
            this.Name = "GameSetupPanel";
            this.Size = new System.Drawing.Size(505, 450);
            this.pnlOtherOptions.ResumeLayout(false);
            this.pnlOtherOptions.PerformLayout();
            this.pnlMountingOptions.ResumeLayout(false);
            this.pnlMountingOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAdditionalCommands;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCDImage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGameConfigurationFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGameSetupExe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMountDirectory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGameExe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlOtherOptions;
        private System.Windows.Forms.CheckBox chkQuitOnExit;
        private System.Windows.Forms.CheckBox chkFullscreen;
        private System.Windows.Forms.CheckBox chkNoConsole;
        private System.Windows.Forms.Label lblOtherOptions;
        private System.Windows.Forms.Label lblAdditionalCommands;
        private System.Windows.Forms.Panel pnlMountingOptions;
        private System.Windows.Forms.RadioButton rdbNone;
        private System.Windows.Forms.RadioButton rdbMountFloppy;
        private System.Windows.Forms.RadioButton rdbUseIOCTL;
        private System.Windows.Forms.Label lblMountingOptions;
        private System.Windows.Forms.Button btnCDFolder;
        private System.Windows.Forms.Button btnCDImage;
        private System.Windows.Forms.Label lblCDImage;
        private System.Windows.Forms.CheckBox chkNoConfig;
        private System.Windows.Forms.Button btnCustomConfig;
        private System.Windows.Forms.Label lblCustomConfigLocation;
        private System.Windows.Forms.Button btnGameSetupEXE;
        private System.Windows.Forms.Label lblGameSetupExe;
        private System.Windows.Forms.Button btnChooseMountDirectory;
        private System.Windows.Forms.Label lblMountDirectory;
        private System.Windows.Forms.Button btnOpenGameEXE;
        private System.Windows.Forms.Label lblGameExe;
    }
}
