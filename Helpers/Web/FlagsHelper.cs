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
