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
using Helpers.Threading.Workers.Base;
using Helpers.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Threading.Workers
{
    class FileDownloader : WorkerBase
    {
        #region "Declarations"
        private string _URI;
        private string _DestinationFile;
        private CookieAwareWebClient _downloader;

        #region "Event"
        public delegate void DownloadFileCompletedDelegate(object sender, string DestinationFile);
        public event DownloadFileCompletedDelegate DownloadFileCompleted;

        public delegate void DownloadProgressChangedDelegate(object sender, DownloadProgressChangedEventArgs e);
        public event DownloadProgressChangedDelegate DownloadProgressChanged;
        #endregion
        #endregion

        #region "Constructor"
        public FileDownloader(string URI, string DestinationFile)
            : base()
        {
            _URI = URI;
            _DestinationFile = DestinationFile;
            _downloader = null;

        }
        #endregion

        #region "Methods"
        #region "Public"
        // This is the method that will be called when the work item is serviced on the thread pool.
        // That means this method will be called when the thread pool has an available thread for the work item.
        public override void DoWork()
        {
            // Do the real work
            lock (_URI)
            {
                Download();
            }

            // The Interlocked.Increment method allows thread-safe modification of variables accessible across multiple threads.
            if (eventX != null)
                eventX.Set();
        }

        public override void Dispose()
        {
            if (_downloader != null)
            {
                RemoveHandlers();
                _downloader.Dispose();
            }

            base.Dispose();
        }

        public override void Download()
        {
            using (_downloader = new CookieAwareWebClient())
            {
                AddHandlers();
                _downloader.DownloadFileAsync(new Uri(_URI, UriKind.Absolute ), _DestinationFile);
            }
    
        }

        #endregion

        #region "Private"
        private void AddHandlers()
        {
            if (_downloader != null)
            {
                _downloader.DownloadFileCompleted += _downloader_DownloadFileCompleted;
                _downloader.DownloadProgressChanged += _downloader_DownloadProgressChanged;
            }
        }

        private void RemoveHandlers()
        {
            if (_downloader != null)
            {
                _downloader.DownloadFileCompleted -= _downloader_DownloadFileCompleted;
                _downloader.DownloadProgressChanged -= _downloader_DownloadProgressChanged;
            }
        }
        #endregion

        #region "Events Handling"
        private void _downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (!this.IsDisposed)
                if (DownloadProgressChanged!=null)
                    DownloadProgressChanged(this, e);
        }

        void _downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (!this.IsDisposed)
                if (DownloadFileCompleted != null)
                    DownloadFileCompleted(this, _DestinationFile);
        }
        #endregion
        #endregion
    }
}
