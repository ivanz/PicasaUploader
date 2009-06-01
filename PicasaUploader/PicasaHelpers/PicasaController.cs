//
// Copyright (c) 2009 Ivan N. Zlatev <contact@i-nz.net>
//
// Authors:
//	Ivan N. Zlatev <contact@i-nz.net>
//
// License: MIT/X11 - See LICENSE.txt
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.GData.Photos;
using Google.GData.Client;
using Google.GData.Extensions;
using System.Security;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
namespace PicasaUploader
{
	class PicasaController
	{
		private PicasaService _picasaService;
		private string _username;

		public PicasaController ()
		{
			_picasaService = new PicasaService ("PicasaUploader");
			// No CA certificates on Mono for some reason
			if (MonoRuntimeDetect.IsRunningOnMono)
				ServicePointManager.CertificatePolicy = new NoCheckCertificatePolicy ();
		}

                public bool Login (string username, string password)
		{
			_picasaService.setUserCredentials (username, password);

			try {
				_picasaService.Query (new AlbumQuery (PicasaQuery.CreatePicasaUri (username)));
				_username = username;
			} catch (AuthenticationException e) {
				if (e == null) { } // suppress unused warning
				return false;
			} catch {
				return false;
			}

			return true;
		}

		public AlbumInfo[] Albums {
			get
			{
				return (from PicasaEntry entry in _picasaService.Query (new AlbumQuery (PicasaQuery.CreatePicasaUri (_username))).Entries
					select new AlbumInfo (entry, _picasaService)).ToArray ();
			}
		}

		public void CreateAlbum (string title, string description, string location, DateTime date, bool publik)
		{
			if (String.IsNullOrEmpty (title))
				throw new ArgumentException ("title is null or empty.", "title");

			if (description == null)
				description = String.Empty;
			if (location == null)
				location = String.Empty;

			AlbumEntry entry = new AlbumEntry ();
			entry.Title.Text = title;
			entry.Summary.Text = description;
			AlbumAccessor access = new AlbumAccessor (entry);
			access.Access = publik ? "public" : "private";
			access.Location = location;
			entry.SetPhotoExtensionValue ("timestamp", UnixTime.FromDateTime (date).ToString ());
			_picasaService.Insert (new Uri (PicasaQuery.CreatePicasaUri (_username)), entry);
		}

		public static string GetMimeType (string fileName)
		{
			if (String.IsNullOrEmpty(fileName))
				throw new ArgumentException("fileName is null or empty.", "fileName");

			string extension = Path.GetExtension (fileName).ToLower ();
			if (extension == ".gif")
				return "image/gif";
			else if (extension == ".jpeg" || extension == ".jpg")
				return "image/jpeg";
			else if (extension == ".png")
				return "image/png";
			else if (extension == ".bmp")
				return "image/bmp";

			return null;
		}

		public static string[] SupportedPhotoFormats
		{
			get { return new string[] { ".gif", ".png", ".jpeg", ".jpg", ".bmp" }; }
		}
	}

	class AlbumInfo
	{
		private PicasaEntry _album;
		private PicasaService _picasaService;
                private AlbumAccessor _accessor;

		internal AlbumInfo (PicasaEntry album, PicasaService picasaService)
		{
			if (picasaService == null)
				throw new ArgumentNullException("picasaService", "picasaService is null.");
			if (album == null)
				throw new ArgumentNullException ("album", "album is null.");
			
			_picasaService = picasaService;
			_album = album;
			_accessor = new AlbumAccessor (album);
		}

		public AlbumAccessor Album
		{
			get { return _accessor; }
		}

		public Bitmap AlbumCover
		{
			get
			{
				if (_album.Media.Thumbnails != null && _album.Media.Thumbnails.Count > 0)
					return new Bitmap (_picasaService.Query (new Uri ((string)_album.Media.Thumbnails[0].Attributes["url"])));
				return null;
			}
		}

		public uint MaxPhotosCount
		{
			get { return _accessor.NumPhotos + _accessor.NumPhotosRemaining; }
		}

		// Only checks if there is a photo with the same title and 
		// does *not* check if the content matches.
		//
		public bool IsPhotoDupliate (string fileName)
		{
			if (String.IsNullOrEmpty (fileName))
				throw new ArgumentNullException ("fileName");

			if (FindPhotoByTitle (Path.GetFileName (fileName)) != null)
				return true;

			return false;
		}

		private PicasaEntry FindPhotoByTitle (string title)
		{	
			if (String.IsNullOrEmpty (title))
				throw new ArgumentNullException (title);

			PhotoQuery photoQuery = new PhotoQuery (PicasaQuery.CreatePicasaUri (_picasaService.Credentials.Username, _accessor.Id));
			var results = from photo in _picasaService.Query (photoQuery).Entries
					where photo.Title.Text == title
					select photo;
			if (results.Count() > 0)
				return (PicasaEntry)results.First();

			return null;
		}

		public void UploadPhoto (string fileName)
		{
			if (String.IsNullOrEmpty (fileName))
				throw new ArgumentException ("fileName is null or empty.", "fileName");

			string mimeType = PicasaController.GetMimeType (fileName);
			if (mimeType == null) // not supported
				throw new NotSupportedException ("Image type not supported");

			using (Stream file = File.OpenRead (fileName)) {
				UploadPhoto (file, fileName, PicasaController.GetMimeType (fileName));
			}
		}

		public void UploadPhoto (Stream file, string title, string mimeType)
		{
			if (String.IsNullOrEmpty (mimeType))
				throw new ArgumentException ("mimeType is null or empty.", "mimeType");
			if (String.IsNullOrEmpty (title))
				throw new ArgumentException ("title is null or empty.", "title");
			if (file == null)
				throw new ArgumentNullException ("file", "file is null.");
			
			_picasaService.Insert (new Uri (PhotoQuery.CreatePicasaUri (_picasaService.Credentials.Username, _accessor.Id)),
					       file, mimeType, title);
		}

		public void ReplacePhoto (string fileName)
		{			
			if (String.IsNullOrEmpty (fileName))
				throw new ArgumentNullException ("fileName");

			PicasaEntry photo = FindPhotoByTitle (Path.GetFileName (fileName));
			if (photo != null) {
				_picasaService.Delete (photo);
				UploadPhoto (fileName);
			}
		}

		public void ReplacePhoto (Stream file, string title, string mimeType)
		{
			if (file == null)
				throw new ArgumentNullException ("file", "file is null.");
			if (String.IsNullOrEmpty (title))
				throw new ArgumentException ("title is null or empty.", "title");
			if (String.IsNullOrEmpty (mimeType))
				throw new ArgumentException ("mimeType is null or empty.", "mimeType");

			PicasaEntry photo = FindPhotoByTitle (title);
			if (photo != null) {
				_picasaService.Delete (photo);
				UploadPhoto (file, title, mimeType);
			}
		}
	}
}
