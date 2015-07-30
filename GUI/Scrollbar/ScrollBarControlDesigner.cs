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
namespace GUI.Scrollbar.Design
{
   using System.ComponentModel;
   using System.Windows.Forms.Design;

   /// <summary>
   /// The designer for the <see cref="ScrollBarEx"/> control.
   /// </summary>
   internal class ScrollBarControlDesigner : ControlDesigner
   {
      /// <summary>
      /// Gets the <see cref="SelectionRules"/> for the control.
      /// </summary>
      public override SelectionRules SelectionRules
      {
         get
         {
            // gets the property descriptor for the property "Orientation"
            PropertyDescriptor propDescriptor =
               TypeDescriptor.GetProperties(this.Component)["Orientation"];

            // if not null - we can read the current orientation of the scroll bar
            if (propDescriptor != null)
            {
               // get the current orientation
               ScrollBarOrientation orientation =
                  (ScrollBarOrientation) propDescriptor.GetValue(this.Component);

               // if vertical orientation
               if (orientation == ScrollBarOrientation.Vertical)
               {
                  return SelectionRules.Visible
                     | SelectionRules.Moveable
                     | SelectionRules.BottomSizeable
                     | SelectionRules.TopSizeable;
               }

               return SelectionRules.Visible | SelectionRules.Moveable
                  | SelectionRules.LeftSizeable | SelectionRules.RightSizeable;
            }

            return base.SelectionRules;
         }
      }

      /// <summary>
      /// Prefilters the properties so that unnecessary properties are hidden
      /// in the property browser of Visual Studio.
      /// </summary>
      /// <param name="properties">The property dictionary.</param>
      protected override void PreFilterProperties(
         System.Collections.IDictionary properties)
      {
         properties.Remove("Text");
         properties.Remove("BackgroundImage");
         properties.Remove("ForeColor");
         properties.Remove("ImeMode");
         properties.Remove("Padding");
         properties.Remove("BackgroundImageLayout");
         properties.Remove("BackColor");
         properties.Remove("Font");
         properties.Remove("RightToLeft");

         base.PreFilterProperties(properties);
      }
   }
}
