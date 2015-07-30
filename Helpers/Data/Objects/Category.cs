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
    public class Category
    {
        #region "Declarations"
        private int _ID;
        private String _Name;
        private String _Icon;
        private bool _isExpanded;
        private bool _isSelected;
        #endregion

        #region "Constructors"
        public Category()
        {
            _ID = -1;
            _Name = String.Empty;
            _Icon = String.Empty;
            _isExpanded = false;
            _isSelected = false;
        }

        public Category(int ID, String Name, String Icon, bool isExpanded, bool isSelected)
        {
            _ID = ID;
            _Name = Name;
            _Icon = Icon;
            _isExpanded = isExpanded;
            _isSelected = isSelected;
        }
        #endregion

        #region "Properties"
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public String Icon
        {
            get { return _Icon; }
            set { _Icon = value; }
        }

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { _isExpanded = value; }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }
        #endregion

        #region "Overrides"
        public override string ToString()
        {
            return _Name;
        }
        #endregion
    }
}
