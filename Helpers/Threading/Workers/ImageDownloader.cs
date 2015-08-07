﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers.Threading.Workers.Base;

namespace Helpers.Threading.Workers
{
    public class ImageDownloader : WorkerBase
    {
        #region "Declarations"
        private string _URI;
        private WebClient _downloader;
        private Stream _imageStream;

        #region "Event"
        public delegate void DownloadDataCompletedDelegate(object sender, Stream ImageStream);
        public event DownloadDataCompletedDelegate DownloadDataCompleted;

        public delegate void DownloadProgressChangedDelegate(object sender, DownloadProgressChangedEventArgs e);
        public event DownloadProgressChangedDelegate DownloadProgressChanged;
        #endregion
        #endregion

        #region "Constructor"
        public ImageDownloader(string URI)
            : base()
        {
            _URI = URI;
            _downloader = null;
            _imageStream = null;
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
            if(eventX != null)
                eventX.Set();
        }

        public override void Dispose()
        {
            if (_downloader != null)
            {
                RemoveHandlers();
                _downloader.Dispose();
            }

            if(_imageStream != null)
                _imageStream.Dispose();

            base.Dispose();
        }

        public override void Download()
        {
            if (_URI != string.Empty)
            {
                using (_downloader = new WebClient())
                {
                    AddHandlers();

                    try
                    {
                        _downloader.DownloadDataAsync(new Uri(_URI, UriKind.Absolute));
                    }
                    catch (Exception)
                    {
                        if (DownloadDataCompleted != null)
                            DownloadDataCompleted(this, null);
                    }
                }
            }
        }

        #endregion

        #region "Private"
        private void AddHandlers()
        {
            if (_downloader != null)
            {
                _downloader.DownloadDataCompleted += _downloader_DownloadDataCompleted;
                _downloader.DownloadProgressChanged += _downloader_DownloadProgressChanged;
            }
        }

        private void RemoveHandlers()
        {
            if (_downloader != null)
            {
                _downloader.DownloadDataCompleted -= _downloader_DownloadDataCompleted;
                _downloader.DownloadProgressChanged -= _downloader_DownloadProgressChanged;
            }
        }
        #endregion

        #region "Events Handling"
        private void _downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (DownloadProgressChanged != null)
                DownloadProgressChanged(this, e);
        }

        private void _downloader_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            if (DownloadDataCompleted != null)
            {
                _imageStream = new MemoryStream(e.Result);
                DownloadDataCompleted(this, _imageStream);
            }
        }
        #endregion
        #endregion
    }
}
