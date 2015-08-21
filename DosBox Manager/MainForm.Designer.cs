using System.Windows.Forms;
using GUI.Tabs;
namespace DosBox_Manager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem createDatabaseToolStripMenuItem;
        private ToolStripMenuItem openDatabaseToolStripMenuItem;
        private ToolStrip toolStrip;
        private StatusStrip statusStrip;
        private TableLayoutPanel tableLayoutPanel;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private ToolStripMenuItem categoriesToolStripMenuItem;
        private ToolStripMenuItem addCategoryToolStripMenuItem;
        private ToolStripMenuItem editCategoryToolStripMenuItem;
        private ToolStripMenuItem deleteCategoryToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripButton tsbAddDatabase;
        private ToolStripButton tsbOpenDatabase;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbNewCategory;
        private ToolStripButton tsbEditCategory;
        private ToolStripButton tsbDeleteCategory;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem closeDatabaseToolStripMenuItem;
        private ToolStripButton tsbDisconnectDatabase;
        private ToolStripMenuItem gamesToolStripMenuItem;
        private ToolStripMenuItem addGameToolStripMenuItem;
        private ToolStripMenuItem editGameToolStripMenuItem;
        private ToolStripMenuItem deleteGameToolStripMenuItem;
        private ToolStripButton tsbAddGame;
        private ToolStripButton tsbEditGame;
        private ToolStripButton tsbDeleteGame;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton tsbClose;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem runGameToolStripMenuItem;
        private ToolStripMenuItem editGameConfigurationToolStripMenuItem;
        private ToolStripButton tsbRunGame;
        private ToolStripButton tsbGameConfig;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton tsbSettings;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripButton tsbAbout;
        private ToolStripButton tsbMakeGameConfigFile;
        private ToolStripMenuItem makeGameConfigurationToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem moveToCategoryToolStripMenuItem;
        private ToolStripSplitButton tsbMoveToCategory;
        private NotifyIcon notifyIcon;
        private CategoriesTabs categoriesTabs;
        private Label lblCategories;
        private Panel pnlGames;
        private Panel pnlSearch;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.runGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeGameConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGameConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.getGameFromMyAbandonwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.moveToCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbAddDatabase = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenDatabase = new System.Windows.Forms.ToolStripButton();
            this.tsbDisconnectDatabase = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNewCategory = new System.Windows.Forms.ToolStripButton();
            this.tsbEditCategory = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteCategory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAddGame = new System.Windows.Forms.ToolStripButton();
            this.tsbEditGame = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteGame = new System.Windows.Forms.ToolStripButton();
            this.tsbRunGame = new System.Windows.Forms.ToolStripButton();
            this.tsbMakeGameConfigFile = new System.Windows.Forms.ToolStripButton();
            this.tsbGameConfig = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveToCategory = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMyAbandonware = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblCategories = new System.Windows.Forms.Label();
            this.pnlGames = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.categoriesTabs = new GUI.Tabs.CategoriesTabs();
            this.recentDBsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.categoriesToolStripMenuItem,
            this.gamesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(921, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDatabaseToolStripMenuItem,
            this.openDatabaseToolStripMenuItem,
            this.closeDatabaseToolStripMenuItem,
            this.toolStripSeparator13,
            this.recentDBsToolStripMenuItem,
            this.toolStripSeparator1,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator6,
            this.aboutToolStripMenuItem,
            this.toolStripSeparator8,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createDatabaseToolStripMenuItem
            // 
            this.createDatabaseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.createDatabaseToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.database_add;
            this.createDatabaseToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createDatabaseToolStripMenuItem.Name = "createDatabaseToolStripMenuItem";
            this.createDatabaseToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.createDatabaseToolStripMenuItem.Text = "Create Database...";
            this.createDatabaseToolStripMenuItem.Click += new System.EventHandler(this.createDatabaseToolStripMenuItem_Click);
            // 
            // openDatabaseToolStripMenuItem
            // 
            this.openDatabaseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openDatabaseToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.database_connect;
            this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
            this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.openDatabaseToolStripMenuItem.Text = "Open Database...";
            this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
            // 
            // closeDatabaseToolStripMenuItem
            // 
            this.closeDatabaseToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.closeDatabaseToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.disconnect;
            this.closeDatabaseToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeDatabaseToolStripMenuItem.Name = "closeDatabaseToolStripMenuItem";
            this.closeDatabaseToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.closeDatabaseToolStripMenuItem.Text = "Close Database";
            this.closeDatabaseToolStripMenuItem.Click += new System.EventHandler(this.closeDatabaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.wrench;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(165, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.information;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(165, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.door_out;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCategoryToolStripMenuItem,
            this.editCategoryToolStripMenuItem,
            this.deleteCategoryToolStripMenuItem});
            this.categoriesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.categoriesToolStripMenuItem.Text = "Categories";
            // 
            // addCategoryToolStripMenuItem
            // 
            this.addCategoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.addCategoryToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.brick_add;
            this.addCategoryToolStripMenuItem.Name = "addCategoryToolStripMenuItem";
            this.addCategoryToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addCategoryToolStripMenuItem.Text = "New Category...";
            this.addCategoryToolStripMenuItem.Click += new System.EventHandler(this.addCategoryToolStripMenuItem_Click);
            // 
            // editCategoryToolStripMenuItem
            // 
            this.editCategoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editCategoryToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.brick_edit;
            this.editCategoryToolStripMenuItem.Name = "editCategoryToolStripMenuItem";
            this.editCategoryToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.editCategoryToolStripMenuItem.Text = "Edit Category...";
            this.editCategoryToolStripMenuItem.Click += new System.EventHandler(this.editCategoryToolStripMenuItem_Click);
            // 
            // deleteCategoryToolStripMenuItem
            // 
            this.deleteCategoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.deleteCategoryToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.brick_delete;
            this.deleteCategoryToolStripMenuItem.Name = "deleteCategoryToolStripMenuItem";
            this.deleteCategoryToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deleteCategoryToolStripMenuItem.Text = "Delete Category";
            this.deleteCategoryToolStripMenuItem.Click += new System.EventHandler(this.deleteCategoryToolStripMenuItem_Click);
            // 
            // gamesToolStripMenuItem
            // 
            this.gamesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGameToolStripMenuItem,
            this.editGameToolStripMenuItem,
            this.deleteGameToolStripMenuItem,
            this.toolStripSeparator5,
            this.runGameToolStripMenuItem,
            this.makeGameConfigurationToolStripMenuItem,
            this.editGameConfigurationToolStripMenuItem,
            this.toolStripSeparator10,
            this.getGameFromMyAbandonwareToolStripMenuItem,
            this.toolStripSeparator12,
            this.moveToCategoryToolStripMenuItem});
            this.gamesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.gamesToolStripMenuItem.Name = "gamesToolStripMenuItem";
            this.gamesToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.gamesToolStripMenuItem.Text = "Games";
            // 
            // addGameToolStripMenuItem
            // 
            this.addGameToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.addGameToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.controller_add;
            this.addGameToolStripMenuItem.Name = "addGameToolStripMenuItem";
            this.addGameToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.addGameToolStripMenuItem.Text = "Add Game...";
            this.addGameToolStripMenuItem.Click += new System.EventHandler(this.addGameToolStripMenuItem_Click);
            // 
            // editGameToolStripMenuItem
            // 
            this.editGameToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editGameToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.controller_edit;
            this.editGameToolStripMenuItem.Name = "editGameToolStripMenuItem";
            this.editGameToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.editGameToolStripMenuItem.Text = "Edit Game...";
            this.editGameToolStripMenuItem.Click += new System.EventHandler(this.editGameToolStripMenuItem_Click);
            // 
            // deleteGameToolStripMenuItem
            // 
            this.deleteGameToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.deleteGameToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.controller_delete;
            this.deleteGameToolStripMenuItem.Name = "deleteGameToolStripMenuItem";
            this.deleteGameToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.deleteGameToolStripMenuItem.Text = "Delete Game";
            this.deleteGameToolStripMenuItem.Click += new System.EventHandler(this.deleteGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(246, 6);
            // 
            // runGameToolStripMenuItem
            // 
            this.runGameToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.runGameToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.control_play_blue;
            this.runGameToolStripMenuItem.Name = "runGameToolStripMenuItem";
            this.runGameToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.runGameToolStripMenuItem.Text = "Run Game";
            this.runGameToolStripMenuItem.Click += new System.EventHandler(this.runGameToolStripMenuItem_Click);
            // 
            // makeGameConfigurationToolStripMenuItem
            // 
            this.makeGameConfigurationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.makeGameConfigurationToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.script_gear;
            this.makeGameConfigurationToolStripMenuItem.Name = "makeGameConfigurationToolStripMenuItem";
            this.makeGameConfigurationToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.makeGameConfigurationToolStripMenuItem.Text = "Make Game Configuration";
            this.makeGameConfigurationToolStripMenuItem.Click += new System.EventHandler(this.makeGameConfigurationToolStripMenuItem_Click);
            // 
            // editGameConfigurationToolStripMenuItem
            // 
            this.editGameConfigurationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editGameConfigurationToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.script_edit;
            this.editGameConfigurationToolStripMenuItem.Name = "editGameConfigurationToolStripMenuItem";
            this.editGameConfigurationToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.editGameConfigurationToolStripMenuItem.Text = "Edit Game Configuration";
            this.editGameConfigurationToolStripMenuItem.Click += new System.EventHandler(this.editGameConfigurationToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(246, 6);
            // 
            // getGameFromMyAbandonwareToolStripMenuItem
            // 
            this.getGameFromMyAbandonwareToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.getGameFromMyAbandonwareToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.myabandonware;
            this.getGameFromMyAbandonwareToolStripMenuItem.Name = "getGameFromMyAbandonwareToolStripMenuItem";
            this.getGameFromMyAbandonwareToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.getGameFromMyAbandonwareToolStripMenuItem.Text = "Get Game from MyAbandonware";
            this.getGameFromMyAbandonwareToolStripMenuItem.Click += new System.EventHandler(this.getGameFromMyAbandonwareToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(246, 6);
            // 
            // moveToCategoryToolStripMenuItem
            // 
            this.moveToCategoryToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.moveToCategoryToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.brick_go;
            this.moveToCategoryToolStripMenuItem.Name = "moveToCategoryToolStripMenuItem";
            this.moveToCategoryToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.moveToCategoryToolStripMenuItem.Text = "Move to Category";
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddDatabase,
            this.tsbOpenDatabase,
            this.tsbDisconnectDatabase,
            this.toolStripSeparator2,
            this.tsbNewCategory,
            this.tsbEditCategory,
            this.tsbDeleteCategory,
            this.toolStripSeparator3,
            this.tsbAddGame,
            this.tsbEditGame,
            this.tsbDeleteGame,
            this.tsbRunGame,
            this.tsbMakeGameConfigFile,
            this.tsbGameConfig,
            this.tsbMoveToCategory,
            this.toolStripSeparator11,
            this.tsbMyAbandonware,
            this.toolStripSeparator4,
            this.tsbSettings,
            this.toolStripSeparator9,
            this.tsbAbout,
            this.toolStripSeparator7,
            this.tsbClose});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(921, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip";
            // 
            // tsbAddDatabase
            // 
            this.tsbAddDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddDatabase.Image = global::DosBox_Manager.Properties.Resources.database_add;
            this.tsbAddDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddDatabase.Name = "tsbAddDatabase";
            this.tsbAddDatabase.Size = new System.Drawing.Size(23, 22);
            this.tsbAddDatabase.Text = "toolStripButton1";
            this.tsbAddDatabase.ToolTipText = "Create Database";
            this.tsbAddDatabase.Click += new System.EventHandler(this.tsbAddDatabase_Click);
            // 
            // tsbOpenDatabase
            // 
            this.tsbOpenDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenDatabase.Image = global::DosBox_Manager.Properties.Resources.database_connect;
            this.tsbOpenDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenDatabase.Name = "tsbOpenDatabase";
            this.tsbOpenDatabase.Size = new System.Drawing.Size(23, 22);
            this.tsbOpenDatabase.Text = "toolStripButton1";
            this.tsbOpenDatabase.ToolTipText = "Open Database";
            this.tsbOpenDatabase.Click += new System.EventHandler(this.tsbOpenDatabase_Click);
            // 
            // tsbDisconnectDatabase
            // 
            this.tsbDisconnectDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDisconnectDatabase.Image = global::DosBox_Manager.Properties.Resources.disconnect;
            this.tsbDisconnectDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDisconnectDatabase.Name = "tsbDisconnectDatabase";
            this.tsbDisconnectDatabase.Size = new System.Drawing.Size(23, 22);
            this.tsbDisconnectDatabase.Text = "toolStripButton1";
            this.tsbDisconnectDatabase.ToolTipText = "Close Database";
            this.tsbDisconnectDatabase.Click += new System.EventHandler(this.tsbDisconnectDatabase_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbNewCategory
            // 
            this.tsbNewCategory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewCategory.Image = global::DosBox_Manager.Properties.Resources.brick_add;
            this.tsbNewCategory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewCategory.Name = "tsbNewCategory";
            this.tsbNewCategory.Size = new System.Drawing.Size(23, 22);
            this.tsbNewCategory.Text = "toolStripButton1";
            this.tsbNewCategory.ToolTipText = "New Category";
            this.tsbNewCategory.Click += new System.EventHandler(this.tsbNewCategory_Click);
            // 
            // tsbEditCategory
            // 
            this.tsbEditCategory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditCategory.Image = global::DosBox_Manager.Properties.Resources.brick_edit;
            this.tsbEditCategory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditCategory.Name = "tsbEditCategory";
            this.tsbEditCategory.Size = new System.Drawing.Size(23, 22);
            this.tsbEditCategory.Text = "toolStripButton2";
            this.tsbEditCategory.ToolTipText = "Edit Category";
            this.tsbEditCategory.Click += new System.EventHandler(this.tsbEditCategory_Click);
            // 
            // tsbDeleteCategory
            // 
            this.tsbDeleteCategory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteCategory.Image = global::DosBox_Manager.Properties.Resources.brick_delete;
            this.tsbDeleteCategory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteCategory.Name = "tsbDeleteCategory";
            this.tsbDeleteCategory.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteCategory.Text = "toolStripButton3";
            this.tsbDeleteCategory.ToolTipText = "Delete Category";
            this.tsbDeleteCategory.Click += new System.EventHandler(this.tsbDeleteCategory_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAddGame
            // 
            this.tsbAddGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddGame.Image = global::DosBox_Manager.Properties.Resources.controller_add;
            this.tsbAddGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddGame.Name = "tsbAddGame";
            this.tsbAddGame.Size = new System.Drawing.Size(23, 22);
            this.tsbAddGame.Text = "toolStripButton1";
            this.tsbAddGame.ToolTipText = "Add Game";
            this.tsbAddGame.Click += new System.EventHandler(this.tsbAddGame_Click);
            // 
            // tsbEditGame
            // 
            this.tsbEditGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditGame.Image = global::DosBox_Manager.Properties.Resources.controller_edit;
            this.tsbEditGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditGame.Name = "tsbEditGame";
            this.tsbEditGame.Size = new System.Drawing.Size(23, 22);
            this.tsbEditGame.Text = "toolStripButton1";
            this.tsbEditGame.ToolTipText = "Edit Game";
            this.tsbEditGame.Click += new System.EventHandler(this.tsbEditGame_Click);
            // 
            // tsbDeleteGame
            // 
            this.tsbDeleteGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteGame.Image = global::DosBox_Manager.Properties.Resources.controller_delete;
            this.tsbDeleteGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteGame.Name = "tsbDeleteGame";
            this.tsbDeleteGame.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteGame.Text = "toolStripButton2";
            this.tsbDeleteGame.ToolTipText = "Delete Game";
            this.tsbDeleteGame.Click += new System.EventHandler(this.tsbDeleteGame_Click);
            // 
            // tsbRunGame
            // 
            this.tsbRunGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRunGame.Image = global::DosBox_Manager.Properties.Resources.control_play_blue;
            this.tsbRunGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRunGame.Name = "tsbRunGame";
            this.tsbRunGame.Size = new System.Drawing.Size(23, 22);
            this.tsbRunGame.Text = "toolStripButton1";
            this.tsbRunGame.ToolTipText = "Run the Game";
            this.tsbRunGame.Click += new System.EventHandler(this.tsbRunGame_Click);
            // 
            // tsbMakeGameConfigFile
            // 
            this.tsbMakeGameConfigFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMakeGameConfigFile.Image = global::DosBox_Manager.Properties.Resources.script_gear;
            this.tsbMakeGameConfigFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMakeGameConfigFile.Name = "tsbMakeGameConfigFile";
            this.tsbMakeGameConfigFile.Size = new System.Drawing.Size(23, 22);
            this.tsbMakeGameConfigFile.ToolTipText = "Make Game Configuration";
            this.tsbMakeGameConfigFile.Click += new System.EventHandler(this.tsbMakeGameConfigFile_Click);
            // 
            // tsbGameConfig
            // 
            this.tsbGameConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGameConfig.Image = global::DosBox_Manager.Properties.Resources.script_edit;
            this.tsbGameConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGameConfig.Name = "tsbGameConfig";
            this.tsbGameConfig.Size = new System.Drawing.Size(23, 22);
            this.tsbGameConfig.Text = "toolStripButton1";
            this.tsbGameConfig.ToolTipText = "Edit Game Configuration";
            this.tsbGameConfig.Click += new System.EventHandler(this.tsbGameConfig_Click);
            // 
            // tsbMoveToCategory
            // 
            this.tsbMoveToCategory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveToCategory.Image = global::DosBox_Manager.Properties.Resources.brick_go;
            this.tsbMoveToCategory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveToCategory.Name = "tsbMoveToCategory";
            this.tsbMoveToCategory.Size = new System.Drawing.Size(32, 22);
            this.tsbMoveToCategory.Text = "toolStripButton1";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbMyAbandonware
            // 
            this.tsbMyAbandonware.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMyAbandonware.Image = global::DosBox_Manager.Properties.Resources.myabandonware;
            this.tsbMyAbandonware.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMyAbandonware.Name = "tsbMyAbandonware";
            this.tsbMyAbandonware.Size = new System.Drawing.Size(23, 22);
            this.tsbMyAbandonware.ToolTipText = "Get Game from MyAbandonware";
            this.tsbMyAbandonware.Click += new System.EventHandler(this.tsbMyAbandonware_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSettings
            // 
            this.tsbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSettings.Image = global::DosBox_Manager.Properties.Resources.wrench;
            this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(23, 22);
            this.tsbSettings.Text = "toolStripButton1";
            this.tsbSettings.ToolTipText = "Application Settings";
            this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAbout
            // 
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbout.Image = global::DosBox_Manager.Properties.Resources.information;
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(23, 22);
            this.tsbAbout.Text = "toolStripButton1";
            this.tsbAbout.ToolTipText = "About...";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = global::DosBox_Manager.Properties.Resources.door_out;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(23, 22);
            this.tsbClose.Text = "toolStripButton1";
            this.tsbClose.ToolTipText = "Close DOSBox Manager";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.statusStrip.Location = new System.Drawing.Point(0, 540);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(921, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            this.statusStrip.Paint += new System.Windows.Forms.PaintEventHandler(this.statusStrip_Paint);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel.Controls.Add(this.categoriesTabs, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.lblCategories, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.pnlGames, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.pnlSearch, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 49);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(921, 491);
            this.tableLayoutPanel.TabIndex = 5;
            // 
            // lblCategories
            // 
            this.lblCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCategories.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategories.ForeColor = System.Drawing.Color.White;
            this.lblCategories.Location = new System.Drawing.Point(0, 0);
            this.lblCategories.Margin = new System.Windows.Forms.Padding(0);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(184, 20);
            this.lblCategories.TabIndex = 8;
            this.lblCategories.Text = "Available Categories";
            this.lblCategories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlGames
            // 
            this.pnlGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGames.Location = new System.Drawing.Point(184, 140);
            this.pnlGames.Margin = new System.Windows.Forms.Padding(0);
            this.pnlGames.Name = "pnlGames";
            this.pnlGames.Size = new System.Drawing.Size(737, 351);
            this.pnlGames.TabIndex = 7;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearch.Location = new System.Drawing.Point(184, 20);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(737, 120);
            this.pnlSearch.TabIndex = 11;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // categoriesTabs
            // 
            this.categoriesTabs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.categoriesTabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.categoriesTabs.Count = 0;
            this.categoriesTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesTabs.Location = new System.Drawing.Point(0, 20);
            this.categoriesTabs.Manager = null;
            this.categoriesTabs.Margin = new System.Windows.Forms.Padding(0);
            this.categoriesTabs.Name = "categoriesTabs";
            this.tableLayoutPanel.SetRowSpan(this.categoriesTabs, 2);
            this.categoriesTabs.SelectedTab = null;
            this.categoriesTabs.Size = new System.Drawing.Size(184, 471);
            this.categoriesTabs.TabBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.categoriesTabs.TabForeColor = System.Drawing.Color.White;
            this.categoriesTabs.TabHeight = 30;
            this.categoriesTabs.TabHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.categoriesTabs.TabImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.categoriesTabs.TabIndex = 10;
            this.categoriesTabs.TabTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.categoriesTabs.SearchSelected += new GUI.Tabs.CategoriesTabs.SearchSelectedDelegate(this.categoriesTabs_SearchSelected);
            this.categoriesTabs.CategoryEditClick += new GUI.Tabs.CategoriesTabs.CategoryEditClickDelegate(this.categoriesTabs_CategoryEditClick);
            this.categoriesTabs.CategoryDeleteClick += new GUI.Tabs.CategoriesTabs.CategoryDeleteClickDelegate(this.categoriesTabs_CategoryDeleteClick);
            this.categoriesTabs.CategoryCreateClick += new GUI.Tabs.CategoriesTabs.CategoryCreateClickDelegate(this.categoriesTabs_CategoryCreateClick);
            // 
            // recentDBsToolStripMenuItem
            // 
            this.recentDBsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.recentDBsToolStripMenuItem.Image = global::DosBox_Manager.Properties.Resources.database_refresh;
            this.recentDBsToolStripMenuItem.Name = "recentDBsToolStripMenuItem";
            this.recentDBsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.recentDBsToolStripMenuItem.Text = "Recent DBs";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(165, 6);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(921, 562);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DOSBox Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStripSeparator toolStripSeparator11;
        private ToolStripButton tsbMyAbandonware;
        private ToolStripMenuItem getGameFromMyAbandonwareToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem recentDBsToolStripMenuItem;
    }
}