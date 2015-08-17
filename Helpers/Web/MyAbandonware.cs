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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Helpers.Data.Objects.MyAbandonwareData;
using Helpers.IO;
using HtmlAgilityPack;
using Helpers.Threading.Workers;
using System.Threading;
using Helpers.Business;
using CustomMessageBoxes.MessageBoxes;

namespace Helpers.Web
{
    public class MyAbandonware
    {
        #region "Declarations"
        private HtmlDocument htmlDoc = null;
        private HttpWebRequest request = null;
        private HttpWebResponse response = null;

        private AppManager _manager = null;

        private string baseSearchUri = "http://www.myabandonware.com/search/q/{0}";
        private string baseUri = "http://www.myabandonware.com/{0}";

        private FlagsHelper flags = null;

        private FileDownloader _fileDownload = null;
        private Thread _thread = null;

        #region "Event"
        public delegate void DownloadFileCompletedDelegate(object sender, string DestinationFile);
        public event DownloadFileCompletedDelegate DownloadFileCompleted;

        public delegate void DownloadProgressChangedDelegate(object sender, DownloadProgressChangedEventArgs e);
        public event DownloadProgressChangedDelegate DownloadProgressChanged;
        #endregion
        #endregion

        #region "Constructors"
        public MyAbandonware(AppManager Manager)
        {
            htmlDoc = new HtmlDocument();
            flags = new FlagsHelper();
            _manager = Manager;
        }
        #endregion

