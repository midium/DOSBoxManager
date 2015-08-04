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

namespace Helpers.Web
{
    public class MyAbandonware
    {
        #region "Declarations"
        HtmlDocument htmlDoc = null;
        HttpWebRequest request = null;
        HttpWebResponse response = null;

        string baseSearchUri = "http://www.myabandonware.com/search/q/{0}";
        string baseUri = "http://www.myabandonware.com/{0}";

        FlagsHelper flags = null;
        #endregion

        #region "Constructors"
        public MyAbandonware()
        {
            htmlDoc = new HtmlDocument();
            flags = new FlagsHelper();
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
                                            result.Year= itemNode.InnerText.Trim();

                                        if (flags.IsPlatform)
                                            result.Platform = itemNode.InnerText.Trim();

                                        if (flags.IsReleasedIn)
                                            result.ReleasedIn = itemNode.InnerText.Trim();

                                        if(flags.IsGenre)
                                            result.Genre = itemNode.InnerText.Trim();

                                        if (flags.IsTheme)
                                        {
                                            string themeString = itemNode.InnerText.Trim();

                                            if (themeString != string.Empty)
                                                result.Themes = themeString.Replace(", ",",").Split(',').ToList();
                                        }

                                        if (flags.IsPublisher)
                                            result.Publisher = itemNode.InnerText.Trim();

                                        if (flags.IsDeveloper)
                                            result.Developer = itemNode.InnerText.Trim();

                                        if (flags.IsPerspectives)
                                        {
                                            string perspectiveString = itemNode.InnerText.Trim();

                                            if (perspectiveString != string.Empty)
                                                result.Perspectives = perspectiveString.Replace(", ", ",").Split(',', ' ').ToList();
                                        }

                                        if (flags.IsDosBox)
                                            result.DosBoxVersion = itemNode.InnerText.Trim();
                                           
                                    }
                                }

                            }

                            //Game Vote
                            HtmlNode voteNode = bodyNode.SelectSingleNode("//span[@itemprop='ratingValue']");
                            if (voteNode != null)
                                result.Vote = voteNode.InnerText;

                            //Game Descritpion
                            HtmlNode descriptionNode = bodyNode.SelectSingleNode("//div[@class='gameDescription dscr']/p");
                            if (descriptionNode != null)
                            {
                                if (descriptionNode.FirstChild != null)
                                {
                                    result.Description = descriptionNode.FirstChild.InnerText;
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

                                        result.Screenshots.Add(screen.Attributes["src"].Value);
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
                                    HtmlNode yearNode = node.SelectSingleNode("div[@class='year']");
                                    HtmlNode coverNode = node.SelectSingleNode("div[@class='thumb']/a/img");

                                    string title = nameNode.InnerText.Trim();
                                    string gameUri = nameNode.SelectSingleNode("a").Attributes["href"].Value.Trim();
                                    string year = yearNode.InnerText.Trim();
                                    if(year != string.Empty)
                                    {
                                        string[] yearData = year.Split('-');
                                        if (yearData.GetLength(0) == 2)
                                            year = yearData[1].Trim();
                                        else
                                            year = string.Empty;
                                    }
                                    string coverUri = coverNode.Attributes["src"].Value.Trim();




                                    result.Add(new MyAbandonGameFound(title, year, coverUri, gameUri));
                                    Console.WriteLine(node.OuterHtml);
                                }
                            }
                        }
                    }
                }
                

            }

            return result;
        }
        #endregion

        #region "Public Methods"
        public void DownloadMedia(string MediaUri, string DownloadPath)
        {
            FileHelpers fh = new FileHelpers();
            string fileName = fh.ExtractFileName(MediaUri);

            using (var client = new WebClient())
            {
                client.DownloadFile(MediaUri, DownloadPath + "\\" + fileName);
            }
        }

        public Stream DownloadMediaStream(string MediaUri)
        {
            Stream result = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(baseUri,MediaUri));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Check that the remote file was found. The ContentType
            // check is performed since a request for a non-existent
            // image file might be redirected to a 404-page, which would
            // yield the StatusCode "OK", even though the image was not
            // found.
            if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {

                // if the remote file was found, download oit
                /*using (Stream inputStream = response.GetResponseStream())
                using (Stream outputStream = File.OpenWrite(fileName))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }*/

                result = response.GetResponseStream();
            }

            return result;
        }

        public List<MyAbandonGameFound> SearchGames(string GameName)
        {
            string queryResult = string.Empty;
            string queryUri = string.Format(baseSearchUri, GameName);

            /*request = (HttpWebRequest)WebRequest.Create(queryUri);
            response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                queryResult = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }*/

            StreamReader read = new StreamReader("D:\\Progetti .NET\\Search_result.txt");

            queryResult = read.ReadToEnd();

            read.Close();

            List<MyAbandonGameFound> result = ParseSearchResult(queryResult);

            return result;
        }

        public MyAbandonGameInfo RetrieveGameData()
        {
            string queryResult = string.Empty;
            //string queryUri = string.Format(baseSearchUri, GameName);

            //TODO: Make proper web search
            /*request = (HttpWebRequest)WebRequest.Create(queryUri);
            response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                queryResult = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }*/

            StreamReader read = new StreamReader("D:\\Game_page.txt");

            queryResult = read.ReadToEnd();

            read.Close();

            MyAbandonGameInfo result = ParseGamePage(queryResult);

            return result;
        }
        #endregion
        #endregion

    }
}
