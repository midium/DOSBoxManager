namespace GUI.Images
{
    partial class FoundedGameCard
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
            this.lblGameName = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblPlatform = new System.Windows.Forms.Label();
            this.screenshot = new GUI.Images.Screenshot(this.components);
            this.SuspendLayout();
            // 
            // lblGameName
            // 
            this.lblGameName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGameName.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameName.Location = new System.Drawing.Point(122, 3);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(252, 45);
            this.lblGameName.TabIndex = 1;
            this.lblGameName.Text = "Game Title";
            // 
            // lblYear
            // 
            this.lblYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(123, 48);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(34, 17);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Year";
            // 
            // lblPlatform
            // 
            this.lblPlatform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlatform.AutoSize = true;
            this.lblPlatform.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlatform.Location = new System.Drawing.Point(123, 65);
            this.lblPlatform.Name = "lblPlatform";
            this.lblPlatform.Size = new System.Drawing.Size(57, 17);
            this.lblPlatform.TabIndex = 3;
            this.lblPlatform.Text = "Platform";
            // 
            // screenshot
            // 
            this.screenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.screenshot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.screenshot.ImageURI = null;
            this.screenshot.IsHover = false;
            this.screenshot.IsSelected = false;
            this.screenshot.Location = new System.Drawing.Point(3, 3);
            this.screenshot.Name = "screenshot";
            this.screenshot.ScreenshotImage = null;
            this.screenshot.Size = new System.Drawing.Size(113, 79);
            this.screenshot.TabIndex = 0;
            this.screenshot.Text = "screenshot1";
            // 
            // FoundedGameCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.lblPlatform);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblGameName);
            this.Controls.Add(this.screenshot);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(377, 85);
            this.Name = "FoundedGameCard";
            this.Size = new System.Drawing.Size(377, 85);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Screenshot screenshot;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblPlatform;
    }
}
