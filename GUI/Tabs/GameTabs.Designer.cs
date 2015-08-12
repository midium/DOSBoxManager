using GUI.Tabs.Base;
namespace GUI.Tabs
{
    partial class GameTabs : TabsBase
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
            this.dosboxTab = new System.Windows.Forms.RadioButton();
            this.infoTab = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // dosboxTab
            // 
            this.dosboxTab.Appearance = System.Windows.Forms.Appearance.Button;
            this.dosboxTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dosboxTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dosboxTab.Image = global::GUI.Properties.Resources.dosbox;
            this.dosboxTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dosboxTab.Location = new System.Drawing.Point(124, 0);
            this.dosboxTab.Name = "dosboxTab";
            this.dosboxTab.Size = new System.Drawing.Size(125, 26);
            this.dosboxTab.TabIndex = 8;
            this.dosboxTab.TabStop = true;
            this.dosboxTab.Text = "Game Settings";
            this.dosboxTab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dosboxTab.UseVisualStyleBackColor = true;
            // 
            // infoTab
            // 
            this.infoTab.Appearance = System.Windows.Forms.Appearance.Button;
            this.infoTab.Checked = true;
            this.infoTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.infoTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoTab.Image = global::GUI.Properties.Resources.information;
            this.infoTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.infoTab.Location = new System.Drawing.Point(0, 0);
            this.infoTab.Name = "infoTab";
            this.infoTab.Size = new System.Drawing.Size(125, 26);
            this.infoTab.TabIndex = 7;
            this.infoTab.TabStop = true;
            this.infoTab.Text = "Game Details";
            this.infoTab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.infoTab.UseVisualStyleBackColor = true;
            // 
            // GameTabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dosboxTab);
            this.Controls.Add(this.infoTab);
            this.MaximumSize = new System.Drawing.Size(249, 26);
            this.MinimumSize = new System.Drawing.Size(249, 26);
            this.Name = "GameTabs";
            this.Size = new System.Drawing.Size(249, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton dosboxTab;
        private System.Windows.Forms.RadioButton infoTab;
    }
}
