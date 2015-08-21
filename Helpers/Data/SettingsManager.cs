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
using Helpers.Data.Base;
using System.Data.SQLite;
using System.Windows.Forms;
using Helpers.Data.Objects;
using Helpers.Data.Objects.Translation;
using Helpers.Translation;
using CustomMessageBoxes.MessageBoxes;

namespace Helpers.Data
{
    public class SettingsManager : BaseData
    {
        #region "Constructors"
        public SettingsManager() 
            : base()            
        {

        }

        public SettingsManager(String DBPath)
            : base(DBPath)
        {

        }
        #endregion

        #region "DB Tables Creation"
        private void CreateSettingsTable()
        {
            try
            {
                String sql = "CREATE TABLE Settings (app_width INTEGER, app_height INTEGER, portable_mode BOOLEAN, dosbox_path TEXT, dosbox_default_conf_file_path TEXT, " +
                             "dosbox_default_lang_file_path TEXT, cds_default_dir TEXT, games_default_dir TEXT, games_no_console BOOLEAN, games_in_full_screen BOOLEAN, " +
                             "games_quit_on_exit BOOLEAN, games_additional_commands TEXT, box_rendered BOOLEAN, app_fullscreen BOOLEAN, menu_bar_visible BOOLEAN, " +
                             "toolbar_visible BOOLEAN, status_bar_visible BOOLEAN, config_editor_path TEXT, config_editor_additional_parameters TEXT, " +
                             "category_delete_prompt BOOLEAN, game_delete_prompt BOOLEAN, remember_window_size BOOLEAN, language INTEGER NOT NULL DEFAULT (0), " +
                             "reload_latest_db BOOLEAN NOT NULL DEFAULT (0), reduce_to_tray_on_play BOOLEAN);";

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateRecentDatabasesTable()
        {
            try
            {
                String sql = "CREATE TABLE RecentDatabases (id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, path TEXT NOT NULL, " +
                             "latest_access DATETIME DEFAULT (CURRENT_TIMESTAMP));";

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Settings Methods"
        public void SaveSettings(Settings AppSettings)
        {
            if (AppSettings == null)
                throw new Exception("No application settings provided!");

            try
            {
                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE Settings SET ");
                sql.AppendLine(string.Format("app_width = {0}, ", AppSettings.AppWidth));
                sql.AppendLine(string.Format("app_height = {0}, ", AppSettings.AppHeight));
                sql.AppendLine(string.Format("portable_mode = {0}, ", BoolToInt(AppSettings.PortableMode)));
                sql.AppendLine(string.Format("dosbox_path = '{0}', ", AppSettings.DosboxPath.Replace("'", "''")));
                sql.AppendLine(string.Format("dosbox_default_conf_file_path = '{0}', ", AppSettings.DosboxDefaultConfFilePath.Replace("'", "''")));
                sql.AppendLine(string.Format("dosbox_default_lang_file_path = '{0}', ", AppSettings.DosboxDefaultLangFilePath.Replace("'", "''")));
                sql.AppendLine(string.Format("cds_default_dir = '{0}', ", AppSettings.CDsDefaultDir.Replace("'", "''")));
                sql.AppendLine(string.Format("games_default_dir = '{0}', ", AppSettings.GamesDefaultDir.Replace("'", "''")));
                sql.AppendLine(string.Format("games_no_console = {0}, ", BoolToInt(AppSettings.GamesNoConsole)));
                sql.AppendLine(string.Format("games_in_full_screen = {0}, ", BoolToInt(AppSettings.GamesInFullScreen)));
                sql.AppendLine(string.Format("games_quit_on_exit = {0}, ", BoolToInt(AppSettings.GamesQuitOnExit)));
                sql.AppendLine(string.Format("games_additional_commands = '{0}', ", AppSettings.GamesAdditionalCommands.Replace("'", "''")));
                sql.AppendLine(string.Format("box_rendered = {0}, ", BoolToInt(AppSettings.BoxRendered)));
                sql.AppendLine(string.Format("app_fullscreen = {0}, ", BoolToInt(AppSettings.AppFullscreen)));
                sql.AppendLine(string.Format("menu_bar_visible = {0}, ", BoolToInt(AppSettings.MenuBarVisible)));
                sql.AppendLine(string.Format("toolbar_visible = {0}, ", BoolToInt(AppSettings.ToolbarVisible)));
                sql.AppendLine(string.Format("status_bar_visible = {0}, ", BoolToInt(AppSettings.StatusBarVisible)));
                sql.AppendLine(string.Format("config_editor_path = '{0}', ", AppSettings.ConfigEditorPath.Replace("'", "''")));
                sql.AppendLine(string.Format("config_editor_additional_parameters = '{0}', ", AppSettings.ConfigEditorAdditionalParameters.Replace("'", "''")));
                sql.AppendLine(string.Format("category_delete_prompt = {0}, ", BoolToInt(AppSettings.CategoryDeletePrompt)));
                sql.AppendLine(string.Format("game_delete_prompt = {0}, ", BoolToInt(AppSettings.GameDeletePrompt)));
                sql.AppendLine(string.Format("remember_window_size = {0}, ", BoolToInt(AppSettings.RememberWindowSize)));
                sql.AppendLine(string.Format("reload_latest_db = {0}, ", BoolToInt(AppSettings.ReloadLatestDB)));
                sql.AppendLine(string.Format("language = {0}, ", ((AppSettings.Language == Settings.Languages.English) ? 0 : 1)));
                sql.AppendLine(string.Format("reduce_to_tray_on_play = {0};", BoolToInt(AppSettings.ReduceToTrayOnPlay)));

                SQLiteCommand command = new SQLiteCommand(sql.ToString(), _Connection);
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                CustomMessageBox cmb = new CustomMessageBox("An issues raised trying to save the application settings:\n" + e.Message, "Error", MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Error, false, false);
                cmb.ShowDialog();
                cmb.Dispose();
            }

        }

        public Settings LoadSettings()
        {
            Settings result = null;

            try
            {

                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                String sql = "SELECT * FROM Settings;";
                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    result = new Settings();

                    reader.Read(); //Load the settings row

                    if (reader["app_width"] != DBNull.Value)
                        result.AppWidth = reader.GetInt32(0);

                    if (reader["app_height"] != DBNull.Value)
                        result.AppHeight = reader.GetInt32(1);

                    if (reader["portable_mode"] != DBNull.Value)
                        result.PortableMode = reader.GetBoolean(2);

                    if (reader["dosbox_path"] != DBNull.Value)
                        result.DosboxPath = reader.GetString(3);

                    if (reader["dosbox_default_conf_file_path"] != DBNull.Value)
                        result.DosboxDefaultConfFilePath = reader.GetString(4);

                    if (reader["dosbox_default_lang_file_path"] != DBNull.Value)
                        result.DosboxDefaultLangFilePath = reader.GetString(5);

                    if (reader["cds_default_dir"] != DBNull.Value)
                        result.CDsDefaultDir = reader.GetString(6);

                    if (reader["games_default_dir"] != DBNull.Value)
                        result.GamesDefaultDir = reader.GetString(7);

                    if (reader["games_no_console"] != DBNull.Value)
                        result.GamesNoConsole = reader.GetBoolean(8);

                    if (reader["games_in_full_screen"] != DBNull.Value)
                        result.GamesInFullScreen = reader.GetBoolean(9);

                    if (reader["games_quit_on_exit"] != DBNull.Value)
                        result.GamesQuitOnExit = reader.GetBoolean(10);

                    if (reader["games_additional_commands"] != DBNull.Value)
                        result.GamesAdditionalCommands = reader.GetString(11);

                    if (reader["box_rendered"] != DBNull.Value)
                        result.BoxRendered = reader.GetBoolean(12);

                    if (reader["app_fullscreen"] != DBNull.Value)
                        result.AppFullscreen = reader.GetBoolean(13);

                    if (reader["menu_bar_visible"] != DBNull.Value)
                        result.MenuBarVisible = reader.GetBoolean(14);

                    if (reader["toolbar_visible"] != DBNull.Value)
                        result.ToolbarVisible = reader.GetBoolean(15);

                    if (reader["status_bar_visible"] != DBNull.Value)
                        result.StatusBarVisible = reader.GetBoolean(16);

                    if (reader["config_editor_path"] != DBNull.Value)
                        result.ConfigEditorPath = reader.GetString(17);

                    if (reader["config_editor_additional_parameters"] != DBNull.Value)
                        result.ConfigEditorAdditionalParameters = reader.GetString(18);

                    if (reader["category_delete_prompt"] != DBNull.Value)
                        result.CategoryDeletePrompt = reader.GetBoolean(19);

                    if (reader["game_delete_prompt"] != DBNull.Value)
                        result.GameDeletePrompt = reader.GetBoolean(20);

                    if (reader["remember_window_size"] != DBNull.Value)
                        result.RememberWindowSize = reader.GetBoolean(21);

                    if (reader["language"] != DBNull.Value)
                        result.Language = (reader.GetInt32(22) == 0) ? Settings.Languages.English : Settings.Languages.Italian;

                    if (reader["reload_latest_db"] != DBNull.Value)
                        result.ReloadLatestDB = reader.GetBoolean(23);

                    if (reader["reduce_to_tray_on_play"] != DBNull.Value)
                        result.ReduceToTrayOnPlay = reader.GetBoolean(24);
                }
                else
                {
                    //Nothing found I set the defaults and return them
                    return SetDefaultSettings();
                }

            }
            catch (Exception)
            {
                //In case of errors I return at least the defaults ones without storing them to avoid other issues.
                return GetDefaultSettings();
            }

            return result;
        }

        public Settings SetDefaultSettings()
        {
            Settings result = null;

            try
            {
                String sql = "INSERT INTO Settings (app_width, app_height, portable_mode, " +
                             "  dosbox_path, dosbox_default_conf_file_path, dosbox_default_lang_file_path, cds_default_dir, games_default_dir, games_no_console, " +
                             "  games_in_full_screen, games_quit_on_exit, games_additional_commands, box_rendered, app_fullscreen, menu_bar_visible, toolbar_visible, " +
                             "  status_bar_visible, config_editor_path, config_editor_additional_parameters, category_delete_prompt, game_delete_prompt, " +
                             "  remember_window_size, language, reload_latest_db, reduce_to_tray_on_play) " +
                             "VALUES (800, 600, 0, '', '', '', '', '', 0, 0, 0, '', 0, 0, 1, 1, 1, '', '', 0, 0, 1, 0, 0, 1);";

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();

                result = GetDefaultSettings();

                return result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        private static Settings GetDefaultSettings()
        {
            Settings result = new Settings();

            result.AppWidth = 800;
            result.AppHeight = 600;
            result.PortableMode = false;
            result.DosboxPath = string.Empty;
            result.DosboxDefaultConfFilePath = string.Empty;
            result.DosboxDefaultLangFilePath = string.Empty;
            result.CDsDefaultDir = string.Empty;
            result.GamesDefaultDir = string.Empty;
            result.GamesNoConsole = false;
            result.GamesInFullScreen = false;
            result.GamesQuitOnExit = false;
            result.GamesAdditionalCommands = string.Empty;
            result.BoxRendered = false;
            result.AppFullscreen = false;
            result.MenuBarVisible = true;
            result.ToolbarVisible = true;
            result.StatusBarVisible = true;
            result.ConfigEditorPath = string.Empty;
            result.ConfigEditorAdditionalParameters = string.Empty;
            result.CategoryDeletePrompt = true;
            result.GameDeletePrompt = true;
            result.RememberWindowSize = true;
            result.ReloadLatestDB = false;
            result.Language = Settings.Languages.English;
            result.ReduceToTrayOnPlay = true;

            return result;
        }
        #endregion

        #region "Translations Methods"
        public Dictionary<int, MessageTranslation> LoadMessagesTranslations()
        {
            Dictionary<int, MessageTranslation> result = null; 

            try
            {
                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                String sql = "SELECT * FROM MessagesTranslations;";

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    result = new Dictionary<int, MessageTranslation>();

                    while (reader.Read())
                    {
                        MessageTranslation msg = new MessageTranslation();

                        if (reader["id"] != DBNull.Value)
                            msg.ID = reader.GetInt32(0);

                        if (reader["english"] != DBNull.Value)
                            msg.English = reader.GetString(1);

                        if (reader["italian"] != DBNull.Value)
                            msg.Italian = reader.GetString(2);

                        result.Add(msg.ID, msg);
                    }

                }

                return result;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public Dictionary<string, ComponentTranslation> LoadComponentsTranslations()
        {
            Dictionary<string, ComponentTranslation> result = null;

            try
            {
                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                String sql = "SELECT * FROM ComponentsTranslations ORDER BY parent_form, component_name;";

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    result = new Dictionary<string, ComponentTranslation>();

                    while (reader.Read())
                    {
                        ComponentTranslation cmp = new ComponentTranslation();

                        if (reader["id"] != DBNull.Value)
                            cmp.ID = reader.GetInt32(0);

                        if (reader["parent_form"] != DBNull.Value)
                            cmp.ParentForm = reader.GetString(1);

                        if (reader["component_name"] != DBNull.Value)
                            cmp.ComponentName = reader.GetString(2);

                        if (reader["tooltip_english"] != DBNull.Value)
                            cmp.EnglishTooltip = reader.GetString(3);

                        if (reader["tooltip_italian"] != DBNull.Value)
                            cmp.ItalianTooltip = reader.GetString(4);

                        if (reader["english"] != DBNull.Value)
                            cmp.English = reader.GetString(5);

                        if (reader["italian"] != DBNull.Value)
                            cmp.Italian = reader.GetString(6);

                        result.Add(cmp.ParentForm + cmp.ComponentName, cmp);
                    }

                }

                return result;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public void UpdateTranslations(TranslationsHelpers Translations)
        {
            //Starting updating messages translations;
            if (Translations.MessagesTranslations != null)
            {
                foreach (MessageTranslation msg in Translations.MessagesTranslations.Values)
                {
                    if (msg.Changed)
                        UpdateMessageTranslation(msg.ID, msg.English, msg.Italian);
                }
            }

            //Now I update the components translations
            if (Translations.ComponentsTranslations != null)
            {
                foreach (ComponentTranslation cmp in Translations.ComponentsTranslations.Values)
                {
                    if (cmp.Changed)
                        UpdateComponentTranslation(cmp.ID, cmp.English, cmp.Italian, cmp.EnglishTooltip, cmp.ItalianTooltip);
                }
            }
        }

        private void UpdateComponentTranslation(int ID, string English, string Italian, string EnglishTooltip, string ItalianTooltip)
        {
            try
            {
                string sql = String.Format("UPDATE ComponentsTranslations SET english = '{1}', italian = '{2}', tooltip_english = '{3}', tooltip_italian = '{4}' WHERE id = {0};",
                                    ID, English.Replace("'", "''"), Italian.Replace("'", "''"),
                                    EnglishTooltip.Replace("'", "''"), ItalianTooltip.Replace("'", "''"));

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void UpdateMessageTranslation(int ID, string English, string Italian)
        {
            try
            {
                string sql = String.Format("UPDATE MessagesTranslations SET english = '{1}', italian = '{2}' WHERE id = {0};",
                                    ID, English.Replace("'", "''"), Italian.Replace("'", "''"));

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Recent Databases"
        public Dictionary<string, RecentDatabase> LoadRecentDatabases()
        {
            Dictionary<string, RecentDatabase> result = null;

            try
            {
                if (_Connection.State != System.Data.ConnectionState.Open)
                    //I raise an error as there is no connection to the database
                    throw new Exception("There is no connection to the database");

                String sql = "SELECT * FROM RecentDatabases ORDER BY latest_access DESC;";

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    result = new Dictionary<string, RecentDatabase>();

                    while (reader.Read())
                    {
                        RecentDatabase db = new RecentDatabase();

                        if (reader["id"] != DBNull.Value)
                            db.ID = reader.GetInt32(0);

                        if (reader["path"] != DBNull.Value)
                            db.DBPath = reader.GetString(1);

                        if (reader["latest_access"] != DBNull.Value)
                            db.LatestAccess = reader.GetDateTime(2);

                        result.Add(db.DBPath, db);
                    }

                }

            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }

        public int GetRecentDatabasesCount()
        {
            try
            {
                int result = 0;

                String sql = "SELECT COUNT(*) FROM RecentDatabases;";

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    result = reader.GetInt32(0);
                }

                reader.Close();
                command.Dispose();

                return result;

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool AddToRecentDatabases(string DBPath)
        {
            try
            {
                //First I check if the file already exists in the database
                String sql = String.Format("SELECT * FROM RecentDatabases WHERE path = '{0}';", DBPath);

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    //This means the opened DB is already within those available, I just need to update the latest_access
                    //First I clean the connection to avoid problems with the next query
                    reader.Close();
                    command.Dispose();

                    //Now I update the table
                    sql = String.Format("UPDATE RecentDatabases SET latest_access = '{0}' WHERE path = '{1}';",
                                        DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), DBPath);

                    command = new SQLiteCommand(sql, _Connection);
                    command.ExecuteNonQuery();

                }
                else
                {
                    //Not found, I need to add it

                    //First I clean the connection to avoid problems with the next query
                    reader.Close();
                    command.Dispose();

                    //Now I check if I have or exceed limit of 5 entries
                    if (GetRecentDatabasesCount() >= 5)
                    {
                        //If limit reached I remove the oldest
                        RemoveOldestRecentDatabase();
                    }

                    //Now I can add the new entry
                    sql = String.Format("INSERT INTO RecentDatabases (path) VALUES ('{0}');", DBPath);

                    command = new SQLiteCommand(sql, _Connection);
                    command.ExecuteNonQuery();

                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveRecentDatabase(string dbPath)
        {
            try
            {
                string sql = string.Format("DELETE FROM RecentDatabases WHERE path = '{0}';", dbPath);

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        private void RemoveOldestRecentDatabase()
        {
            try
            {
                string sql = "DELETE FROM RecentDatabases WHERE latest_access = (SELECT MIN(latest_access) FROM RecentDatabases);";

                SQLiteCommand command = new SQLiteCommand(sql, _Connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
