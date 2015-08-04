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
using System.Windows.Forms;
using DosBox_Manager.Business;

namespace DosBox_Manager
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
        AppManager manager = new AppManager();

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Form main = new MainForm(manager);
        if(!main.IsDisposed)
            Application.Run(main);

        manager.Dispose();
    }
  }
}
