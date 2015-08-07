namespace GUI.Buttons
{
    partial class GameDownloader
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
            this.pgbDownload = new System.Windows.Forms.ProgressBar();
            this.btnDownloadGame = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pgbDownload
            // 
            this.pgbDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbDownload.Location = new System.Drawing.Point(3, 3);
            this.pgbDownload.Name = "pgbDownload";
            this.pgbDownload.Size = new System.Drawing.Size(144, 15);
            this.pgbDownload.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbDownload.TabIndex = 36;
            this.pgbDownload.Visible = false;
            // 
            // btnDownloadGame
            // 
            this.btnDownloadGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDownloadGame.Image = global::GUI.Properties.Resources.download;
            this.btnDownloadGame.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownloadGame.Location = new System.Drawing.Point(3, 26);
            this.btnDownloadGame.Name = "btnDownloadGame";
            this.btnDownloadGame.Size = new System.Drawing.Size(144, 30);
            this.btnDownloadGame.TabIndex = 35;
            this.btnDownloadGame.Text = "Download Game";
            this.btnDownloadGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownloadGame.UseVisualStyleBackColor = true;
            this.btnDownloadGame.Click += new System.EventHandler(this.btnDownloadGame_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(3, 3);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(144, 15);
            this.lblStatus.TabIndex = 37;
            this.lblStatus.Text = "Download Completed!!!";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Visible = false;
            // 
            // GameDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pgbDownload);
            this.Controls.Add(this.btnDownloadGame);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(150, 59);
            this.Name = "GameDownloader";
            this.Size = new System.Drawing.Size(150, 59);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbDownload;
        private System.Windows.Forms.Button btnDownloadGame;
        private System.Windows.Forms.Label lblStatus;
    }
}
