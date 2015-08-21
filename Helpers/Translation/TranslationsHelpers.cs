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
using System.Windows.Forms;
using Helpers.Data.Objects;
using Helpers.Data.Objects.Translation;

namespace Helpers.Translation
{
    public class TranslationsHelpers : ICloneable
    {

        private Dictionary<int, MessageTranslation> _messagesTranslations = null;
        private Dictionary<string, ComponentTranslation> _componentsTranslations = null;

        public TranslationsHelpers(Dictionary<int, MessageTranslation> Messages, Dictionary<string, ComponentTranslation> Components)
        {
            _messagesTranslations = Messages;
            _componentsTranslations = Components;
        }

        public string GetTranslatedMessage(Settings.Languages Language, int MessageID, string DefaultValue)
        {
            if (_messagesTranslations != null && _messagesTranslations.ContainsKey(MessageID))
                return _messagesTranslations[MessageID].GetTranslation(Language);

            return DefaultValue;
        }

        public void TranslateUI(Settings.Languages Language, String FormName, Control.ControlCollection controls)
        {
            if (_componentsTranslations != null)
            {
                foreach (object cmp in controls)
                {
                    Control itm = (Control)cmp;

                    if (_componentsTranslations.ContainsKey(FormName + itm.Name))
                    {
                        itm.Text = _componentsTranslations[FormName + itm.Name].GetTranslation(Language);

                        //Setting eventual tooltip
                        string ToolTipText = _componentsTranslations[FormName + itm.Name].GetTooltipTranslation(Language);
                        if (ToolTipText != string.Empty)
                        {
                            ToolTip tp = new ToolTip();
                            tp.SetToolTip(itm, ToolTipText);
                        }
                            
                    }

                    if (itm.HasChildren)
                    {
                        TranslateUI(Language, FormName, itm.Controls);
                    }

                    if (itm.GetType() == typeof(MenuStrip))
                    {
                        MenuStrip mnu = (MenuStrip)itm;
                        if (mnu.Items.Count > 0)
                            TranslateMenusUI(Language, FormName, mnu.Items);
                    }

                    if (itm.GetType() == typeof(ToolStrip))
                    {
                        ToolStrip tsp = (ToolStrip)itm;
                        if (tsp.Items.Count > 0)
                            TranslateToolStripsUI(Language, FormName, tsp.Items);
                    }


                }
            }
        }

        private void TranslateToolStripsUI(Settings.Languages Language, String FormName, ToolStripItemCollection buttonsCollection)
        {
            if (_componentsTranslations != null)
            {
                foreach (object mnu in buttonsCollection)
                {
                    if (mnu.GetType() != typeof(ToolStripSeparator) && mnu.GetType() == typeof(ToolStripButton))
                    {
                        ToolStripButton itm = (ToolStripButton)mnu;
                        if (_componentsTranslations.ContainsKey(FormName + itm.Name))
                        {
                            itm.Text = _componentsTranslations[FormName + itm.Name].GetTranslation(Language);
                            itm.ToolTipText = _componentsTranslations[FormName + itm.Name].GetTooltipTranslation(Language);
                        }

                    }
                    else if (mnu.GetType() == typeof(ToolStripSplitButton))
                    {
                        ToolStripSplitButton itm = (ToolStripSplitButton)mnu;
                        if (_componentsTranslations.ContainsKey(FormName + itm.Name))
                        {
                            itm.Text = _componentsTranslations[FormName + itm.Name].GetTranslation(Language);
                            itm.ToolTipText = _componentsTranslations[FormName + itm.Name].GetTooltipTranslation(Language);
                        }

                        if (itm.HasDropDownItems)
                            TranslateMenusUI(Language, FormName, itm.DropDownItems);
                    }
                }
            }
        }

        public void TranslateMenusUI(Settings.Languages Language, String FormName, ToolStripItemCollection menuCollection)
        {
            if (_componentsTranslations != null)
            {
                foreach (object mnu in menuCollection)
                {
                    if (mnu.GetType() != typeof(ToolStripSeparator))
                    {
                        ToolStripMenuItem itm = (ToolStripMenuItem)mnu;

                        if (_componentsTranslations.ContainsKey(FormName + itm.Name))
                        {
                            itm.Text = _componentsTranslations[FormName + itm.Name].GetTranslation(Language);
                            itm.ToolTipText = _componentsTranslations[FormName + itm.Name].GetTooltipTranslation(Language);
                        }

                        if (itm.HasDropDownItems)
                            TranslateMenusUI(Language, FormName, itm.DropDownItems);
                    }
                }
            }

        }

        #region "Properties"
        public Dictionary<int, MessageTranslation> MessagesTranslations
        {
            get { return _messagesTranslations; }
            set { _messagesTranslations = value; }
        }

        public Dictionary<string, ComponentTranslation> ComponentsTranslations
        {
            get { return _componentsTranslations; }
            set { _componentsTranslations = value; }
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
