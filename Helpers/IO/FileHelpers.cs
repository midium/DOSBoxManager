﻿/*
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

namespace Helpers.IO
{
    public class FileHelpers
    {
        public String ExtractFileName(String FullFilePath)
        {
            String result = String.Empty;

            if (FullFilePath.Length == 0)
                return result;

            String[] pieces = FullFilePath.Split('\\');
            result = pieces[pieces.GetUpperBound(0)];

            return result;
        }

        public String ExtractFilePath(String FullFilePath)
        {
            String result = String.Empty;

            if (FullFilePath.Length == 0)
                return result;

            String[] pieces = FullFilePath.Split('\\');
            pieces = pieces.Take(pieces.Count() - 1).ToArray();
            result = String.Join("\\", pieces);

            return result;
        }
    }
}
