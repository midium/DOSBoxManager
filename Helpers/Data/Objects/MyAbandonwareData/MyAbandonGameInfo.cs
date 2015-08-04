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
        }

        public MyAbandonGameInfo(string Title, string Year, string Platform, string ReleasedIn, string Genre, List<string> Themes, string Publisher, 
                                 string Developer, List<string> Prospectives, string DosBoxVersion, string DownloadLink, string DownloadSize, 
                                 string Vote, string Description, List<string> Screenshots)
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

        }
        #endregion 
    }
}
