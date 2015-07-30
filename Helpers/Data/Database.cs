/*
 * DOSBox Manager : .NET front-end for DOSBox
 * Copyright (C) 2015 MiDiUm Software
 * 
 * This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 * See the GNU General Public License for more details.
 * You should have received a copy of the GNU General Public License along with this program.
 * If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Helpers.Data.Base;
using Helpers.Data.Objects;
using System.Windows.Forms;
using GUI.MessageBoxes;

namespace Helpers.Data
{
    public class Database : BaseData
    {
        #region "Constructors"
        public Database() : base()
        {
        }

        public Database(String DBPath)
            : base(DBPath)
        {
        }
        #endregion

        #region "Methods"
        #region "DB Tables Creation"
        private void CreateCategoriesTable()
        {
            try
            {
                String sql = "CREATE TABLE Categories ( " +
                             "    id   INTEGER      NOT NULL " +
                             "                      PRIMARY KEY AUTOINCREMENT " +
                             "                      UNIQUE, " +
                             "    name VARCHAR (20) NOT NULL, " +
                             "    icon TEXT, " +
                             "    expanded BOOLEAN " +
                             ");";

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //MessageBox.Show(e.Message);
                throw;
            }
        }

        private void CreateGamesTable()
        {
            try
            {
                String sql = "CREATE TABLE Games ( " + 
                             "    id                  INTEGER       NOT NULL " + 
                             "                                      PRIMARY KEY AUTOINCREMENT " + 
                             "                                      UNIQUE, " +
                             "    category_id         INTEGER       NOT NULL, " +
                             "    title               VARCHAR (100) NOT NULL, " + 
                             "    year                INTEGER, " + 
                             "    developer           VARCHAR (256), " + 
                             "    setup_exe_path      TEXT, " + 
                             "    directory           TEXT, " + 
                             "    db_config_path      TEXT, " + 
                             "    dos_exe_path        TEXT, " + 
                             "    cd_path             TEXT, " + 
                             "    cd_image            BOOLEAN, " + 
                             "    use_IOCTL           BOOLEAN, " + 
                             "    mount_as_floppy     BOOLEAN, " + 
                             "    additional_commands TEXT, " + 
                             "    no_config           BOOLEAN, " + 
                             "    in_full_screen      BOOLEAN, " + 
                             "    no_console          BOOLEAN, " + 
                             "    quit_on_exit        BOOLEAN, " + 
                             "    image_path          TEXT " +
                             "    created_at          DATETIME      NOT NULL, "+
                             "    updated_at          DATETIME      DEFAULT (CURRENT_TIMESTAMP) NOT NULL " +
                             "); ";

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateRecentGamesTable()
        {
            try
            {
                String sql = "CREATE TABLE RecentGames ( " +
                             "    id            INTEGER  PRIMARY KEY AUTOINCREMENT " +
                             "                           UNIQUE " +
                             "                           NOT NULL, " +
                             "    game_id       INTEGER  NOT NULL, " +
                             "    latest_access DATETIME DEFAULT (CURRENT_TIMESTAMP)  " +
                             "); ";

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Publics"
        public bool CreateDB(String DBPath)
        {
            bool result = true;

            try
            {
                //Creating the DB file
                SQLiteConnection.CreateFile(DBPath);

                //Initiating connection in case it is not inited
                if (_Connection == null)
                    _Connection = new SQLiteConnection();

                //Opening new connection
                _DBPath = DBPath;
                _ConnectionString = String.Format("Data Source={0};Version=3;", DBPath);
                _Connection.ConnectionString = _ConnectionString;
                _Connection.Open();

                //Creating the DB tables
                CreateCategoriesTable();
                CreateGamesTable();
                CreateRecentGamesTable();

            }
            catch (Exception)
            {
                result = false;
            }

            return result;
            
        }
        #endregion

        #region "Categories"
        public Category GetCategory(int categoryID)
        {
            Category result = null;

            if (_Connection.State != System.Data.ConnectionState.Open)
                //I raise an error as there is no connection to the database
                throw new Exception("There is no connection to the database");

            String sql = string.Format("SELECT id, name, icon, expanded " +
                         "FROM Categories C " +
                         "WHERE id = {0};",categoryID);

            SQLiteCommand command = new SQLiteCommand(sql, _Connection);
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                int itemID = -1;
                if (reader["id"] != DBNull.Value)
                    itemID = reader.GetInt32(0);

                string itemName = string.Empty;
                if (reader["name"] != DBNull.Value)
                    itemName = reader.GetString(1);

                string itemIcon = string.Empty;
                if (reader["icon"] != DBNull.Value)
                    itemIcon = reader.GetString(2);

                bool itemExpanded = false;
                if (reader["expanded"] != DBNull.Value)
                    itemExpanded = reader.GetBoolean(3);

                bool itemSelected = (itemExpanded) ? true : false;

                result = new Category(itemID, itemName, itemIcon, itemExpanded, itemSelected);
            }

            return result;
        }

        public List<Category> GetAllCategories()
        {
            if (_Connection.State != System.Data.ConnectionState.Open)
                //I raise an error as there is no connection to the database
                throw new Exception("There is no connection to the database");

            List<Category> categories = null;

            String sql = "SELECT id, name, icon, expanded "+
                         "FROM Categories C " +
                         "ORDER BY name;";

            SQLiteCommand command = new SQLiteCommand(sql, _Connection);
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                categories = new List<Category>();

                while (reader.Read())
                {
                    int itemID = -1;
                    if(reader["id"] != DBNull.Value) 
                        itemID = reader.GetInt32(0);

                    string itemName = string.Empty;
                    if (reader["name"] != DBNull.Value) 
                        itemName = reader.GetString(1);

                    string itemIcon =  string.Empty;
                    if (reader["icon"] != DBNull.Value) 
                        itemIcon = reader.GetString(2);

                    bool itemExpanded = false;
                    if (reader["expanded"] != DBNull.Value) 
                        itemExpanded = reader.GetBoolean(3);

                    bool isSelected = (itemExpanded) ? true : false;

                    categories.Add(new Category(itemID, itemName, itemIcon, itemExpanded, isSelected));
                }

            }

            return categories;

        }

        public bool AddCategory(String Name, String Icon)
        {
            try
            {

                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                String sql = String.Format("INSERT INTO Categories (Name, Icon) VALUES ('{0}','{1}');", Name, Icon);

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditCategory(int catId, String Name, String Icon)
        {
            try
            {

                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                String sql = String.Format("UPDATE Categories SET name = '{0}', icon = '{1}' WHERE id = {2};", Name, Icon, catId );

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveCategory(int catId)
        {
            try
            {
                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                //First I remove all the games related to this category
                String sql = String.Format("DELETE FROM Games WHERE category_id = {0};", catId);
                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();

                //Now I remove the category
                sql = String.Format("DELETE FROM Categories WHERE id = {0};", catId);
                command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int GetCategoriesCount()
        {
            try
            {
                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                    String sql = "SELECT COUNT(id) "+
                                 "FROM Categories C;";

                    SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                    SQLiteDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        return reader.GetInt32(0);
                    }
                    else
                        return 0;

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void SwitchExpandedStatus(int PreviousCategoryID, int CategoryID)
        {
            try
            {
                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                String sql = String.Format("UPDATE Categories SET expanded = 0 WHERE id = {0};", PreviousCategoryID);

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();

                sql = String.Format("UPDATE Categories SET expanded = 1 WHERE id = {0};", CategoryID);

                command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Games"
        public bool RemoveGame(int GameID)
        {
            try
            {
                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                String sql = String.Format("DELETE FROM Games WHERE id = {0}", GameID);

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();

                return true;

            }
            catch (Exception e)
            {
                CustomMessageBox cmb = new CustomMessageBox("An error raised trying to remove the selected game:\n" + e.Message, "Error",MessageBoxDialogButtons.Ok,MessageBoxDialogIcon.Error,false,false);
                cmb.ShowDialog();
                cmb.Dispose();
                return false;   
            }
        }

        public bool MoveGameToCategory(int GameID, int CategoryID)
        {
            try
            {
                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                String sql = String.Format("UPDATE Games SET category_id = {1} WHERE id = {0}", GameID, CategoryID);

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                CustomMessageBox cmb = new CustomMessageBox("An error raised trying to move the selected game to the new category:\n" + e.Message, "Error", MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Error, false, false);
                cmb.ShowDialog();
                cmb.Dispose();
                return false;
            }
        }

        public bool SaveGame(Game game)
        {
            try
            {

                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                String sql;

                if (game.ID != 0)
                {
                    //Edit
                    sql = String.Format("UPDATE Games SET " +
                                        "category_id = {0}, title = '{1}', year = {2}, developer = '{3}', setup_exe_path = '{4}', " +
                                        "directory = '{5}', db_config_path = '{6}', dos_exe_path = '{7}', cd_path = '{8}', cd_image = {9}, " +
                                        "use_IOCTL = {10}, mount_as_floppy = {11}, additional_commands = '{12}', no_config = {13}, " +
                                        "in_full_screen = {14}, no_console = {15}, quit_on_exit = {16}, image_path = '{17}', created_at = '{18}' " +
                                        "WHERE id = {19};",
                                        game.CategoryID, game.Title.Replace("'", "''"), game.Year, game.Developer.Replace("'", "''"),
                                        game.SetupExePath.Replace("'", "''"), game.Directory.Replace("'", "''"),
                                        game.DBConfigPath.Replace("'", "''"), game.DOSExePath.Replace("'", "''"),
                                        game.CDPath.Replace("'", "''"), BoolToInt(game.IsCDImage), BoolToInt(game.UseIOCTL),
                                        BoolToInt(game.MountAsFloppy), game.AdditionalCommands.Replace("'", "''"),
                                        BoolToInt(game.NoConfig), BoolToInt(game.InFullScreen), BoolToInt(game.NoConsole),
                                        BoolToInt(game.QuitOnExit), game.ImagePath.Replace("'", "''"),
                                        DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), game.ID);

                }
                else
                {
                    //Add
                    sql = String.Format("INSERT INTO Games (category_id, title, year, developer, setup_exe_path, " +
                                               "directory, db_config_path, dos_exe_path, cd_path, cd_image, " +
                                               "use_IOCTL, mount_as_floppy, additional_commands, no_config, " +
                                               "in_full_screen, no_console, quit_on_exit, image_path, created_at) " +
                                               "VALUES ({0}, '{1}', {2}, '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', " +
                                               "{9}, {10}, {11}, '{12}', {13}, {14}, {15}, {16}, '{17}', '{18}');",
                                               game.CategoryID, game.Title.Replace("'", "''"), game.Year, game.Developer.Replace("'", "''"),
                                               game.SetupExePath.Replace("'", "''"), game.Directory.Replace("'", "''"),
                                               game.DBConfigPath.Replace("'", "''"), game.DOSExePath.Replace("'", "''"),
                                               game.CDPath.Replace("'", "''"), BoolToInt(game.IsCDImage), BoolToInt(game.UseIOCTL),
                                               BoolToInt(game.MountAsFloppy), game.AdditionalCommands.Replace("'", "''"),
                                               BoolToInt(game.NoConfig), BoolToInt(game.InFullScreen), BoolToInt(game.NoConsole),
                                               BoolToInt(game.QuitOnExit), game.ImagePath.Replace("'", "''"),
                                               DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

                }

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int GetTotalGamesCount()
        {
            try
            {
                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                String sql = "SELECT COUNT(id) " +
                             "FROM Games G;";

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
                else
                    return 0;

            }
            catch (Exception)
            {
                return 0;
            }
        }
        
        public List<Game> GetAllGamesForCategory(int CategoryID)
        {
            if (_Connection.State != System.Data.ConnectionState.Open)
                //I raise an error as there is no connection to the database
                throw new Exception("There is no connection to the database");

            List<Game> games = null;

            String sql = string.Format("SELECT id, category_id, title, year, developer, setup_exe_path, " +
                         "directory, db_config_path, dos_exe_path, cd_path, cd_image, use_IOCTL, " +
                         "mount_as_floppy, additional_commands, no_config, in_full_screen, no_console, " +
                         "quit_on_exit, image_path, created_at, updated_at " +
                         "FROM Games G " +
                         "WHERE G.category_id = {0} " +
                         "ORDER BY title;", CategoryID);

            SQLiteCommand command = new SQLiteCommand(sql, _Connection);
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                games = new List<Game>();

                while (reader.Read())
                {
                    int itemID = -1;
                    if (reader["id"] != DBNull.Value)
                        itemID = reader.GetInt32(0);

                    int itemCategoryID = -1;
                    if (reader["category_id"] != DBNull.Value)
                        itemCategoryID = reader.GetInt32(1);

                    string itemTitle = string.Empty;
                    if (reader["title"] != DBNull.Value)
                        itemTitle = reader.GetString(2);

                    int itemYear = -1;
                    if (reader["year"] != DBNull.Value)
                        itemYear = reader.GetInt32(3);

                    string itemDeveloper = string.Empty;
                    if (reader["developer"] != DBNull.Value)
                        itemDeveloper = reader.GetString(4);

                    string itemSetupExePath = string.Empty;
                    if (reader["setup_exe_path"] != DBNull.Value)
                        itemSetupExePath = reader.GetString(5);

                    string itemDirectory = string.Empty;
                    if (reader["directory"] != DBNull.Value)
                        itemDirectory = reader.GetString(6);

                    string itemDBConfigPath = string.Empty;
                    if (reader["db_config_path"] != DBNull.Value)
                        itemDBConfigPath = reader.GetString(7);

                    string itemDosExePath = string.Empty;
                    if (reader["dos_exe_path"] != DBNull.Value)
                        itemDosExePath = reader.GetString(8);

                    string itemCDPath = string.Empty;
                    if (reader["cd_path"] != DBNull.Value)
                        itemCDPath = reader.GetString(9);

                    bool itemCDImage = false;
                    if (reader["cd_image"] != DBNull.Value)
                        itemCDImage = reader.GetBoolean(10);

                    bool itemUseIOCTL = false;
                    if (reader["use_IOCTL"] != DBNull.Value)
                        itemUseIOCTL = reader.GetBoolean(11);

                    bool itemMountAsFloppy = false;
                    if (reader["mount_as_floppy"] != DBNull.Value)
                        itemMountAsFloppy = reader.GetBoolean(12);

                    string itemAdditionalCommands = string.Empty;
                    if (reader["additional_commands"] != DBNull.Value)
                        itemAdditionalCommands = reader.GetString(13);

                    bool itemNoConfig = false;
                    if (reader["no_config"] != DBNull.Value)
                        itemNoConfig = reader.GetBoolean(14);

                    bool itemInFullScreen = false;
                    if (reader["in_full_screen"] != DBNull.Value)
                        itemInFullScreen = reader.GetBoolean(15);

                    bool itemNoConsole = false;
                    if (reader["no_console"] != DBNull.Value)
                        itemNoConsole = reader.GetBoolean(16);

                    bool itemQuitOnExit = false;
                    if (reader["quit_on_exit"] != DBNull.Value)
                        itemQuitOnExit = reader.GetBoolean(17);

                    string itemImagePath = string.Empty;
                    if (reader["image_path"] != DBNull.Value)
                        itemImagePath = reader.GetString(18);

                    DateTime itemCreatedAt = DateTime.MinValue;
                    if (reader["created_at"] != DBNull.Value)
                        itemCreatedAt = reader.GetDateTime(19);

                    DateTime itemUpdatedAt = DateTime.MinValue;
                    if (reader["updated_at"] != DBNull.Value)
                        itemUpdatedAt = reader.GetDateTime(20);

                    games.Add(new Game(itemID,itemCategoryID,itemTitle,itemYear,itemDeveloper,
                                       itemSetupExePath,itemDirectory,itemDBConfigPath,itemDosExePath,
                                       itemCDPath,itemCDImage,itemUseIOCTL,itemMountAsFloppy,
                                       itemAdditionalCommands,itemNoConfig,itemInFullScreen,
                                       itemNoConsole, itemQuitOnExit, itemImagePath, itemCreatedAt, itemUpdatedAt));
                }

            }

            return games;

        }

        public List<Game> SearchGames(string Title, string Year, string Developer, int CategoryID)
        {
            try
            {
                List<Game> result = null;

                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                String sql = "SELECT id, category_id, title, year, developer, setup_exe_path, " +
                         "directory, db_config_path, dos_exe_path, cd_path, cd_image, use_IOCTL, " +
                         "mount_as_floppy, additional_commands, no_config, in_full_screen, no_console, " +
                         "quit_on_exit, image_path, created_at, updated_at " +
                         "FROM Games G ";

                String where = ComposeSearchWhereClausule(Title, Year, Developer, CategoryID);

                SQLiteCommand command = new SQLiteCommand(sql + where, _Connection);
                SQLiteDataReader reader = command.ExecuteReader();

                //Checking if something has been found
                if (reader.HasRows)
                {
                    result = new List<Game>();

                    while (reader.Read())
                    {
                        int itemID = -1;
                        if (reader["id"] != DBNull.Value)
                            itemID = reader.GetInt32(0);

                        int itemCategoryID = -1;
                        if (reader["category_id"] != DBNull.Value)
                            itemCategoryID = reader.GetInt32(1);

                        string itemTitle = string.Empty;
                        if (reader["title"] != DBNull.Value)
                            itemTitle = reader.GetString(2);

                        int itemYear = -1;
                        if (reader["year"] != DBNull.Value)
                            itemYear = reader.GetInt32(3);

                        string itemDeveloper = string.Empty;
                        if (reader["developer"] != DBNull.Value)
                            itemDeveloper = reader.GetString(4);

                        string itemSetupExePath = string.Empty;
                        if (reader["setup_exe_path"] != DBNull.Value)
                            itemSetupExePath = reader.GetString(5);

                        string itemDirectory = string.Empty;
                        if (reader["directory"] != DBNull.Value)
                            itemDirectory = reader.GetString(6);

                        string itemDBConfigPath = string.Empty;
                        if (reader["db_config_path"] != DBNull.Value)
                            itemDBConfigPath = reader.GetString(7);

                        string itemDosExePath = string.Empty;
                        if (reader["dos_exe_path"] != DBNull.Value)
                            itemDosExePath = reader.GetString(8);

                        string itemCDPath = string.Empty;
                        if (reader["cd_path"] != DBNull.Value)
                            itemCDPath = reader.GetString(9);

                        bool itemCDImage = false;
                        if (reader["cd_image"] != DBNull.Value)
                            itemCDImage = reader.GetBoolean(10);

                        bool itemUseIOCTL = false;
                        if (reader["use_IOCTL"] != DBNull.Value)
                            itemUseIOCTL = reader.GetBoolean(11);

                        bool itemMountAsFloppy = false;
                        if (reader["mount_as_floppy"] != DBNull.Value)
                            itemMountAsFloppy = reader.GetBoolean(12);

                        string itemAdditionalCommands = string.Empty;
                        if (reader["additional_commands"] != DBNull.Value)
                            itemAdditionalCommands = reader.GetString(13);

                        bool itemNoConfig = false;
                        if (reader["no_config"] != DBNull.Value)
                            itemNoConfig = reader.GetBoolean(14);

                        bool itemInFullScreen = false;
                        if (reader["in_full_screen"] != DBNull.Value)
                            itemInFullScreen = reader.GetBoolean(15);

                        bool itemNoConsole = false;
                        if (reader["no_console"] != DBNull.Value)
                            itemNoConsole = reader.GetBoolean(16);

                        bool itemQuitOnExit = false;
                        if (reader["quit_on_exit"] != DBNull.Value)
                            itemQuitOnExit = reader.GetBoolean(17);

                        string itemImagePath = string.Empty;
                        if (reader["image_path"] != DBNull.Value)
                            itemImagePath = reader.GetString(18);

                        DateTime itemCreatedAt = DateTime.MinValue;
                        if (reader["created_at"] != DBNull.Value)
                            itemCreatedAt = reader.GetDateTime(19);

                        DateTime itemUpdatedAt = DateTime.MinValue;
                        if (reader["updated_at"] != DBNull.Value)
                            itemUpdatedAt = reader.GetDateTime(20);

                        result.Add(new Game(itemID, itemCategoryID, itemTitle, itemYear, itemDeveloper,
                                           itemSetupExePath, itemDirectory, itemDBConfigPath, itemDosExePath,
                                           itemCDPath, itemCDImage, itemUseIOCTL, itemMountAsFloppy,
                                           itemAdditionalCommands, itemNoConfig, itemInFullScreen,
                                           itemNoConsole, itemQuitOnExit, itemImagePath, itemCreatedAt, itemUpdatedAt));
                    }
                }

                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        private string ComposeSearchWhereClausule(string Title, string Year, string Developer, int CategoryID)
        {
            string title_clausule = string.Empty;
            string year_clausule = string.Empty;
            string developer_clausule = string.Empty;
            string categories_clausule = string.Empty;

            if (Title != string.Empty)
                title_clausule = string.Format("title LIKE '%{0}%' AND ", Title);

            if (Year != string.Empty)
                year_clausule = string.Format("year = {0} AND ", Year);

            if (Developer != string.Empty)
                developer_clausule = string.Format("developer LIKE '%{0}%' AND ", Developer);

            if (CategoryID > 0)
                categories_clausule = string.Format("category_id = {0} AND ", CategoryID);

            string result = string.Format("WHERE {0}{1}{2}{3}", title_clausule, year_clausule, developer_clausule, categories_clausule);

            if (result == "WHERE ")
                return string.Empty; //No selection, no where clausule, all games will be taken
            else
                result = result.Substring(0, result.Length - 4); //Removing latest "AND " from the string

            return result;
        
        }

        public Game GetGamesFromID(int GameID)
        {
            if (_Connection.State != System.Data.ConnectionState.Open)
                //I raise an error as there is no connection to the database
                throw new Exception("There is no connection to the database");

            Game game = null;

            String sql = string.Format("SELECT id, category_id, title, year, developer, setup_exe_path, " +
                         "directory, db_config_path, dos_exe_path, cd_path, cd_image, use_IOCTL, " +
                         "mount_as_floppy, additional_commands, no_config, in_full_screen, no_console, " +
                         "quit_on_exit, image_path, created_at, updated_at " +
                         "FROM Games G " +
                         "WHERE G.id = {0};", GameID);

            SQLiteCommand command = new SQLiteCommand(sql, _Connection);
            SQLiteDataReader reader = command.ExecuteReader();

            //Checking if something has been found
            if (reader.HasRows)
            {
                //Loading the data
                reader.Read();
                
                int itemID = -1;
                if (reader["id"] != DBNull.Value)
                    itemID = reader.GetInt32(0);

                int itemCategoryID = -1;
                if (reader["category_id"] != DBNull.Value)
                    itemCategoryID = reader.GetInt32(1);

                string itemTitle = string.Empty;
                if (reader["title"] != DBNull.Value)
                    itemTitle = reader.GetString(2);

                int itemYear = -1;
                if (reader["year"] != DBNull.Value)
                    itemYear = reader.GetInt32(3);

                string itemDeveloper = string.Empty;
                if (reader["developer"] != DBNull.Value)
                    itemDeveloper = reader.GetString(4);

                string itemSetupExePath = string.Empty;
                if (reader["setup_exe_path"] != DBNull.Value)
                    itemSetupExePath = reader.GetString(5);

                string itemDirectory = string.Empty;
                if (reader["directory"] != DBNull.Value)
                    itemDirectory = reader.GetString(6);

                string itemDBConfigPath = string.Empty;
                if (reader["db_config_path"] != DBNull.Value)
                    itemDBConfigPath = reader.GetString(7);

                string itemDosExePath = string.Empty;
                if (reader["dos_exe_path"] != DBNull.Value)
                    itemDosExePath = reader.GetString(8);

                string itemCDPath = string.Empty;
                if (reader["cd_path"] != DBNull.Value)
                    itemCDPath = reader.GetString(9);

                bool itemCDImage = false;
                if (reader["cd_image"] != DBNull.Value)
                    itemCDImage = reader.GetBoolean(10);

                bool itemUseIOCTL = false;
                if (reader["use_IOCTL"] != DBNull.Value)
                    itemUseIOCTL = reader.GetBoolean(11);

                bool itemMountAsFloppy = false;
                if (reader["mount_as_floppy"] != DBNull.Value)
                    itemMountAsFloppy = reader.GetBoolean(12);

                string itemAdditionalCommands = string.Empty;
                if (reader["additional_commands"] != DBNull.Value)
                    itemAdditionalCommands = reader.GetString(13);

                bool itemNoConfig = false;
                if (reader["no_config"] != DBNull.Value)
                    itemNoConfig = reader.GetBoolean(14);

                bool itemInFullScreen = false;
                if (reader["in_full_screen"] != DBNull.Value)
                    itemInFullScreen = reader.GetBoolean(15);

                bool itemNoConsole = false;
                if (reader["no_console"] != DBNull.Value)
                    itemNoConsole = reader.GetBoolean(16);

                bool itemQuitOnExit = false;
                if (reader["quit_on_exit"] != DBNull.Value)
                    itemQuitOnExit = reader.GetBoolean(17);

                string itemImagePath = string.Empty;
                if (reader["image_path"] != DBNull.Value)
                    itemImagePath = reader.GetString(18);

                DateTime itemCreatedAt = DateTime.MinValue;
                if (reader["created_at"] != DBNull.Value)
                    itemCreatedAt = reader.GetDateTime(19);

                DateTime itemUpdatedAt = DateTime.MinValue;
                if (reader["updated_at"] != DBNull.Value)
                    itemUpdatedAt = reader.GetDateTime(20);

                game = new Game(itemID, itemCategoryID, itemTitle, itemYear, itemDeveloper,
                                    itemSetupExePath, itemDirectory, itemDBConfigPath, itemDosExePath,
                                    itemCDPath, itemCDImage, itemUseIOCTL, itemMountAsFloppy,
                                    itemAdditionalCommands, itemNoConfig, itemInFullScreen,
                                    itemNoConsole, itemQuitOnExit, itemImagePath, itemCreatedAt, itemUpdatedAt);
                
            }

            return game;

        }
        #endregion
        #endregion
    }
}
