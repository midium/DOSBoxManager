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
    public class ComponentTranslation
    {
        #region "Declaration"
        private int _ID;
        private string _parentForm;
        private string _componentName;
        private string _tooltip_english;
        private string _tooltip_italian;
        private string _english;
        private string _italian;
        private bool _changed;
        #endregion

        #region "Constructor"
        public ComponentTranslation()
        {
            _ID = -1;
            _parentForm = string.Empty;
            _componentName = string.Empty;
            _tooltip_english = string.Empty;
            _tooltip_italian = string.Empty;
            _english = string.Empty;
            _italian = string.Empty;
            _changed = false;
        }

        public ComponentTranslation(int ID, string ParentForm, string ComponentName, string EnglishTooltip, string ItalianTooltip, string English, string Italian)
        {
            _ID = ID;
            _parentForm = ParentForm;
            _componentName = ComponentName;
            _tooltip_english = EnglishTooltip;
            _tooltip_italian = ItalianTooltip;
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

        public string ParentForm
        {
            get { return _parentForm; }
            set { _parentForm = value; }
        }

        public string ComponentName
        {
            get { return _componentName; }
            set { _componentName = value; }
        }

        public string EnglishTooltip
        {
            get { return _tooltip_english; }
            set { _tooltip_english = value; }
        }

        public string ItalianTooltip
        {
            get { return _tooltip_italian; }
            set { _tooltip_italian = value; }
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

        internal string GetTooltipTranslation(Settings.Languages lang)
        {
            if (lang == Settings.Languages.English)
                return _tooltip_english;
            else
            {
                if (_tooltip_italian != string.Empty)
                    return _tooltip_italian;
                else
                    return _tooltip_english;
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
