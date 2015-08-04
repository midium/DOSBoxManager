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
using Helpers.Apps;
using Helpers.Data;
using Helpers.Data.Objects;
using Helpers.IO;
using Helpers.Translation;

namespace DosBox_Manager.Business
{
    public class AppManager : IDisposable 
    {
        #region "Declarations"
        private Settings _AppSettings = null;
        private DOSBoxHelpers _DosBoxHelper = null;
        private FileHelpers _fileHelper = null;

        private Dictionary<string, RecentDatabase> _recentDBs = null;
        private TranslationsHelpers _translator = null;
        
        private Database _DB;
        private SettingsManager _SettingsDB;
        #endregion

        #region "Constructors"
        public AppManager()
        {
            _SettingsDB = new SettingsManager("settings.dbm");
            _translator = new TranslationsHelpers(_SettingsDB.LoadMessagesTranslations(), _SettingsDB.LoadComponentsTranslations());
            _AppSettings = _SettingsDB.LoadSettings();
            _recentDBs = _SettingsDB.LoadRecentDatabases();
            _DB = new Database();
            _DosBoxHelper = new DOSBoxHelpers();
            _fileHelper = new FileHelpers();

        }
        #endregion

        #region "Propeties"
        public Settings AppSettings
        {
            get { return _AppSettings; }
            set { _AppSettings = value; }
        }

        public DOSBoxHelpers DosBoxHelper
        {
            get { return _DosBoxHelper; }
        }

        public FileHelpers FileHelper
        {
            get { return _fileHelper; }
        }

        public Dictionary<string, RecentDatabase> RecentDBs
        {
            get { return _recentDBs; }
            set { _recentDBs = value; }
        }

        public TranslationsHelpers Translator
        {
            get { return _translator; }
        }

        public Database DB
        {
            get { return _DB; }
        }

        public SettingsManager SettingsDB
        {
            get { return _SettingsDB; }
        }
        #endregion

        #region "IDisposable Implementation"
        public void Dispose()
        {
            _recentDBs = null;
            _translator = null;
            _AppSettings = null;
            _DosBoxHelper = null;
            _fileHelper = null;
            
            if(_DB != null && _DB.ConnectionStatus == System.Data.ConnectionState.Open)
                _DB.Disconnect();
            _DB = null;

            if (_SettingsDB != null && _SettingsDB.ConnectionStatus == System.Data.ConnectionState.Open)
                _SettingsDB.Disconnect();
            _SettingsDB = null;
            
        }
        #endregion
    }
}
