using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicasaUploader.Services
{
    public interface IAlbumContext
    {
        IAlbumInfo Album { get; set; }
    }
}
