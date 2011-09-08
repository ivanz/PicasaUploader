using System;
using System.Collections.Generic;
using System.Linq;

namespace PicasaUploader
{
    public interface IPicasaController
    {
        bool Login(string username, string password);

        AlbumInfo[] LoadAlbums();

        void CreateAlbum(string title, string description, string location, DateTime date, bool makePublic);
    }
}
