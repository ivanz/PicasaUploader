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
using System.Text;
using Google.GData.Photos;
using Google.GData.Client;
using Google.GData.Extensions;
using System.Security;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Globalization;
using Google.Picasa;
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
			System.Net.ServicePointManager.Expect100Continue = false;

			// Desperate hacks to avoid random connection closed exceptions when uploading videos
			GDataRequestFactory requestFactory = (GDataRequestFactory)_picasaService.RequestFactory;
			requestFactory.KeepAlive = false;
			requestFactory.Timeout = Int32.MaxValue;
		}

		// TODO: Update this code to use the new authentication token from the gdata api
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

		public void CreateAlbum (string title, string description, string location, DateTime date, bool makePublic)
		{
			if (String.IsNullOrEmpty (title))
				throw new ArgumentException ("title is null or empty.", "title");

			if (description == null)
				description = String.Empty;
			if (location == null)
				location = String.Empty;

			Album album = new Album ();
			album.Title = title;
			album.Location = location;
			album.Summary = description;
			album.Access = makePublic ? "public" : "private";
			album.Updated = date;
			album.PicasaEntry.SetPhotoExtensionValue ("timestamp", UnixTime.FromDateTime (date).ToString ());
			_picasaService.Insert (new Uri (PicasaQuery.CreatePicasaUri (_username)), album.PicasaEntry);
		}

		// TODO: Make this use a hashtable/dictionary internally
		public static string GetMimeType (string fileName)
		{
			if (String.IsNullOrEmpty(fileName))
				throw new ArgumentException("fileName is null or empty.", "fileName");

			string extension = Path.GetExtension (fileName).ToLower ();
			if (String.Compare (extension, ".gif", StringComparison.InvariantCultureIgnoreCase) == 0)
				return "image/gif";
			else if (String.Compare (extension, ".jpeg", StringComparison.InvariantCultureIgnoreCase) == 0 || 
				 String.Compare (extension, ".jpg", StringComparison.InvariantCultureIgnoreCase) == 0)
				return "image/jpeg";
			else if (String.Compare (extension, ".png", StringComparison.InvariantCultureIgnoreCase) == 0)
				return "image/png";
			else if (String.Compare (extension, ".bmp", StringComparison.InvariantCultureIgnoreCase) == 0)
				return "image/bmp";
			else if (String.Compare (extension, ".avi", StringComparison.InvariantCultureIgnoreCase) == 0)
				return "video/avi";
			else if (String.Compare (extension, ".mp4", StringComparison.InvariantCultureIgnoreCase) == 0)
				return "video/mp4";
			else if (String.Compare (extension, ".mov", StringComparison.InvariantCultureIgnoreCase) == 0)
				return "video/quicktime";
			else if (String.Compare (extension, ".mpeg", StringComparison.InvariantCultureIgnoreCase) == 0 ||
				 String.Compare (extension, ".mpg", StringComparison.InvariantCultureIgnoreCase) == 0)
				return "video/mpeg";
			else if (String.Compare (extension, ".asf", StringComparison.InvariantCultureIgnoreCase) == 0)
				return "video/x-ms-asf";
			else if (String.Compare (extension, ".wmv", StringComparison.InvariantCultureIgnoreCase) == 0)
				return "video/mp4";
			else if (String.Compare (extension, ".3gp", StringComparison.InvariantCultureIgnoreCase) == 0)
				return "video/3gpp";
			return null;
		}

		public static string[] SupportedPhotoFormats
		{
			get { return new string[] { ".gif", ".png", ".jpeg", ".jpg", ".bmp" }; }
		}

		public static string[] SupportedVideoFormats {
			get { return new string[] { ".avi", ".3gp", ".mp4", ".mov", ".mpg", ".mpeg", ".asf", ".wmv" }; }
		}

		#region Album Limits
		
		// Docs: http://picasa.google.com/support/bin/topic.py?topic=20043

		/// <summary>
		/// In MBs.
		/// </summary>
		public static int VideoFileSizeLimit
		{
			get { return 100; }
		}

		/// <summary>
		/// In MBs
		/// </summary>
		public static int PhotoFileSizeLimit
		{
			get { return 20; }
		}

		public static int AlbumsCountLimit
		{
			get { return 10000; }
		}

		public static int AlbumFilesCountLimit
		{
			get { return 1000; }
		}
		#endregion
	}

	class AlbumInfo
	{
		private PicasaEntry _album;
		private PicasaService _picasaService;

		internal AlbumInfo (PicasaEntry album, PicasaService picasaService)
		{
			if (picasaService == null)
				throw new ArgumentNullException("picasaService", "picasaService is null.");
			if (album == null)
				throw new ArgumentNullException ("album", "album is null.");
			
			_picasaService = picasaService;
			_album = album;

			NumPhotos = Int32.Parse (_album.GetPhotoExtensionValue (GPhotoNameTable.NumPhotos));
			NumPhotosRemaining = Int32.Parse (_album.GetPhotoExtensionValue (GPhotoNameTable.NumPhotosRemaining));
			Title = _album.Title.Text;
			if (_album.Media.Thumbnails != null && _album.Media.Thumbnails.Count > 0)
				AlbumCover = new Bitmap (_picasaService.Query (new Uri ((string)_album.Media.Thumbnails[0].Attributes["url"])));
			Id = _album.GetPhotoExtensionValue (GPhotoNameTable.Id);
		}

		public int NumPhotos
		{
			get;
			private set;
		}

		public string Title
		{
			get;
			private set;
		}

		public string Id
		{
			get;
			private set;
		}

		public Bitmap AlbumCover
		{
			get;
			private set;
		}

		public int NumPhotosRemaining {
			get;
			private set;
		}

                // Only checks if there is a photo with the same title and 
		// does *not* check if the content matches.
		//
		public bool IsFileDuplicate (string fileName)
		{
			if (String.IsNullOrEmpty (fileName))
				throw new ArgumentNullException ("fileName");

			if (FindFileByTitle (Path.GetFileName (fileName)) != null)
				return true;

			return false;
		}

		private PicasaEntry FindFileByTitle (string title)
		{	
			if (String.IsNullOrEmpty (title))
				throw new ArgumentNullException (title);

			PhotoQuery photoQuery = new PhotoQuery (PicasaQuery.CreatePicasaUri (_picasaService.Credentials.Username, Id));
			var results = from photo in _picasaService.Query (photoQuery).Entries
					where photo.Title.Text == title
					select photo;
			if (results.Count() > 0)
				return (PicasaEntry)results.First();

			return null;
		}

		public void UploadFile (string fileName)
		{
			if (String.IsNullOrEmpty (fileName))
				throw new ArgumentException ("fileName is null or empty.", "fileName");

			string mimeType = PicasaController.GetMimeType (fileName);
			if (mimeType == null) // not supported
				throw new NotSupportedException ("Image type not supported");

			using (Stream file = File.OpenRead (fileName)) {
				UploadFile (file, fileName, PicasaController.GetMimeType (fileName));
			}
		}

		public void UploadFile (Stream file, string title, string mimeType)
		{
			if (String.IsNullOrEmpty (mimeType))
				throw new ArgumentException ("mimeType is null or empty.", "mimeType");
			if (String.IsNullOrEmpty (title))
				throw new ArgumentException ("title is null or empty.", "title");
			if (file == null)
				throw new ArgumentNullException ("file", "file is null.");
			
			PhotoEntry entry = new PhotoEntry ();
			entry.Title = new AtomTextConstruct (AtomTextConstructElementType.Title, title);
			MediaFileSource fileSource = new MediaFileSource (file, title, mimeType);
			entry.MediaSource = fileSource;

			_picasaService.Insert (new Uri (PhotoQuery.CreatePicasaUri (_picasaService.Credentials.Username, Id)),
					       entry);
		}

		public void ReplaceFile (string fileName)
		{			
			if (String.IsNullOrEmpty (fileName))
				throw new ArgumentNullException ("fileName");

			PicasaEntry photo = FindFileByTitle (Path.GetFileName (fileName));
			if (photo != null) {
				_picasaService.Delete (photo);
				UploadFile (fileName);
			}
		}

		public void ReplaceFile (Stream file, string title, string mimeType)
		{
			if (file == null)
				throw new ArgumentNullException ("file", "file is null.");
			if (String.IsNullOrEmpty (title))
				throw new ArgumentException ("title is null or empty.", "title");
			if (String.IsNullOrEmpty (mimeType))
				throw new ArgumentException ("mimeType is null or empty.", "mimeType");

			PicasaEntry photo = FindFileByTitle (title);
			if (photo != null) {
				_picasaService.Delete (photo);
				UploadFile (file, title, mimeType);
			}
		}
	}
}
