using GUI.Tabs.Base;
namespace GUI.Tabs
{
    partial class SettingsTabs : TabsBase
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
            this.behaviourTab = new System.Windows.Forms.RadioButton();
            this.gamesTab = new System.Windows.Forms.RadioButton();
            this.dosBoxTab = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // behaviourTab
            // 
            this.behaviourTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.behaviourTab.Appearance = System.Windows.Forms.Appearance.Button;
            this.behaviourTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.behaviourTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.behaviourTab.Image = global::GUI.Properties.Resources.setting_tools;
            this.behaviourTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.behaviourTab.Location = new System.Drawing.Point(3, 53);
            this.behaviourTab.Name = "behaviourTab";
            this.behaviourTab.Size = new System.Drawing.Size(107, 26);
            this.behaviourTab.TabIndex = 7;
            this.behaviourTab.TabStop = true;
            this.behaviourTab.Text = "Behaviours";
            this.behaviourTab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.behaviourTab.UseVisualStyleBackColor = true;
            // 
            // gamesTab
            // 
            this.gamesTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gamesTab.Appearance = System.Windows.Forms.Appearance.Button;
            this.gamesTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gamesTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gamesTab.Image = global::GUI.Properties.Resources.game_monitor;
            this.gamesTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.gamesTab.Location = new System.Drawing.Point(3, 28);
            this.gamesTab.Name = "gamesTab";
            this.gamesTab.Size = new System.Drawing.Size(107, 26);
            this.gamesTab.TabIndex = 4;
            this.gamesTab.TabStop = true;
            this.gamesTab.Text = "Games";
            this.gamesTab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.gamesTab.UseVisualStyleBackColor = true;
            // 
            // dosBoxTab
            // 
            this.dosBoxTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dosBoxTab.Appearance = System.Windows.Forms.Appearance.Button;
            this.dosBoxTab.Checked = true;
            this.dosBoxTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dosBoxTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dosBoxTab.Image = global::GUI.Properties.Resources.dosbox;
            this.dosBoxTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dosBoxTab.Location = new System.Drawing.Point(3, 3);
            this.dosBoxTab.Name = "dosBoxTab";
            this.dosBoxTab.Size = new System.Drawing.Size(107, 26);
            this.dosBoxTab.TabIndex = 3;
            this.dosBoxTab.TabStop = true;
            this.dosBoxTab.Text = "DOSBox";
            this.dosBoxTab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dosBoxTab.UseVisualStyleBackColor = true;
            // 
            // SettingsTabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.behaviourTab);
            this.Controls.Add(this.gamesTab);
            this.Controls.Add(this.dosBoxTab);
            this.MinimumSize = new System.Drawing.Size(113, 82);
            this.Name = "SettingsTabs";
            this.Size = new System.Drawing.Size(113, 83);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton dosBoxTab;
        private System.Windows.Forms.RadioButton gamesTab;
        private System.Windows.Forms.RadioButton behaviourTab;
    }
}
