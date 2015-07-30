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
using Helpers.Data.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers.Translation;
using GUI.MessageBoxes;

namespace Helpers.Apps
{
    public class DOSBoxHelpers
    {
        public String BuildArgs(bool Setup, Game game, Settings settings)
        {
            //Arguments string for DOSBox.exe
            String Arguments = String.Empty;

            if (settings.DosboxPath != String.Empty && settings.DosboxPath != "dosbox.exe isn't in the same directory as DosBoxManager.exe!" && File.Exists(settings.DosboxPath))
            {
                String qt = char.ToString('"');
                if (game.Directory[0] != '/')
                    qt = "'";
                //string for the Game's configuration file.
                String DBCfgPath = String.Empty;
                //if the "do not use any config file at all" has not been checked
                if (game.NoConfig == false)
                {
                    //use at first the game's custom config file
                    if (game.DBConfigPath != String.Empty)
                        DBCfgPath = game.DBConfigPath;
                    //if not, use the default dosbox.conf file
                    else if (settings.DosboxDefaultConfFilePath != String.Empty && settings.DosboxDefaultConfFilePath != "No configuration file (*.conf) found in DosBoxManager's directory.")
                        DBCfgPath = settings.DosboxDefaultConfFilePath;
                }
                //The arguments for DOSBox begins with the game executable (.exe, .bat, or .com)
                if (game.DOSExePath != String.Empty)
                {
                    if (!Setup)
                        Arguments = '"' + game.DOSExePath + '"';
                    else
                        Arguments = '"' + game.DOSExePath + '"';
                }
                //the game directory mounted as C (if the DOSEXEPath is specified, the DOSEXEPath parent directory will be mounted as C: by DOSBox
                //hence the "else if" instead of "if".
                else if (game.Directory != String.Empty)
                    Arguments = " -c " + '"' + "mount c " + qt + game.Directory + qt + '"';
                //puting DBCfgPath and Arguments together
                if (DBCfgPath != String.Empty)
                    Arguments = Arguments + " -conf " + '"' + DBCfgPath + '"';
                //Path for the default language file used for DOSBox and specified by the user in the Tools menu
                if (settings.DosboxDefaultLangFilePath != String.Empty && settings.DosboxDefaultLangFilePath != "No language file (*.lng) found in DosBoxManager's directory.")
                    Arguments = Arguments + " -lang " + '"' + settings.DosboxDefaultLangFilePath + '"';
                //Path for the game's CD image (.bin, .cue, or .iso) mounted as D:
                if (game.CDPath != String.Empty)
                {
                    //put ' and _not_ " after imgmount (or else the path will be misunderstood by DOSBox). Paths with spaces will NOT work either way on GNU/Linux!
                    if (game.IsCDImage == true)
                    {
                        Arguments = Arguments + " -c " + '"' + "imgmount";
                        if (game.MountAsFloppy == true)
                            Arguments = Arguments + " a " + qt + game.CDPath + qt + " -t floppy" + '"';
                        else
                            Arguments = Arguments + " d " + qt + game.CDPath + qt + " -t iso" + '"';
                    }
                    else
                    {
                        if (game.UseIOCTL == true)
                            Arguments = Arguments + " -c " + '"' + "mount d " + qt + game.CDPath + qt + " -t cdrom -usecd 0 -ioctl" + '"';
                        else if (game.MountAsFloppy == true)
                            Arguments = Arguments + " -c " + '"' + "mount a " + qt + game.CDPath + qt + " -t floppy" + '"';
                        else
                            Arguments = Arguments + " -c " + '"' + "mount d " + qt + game.CDPath + qt;
                    }
                }
                //Additionnal user commands for the game
                if (game.AdditionalCommands != String.Empty)
                    Arguments = Arguments + " " + game.AdditionalCommands;
                //corresponds to the Fullscreen checkbox in GameForm
                if (game.InFullScreen == true)
                    Arguments = Arguments + " -fullscreen";
                //corresponds to the "no console" checkbox in the GameForm
                if (game.NoConsole == true)
                    Arguments = Arguments + " -noconsole";
                //corresponds to the "quit on exit (only for .exe)" checkbox in the GameForm
                if (game.QuitOnExit == true)
                    Arguments = Arguments + " -exit";
                return Arguments;
            }
            else
            {
                return null;
            }
        }

        public bool MakeGamesConfiguration(TranslationsHelpers translator, Settings settings, Game game)
        {
            string body;
            string title;
            CustomMessageBox cmb;

            if (game != null && settings.DosboxDefaultConfFilePath != String.Empty)
            {
                if(File.Exists(settings.DosboxDefaultConfFilePath)){
                    body = "'" + game.Directory + "/" + Path.GetFileName(settings.DosboxDefaultConfFilePath) + "' " +
                                  translator.GetTranslatedMessage(settings.Language, 64, "already exists, do you want to overwrite it ?");
                    title = translator.GetTranslatedMessage(settings.Language, 8, "Attention");
                    cmb = new CustomMessageBox(body, title, MessageBoxDialogButtons.YesNo, MessageBoxDialogIcon.Question, false, false);

                    if ((!File.Exists(game.Directory + "/" + Path.GetFileName(settings.DosboxDefaultConfFilePath))) || (cmb.ShowDialog() == DialogResult.Yes))
                    {
                        if (Directory.Exists(game.Directory))
                        {
                            File.Copy(settings.DosboxDefaultConfFilePath, game.Directory + "/" + Path.GetFileName(settings.DosboxDefaultConfFilePath), true);
                            game.DBConfigPath = game.Directory + "/" + Path.GetFileName(settings.DosboxDefaultConfFilePath);

                            body = translator.GetTranslatedMessage(settings.Language, 65, "The configuration file has been created correctly.");
                            title = translator.GetTranslatedMessage(settings.Language, 66, "Success");
                            cmb = new CustomMessageBox(body, title, MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Information, false, false);
                            cmb.ShowDialog();
                            cmb.Dispose();

                            return true;
                        }
                        else
                        {
                            body = translator.GetTranslatedMessage(settings.Language, 67, "The path to the selected game seems missing, please check and eventually modify the game folder location to continue.");
                            title = translator.GetTranslatedMessage(settings.Language, 28, "Error");
                            cmb = new CustomMessageBox(body, title, MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Error, false, false);
                            cmb.ShowDialog();
                            cmb.Dispose();

                            return false;
                        }

                    }
                    else
                    {
                        return false;
                    }

                } else {
                    body = translator.GetTranslatedMessage(settings.Language, 68, "The path to the given DosBox configuration file seems missing, please check and eventually modify the DosBox configuration file location to continue.");
                    title = translator.GetTranslatedMessage(settings.Language, 28, "Error");
                    cmb = new CustomMessageBox(body, title, MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Error, false, false);
                    cmb.ShowDialog();
                    cmb.Dispose();

                    return false;
                }
            }

            return false;
        }
    }
}
