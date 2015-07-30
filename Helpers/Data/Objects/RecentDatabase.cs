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
    public class RecentDatabase
    {
        #region "Declarations"
        private int _ID;
        private string _dbPath;
        private DateTime _latestAccess;
        #endregion

        #region "Constructor"
        public RecentDatabase()
        {
            _ID = -1;
            _dbPath = string.Empty;
            _latestAccess = DateTime.MinValue;
        }

        public RecentDatabase(int ID, string DBPath, DateTime LatestAccess)
        {
            _ID = ID;
            _dbPath = DBPath;
            _latestAccess = LatestAccess;
        }
        #endregion

        #region "Properties"
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string DBPath
        {
            get { return _dbPath; }
            set { _dbPath = value; }
        }
        public DateTime LatestAccess
        {
            get { return _latestAccess; }
            set { _latestAccess = value; }
        }
        #endregion
    }
}
