using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicasaUploader.Services
{
    public interface IAlbumContext
    {
        AlbumInfo Album { get; set; }
    }
}
