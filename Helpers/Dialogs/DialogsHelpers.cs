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

namespace Helpers.Dialogs
{
    public class DialogsHelpers
    {

        public string OpenFile(string DialogTitle, string Filename, string DialogFilter, string InitialDirectory, string DefaultReturn)
        {
            OpenFileDialog ofdOpen = new OpenFileDialog();
            ofdOpen.Title = DialogTitle;
            ofdOpen.FileName = Filename;
            ofdOpen.InitialDirectory = InitialDirectory;
            ofdOpen.Filter = DialogFilter;
            if (ofdOpen.ShowDialog() == DialogResult.OK)
                return ofdOpen.FileName;

            return DefaultReturn;
        }

        public string OpenFolder(string DialogDescription, string SelectedPath, bool NewFolderButton, string DefaultReturn)
        {
            FolderBrowserDialog fdbDir = new FolderBrowserDialog();
            fdbDir.SelectedPath = SelectedPath;
            fdbDir.ShowNewFolderButton = NewFolderButton;
            fdbDir.Description = DialogDescription;
            if (fdbDir.ShowDialog() == DialogResult.OK)
                return fdbDir.SelectedPath;

            return DefaultReturn;
        }

    }
}