        #region "Methods"
        #region "Private Methods"
        private MyAbandonGameInfo ParseGamePage(string queryResult)
        {
            MyAbandonGameInfo result = null;

            if (queryResult != string.Empty)
            {
                htmlDoc.LoadHtml(queryResult);
                if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Count() > 0)
                {
                    // Handle any parse errors as required
                    string errorMessage = string.Empty;
                    foreach (HtmlParseError error in htmlDoc.ParseErrors)
                    {
                        errorMessage += error.Reason + "\n";
                    }

                    CustomMessageBox cmb = new CustomMessageBox(errorMessage, _manager.Translator.GetTranslatedMessage(_manager.AppSettings.Language, 28, "Error"),
                                                                MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Error, false, false);
                    cmb.ShowDialog();
                    cmb.Dispose();
                    
                }
                else
                {

                    if (htmlDoc.DocumentNode != null)
                    {
                        HtmlNode bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body//div[@class='box']");

                        if (bodyNode != null)
                        {
                            result = new MyAbandonGameInfo();

                            //Game Name
                            HtmlNode nameNode = bodyNode.SelectSingleNode("//h2[@itemprop='name']");
                            if (nameNode != null)
                            {
                                result.Title = nameNode.InnerText.Trim();
                            }

                            //Game Data
                            HtmlNode gameDataNode = bodyNode.SelectSingleNode("//div[@class='gameData']/dl");
                            if (gameDataNode != null)
                            {
                                foreach(HtmlNode itemNode in gameDataNode.ChildNodes)
                                {

                                    if (itemNode.Name.ToLower() == "dt")
                                    {
                                        if (itemNode.InnerText.Trim().ToLower() == "year")
                                            flags.SetFlags(true, false, false, false, false, false, false, false, false);

                                        if (itemNode.InnerText.Trim().ToLower() == "platform")
                                            flags.SetFlags(false, true, false, false, false, false, false, false, false);

                                        if (itemNode.InnerText.Trim().ToLower() == "released in")
                                            flags.SetFlags(false, false, true, false, false, false, false, false, false);

                                        if (itemNode.InnerText.Trim().ToLower() == "genre")
                                            flags.SetFlags(false, false, false, true, false, false, false, false, false);

                                        if (itemNode.InnerText.Trim().ToLower() == "theme")
                                            flags.SetFlags(false, false, false, false, true, false, false, false, false);

                                        if (itemNode.InnerText.Trim().ToLower() == "publisher")
                                            flags.SetFlags(false, false, false, false, false, true, false, false, false);

                                        if (itemNode.InnerText.Trim().ToLower() == "developer")
                                            flags.SetFlags(false, false, false, false, false, false, true, false, false);

                                        if (itemNode.InnerText.Trim().ToLower() == "perspectives")
                                            flags.SetFlags(false, false, false, false, false, false, false, true, false);

                                        if (itemNode.InnerText.Trim().ToLower() == "dosbox support")
                                            flags.SetFlags(false, false, false, false, false, false, false, false, true);

                                    }

                                    if(itemNode.Name.ToLower() == "dd")
                                    {

                                        if(flags.IsYear)
                                            result.Year= WebUtility.HtmlDecode(itemNode.InnerText.Trim());

                                        if (flags.IsPlatform)
                                            result.Platform = WebUtility.HtmlDecode(itemNode.InnerText.Trim());

                                        if (flags.IsReleasedIn)
                                            result.ReleasedIn = WebUtility.HtmlDecode(itemNode.InnerText.Trim());

                                        if(flags.IsGenre)
                                            result.Genre = WebUtility.HtmlDecode(itemNode.InnerText.Trim());

                                        if (flags.IsTheme)
                                        {
                                            string themeString = WebUtility.HtmlDecode(itemNode.InnerText.Trim());

                                            if (themeString != string.Empty)
                                                result.Themes = themeString.Replace(", ",",").Split(',').ToList();
                                        }

                                        if (flags.IsPublisher)
                                            result.Publisher = WebUtility.HtmlDecode(itemNode.InnerText.Trim());

                                        if (flags.IsDeveloper)
                                            result.Developer = WebUtility.HtmlDecode(itemNode.InnerText.Trim());

                                        if (flags.IsPerspectives)
                                        {
                                            string perspectiveString = WebUtility.HtmlDecode(itemNode.InnerText.Trim());

                                            if (perspectiveString != string.Empty)
                                                result.Perspectives = perspectiveString.Replace(", ", ",").Split(',', ' ').ToList();
                                        }

                                        if (flags.IsDosBox)
                                            result.DosBoxVersion = WebUtility.HtmlDecode(itemNode.InnerText.Trim());
                                           
                                    }
                                }

                            }

                            //Game Vote
                            HtmlNode voteNode = bodyNode.SelectSingleNode("//span[@itemprop='ratingValue']");
                            if (voteNode != null)
                                result.Vote = voteNode.InnerText;

                            //Game Descritpion
                            HtmlNode descriptionNode = bodyNode.SelectSingleNode("//div[@class='box']/h3[@class='cBoth']");
                            if (descriptionNode != null)
                            {
                                if (descriptionNode != null)
                                {
                                    HtmlNode descNone = descriptionNode.ParentNode.SelectSingleNode("p");
                                    if(descNone!=null)
                                        result.Description = WebUtility.HtmlDecode(descNone.InnerText);
                                }
                            }

                            //Game Screenshots
                            HtmlNodeCollection screenshotsNodes = bodyNode.SelectNodes("//body//div[@class='thumb']/a[@class='lb']/img");
                            if (screenshotsNodes != null)
                            {
                                foreach (HtmlNode screen in screenshotsNodes)
                                {
                                    if(screen.Name.ToLower().Trim() == "img")
                                    {
                                        if (result.Screenshots == null)
                                            result.Screenshots = new List<string>();

                                        result.Screenshots.Add(GetMediaURI(screen.Attributes["src"].Value));
                                    }
                                            
                                        
                                }
                            }

                            //Game Download & Size
                            HtmlNode downloadNode = bodyNode.SelectSingleNode("//a[@class='button download']");
                            if (downloadNode != null)
                            {
                                result.DownloadLink = downloadNode.Attributes["href"].Value;

                                HtmlNode downloadSize = downloadNode.SelectSingleNode("//a[@class='button download']/span");
                                if (downloadSize != null)
                                {
                                    result.DownloadSize = downloadSize.InnerText.Trim();
                                }
                            }

                        }
                    }
                }
            }

            return result;
        }

