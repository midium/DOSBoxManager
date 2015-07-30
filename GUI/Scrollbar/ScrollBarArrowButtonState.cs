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
namespace GUI.Scrollbar
{
   /// <summary>
   /// The scrollbar arrow button states.
   /// </summary>
   internal enum ScrollBarArrowButtonState
   {
      /// <summary>
      /// Indicates the up arrow is in normal state.
      /// </summary>
      UpNormal,

      /// <summary>
      /// Indicates the up arrow is in hot state.
      /// </summary>
      UpHot,

      /// <summary>
      /// Indicates the up arrow is in active state.
      /// </summary>
      UpActive,

      /// <summary>
      /// Indicates the up arrow is in pressed state.
      /// </summary>
      UpPressed,

      /// <summary>
      /// Indicates the up arrow is in disabled state.
      /// </summary>
      UpDisabled,

      /// <summary>
      /// Indicates the down arrow is in normal state.
      /// </summary>
      DownNormal,

      /// <summary>
      /// Indicates the down arrow is in hot state.
      /// </summary>
      DownHot,

      /// <summary>
      /// Indicates the down arrow is in active state.
      /// </summary>
      DownActive,

      /// <summary>
      /// Indicates the down arrow is in pressed state.
      /// </summary>
      DownPressed,

      /// <summary>
      /// Indicates the down arrow is in disabled state.
      /// </summary>
      DownDisabled
   }
}
