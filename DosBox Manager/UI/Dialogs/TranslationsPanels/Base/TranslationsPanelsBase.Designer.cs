using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace DosBox_Manager.UI.Dialogs.TranslationsPanels.Base
{
    partial class TranslationsPanelsBase
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        protected DataGridView dgvTranslations;
        protected Label lblPanelTitle;
        private TableLayoutPanel tableLayoutPanel;

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
            components = new System.ComponentModel.Container();
            this.dgvTranslations = new DataGridView();
            this.lblPanelTitle = new Label();
            this.tableLayoutPanel = new TableLayoutPanel();
            ((ISupportInitialize)this.dgvTranslations).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            this.dgvTranslations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTranslations.Dock = DockStyle.Fill;
            this.dgvTranslations.Location = new Point(3, 23);
            this.dgvTranslations.Name = "dgvTranslations";
            this.dgvTranslations.Size = new Size(655, 627);
            this.dgvTranslations.TabIndex = 3;
            this.lblPanelTitle.AutoSize = true;
            this.lblPanelTitle.Font = new Font("Segoe UI Light", 11.25f, FontStyle.Italic, GraphicsUnit.Point, (byte)0);
            this.lblPanelTitle.Location = new Point(3, 0);
            this.lblPanelTitle.Name = "lblPanelTitle";
            this.lblPanelTitle.Size = new Size(73, 20);
            this.lblPanelTitle.TabIndex = 2;
            this.lblPanelTitle.Text = "Panel Title";
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel.Controls.Add((Control)this.lblPanelTitle, 0, 0);
            this.tableLayoutPanel.Controls.Add((Control)this.dgvTranslations, 0, 1);
            this.tableLayoutPanel.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Location = new Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel.Size = new Size(661, 653);
            this.tableLayoutPanel.TabIndex = 4;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.BackColor = Color.FromArgb(50, 50, 50);
            this.Controls.Add((Control)this.tableLayoutPanel);
            this.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.ForeColor = Color.White;
            this.Name = "TranslationsPanelsBase";
            this.Size = new Size(661, 653);
            ((ISupportInitialize)this.dgvTranslations).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
