using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;

namespace PicasaUploader
{
    public interface IAlbumInfo
    {
        int NumPhotos { get; }
        string Title { get; }
        string Id { get; }
        Bitmap AlbumCover { get; }
        int RemainingPhotos { get; }

        bool IsFileDuplicate(string fileName);
        void UploadFile(string fileName);
        void UploadFile(Stream file, string title, string mimeType);
        void ReplaceFile(string fileName);
        void ReplaceFile(Stream file, string title, string mimeType);
    }
}

