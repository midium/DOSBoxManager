using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Web
{
    public class FlagsHelper
    {
        #region "Declarations"
        bool _isYear = false;
        bool _isPlatform = false;
        bool _isReleasedIn = false;
        bool _isGenre = false;
        bool _isTheme = false;
        bool _isPublisher = false;
        bool _isDeveloper = false;
        bool _isPerspectives = false;
        bool _isDosBox = false;
        #endregion

        #region "Propeties"
        public bool IsYear
        {
            get { return _isYear; }
            set { _isYear = value; }
        }

        public bool IsPlatform
        {
            get { return _isPlatform; }
            set { _isPlatform = value; }
        }

        public bool IsReleasedIn
        {
            get { return _isReleasedIn; }
            set { _isReleasedIn = value; }
        }

        public bool IsGenre
        {
            get { return _isGenre; }
            set { _isGenre = value; }
        }

        public bool IsTheme
        {
            get { return _isTheme; }
            set { _isTheme = value; }
        }

        public bool IsPublisher
        {
            get { return _isPublisher; }
            set { _isPublisher = value; }
        }

        public bool IsDeveloper
        {
            get { return _isDeveloper; }
            set { _isDeveloper = value; }
        }

        public bool IsPerspectives
        {
            get { return _isPerspectives; }
            set { _isPerspectives = value; }
        }

        public bool IsDosBox
        {
            get { return _isDosBox; }
            set { _isDosBox = value; }
        }
        #endregion

        #region "Constructor"
        public FlagsHelper()
        {
            _isYear = false;
            _isPlatform = false;
            _isReleasedIn = false;
            _isGenre = false;
            _isTheme = false;
            _isPublisher = false;
            _isDeveloper = false;
            _isPerspectives = false;
            _isDosBox = false;
        }
        #endregion

        #region "Methods"
        public void SetFlags(bool isYear, bool isPlatform, bool isReleasedIn, bool isGenre, bool isTheme, bool isPublisher, bool isDeveloper, bool isPerspectives, bool isDosBox)
        {
            _isYear = isYear;
            _isPlatform = isPlatform;
            _isReleasedIn = isReleasedIn;
            _isGenre = isGenre;
            _isTheme = isTheme;
            _isPublisher = isPublisher;
            _isDeveloper = isDeveloper;
            _isPerspectives = isPerspectives;
            _isDosBox = isDosBox;

        }
        #endregion
    }
}
