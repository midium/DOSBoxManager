﻿/*
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
    public class Game : ICloneable
    {
        #region "Declarations"
        private int _ID;
        private string _SetupExePath;
        private string _Directory;
        private string _DBConfigPath;
        private string _DOSExePath;
        private string _CDPath;
        private bool _IsCDImage;
        private bool _UseIOCTL;
        private bool _MountAsFloppy;
        private string _AdditionalCommands;
        private bool _NoConfig;
        private bool _InFullScreen;
        private bool _NoConsole;
        private bool _QuitOnExit;
        private string _ImagePath;
        private DateTime _CreatedAt;
        private DateTime _UpdatedAt;

        //Game Details
        private int _CategoryID;
        private string _Title;
        private int _Year;
        private string _Developer;
        private string _Platform;
        private string _ReleasedIn;
        private string _Publisher;
        private string _Themes;
        private string _Perspectives;
        private string _Dosbox_version;
        private string _Vote;
        private string _Description;

        #endregion

        #region "Constructors"
        public Game()
        {
            _ID = 0;
            _CategoryID = 0;
            _Title = string.Empty;
            _Year = 0;
            _Developer = string.Empty;
            _SetupExePath = string.Empty;
            _Directory = string.Empty;
            _DBConfigPath = string.Empty;
            _DOSExePath = string.Empty;
            _CDPath = string.Empty;
            _IsCDImage = false;
            _UseIOCTL = false;
            _MountAsFloppy = false;
            _AdditionalCommands = string.Empty;
            _NoConfig = false;
            _InFullScreen = false;
            _NoConsole = false;
            _QuitOnExit = false;
            _ImagePath = string.Empty;
            _CreatedAt = DateTime.MinValue;
            _UpdatedAt = DateTime.MinValue;

            _Platform = string.Empty;
            _ReleasedIn = string.Empty;
            _Publisher = string.Empty;
            _Themes = string.Empty;
            _Perspectives = string.Empty;
            _Dosbox_version = string.Empty;
            _Vote = string.Empty;
            _Description = string.Empty;
        }

        public Game(int ID, int CategoryID, string Title, int Year, string Developer, string SetupExePath,
                         string Directory, string DBConfigPath, string DOSExePath, string CDPath,
                         bool IsCDImage, bool UseIOCTL, bool MountAsFloppy, string AdditionalCommands,
                         bool NoConfig, bool InFullScreen, bool NoConsole, bool QuitOnExit, string ImagePath,
                         DateTime CreatedAt, DateTime UpdatedAt, string Platform, string ReleasedIn, string Publisher,
                         string Themes, string Perspectives, string DosBoxVersion, string Vote, string Description)
        {
            _ID = ID;
            _CategoryID = CategoryID;
            _Title = Title;
            _Year = Year;
            _Developer = Developer;
            _SetupExePath = SetupExePath;
            _Directory = Directory;
            _DBConfigPath = DBConfigPath;
            _DOSExePath = DOSExePath;
            _CDPath = CDPath;
            _IsCDImage = IsCDImage;
            _UseIOCTL = UseIOCTL;
            _MountAsFloppy = MountAsFloppy;
            _AdditionalCommands = AdditionalCommands;
            _NoConfig = NoConfig;
            _InFullScreen = InFullScreen;
            _NoConsole = NoConsole;
            _QuitOnExit = QuitOnExit;
            _ImagePath = ImagePath;
            _CreatedAt = CreatedAt;
            _UpdatedAt = UpdatedAt;

            _Platform = Platform;
            _ReleasedIn = ReleasedIn;
            _Publisher = Publisher;
            _Themes = Themes;
            _Perspectives = Perspectives;
            _Dosbox_version = DosBoxVersion;
            _Vote = Vote;
            _Description = Description;
        }
        #endregion

        #region "Properties"
        public string Platform
        {
            get { return _Platform; }
            set { _Platform = value; }
        }
        public string ReleasedIn
        {
            get { return _ReleasedIn; }
            set { _ReleasedIn = value; }
        }
        public string Publisher
        {
            get { return _Publisher; }
            set { _Publisher = value; }
        }
        public string Themes
        {
            get { return _Themes; }
            set { _Themes = value; }
        }
        public string Perspectives
        {
            get { return _Perspectives; }
            set { _Perspectives = value; }
        }
        public string DosboxVersion
        {
            get { return _Dosbox_version; }
            set { _Dosbox_version = value; }
        }
        public string Vote
        {
            get { return _Vote; }
            set { _Vote = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        public string Developer
        {
            get { return _Developer; }
            set { _Developer = value; }
        }

        public string SetupExePath
        {
            get { return _SetupExePath; }
            set { _SetupExePath = value; }
        }

        public string Directory
        {
            get { return _Directory; }
            set { _Directory = value; }
        }

        public string DBConfigPath
        {
            get { return _DBConfigPath; }
            set { _DBConfigPath = value; }
        }

        public string DOSExePath
        {
            get { return _DOSExePath; }
            set { _DOSExePath = value; }
        }

        public string CDPath
        {
            get { return _CDPath; }
            set { _CDPath = value; }
        }

        public bool IsCDImage
        {
            get { return _IsCDImage; }
            set { _IsCDImage = value; }
        }

        public bool UseIOCTL
        {
            get { return _UseIOCTL; }
            set { _UseIOCTL = value; }
        }

        public bool MountAsFloppy
        {
            get { return _MountAsFloppy; }
            set { _MountAsFloppy = value; }
        }

        public string AdditionalCommands
        {
            get { return _AdditionalCommands; }
            set { _AdditionalCommands = value; }
        }

        public bool NoConfig
        {
            get { return _NoConfig; }
            set { _NoConfig = value; }
        }

        public bool InFullScreen
        {
            get { return _InFullScreen; }
            set { _InFullScreen = value; }
        }

        public bool NoConsole
        {
            get { return _NoConsole; }
            set { _NoConsole = value; }
        }

        public bool QuitOnExit
        {
            get { return _QuitOnExit; }
            set { _QuitOnExit = value; }
        }

        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public DateTime CreatedAt
        {
            get { return _CreatedAt; }
            set { _CreatedAt = value; }
        }

        public DateTime UpdatedAt
        {
            get { return _UpdatedAt; }
            set { _UpdatedAt = value; }
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