        private List<MyAbandonGameFound> ParseSearchResult(string queryResult)
        {

            List<MyAbandonGameFound> result = null;

            if (queryResult != string.Empty)
            {

                htmlDoc.LoadHtml(queryResult);
                if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Count() > 0)
                {
                    // Handle any parse errors as required

                }
                else
                {

                    if (htmlDoc.DocumentNode != null)
                    {
                        HtmlNode bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body//div[@class='items games']");

                        if (bodyNode != null)
                        {
                            result = new List<MyAbandonGameFound>();
                            foreach (HtmlNode node in bodyNode.ChildNodes)
                            {

                                if (node.Attributes["class"] != null && node.Attributes["class"].Value.IndexOf("be") == -1 && node.Attributes["class"].Value.IndexOf("itemListGame") != -1)
                                {
                                    HtmlNode nameNode = node.SelectSingleNode("div[@class='name']");
                                    HtmlNode yearNode = node.SelectSingleNode("div[@class='platyear']/span[@class='year']");
                                    HtmlNode platformNode = node.SelectSingleNode("div[@class='platyear']/span[@class='ptf']");
                                    HtmlNode coverNode = node.SelectSingleNode("div[@class='thumb']/a/img");

                                    string title = string.Empty;
                                    string gameUri = string.Empty;

                                    if (nameNode != null)
                                    {
                                        title = WebUtility.HtmlDecode(nameNode.InnerText.Trim());
                                        gameUri = nameNode.SelectSingleNode("a").Attributes["href"].Value.Trim();
                                        gameUri = string.Format(baseUri, gameUri.Substring(1, gameUri.Length - 1));
                                    }
                                    string year = (yearNode == null) ? string.Empty : yearNode.InnerText.Trim();
                                    string platform = (platformNode == null) ? string.Empty : platformNode.InnerText.Trim();
                                    string coverUri = (coverNode==null)?string.Empty:string.Format(baseUri, coverNode.Attributes["src"].Value.Trim());

                                    result.Add(new MyAbandonGameFound(title, year, platform, coverUri, gameUri));
                                }
                            }
                        }
                    }
                }
                

            }

            return result;
        }

        private void RemoveDownloadHandlers(FileDownloader downloader)
        {
            downloader.DownloadFileCompleted -= downloader_DownloadFileCompleted;
            downloader.DownloadProgressChanged -= downloader_DownloadProgressChanged;
        }

        private void AddDownloadHandlers(FileDownloader downloader)
        {
            downloader.DownloadFileCompleted += downloader_DownloadFileCompleted;
            downloader.DownloadProgressChanged += downloader_DownloadProgressChanged;
        }
        #endregion

        #region "Download event handler"
        private void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (DownloadProgressChanged != null)
                DownloadProgressChanged(sender, e);
        }

        private void downloader_DownloadFileCompleted(object sender, string DestinationFile)
        {
            if (DownloadFileCompleted != null)
                DownloadFileCompleted(sender, DestinationFile);

            RemoveDownloadHandlers(_fileDownload);
            _fileDownload.Dispose();
            _thread = null;
        }
        #endregion

        #region "Public Methods"
        public string GetMediaURI(string uri)
        {
            return string.Format(baseUri, uri);
        }

        public void DownloadMedia(string MediaUri, string DownloadPath)
        {
            if (MediaUri.Substring(0, 4).ToLower() == "http")
                _fileDownload = new FileDownloader(MediaUri, DownloadPath);
            else
                _fileDownload = new FileDownloader(string.Format(baseUri, MediaUri.Substring(1,MediaUri.Length -1)), DownloadPath); 

            AddDownloadHandlers(_fileDownload);

            _thread = new Thread(_fileDownload.DoWork);
            _thread.Start();

        }

        public List<MyAbandonGameFound> SearchGames(string GameName)
        {

            try
            {
                //Preparing URL and result holder
                string queryResult = string.Empty;
                string queryUri = string.Format(baseSearchUri, GameName);

                //Performing web request to retrieve the page.
                request = (HttpWebRequest)WebRequest.Create(queryUri);
                response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    readStream = new StreamReader(receiveStream, Encoding.UTF8);

                    queryResult = WebUtility.HtmlDecode(readStream.ReadToEnd());

                    response.Close();
                    readStream.Close();
                }

                //Scraping the response to extract the founded games
                List<MyAbandonGameFound> result = ParseSearchResult(queryResult);

                return result;
            }
            catch (Exception e)
            {
                CustomMessageBox cmb = new CustomMessageBox(e.Message, _manager.Translator.GetTranslatedMessage(_manager.AppSettings.Language, 28, "Error"), MessageBoxDialogButtons.Ok, MessageBoxDialogIcon.Error, false, false);
                cmb.ShowDialog();
                cmb.Dispose();

                return null;
            }
        }

        public MyAbandonGameInfo RetrieveGameData(string GameURI)
        {
            string queryResult = string.Empty;
            string queryUri = GameURI;

            request = (HttpWebRequest)WebRequest.Create(queryUri);
            response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                readStream = new StreamReader(receiveStream, Encoding.UTF8);

                queryResult = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }

            MyAbandonGameInfo result = ParseGamePage(queryResult);
            if(result != null)
                result.GameURI = GameURI;

            return result;
        }
        #endregion
        #endregion
    }
}
