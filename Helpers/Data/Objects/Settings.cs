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

namespace Helpers.Data.Objects
{
    public class Settings : ICloneable
    {
        #region "Declarations"
        public enum Languages
        {
            English = 0,
            Italian = 1
        }

        private int app_width;
        private int app_height;
        private bool portable_mode;
        private string dosbox_path;
        private string dosbox_default_conf_file_path;
        private string dosbox_default_lang_file_path;
        private string cds_default_dir;
        private string games_default_dir;
        private bool games_no_console;
        private bool games_in_full_screen;
        private bool games_quit_on_exit;
        private string games_additional_commands;
        private bool box_rendered;
        private bool app_fullscreen;
        private bool menu_bar_visible;
        private bool toolbar_visible;
        private bool status_bar_visible;
        private string config_editor_path;
        private string config_editor_additional_parameters;
        private bool category_delete_prompt;
        private bool game_delete_prompt;
        private bool remember_window_size;
        private bool reload_latest_db;
        private Languages language;
        private bool reduce_to_tray_on_play;
        
        #endregion

        #region "Constructors"
        public Settings()
        {
            SetDefaults();
        }
        #endregion

        #region "Private Methods"
        private void SetDefaults()
        {
            app_width = 800;
            app_height = 600;
            portable_mode = false;
            dosbox_path = string.Empty;
            dosbox_default_conf_file_path = string.Empty;
            dosbox_default_lang_file_path = string.Empty;
            cds_default_dir = string.Empty;
            games_default_dir = string.Empty;
            games_no_console = false;
            games_in_full_screen = false;
            games_quit_on_exit = false;
            games_additional_commands = string.Empty;
            box_rendered = false;
            app_fullscreen = false;
            menu_bar_visible = true;
            toolbar_visible = true;
            status_bar_visible = true;
            config_editor_path = string.Empty;
            config_editor_additional_parameters = string.Empty;
            category_delete_prompt = true;
            game_delete_prompt = true;
            remember_window_size = true;
            reload_latest_db = false;
            language = Languages.English;
            reduce_to_tray_on_play = true;
        }
        #endregion

        #region "Properties"
        public int AppWidth
        {
            get { return app_width; }
            set { app_width = value; }
        }
        public int AppHeight
        {
            get { return app_height; }
            set { app_height = value; }
        }
        public bool PortableMode
        {
            get { return portable_mode; }
            set { portable_mode = value; }
        }
        public string DosboxPath
        {
            get { return dosbox_path; }
            set { dosbox_path = value; }
        }
        public string DosboxDefaultConfFilePath
        {
            get { return dosbox_default_conf_file_path; }
            set { dosbox_default_conf_file_path = value; }
        }
        public string DosboxDefaultLangFilePath
        {
            get { return dosbox_default_lang_file_path; }
            set { dosbox_default_lang_file_path = value; }
        }
        public string CDsDefaultDir
        {
            get { return cds_default_dir; }
            set { cds_default_dir = value; }
        }
        public string GamesDefaultDir
        {
            get { return games_default_dir; }
            set { games_default_dir = value; }
        }
        public bool GamesNoConsole
        {
            get { return games_no_console; }
            set { games_no_console = value; }
        }
        public bool GamesInFullScreen
        {
            get { return games_in_full_screen; }
            set { games_in_full_screen = value; }
        }
        public bool GamesQuitOnExit
        {
            get { return games_quit_on_exit; }
            set { games_quit_on_exit = value; }
        }
        public string GamesAdditionalCommands
        {
            get { return games_additional_commands; }
            set { games_additional_commands = value; }
        }
        public bool BoxRendered
        {
            get { return box_rendered; }
            set { box_rendered = value; }
        }
        public bool AppFullscreen
        {
            get { return app_fullscreen; }
            set { app_fullscreen = value; }
        }
        public bool MenuBarVisible
        {
            get { return menu_bar_visible; }
            set { menu_bar_visible = value; }
        }
        public bool ToolbarVisible
        {
            get { return toolbar_visible; }
            set { toolbar_visible = value; }
        }
        public bool StatusBarVisible
        {
            get { return status_bar_visible; }
            set { status_bar_visible = value; }
        }
        public string ConfigEditorPath
        {
            get { return config_editor_path; }
            set { config_editor_path = value; }
        }
        public string ConfigEditorAdditionalParameters
        {
            get { return config_editor_additional_parameters; }
            set { config_editor_additional_parameters = value; }
        }
        public bool CategoryDeletePrompt
        {
            get { return category_delete_prompt; }
            set { category_delete_prompt = value; }
        }
        public bool GameDeletePrompt
        {
            get { return game_delete_prompt; }
            set { game_delete_prompt = value; }
        }
        public bool RememberWindowSize
        {
            get { return remember_window_size; }
            set { remember_window_size = value; }
        }
        public bool ReloadLatestDB
        {
            get { return reload_latest_db; }
            set { reload_latest_db = value; }
        }
        public Languages Language
        {
            get { return language; }
            set { language = value; }
        }
        public bool ReduceToTrayOnPlay
        {
            get { return reduce_to_tray_on_play; }
            set { reduce_to_tray_on_play = value; }
        }
        #endregion

        #region "IClonable implementation"
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion
    }
}
