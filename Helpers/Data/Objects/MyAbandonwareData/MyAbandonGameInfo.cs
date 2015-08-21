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

namespace Helpers.Data.Objects.MyAbandonwareData
{
    public class MyAbandonGameInfo
    {
        #region "Declarations"
        string _title;
        string _year;
        string _platform;
        string _releasedIn;
        string _genre;
        List<string> _themes;
        string _publisher;
        string _developer;
        List<string> _perspectives;
        string _dosBoxVersion;
        string _downloadLink;
        string _downloadSize;
        string _vote;
        string _description;
        List<string> _screenshots;
        string _gameUri; 
        #endregion

        #region "Properties"
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public string Platform
        {
            get { return _platform; }
            set { _platform = value; }
        }

        public string ReleasedIn
        {
            get { return _releasedIn; }
            set { _releasedIn = value; }
        }

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        public List<string> Themes
        {
            get { return _themes; }
            set { _themes = value; }
        }

        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }

        public string Developer
        {
            get { return _developer; }
            set { _developer = value; }
        }

        public List<string> Perspectives
        {
            get { return _perspectives; }
            set { _perspectives = value; }
        }

        public string DosBoxVersion
        {
            get { return _dosBoxVersion; }
            set { _dosBoxVersion = value; }
        }

        public string DownloadLink
        {
            get { return _downloadLink; }
            set { _downloadLink = value; }
        }

        public string DownloadSize
        {
            get { return _downloadSize; }
            set { _downloadSize = value; }
        }

        public string Vote
        {
            get { return _vote; }
            set { _vote = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public List<string> Screenshots
        {
            get { return _screenshots; }
            set { _screenshots = value; }
        }

        public string GameURI
        {
            get { return _gameUri; }
            set { _gameUri = value; }
        }
        #endregion

        #region "Constructors"
        public MyAbandonGameInfo()
        {
            _title = string.Empty;
            _year = string.Empty;
            _platform = string.Empty;
            _releasedIn = string.Empty;
            _genre = string.Empty;
            _themes = null;
            _publisher = string.Empty;
            _developer = string.Empty;
            _perspectives = null;
            _dosBoxVersion = string.Empty;
            _downloadLink = string.Empty;
            _downloadSize = string.Empty;
            _vote = string.Empty;
            _description = string.Empty;
            _screenshots = null;
            _gameUri = string.Empty;
        }

        public MyAbandonGameInfo(string Title, string Year, string Platform, string ReleasedIn, string Genre, List<string> Themes, string Publisher, 
                                 string Developer, List<string> Prospectives, string DosBoxVersion, string DownloadLink, string DownloadSize, 
                                 string Vote, string Description, List<string> Screenshots, string GameURI)
        {
            _title = Title;
            _year = Year;
            _platform = Platform;
            _releasedIn = ReleasedIn;
            _genre = Genre;
            _themes = Themes;
            _publisher = Publisher;
            _developer = Developer;
            _perspectives = Prospectives;
            _dosBoxVersion = DosBoxVersion;
            _downloadLink = DownloadLink;
            _downloadSize = DownloadSize;
            _vote = Vote;
            _description = Description;
            _screenshots = Screenshots;
            _gameUri = GameURI;

        }
        #endregion 
    }
}
