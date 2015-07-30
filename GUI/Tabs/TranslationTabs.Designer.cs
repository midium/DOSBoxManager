using GUI.Tabs.Base;
namespace GUI.Tabs
{
    partial class TranslationTabs : TabsBase
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
            this.textsTab = new System.Windows.Forms.RadioButton();
            this.formsTab = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textsTab
            // 
            this.textsTab.Appearance = System.Windows.Forms.Appearance.Button;
            this.textsTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textsTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textsTab.Image = global::GUI.Properties.Resources.comments;
            this.textsTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.textsTab.Location = new System.Drawing.Point(127, 3);
            this.textsTab.Name = "textsTab";
            this.textsTab.Size = new System.Drawing.Size(125, 26);
            this.textsTab.TabIndex = 6;
            this.textsTab.TabStop = true;
            this.textsTab.Text = "Texts && Dialogs";
            this.textsTab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.textsTab.UseVisualStyleBackColor = true;
            // 
            // formsTab
            // 
            this.formsTab.Appearance = System.Windows.Forms.Appearance.Button;
            this.formsTab.Checked = true;
            this.formsTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.formsTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.formsTab.Image = global::GUI.Properties.Resources.application;
            this.formsTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.formsTab.Location = new System.Drawing.Point(3, 3);
            this.formsTab.Name = "formsTab";
            this.formsTab.Size = new System.Drawing.Size(125, 26);
            this.formsTab.TabIndex = 5;
            this.formsTab.TabStop = true;
            this.formsTab.Text = "Forms && Controls";
            this.formsTab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.formsTab.UseVisualStyleBackColor = true;
            // 
            // TranslationTabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.textsTab);
            this.Controls.Add(this.formsTab);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.MaximumSize = new System.Drawing.Size(255, 32);
            this.MinimumSize = new System.Drawing.Size(255, 32);
            this.Name = "TranslationTabs";
            this.Size = new System.Drawing.Size(255, 32);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton textsTab;
        private System.Windows.Forms.RadioButton formsTab;
    }
}
