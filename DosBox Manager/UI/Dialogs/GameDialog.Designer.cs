using System.Windows.Forms;
using GUI.TextBoxes;
namespace DosBox_Manager.UI.Dialogs
{
    partial class GameDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button btnCancel;
        private Button btnCommit;
        private Panel pnlMain;
        private TextBox txtTitle;
        private Label lblTitle;
        private PictureBox pctCover;
        private Label lblImage;
        private Button btnClearImage;
        private Button btnOpenImage;
        private TextBox txtDeveloper;
        private Label lblDeveloper;
        private Label lblYear;
        private TextBox txtGameExe;
        private Label lblGameExe;
        private Button btnOpenGameEXE;
        private Button btnChooseMountDirectory;
        private TextBox txtMountDirectory;
        private Label lblMountDirectory;
        private Button btnGameSetupEXE;
        private TextBox txtGameSetupExe;
        private Label lblGameSetupExe;
        private Button btnCustomConfig;
        private TextBox txtGameConfigurationFile;
        private Label lblCustomConfigLocation;
        private CheckBox chkNoConfig;
        private Button btnCDImage;
        private TextBox txtCDImage;
        private Label lblCDImage;
        private Button btnCDFolder;
        private Panel pnlMountingOptions;
        private Label lblMountingOptions;
        private RadioButton rdbNone;
        private RadioButton rdbMountFloppy;
        private RadioButton rdbUseIOCTL;
        private TextBox txtAdditionalCommands;
        private Label lblAdditionalCommands;
        private Panel pnlOtherOptions;
        private CheckBox chkQuitOnExit;
        private CheckBox chkFullscreen;
        private CheckBox chkNoConsole;
        private Label lblOtherOptions;
        private NumericTextBox txtYear;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtAdditionalCommands = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCDImage = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGameConfigurationFile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGameSetupExe = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMountDirectory = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGameExe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYear = new GUI.TextBoxes.NumericTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnCDFolder = new System.Windows.Forms.Button();
            this.btnCDImage = new System.Windows.Forms.Button();
            this.lblCDImage = new System.Windows.Forms.Label();
            this.chkNoConfig = new System.Windows.Forms.CheckBox();
            this.btnCustomConfig = new System.Windows.Forms.Button();
            this.lblCustomConfigLocation = new System.Windows.Forms.Label();
            this.btnGameSetupEXE = new System.Windows.Forms.Button();
            this.lblGameSetupExe = new System.Windows.Forms.Label();
            this.btnChooseMountDirectory = new System.Windows.Forms.Button();
            this.lblMountDirectory = new System.Windows.Forms.Label();
            this.btnOpenGameEXE = new System.Windows.Forms.Button();
            this.lblGameExe = new System.Windows.Forms.Label();
            this.txtDeveloper = new System.Windows.Forms.TextBox();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.pctCover = new System.Windows.Forms.PictureBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlOtherOptions.SuspendLayout();
            this.pnlMountingOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCover)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlMain.Controls.Add(this.txtAdditionalCommands);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.txtCDImage);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.txtGameConfigurationFile);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.txtGameSetupExe);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.txtMountDirectory);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.txtGameExe);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.txtYear);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.txtTitle);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.pnlOtherOptions);
            this.pnlMain.Controls.Add(this.lblAdditionalCommands);
            this.pnlMain.Controls.Add(this.pnlMountingOptions);
            this.pnlMain.Controls.Add(this.btnCDFolder);
            this.pnlMain.Controls.Add(this.btnCDImage);
            this.pnlMain.Controls.Add(this.lblCDImage);
            this.pnlMain.Controls.Add(this.chkNoConfig);
            this.pnlMain.Controls.Add(this.btnCustomConfig);
            this.pnlMain.Controls.Add(this.lblCustomConfigLocation);
            this.pnlMain.Controls.Add(this.btnGameSetupEXE);
            this.pnlMain.Controls.Add(this.lblGameSetupExe);
            this.pnlMain.Controls.Add(this.btnChooseMountDirectory);
            this.pnlMain.Controls.Add(this.lblMountDirectory);
            this.pnlMain.Controls.Add(this.btnOpenGameEXE);
            this.pnlMain.Controls.Add(this.lblGameExe);
            this.pnlMain.Controls.Add(this.txtDeveloper);
            this.pnlMain.Controls.Add(this.lblDeveloper);
            this.pnlMain.Controls.Add(this.lblYear);
            this.pnlMain.Controls.Add(this.btnClearImage);
            this.pnlMain.Controls.Add(this.btnOpenImage);
            this.pnlMain.Controls.Add(this.pctCover);
            this.pnlMain.Controls.Add(this.lblImage);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(565, 644);
            this.pnlMain.TabIndex = 5;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // txtAdditionalCommands
            // 
            this.txtAdditionalCommands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdditionalCommands.Location = new System.Drawing.Point(15, 543);
            this.txtAdditionalCommands.Name = "txtAdditionalCommands";
            this.txtAdditionalCommands.Size = new System.Drawing.Size(473, 22);
            this.txtAdditionalCommands.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = global::DosBox_Manager.Properties.Resources.application_osx_terminal;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(12, 522);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 22);
            this.label9.TabIndex = 40;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCDImage
            // 
            this.txtCDImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCDImage.Location = new System.Drawing.Point(15, 416);
            this.txtCDImage.Name = "txtCDImage";
            this.txtCDImage.Size = new System.Drawing.Size(473, 22);
            this.txtCDImage.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Image = global::DosBox_Manager.Properties.Resources.cd;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(12, 395);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 22);
            this.label8.TabIndex = 39;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGameConfigurationFile
            // 
            this.txtGameConfigurationFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGameConfigurationFile.Location = new System.Drawing.Point(15, 347);
            this.txtGameConfigurationFile.Name = "txtGameConfigurationFile";
            this.txtGameConfigurationFile.Size = new System.Drawing.Size(509, 22);
            this.txtGameConfigurationFile.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Image = global::DosBox_Manager.Properties.Resources.application_form;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(12, 326);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 22);
            this.label7.TabIndex = 38;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGameSetupExe
            // 
            this.txtGameSetupExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGameSetupExe.Location = new System.Drawing.Point(15, 301);
            this.txtGameSetupExe.Name = "txtGameSetupExe";
            this.txtGameSetupExe.Size = new System.Drawing.Size(509, 22);
            this.txtGameSetupExe.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Image = global::DosBox_Manager.Properties.Resources.installer_box;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(12, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 22);
            this.label6.TabIndex = 37;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMountDirectory
            // 
            this.txtMountDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMountDirectory.Location = new System.Drawing.Point(15, 255);
            this.txtMountDirectory.Name = "txtMountDirectory";
            this.txtMountDirectory.Size = new System.Drawing.Size(509, 22);
            this.txtMountDirectory.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = global::DosBox_Manager.Properties.Resources.folder;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(12, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 22);
            this.label5.TabIndex = 36;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGameExe
            // 
            this.txtGameExe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGameExe.Location = new System.Drawing.Point(15, 209);
            this.txtGameExe.Name = "txtGameExe";
            this.txtGameExe.Size = new System.Drawing.Size(509, 22);
            this.txtGameExe.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = global::DosBox_Manager.Properties.Resources.application;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 22);
            this.label4.TabIndex = 35;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::DosBox_Manager.Properties.Resources.box_closed;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(111, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 22);
            this.label3.TabIndex = 34;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(15, 74);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(85, 22);
            this.txtYear.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::DosBox_Manager.Properties.Resources.calendar;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 22);
            this.label2.TabIndex = 33;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(15, 25);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(325, 22);
            this.txtTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::DosBox_Manager.Properties.Resources.game_monitor;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 22);
            this.label1.TabIndex = 32;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlOtherOptions
            // 
            this.pnlOtherOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOtherOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOtherOptions.Controls.Add(this.chkQuitOnExit);
            this.pnlOtherOptions.Controls.Add(this.chkFullscreen);
            this.pnlOtherOptions.Controls.Add(this.chkNoConsole);
            this.pnlOtherOptions.Controls.Add(this.lblOtherOptions);
            this.pnlOtherOptions.Location = new System.Drawing.Point(15, 571);
            this.pnlOtherOptions.Name = "pnlOtherOptions";
            this.pnlOtherOptions.Size = new System.Drawing.Size(473, 52);
            this.pnlOtherOptions.TabIndex = 31;
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
            this.lblAdditionalCommands.Location = new System.Drawing.Point(30, 527);
            this.lblAdditionalCommands.Name = "lblAdditionalCommands";
            this.lblAdditionalCommands.Size = new System.Drawing.Size(310, 13);
            this.lblAdditionalCommands.TabIndex = 29;
            this.lblAdditionalCommands.Text = "Additional DOSBox commands (-c \"command\") (optional):";
            this.lblAdditionalCommands.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlMountingOptions
            // 
            this.pnlMountingOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMountingOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMountingOptions.Controls.Add(this.rdbNone);
            this.pnlMountingOptions.Controls.Add(this.rdbMountFloppy);
            this.pnlMountingOptions.Controls.Add(this.rdbUseIOCTL);
            this.pnlMountingOptions.Controls.Add(this.lblMountingOptions);
            this.pnlMountingOptions.Location = new System.Drawing.Point(15, 444);
            this.pnlMountingOptions.Name = "pnlMountingOptions";
            this.pnlMountingOptions.Size = new System.Drawing.Size(473, 75);
            this.pnlMountingOptions.TabIndex = 28;
            // 
            // rdbNone
            // 
            this.rdbNone.AutoSize = true;
            this.rdbNone.Location = new System.Drawing.Point(14, 46);
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
            this.rdbMountFloppy.Location = new System.Drawing.Point(186, 23);
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
            // btnCDFolder
            // 
            this.btnCDFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCDFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCDFolder.Image = global::DosBox_Manager.Properties.Resources.folder_search;
            this.btnCDFolder.Location = new System.Drawing.Point(530, 412);
            this.btnCDFolder.Name = "btnCDFolder";
            this.btnCDFolder.Size = new System.Drawing.Size(30, 30);
            this.btnCDFolder.TabIndex = 27;
            this.btnCDFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCDFolder.UseVisualStyleBackColor = true;
            this.btnCDFolder.Click += new System.EventHandler(this.btnCDFolder_Click);
            // 
            // btnCDImage
            // 
            this.btnCDImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCDImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCDImage.Image = global::DosBox_Manager.Properties.Resources.magnifier;
            this.btnCDImage.Location = new System.Drawing.Point(494, 412);
            this.btnCDImage.Name = "btnCDImage";
            this.btnCDImage.Size = new System.Drawing.Size(30, 30);
            this.btnCDImage.TabIndex = 26;
            this.btnCDImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCDImage.UseVisualStyleBackColor = true;
            this.btnCDImage.Click += new System.EventHandler(this.btnCDImage_Click);
            // 
            // lblCDImage
            // 
            this.lblCDImage.AutoSize = true;
            this.lblCDImage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCDImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCDImage.Location = new System.Drawing.Point(30, 400);
            this.lblCDImage.Name = "lblCDImage";
            this.lblCDImage.Size = new System.Drawing.Size(276, 13);
            this.lblCDImage.TabIndex = 24;
            this.lblCDImage.Text = "CD image file or directory mounted as D: (optional):";
            this.lblCDImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkNoConfig
            // 
            this.chkNoConfig.AutoSize = true;
            this.chkNoConfig.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNoConfig.Location = new System.Drawing.Point(15, 375);
            this.chkNoConfig.Name = "chkNoConfig";
            this.chkNoConfig.Size = new System.Drawing.Size(390, 17);
            this.chkNoConfig.TabIndex = 23;
            this.chkNoConfig.Text = "No configuration file at all (may not work with DOSBox 0.73 or newer)";
            this.chkNoConfig.UseVisualStyleBackColor = true;
            // 
            // btnCustomConfig
            // 
            this.btnCustomConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomConfig.Image = global::DosBox_Manager.Properties.Resources.magnifier;
            this.btnCustomConfig.Location = new System.Drawing.Point(530, 343);
            this.btnCustomConfig.Name = "btnCustomConfig";
            this.btnCustomConfig.Size = new System.Drawing.Size(30, 30);
            this.btnCustomConfig.TabIndex = 22;
            this.btnCustomConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomConfig.UseVisualStyleBackColor = true;
            this.btnCustomConfig.Click += new System.EventHandler(this.btnCustomConfig_Click);
            // 
            // lblCustomConfigLocation
            // 
            this.lblCustomConfigLocation.AutoSize = true;
            this.lblCustomConfigLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomConfigLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCustomConfigLocation.Location = new System.Drawing.Point(30, 331);
            this.lblCustomConfigLocation.Name = "lblCustomConfigLocation";
            this.lblCustomConfigLocation.Size = new System.Drawing.Size(224, 13);
            this.lblCustomConfigLocation.TabIndex = 20;
            this.lblCustomConfigLocation.Text = "Custom configuration location (optional):";
            this.lblCustomConfigLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGameSetupEXE
            // 
            this.btnGameSetupEXE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGameSetupEXE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGameSetupEXE.Image = global::DosBox_Manager.Properties.Resources.magnifier;
            this.btnGameSetupEXE.Location = new System.Drawing.Point(530, 297);
            this.btnGameSetupEXE.Name = "btnGameSetupEXE";
            this.btnGameSetupEXE.Size = new System.Drawing.Size(30, 30);
            this.btnGameSetupEXE.TabIndex = 19;
            this.btnGameSetupEXE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGameSetupEXE.UseVisualStyleBackColor = true;
            this.btnGameSetupEXE.Click += new System.EventHandler(this.btnGameSetupEXE_Click);
            // 
            // lblGameSetupExe
            // 
            this.lblGameSetupExe.AutoSize = true;
            this.lblGameSetupExe.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameSetupExe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGameSetupExe.Location = new System.Drawing.Point(30, 285);
            this.lblGameSetupExe.Name = "lblGameSetupExe";
            this.lblGameSetupExe.Size = new System.Drawing.Size(231, 13);
            this.lblGameSetupExe.TabIndex = 17;
            this.lblGameSetupExe.Text = "Game setup executable location (optional):";
            this.lblGameSetupExe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnChooseMountDirectory
            // 
            this.btnChooseMountDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseMountDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChooseMountDirectory.Image = global::DosBox_Manager.Properties.Resources.folder_search;
            this.btnChooseMountDirectory.Location = new System.Drawing.Point(530, 251);
            this.btnChooseMountDirectory.Name = "btnChooseMountDirectory";
            this.btnChooseMountDirectory.Size = new System.Drawing.Size(30, 30);
            this.btnChooseMountDirectory.TabIndex = 16;
            this.btnChooseMountDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChooseMountDirectory.UseVisualStyleBackColor = true;
            this.btnChooseMountDirectory.Click += new System.EventHandler(this.btnChooseMountDirectory_Click);
            // 
            // lblMountDirectory
            // 
            this.lblMountDirectory.AutoSize = true;
            this.lblMountDirectory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMountDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMountDirectory.Location = new System.Drawing.Point(30, 239);
            this.lblMountDirectory.Name = "lblMountDirectory";
            this.lblMountDirectory.Size = new System.Drawing.Size(190, 13);
            this.lblMountDirectory.TabIndex = 14;
            this.lblMountDirectory.Text = "Directory mounted as C: (optional):";
            this.lblMountDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOpenGameEXE
            // 
            this.btnOpenGameEXE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenGameEXE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenGameEXE.Image = global::DosBox_Manager.Properties.Resources.magnifier;
            this.btnOpenGameEXE.Location = new System.Drawing.Point(530, 205);
            this.btnOpenGameEXE.Name = "btnOpenGameEXE";
            this.btnOpenGameEXE.Size = new System.Drawing.Size(30, 30);
            this.btnOpenGameEXE.TabIndex = 13;
            this.btnOpenGameEXE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenGameEXE.UseVisualStyleBackColor = true;
            this.btnOpenGameEXE.Click += new System.EventHandler(this.btnOpenGameEXE_Click);
            // 
            // lblGameExe
            // 
            this.lblGameExe.AutoSize = true;
            this.lblGameExe.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameExe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGameExe.Location = new System.Drawing.Point(31, 193);
            this.lblGameExe.Name = "lblGameExe";
            this.lblGameExe.Size = new System.Drawing.Size(356, 13);
            this.lblGameExe.TabIndex = 11;
            this.lblGameExe.Text = "Game executable location (optional if a directory is mounted as C:):";
            this.lblGameExe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDeveloper
            // 
            this.txtDeveloper.Location = new System.Drawing.Point(114, 74);
            this.txtDeveloper.Name = "txtDeveloper";
            this.txtDeveloper.Size = new System.Drawing.Size(226, 22);
            this.txtDeveloper.TabIndex = 10;
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.AutoSize = true;
            this.lblDeveloper.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeveloper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDeveloper.Location = new System.Drawing.Point(128, 57);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(63, 13);
            this.lblDeveloper.TabIndex = 9;
            this.lblDeveloper.Text = "Developer:";
            this.lblDeveloper.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblYear.Location = new System.Drawing.Point(30, 57);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(33, 13);
            this.lblYear.TabIndex = 7;
            this.lblYear.Text = "Year:";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClearImage
            // 
            this.btnClearImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearImage.Image = global::DosBox_Manager.Properties.Resources.broom;
            this.btnClearImage.Location = new System.Drawing.Point(530, 61);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(30, 30);
            this.btnClearImage.TabIndex = 6;
            this.btnClearImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenImage.Image = global::DosBox_Manager.Properties.Resources.folder_image;
            this.btnOpenImage.Location = new System.Drawing.Point(530, 25);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(30, 30);
            this.btnOpenImage.TabIndex = 5;
            this.btnOpenImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // pctCover
            // 
            this.pctCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctCover.Location = new System.Drawing.Point(368, 25);
            this.pctCover.Name = "pctCover";
            this.pctCover.Size = new System.Drawing.Size(157, 119);
            this.pctCover.TabIndex = 3;
            this.pctCover.TabStop = false;
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImage.Location = new System.Drawing.Point(365, 9);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(42, 13);
            this.lblImage.TabIndex = 2;
            this.lblImage.Text = "Image:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(31, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(32, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCommit.Image = global::DosBox_Manager.Properties.Resources.disk;
            this.btnCommit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCommit.Location = new System.Drawing.Point(480, 653);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(77, 30);
            this.btnCommit.TabIndex = 3;
            this.btnCommit.Text = "Save";
            this.btnCommit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Image = global::DosBox_Manager.Properties.Resources.cross;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(397, 653);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // GameDialog
            // 
            this.AcceptButton = this.btnCommit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(564, 692);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCommit);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GameDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlOtherOptions.ResumeLayout(false);
            this.pnlOtherOptions.PerformLayout();
            this.pnlMountingOptions.ResumeLayout(false);
            this.pnlMountingOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}