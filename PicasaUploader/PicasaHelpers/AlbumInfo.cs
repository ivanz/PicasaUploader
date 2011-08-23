using System;
using System.Collections.Generic;
using System.Linq;
using Google.GData.Photos;
using Google.GData.Client;
using System.Drawing;
using System.IO;

namespace PicasaUploader
{
    public class AlbumInfo
    {
        private readonly PicasaEntry _album;
        private readonly PicasaService _picasaService;

        internal AlbumInfo(PicasaEntry album, PicasaService picasaService)
        {
            if (picasaService == null)
                throw new ArgumentNullException("picasaService", "picasaService is null.");
            if (album == null)
                throw new ArgumentNullException("album", "album is null.");

            _picasaService = picasaService;
            _album = album;

            NumPhotos = Int32.Parse(_album.GetPhotoExtensionValue(GPhotoNameTable.NumPhotos));
            RemainingPhotos = Int32.Parse(_album.GetPhotoExtensionValue(GPhotoNameTable.NumPhotosRemaining));
            Title = _album.Title.Text;
            if (_album.Media.Thumbnails != null && _album.Media.Thumbnails.Count > 0)
                AlbumCover = new Bitmap(_picasaService.Query(new Uri((string)_album.Media.Thumbnails[0].Attributes["url"])));
            Id = _album.GetPhotoExtensionValue(GPhotoNameTable.Id);
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

        public int RemainingPhotos
        {
            get;
            private set;
        }

        // Only checks if there is a photo with the same title and 
        // does *not* check if the content matches.
        //
        public bool IsFileDuplicate(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            if (FindFileByTitle(Path.GetFileName(fileName)) != null)
                return true;

            return false;
        }

        private PicasaEntry FindFileByTitle(string title)
        {
            if (String.IsNullOrEmpty(title))
                throw new ArgumentNullException(title);

            PhotoQuery photoQuery = new PhotoQuery(PicasaQuery.CreatePicasaUri(_picasaService.Credentials.Username, Id));
            var results = from photo in _picasaService.Query(photoQuery).Entries
                          where photo.Title.Text == title
                          select photo;
            if (results.Count() > 0)
                return (PicasaEntry)results.First();

            return null;
        }

        public void UploadFile(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentException("fileName is null or empty.", "fileName");

            string mimeType = PicasaController.GetMimeType(fileName);
            if (mimeType == null) // not supported
                throw new NotSupportedException("Image type not supported");

            using (Stream file = File.OpenRead(fileName)) {
                UploadFile(file, fileName, PicasaController.GetMimeType(fileName));
            }
        }

        public void UploadFile(Stream file, string title, string mimeType)
        {
            if (String.IsNullOrEmpty(mimeType))
                throw new ArgumentException("mimeType is null or empty.", "mimeType");
            if (String.IsNullOrEmpty(title))
                throw new ArgumentException("title is null or empty.", "title");
            if (file == null)
                throw new ArgumentNullException("file", "file is null.");

            PhotoEntry entry = new PhotoEntry();
            entry.Title = new AtomTextConstruct(AtomTextConstructElementType.Title, title);
            MediaFileSource fileSource = new MediaFileSource(file, title, mimeType);
            entry.MediaSource = fileSource;

            _picasaService.Insert(new Uri(PhotoQuery.CreatePicasaUri(_picasaService.Credentials.Username, Id)),
                           entry);
        }

        public void ReplaceFile(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            PicasaEntry photo = FindFileByTitle(Path.GetFileName(fileName));
            if (photo != null) {
                _picasaService.Delete(photo);
                UploadFile(fileName);
            }
        }

        public void ReplaceFile(Stream file, string title, string mimeType)
        {
            if (file == null)
                throw new ArgumentNullException("file", "file is null.");
            if (String.IsNullOrEmpty(title))
                throw new ArgumentException("title is null or empty.", "title");
            if (String.IsNullOrEmpty(mimeType))
                throw new ArgumentException("mimeType is null or empty.", "mimeType");

            PicasaEntry photo = FindFileByTitle(title);
            if (photo != null) {
                _picasaService.Delete(photo);
                UploadFile(file, title, mimeType);
            }
        }
    }
}
