using DosBox_Manager.UI.Dialogs.GamePanels.Base;
namespace DosBox_Manager.UI.Dialogs.GamePanels
{
    partial class GameInfoPanel : GamePanelBase
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
            this.components = new System.ComponentModel.Container();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtVote = new GUI.TextBoxes.NumericTextBox(this.components);
            this.txtDosBox = new System.Windows.Forms.TextBox();
            this.txtPerspectives = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.txtThemes = new System.Windows.Forms.TextBox();
            this.txtReleasedIn = new System.Windows.Forms.TextBox();
            this.txtPlatform = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblVote = new System.Windows.Forms.Label();
            this.lblDosBox = new System.Windows.Forms.Label();
            this.lblPerspectives = new System.Windows.Forms.Label();
            this.lblThemes = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblPlatform = new System.Windows.Forms.Label();
            this.lblReleasedIn = new System.Windows.Forms.Label();
            this.txtYear = new GUI.TextBoxes.NumericTextBox(this.components);
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDeveloper = new System.Windows.Forms.TextBox();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pctCover = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctCover)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(16, 323);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(262, 111);
            this.txtDescription.TabIndex = 112;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImage.Location = new System.Drawing.Point(328, 258);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(42, 13);
            this.lblImage.TabIndex = 85;
            this.lblImage.Text = "Image:";
            // 
            // txtVote
            // 
            this.txtVote.Location = new System.Drawing.Point(187, 274);
            this.txtVote.Name = "txtVote";
            this.txtVote.Size = new System.Drawing.Size(91, 22);
            this.txtVote.TabIndex = 121;
            this.txtVote.TextChanged += new System.EventHandler(this.txtVote_TextChanged);
            // 
            // txtDosBox
            // 
            this.txtDosBox.Location = new System.Drawing.Point(15, 274);
            this.txtDosBox.Name = "txtDosBox";
            this.txtDosBox.Size = new System.Drawing.Size(158, 22);
            this.txtDosBox.TabIndex = 109;
            this.txtDosBox.TextChanged += new System.EventHandler(this.txtDosBox_TextChanged);
            // 
            // txtPerspectives
            // 
            this.txtPerspectives.Location = new System.Drawing.Point(15, 225);
            this.txtPerspectives.Name = "txtPerspectives";
            this.txtPerspectives.Size = new System.Drawing.Size(475, 22);
            this.txtPerspectives.TabIndex = 107;
            this.txtPerspectives.TextChanged += new System.EventHandler(this.txtPerspectives_TextChanged);
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(260, 129);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(230, 22);
            this.txtPublisher.TabIndex = 105;
            this.txtPublisher.TextChanged += new System.EventHandler(this.txtPublisher_TextChanged);
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublisher.Location = new System.Drawing.Point(276, 112);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(59, 13);
            this.lblPublisher.TabIndex = 104;
            this.lblPublisher.Text = "Publisher:";
            // 
            // txtThemes
            // 
            this.txtThemes.Location = new System.Drawing.Point(15, 177);
            this.txtThemes.Name = "txtThemes";
            this.txtThemes.Size = new System.Drawing.Size(475, 22);
            this.txtThemes.TabIndex = 103;
            this.txtThemes.TextChanged += new System.EventHandler(this.txtThemes_TextChanged);
            // 
            // txtReleasedIn
            // 
            this.txtReleasedIn.Location = new System.Drawing.Point(16, 129);
            this.txtReleasedIn.Name = "txtReleasedIn";
            this.txtReleasedIn.Size = new System.Drawing.Size(230, 22);
            this.txtReleasedIn.TabIndex = 97;
            this.txtReleasedIn.TextChanged += new System.EventHandler(this.txtReleasedIn_TextChanged);
            // 
            // txtPlatform
            // 
            this.txtPlatform.Location = new System.Drawing.Point(355, 81);
            this.txtPlatform.Name = "txtPlatform";
            this.txtPlatform.Size = new System.Drawing.Size(135, 22);
            this.txtPlatform.TabIndex = 99;
            this.txtPlatform.TextChanged += new System.EventHandler(this.txtPlatform_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(31, 307);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(69, 13);
            this.lblDescription.TabIndex = 111;
            this.lblDescription.Text = "Description:";
            // 
            // lblVote
            // 
            this.lblVote.AutoSize = true;
            this.lblVote.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVote.Location = new System.Drawing.Point(203, 258);
            this.lblVote.Name = "lblVote";
            this.lblVote.Size = new System.Drawing.Size(34, 13);
            this.lblVote.TabIndex = 110;
            this.lblVote.Text = "Vote:";
            // 
            // lblDosBox
            // 
            this.lblDosBox.AutoSize = true;
            this.lblDosBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDosBox.Location = new System.Drawing.Point(31, 258);
            this.lblDosBox.Name = "lblDosBox";
            this.lblDosBox.Size = new System.Drawing.Size(50, 13);
            this.lblDosBox.TabIndex = 108;
            this.lblDosBox.Text = "DosBox:";
            // 
            // lblPerspectives
            // 
            this.lblPerspectives.AutoSize = true;
            this.lblPerspectives.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerspectives.Location = new System.Drawing.Point(31, 209);
            this.lblPerspectives.Name = "lblPerspectives";
            this.lblPerspectives.Size = new System.Drawing.Size(74, 13);
            this.lblPerspectives.TabIndex = 106;
            this.lblPerspectives.Text = "Perspectives:";
            // 
            // lblThemes
            // 
            this.lblThemes.AutoSize = true;
            this.lblThemes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThemes.Location = new System.Drawing.Point(31, 160);
            this.lblThemes.Name = "lblThemes";
            this.lblThemes.Size = new System.Drawing.Size(50, 13);
            this.lblThemes.TabIndex = 102;
            this.lblThemes.Text = "Themes:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(371, 15);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(57, 13);
            this.lblCategory.TabIndex = 100;
            this.lblCategory.Text = "Category:";
            // 
            // lblPlatform
            // 
            this.lblPlatform.AutoSize = true;
            this.lblPlatform.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlatform.Location = new System.Drawing.Point(371, 65);
            this.lblPlatform.Name = "lblPlatform";
            this.lblPlatform.Size = new System.Drawing.Size(55, 13);
            this.lblPlatform.TabIndex = 98;
            this.lblPlatform.Text = "Platform:";
            // 
            // lblReleasedIn
            // 
            this.lblReleasedIn.AutoSize = true;
            this.lblReleasedIn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReleasedIn.Location = new System.Drawing.Point(31, 112);
            this.lblReleasedIn.Name = "lblReleasedIn";
            this.lblReleasedIn.Size = new System.Drawing.Size(69, 13);
            this.lblReleasedIn.TabIndex = 96;
            this.lblReleasedIn.Text = "Released In:";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(16, 81);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(85, 22);
            this.txtYear.TabIndex = 90;
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(16, 32);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(325, 22);
            this.txtTitle.TabIndex = 84;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // txtDeveloper
            // 
            this.txtDeveloper.Location = new System.Drawing.Point(115, 81);
            this.txtDeveloper.Name = "txtDeveloper";
            this.txtDeveloper.Size = new System.Drawing.Size(226, 22);
            this.txtDeveloper.TabIndex = 92;
            this.txtDeveloper.TextChanged += new System.EventHandler(this.txtDeveloper_TextChanged);
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.AutoSize = true;
            this.lblDeveloper.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeveloper.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDeveloper.Location = new System.Drawing.Point(129, 64);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(63, 13);
            this.lblDeveloper.TabIndex = 91;
            this.lblDeveloper.Text = "Developer:";
            this.lblDeveloper.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblYear.Location = new System.Drawing.Point(31, 64);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(33, 13);
            this.lblYear.TabIndex = 89;
            this.lblYear.Text = "Year:";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(32, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(32, 13);
            this.lblTitle.TabIndex = 83;
            this.lblTitle.Text = "Title:";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Image = global::DosBox_Manager.Properties.Resources.page_white_edit;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(13, 302);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 22);
            this.label13.TabIndex = 123;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pctCover
            // 
            this.pctCover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctCover.Location = new System.Drawing.Point(311, 274);
            this.pctCover.Name = "pctCover";
            this.pctCover.Size = new System.Drawing.Size(179, 122);
            this.pctCover.TabIndex = 86;
            this.pctCover.TabStop = false;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Image = global::DosBox_Manager.Properties.Resources.image;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Location = new System.Drawing.Point(308, 253);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 22);
            this.label12.TabIndex = 122;
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Image = global::DosBox_Manager.Properties.Resources.star;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(184, 253);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 22);
            this.label11.TabIndex = 120;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Image = global::DosBox_Manager.Properties.Resources.dosbox;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(13, 253);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 22);
            this.label10.TabIndex = 119;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = global::DosBox_Manager.Properties.Resources.eye;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(13, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 22);
            this.label9.TabIndex = 118;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Image = global::DosBox_Manager.Properties.Resources.lorry;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(257, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 22);
            this.label8.TabIndex = 117;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Image = global::DosBox_Manager.Properties.Resources.bomb;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(13, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 22);
            this.label7.TabIndex = 116;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Image = global::DosBox_Manager.Properties.Resources.it;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(13, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 22);
            this.label6.TabIndex = 115;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = global::DosBox_Manager.Properties.Resources.application_osx_terminal;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(352, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 22);
            this.label5.TabIndex = 114;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = global::DosBox_Manager.Properties.Resources.brick;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(352, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 22);
            this.label4.TabIndex = 113;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::DosBox_Manager.Properties.Resources.box_closed;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(112, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 22);
            this.label3.TabIndex = 95;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::DosBox_Manager.Properties.Resources.calendar;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 22);
            this.label2.TabIndex = 94;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::DosBox_Manager.Properties.Resources.game_monitor;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 22);
            this.label1.TabIndex = 93;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClearImage
            // 
            this.btnClearImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearImage.Image = global::DosBox_Manager.Properties.Resources.broom;
            this.btnClearImage.Location = new System.Drawing.Point(460, 404);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(30, 30);
            this.btnClearImage.TabIndex = 88;
            this.btnClearImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenImage.Image = global::DosBox_Manager.Properties.Resources.folder_image;
            this.btnOpenImage.Location = new System.Drawing.Point(311, 404);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(30, 30);
            this.btnOpenImage.TabIndex = 87;
            this.btnOpenImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // cboCategory
            // 
            this.cboCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCategory.ForeColor = System.Drawing.Color.White;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(355, 33);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(135, 21);
            this.cboCategory.TabIndex = 124;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // GameInfoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.pctCover);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtVote);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDosBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPerspectives);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPublisher);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblPublisher);
            this.Controls.Add(this.txtThemes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtReleasedIn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPlatform);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblVote);
            this.Controls.Add(this.lblDosBox);
            this.Controls.Add(this.lblPerspectives);
            this.Controls.Add(this.lblThemes);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblPlatform);
            this.Controls.Add(this.lblReleasedIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDeveloper);
            this.Controls.Add(this.lblDeveloper);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.btnClearImage);
            this.Controls.Add(this.btnOpenImage);
            this.Controls.Add(this.lblTitle);
            this.Name = "GameInfoPanel";
            this.Size = new System.Drawing.Size(505, 450);
            ((System.ComponentModel.ISupportInitialize)(this.pctCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.PictureBox pctCover;
        private System.Windows.Forms.Label label12;
        private GUI.TextBoxes.NumericTextBox txtVote;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDosBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPerspectives;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.TextBox txtThemes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReleasedIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPlatform;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblVote;
        private System.Windows.Forms.Label lblDosBox;
        private System.Windows.Forms.Label lblPerspectives;
        private System.Windows.Forms.Label lblThemes;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblPlatform;
        private System.Windows.Forms.Label lblReleasedIn;
        private System.Windows.Forms.Label label3;
        private GUI.TextBoxes.NumericTextBox txtYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeveloper;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboCategory;
    }
}
