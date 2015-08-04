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
    public class MyAbandonGameFound
    {
        #region "Declarations"
        private string _title;
        private string _year;
        private string _coverUri;
        private string _uri;
        #endregion

        #region "Constructors"
        public MyAbandonGameFound()
        {
            _title = string.Empty;
            _year = string.Empty;
            _coverUri = string.Empty;
            _uri = string.Empty;
        }

        public MyAbandonGameFound(string Title, string Year, string CoverUri, string Uri)
        {
            _title = Title;
            _year = Year;
            _coverUri = CoverUri;
            _uri = Uri;
        }
        #endregion

        #region "Overrided Methods"
        public override string ToString()
        {
            return string.Format("[{1}] - {0}", _title, _year);
        }
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

        public string CoverUri
        {
            get { return _coverUri; }
            set { _coverUri = value; }
        }

        public string Uri
        {
            get { return _uri; }
            set { _uri = value; }
        }
        #endregion

    }
}
