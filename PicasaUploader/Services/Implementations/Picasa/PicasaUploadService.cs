//
// Copyright (c) 2009 Ivan Zlatev <ivan@ivanz.com>
//
// Authors:
//	Ivan Zlatev <ivan@ivanz.com>
//
// License: MIT/X11 - See LICENSE.txt
//

using System;
using System.Collections.Generic;
using System.Linq;
using Google.GData.Photos;
using Google.GData.Client;
using System.Drawing;
using System.IO;
using System.Net;
using Google.Picasa;

namespace PicasaUploader
{
    public class PicasaUploadService : IMediaUploadService
    {
        private readonly PicasaService _picasaService;
        private string _username;

        public PicasaUploadService()
        {
            _picasaService = new PicasaService("PicasaUploader");
            SetupWorkarounds();
        }

        private void SetupWorkarounds()
        {
            // No CA certificates on Mono for some reason
            if (MonoRuntimeDetect.IsRunningOnMono)
                ServicePointManager.CertificatePolicy = new NoCheckCertificatePolicy();
            ServicePointManager.Expect100Continue = false;

            // Desperate hacks to avoid random connection closed exceptions when uploading videos
            GDataRequestFactory requestFactory = (GDataRequestFactory)_picasaService.RequestFactory;
            requestFactory.KeepAlive = false;
            requestFactory.Timeout = Int32.MaxValue;
        }

        // TODO: Update this code to use the new authentication token from the gdata api
        public bool Login(string username, string password)
        {
            _picasaService.setUserCredentials(username, password);

            try {
                _picasaService.Query(new AlbumQuery(PicasaQuery.CreatePicasaUri(username)));
                _username = username;
            } catch (AuthenticationException e) {
                if (e == null) { } // suppress unused warning
                return false;
            } catch {
                return false;
            }

            return true;
        }

        public IAlbumInfo[] LoadAlbums()
        {
            return _picasaService.Query(new AlbumQuery(PicasaQuery.CreatePicasaUri(_username))).Entries.Select(entry => new PicasaAlbumInfo((PicasaEntry)entry, _picasaService)).ToArray();
        }

        public void CreateAlbum(string title, string description, string location, DateTime date, bool makePublic)
        {
            if (String.IsNullOrEmpty(title))
                throw new ArgumentException("title is null or empty.", "title");

            if (description == null)
                description = String.Empty;
            if (location == null)
                location = String.Empty;

            Album album = new Album() { 
                Title = title, 
                Location = location, 
                Summary = description, 
                Access = makePublic ? "public" : "private", 
                Updated = date 
            };

            album.PicasaEntry.SetPhotoExtensionValue("timestamp", date.ToUnixDateTime().ToString());
            _picasaService.Insert(new Uri(PicasaQuery.CreatePicasaUri(_username)), album.PicasaEntry);
        }

        public string[] SupportedPhotoFormats
        {
            get { return new string[] { ".gif", ".png", ".jpeg", ".jpg", ".bmp" }; }
        }

        public string[] SupportedVideoFormats
        {
            get { return new string[] { ".avi", ".3gp", ".mp4", ".mov", ".mpg", ".mpeg", ".asf", ".wmv" }; }
        }

        #region Album Limits

        // Docs: http://picasa.google.com/support/bin/topic.py?topic=20043

        /// <summary>
        /// In MBs.
        /// </summary>
        public int VideoFileSizeLimit
        {
            get { return 100; }
        }

        /// <summary>
        /// In MBs
        /// </summary>
        public int PhotoFileSizeLimit
        {
            get { return 20; }
        }

        public int AlbumsCountLimit
        {
            get { return 10000; }
        }

        public int AlbumFilesCountLimit
        {
            get { return 1000; }
        }
        #endregion
    }
}