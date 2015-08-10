namespace DosBox_Manager.UI.Dialogs.MyAbandonwareDialogs
{
    partial class MyAbandonwareSearchDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyAbandonwareSearchDialog));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnGameData = new System.Windows.Forms.Button();
            this.lblFounded = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtGameName = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pctIcon = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.foundedGamesList = new GUI.Images.FoundedGamesList(this.components);
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlMain.Controls.Add(this.foundedGamesList);
            this.pnlMain.Controls.Add(this.btnGameData);
            this.pnlMain.Controls.Add(this.lblFounded);
            this.pnlMain.Controls.Add(this.btnFind);
            this.pnlMain.Controls.Add(this.txtGameName);
            this.pnlMain.Controls.Add(this.lblSearch);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.pctIcon);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(558, 467);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // btnGameData
            // 
            this.btnGameData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGameData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGameData.Image = global::DosBox_Manager.Properties.Resources.game_monitor;
            this.btnGameData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGameData.Location = new System.Drawing.Point(422, 420);
            this.btnGameData.Name = "btnGameData";
            this.btnGameData.Size = new System.Drawing.Size(124, 30);
            this.btnGameData.TabIndex = 16;
            this.btnGameData.Text = "View Game Data";
            this.btnGameData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGameData.UseVisualStyleBackColor = true;
            this.btnGameData.Click += new System.EventHandler(this.btnGameData_Click);
            // 
            // lblFounded
            // 
            this.lblFounded.AutoSize = true;
            this.lblFounded.Location = new System.Drawing.Point(12, 134);
            this.lblFounded.Name = "lblFounded";
            this.lblFounded.Size = new System.Drawing.Size(94, 13);
            this.lblFounded.TabIndex = 15;
            this.lblFounded.Text = "Founded Games:";
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFind.Image = global::DosBox_Manager.Properties.Resources.magnifier;
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(445, 69);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(101, 30);
            this.btnFind.TabIndex = 14;
            this.btnFind.Text = "Find Games";
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtGameName
            // 
            this.txtGameName.Location = new System.Drawing.Point(15, 74);
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.Size = new System.Drawing.Size(420, 22);
            this.txtGameName.TabIndex = 4;
            this.txtGameName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtGameName_KeyUp);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 58);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(76, 13);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Search Game:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(44, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(453, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Search && Download Games from MyAbandonware.com";
            // 
            // pctIcon
            // 
            this.pctIcon.Image = global::DosBox_Manager.Properties.Resources.myabandonware_big;
            this.pctIcon.Location = new System.Drawing.Point(3, 4);
            this.pctIcon.Name = "pctIcon";
            this.pctIcon.Size = new System.Drawing.Size(35, 35);
            this.pctIcon.TabIndex = 1;
            this.pctIcon.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Image = global::DosBox_Manager.Properties.Resources.door_out;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(469, 481);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Close";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // foundedGamesList
            // 
            this.foundedGamesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.foundedGamesList.Games = null;
            this.foundedGamesList.Location = new System.Drawing.Point(15, 150);
            this.foundedGamesList.Name = "foundedGamesList";
            this.foundedGamesList.Size = new System.Drawing.Size(400, 300);
            this.foundedGamesList.TabIndex = 18;
            this.foundedGamesList.GameSelected += new GUI.Images.FoundedGamesList.GameSelectedDelegate(this.foundedGamesList_GameSelected);
            this.foundedGamesList.GameDoubleClick += new GUI.Images.FoundedGamesList.GameDoubleClickDelegate(this.foundedGamesList_GameDoubleClick);
            // 
            // MyAbandonwareSearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(558, 523);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyAbandonwareSearchDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyAbandonware";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pctIcon;
        private System.Windows.Forms.TextBox txtGameName;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblFounded;
        private System.Windows.Forms.Button btnGameData;
        private GUI.Images.FoundedGamesList foundedGamesList;
    }
}