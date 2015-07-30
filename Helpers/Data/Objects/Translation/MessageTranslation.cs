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

namespace Helpers.Data.Objects.Translation
{
    public class MessageTranslation
    {
        #region "Declaration"
        private int _ID;
        private string _english;
        private string _italian;
        private bool _changed;
        #endregion

        #region "Constructor"
        public MessageTranslation()
        {
            _ID = -1;
            _english = string.Empty;
            _italian = string.Empty;
            _changed = false;
        }

        public MessageTranslation(int ID, string English, string Italian)
        {
            _ID = ID;
            _english = English;
            _italian = Italian;
            _changed = false;
        }
        #endregion

        #region "Properties"
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string English
        {
            get { return _english; }
            set { _english = value; }
        }

        public string Italian
        {
            get { return _italian; }
            set { _italian = value; }
        }

        public bool Changed
        {
            get { return _changed; }
            set { _changed = value; }
        }
        #endregion

        #region "Public Methods"
        public string GetTranslation(Settings.Languages lang)
        {
            if (lang == Settings.Languages.English)
                return _english;
            else
            {
                if (_italian != string.Empty)
                    return _italian;
                else
                    return _english;
            }
        }
        #endregion

        #region "Methods Override"
        public override string ToString()
        {
            return _english;
        }
        #endregion
    }
}
