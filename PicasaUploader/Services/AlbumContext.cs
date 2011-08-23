using System;
using System.Collections.Generic;
using System.Linq;

namespace PicasaUploader.Services
{
    internal class AlbumContext : IAlbumContext
    {
        public AlbumInfo Album { get; set; }
    }
}
