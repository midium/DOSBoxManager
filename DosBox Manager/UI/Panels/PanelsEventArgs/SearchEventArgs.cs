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

namespace DosBox_Manager.UI.Panels.PanelsEventArgs
{
  public class SearchEventArgs : EventArgs
  {
    private string _title;
    private string _year;
    private string _developer;
    private int _categoryID;

    public string Title
    {
      get
      {
        return _title;
      }
    }

    public string Year
    {
      get
      {
        return _year;
      }
    }

    public string Developer
    {
      get
      {
        return _developer;
      }
    }

    public int CategoryID
    {
      get
      {
        return _categoryID;
      }
    }

    public SearchEventArgs(string Title, string Year, string Developer, int CategoryID)
    {
      _title = Title;
      _year = Year;
      _developer = Developer;
      _categoryID = CategoryID;
    }
  }
}
