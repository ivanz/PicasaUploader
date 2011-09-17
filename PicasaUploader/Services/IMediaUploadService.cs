using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace PicasaUploader
{
    public interface IMediaUploadService
    {
        string[] SupportedPhotoFormats { get; }
        string[] SupportedVideoFormats { get; }
        int VideoFileSizeLimit { get; }
        int PhotoFileSizeLimit { get; }
        int AlbumsCountLimit { get; }
        int AlbumFilesCountLimit { get; }

        bool Login(string username, string password);
        IAlbumInfo[] LoadAlbums();
        void CreateAlbum(string title, string description, string location, DateTime date, bool makePublic);
        //void UploadFile(AlbumInfo album, string fileName);
        //void UploadFile(AlbumInfo album, Stream file, string title, string mimeType);
        //void ReplaceFile(AlbumInfo album, string fileName);
        //void ReplaceFile(AlbumInfo album, Stream file, string title, string mimeType);
        //bool IsFileDuplicate(AlbumInfo album, string fileName);
    }
}
