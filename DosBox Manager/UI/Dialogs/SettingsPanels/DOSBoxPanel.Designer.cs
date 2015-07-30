using System.Drawing;
using System.Windows.Forms;
using DosBox_Manager.UI.Dialogs.SettingsPanels.Base;
namespace DosBox_Manager.UI.Dialogs.SettingsPanels
{
    partial class DOSBoxPanel : BaseSettingsPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label lblDosBoxExe;
        private TextBox txtDosBoxExePath;
        private Button btnOpenGameEXE;
        private Button btnDosBoxConfig;
        private TextBox txtDosBoxConfigFile;
        private Label lblDosBoxConfigFile;
        private Button btnDosBoxLanguage;
        private TextBox txtDosBoxLanguageFile;
        private Label lblDosBoxLanguage;
        private CheckBox chkPortable;
        private Button btnRescan;

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
            this.btnRescan = new System.Windows.Forms.Button();
            this.chkPortable = new System.Windows.Forms.CheckBox();
            this.btnDosBoxLanguage = new System.Windows.Forms.Button();
            this.txtDosBoxLanguageFile = new System.Windows.Forms.TextBox();
            this.lblDosBoxLanguage = new System.Windows.Forms.Label();
            this.btnDosBoxConfig = new System.Windows.Forms.Button();
            this.txtDosBoxConfigFile = new System.Windows.Forms.TextBox();
            this.lblDosBoxConfigFile = new System.Windows.Forms.Label();
            this.btnOpenGameEXE = new System.Windows.Forms.Button();
            this.txtDosBoxExePath = new System.Windows.Forms.TextBox();
            this.lblDosBoxExe = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRescan
            // 
            this.btnRescan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRescan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRescan.Image = global::DosBox_Manager.Properties.Resources.drive_magnify;
            this.btnRescan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRescan.Location = new System.Drawing.Point(606, 170);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(232, 31);
            this.btnRescan.TabIndex = 22;
            this.btnRescan.Text = "Re-scan DOSBox Manager\'s directory";
            this.btnRescan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRescan.UseVisualStyleBackColor = true;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // chkPortable
            // 
            this.chkPortable.AutoSize = true;
            this.chkPortable.Location = new System.Drawing.Point(6, 178);
            this.chkPortable.Name = "chkPortable";
            this.chkPortable.Size = new System.Drawing.Size(102, 17);
            this.chkPortable.TabIndex = 21;
            this.chkPortable.Text = "Portable Mode";
            this.chkPortable.UseVisualStyleBackColor = true;
            this.chkPortable.CheckedChanged += new System.EventHandler(this.chkPortable_CheckedChanged);
            // 
            // btnDosBoxLanguage
            // 
            this.btnDosBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDosBoxLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDosBoxLanguage.Image = global::DosBox_Manager.Properties.Resources.magnifier;
            this.btnDosBoxLanguage.Location = new System.Drawing.Point(814, 135);
            this.btnDosBoxLanguage.Name = "btnDosBoxLanguage";
            this.btnDosBoxLanguage.Size = new System.Drawing.Size(24, 24);
            this.btnDosBoxLanguage.TabIndex = 20;
            this.btnDosBoxLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDosBoxLanguage.UseVisualStyleBackColor = true;
            this.btnDosBoxLanguage.Click += new System.EventHandler(this.btnDosBoxLanguage_Click);
            // 
            // txtDosBoxLanguageFile
            // 
            this.txtDosBoxLanguageFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDosBoxLanguageFile.Location = new System.Drawing.Point(6, 136);
            this.txtDosBoxLanguageFile.Name = "txtDosBoxLanguageFile";
            this.txtDosBoxLanguageFile.Size = new System.Drawing.Size(802, 22);
            this.txtDosBoxLanguageFile.TabIndex = 19;
            this.txtDosBoxLanguageFile.TextChanged += new System.EventHandler(this.txtDosBoxLanguageFile_TextChanged);
            // 
            // lblDosBoxLanguage
            // 
            this.lblDosBoxLanguage.AutoSize = true;
            this.lblDosBoxLanguage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDosBoxLanguage.Location = new System.Drawing.Point(3, 120);
            this.lblDosBoxLanguage.Name = "lblDosBoxLanguage";
            this.lblDosBoxLanguage.Size = new System.Drawing.Size(224, 13);
            this.lblDosBoxLanguage.TabIndex = 18;
            this.lblDosBoxLanguage.Text = "Default DOSBox Language File (optional):";
            // 
            // btnDosBoxConfig
            // 
            this.btnDosBoxConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDosBoxConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDosBoxConfig.Image = global::DosBox_Manager.Properties.Resources.magnifier;
            this.btnDosBoxConfig.Location = new System.Drawing.Point(814, 94);
            this.btnDosBoxConfig.Name = "btnDosBoxConfig";
            this.btnDosBoxConfig.Size = new System.Drawing.Size(24, 24);
            this.btnDosBoxConfig.TabIndex = 17;
            this.btnDosBoxConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDosBoxConfig.UseVisualStyleBackColor = true;
            this.btnDosBoxConfig.Click += new System.EventHandler(this.btnDosBoxConfig_Click);
            // 
            // txtDosBoxConfigFile
            // 
            this.txtDosBoxConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDosBoxConfigFile.Location = new System.Drawing.Point(6, 95);
            this.txtDosBoxConfigFile.Name = "txtDosBoxConfigFile";
            this.txtDosBoxConfigFile.Size = new System.Drawing.Size(802, 22);
            this.txtDosBoxConfigFile.TabIndex = 16;
            this.txtDosBoxConfigFile.TextChanged += new System.EventHandler(this.txtDosBoxConfigFile_TextChanged);
            // 
            // lblDosBoxConfigFile
            // 
            this.lblDosBoxConfigFile.AutoSize = true;
            this.lblDosBoxConfigFile.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDosBoxConfigFile.Location = new System.Drawing.Point(3, 79);
            this.lblDosBoxConfigFile.Name = "lblDosBoxConfigFile";
            this.lblDosBoxConfigFile.Size = new System.Drawing.Size(344, 13);
            this.lblDosBoxConfigFile.TabIndex = 15;
            this.lblDosBoxConfigFile.Text = "Default DOSBox Configuration File (optional but recommended):";
            // 
            // btnOpenGameEXE
            // 
            this.btnOpenGameEXE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenGameEXE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenGameEXE.Image = global::DosBox_Manager.Properties.Resources.magnifier;
            this.btnOpenGameEXE.Location = new System.Drawing.Point(814, 53);
            this.btnOpenGameEXE.Name = "btnOpenGameEXE";
            this.btnOpenGameEXE.Size = new System.Drawing.Size(24, 24);
            this.btnOpenGameEXE.TabIndex = 14;
            this.btnOpenGameEXE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenGameEXE.UseVisualStyleBackColor = true;
            this.btnOpenGameEXE.Click += new System.EventHandler(this.btnOpenGameEXE_Click);
            // 
            // txtDosBoxExePath
            // 
            this.txtDosBoxExePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDosBoxExePath.Location = new System.Drawing.Point(6, 54);
            this.txtDosBoxExePath.Name = "txtDosBoxExePath";
            this.txtDosBoxExePath.Size = new System.Drawing.Size(802, 22);
            this.txtDosBoxExePath.TabIndex = 1;
            this.txtDosBoxExePath.TextChanged += new System.EventHandler(this.txtDosBoxExePath_TextChanged);
            // 
            // lblDosBoxExe
            // 
            this.lblDosBoxExe.AutoSize = true;
            this.lblDosBoxExe.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDosBoxExe.Location = new System.Drawing.Point(3, 38);
            this.lblDosBoxExe.Name = "lblDosBoxExe";
            this.lblDosBoxExe.Size = new System.Drawing.Size(138, 13);
            this.lblDosBoxExe.TabIndex = 0;
            this.lblDosBoxExe.Text = "DOSBox Executable Path:";
            // 
            // DOSBoxPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnRescan);
            this.Controls.Add(this.chkPortable);
            this.Controls.Add(this.btnDosBoxLanguage);
            this.Controls.Add(this.txtDosBoxLanguageFile);
            this.Controls.Add(this.lblDosBoxLanguage);
            this.Controls.Add(this.btnDosBoxConfig);
            this.Controls.Add(this.txtDosBoxConfigFile);
            this.Controls.Add(this.lblDosBoxConfigFile);
            this.Controls.Add(this.btnOpenGameEXE);
            this.Controls.Add(this.txtDosBoxExePath);
            this.Controls.Add(this.lblDosBoxExe);
            this.Name = "DOSBoxPanel";
            this.Size = new System.Drawing.Size(841, 862);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
