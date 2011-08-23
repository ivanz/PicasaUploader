using System;
using System.Collections.Generic;
using System.Linq;
using PicasaUploader.Services;

namespace PicasaUploader.Commands
{
    public class LoadAlbumsCommand
    {
        public LoadAlbumsCommand(PicasaController picasa)
        {
            Picasa = picasa;
        }

        private PicasaController Picasa { get; set; }

        /// <summary>
        /// This method is blocking.
        /// </summary>
        public AlbumInfo[] LoadAlbums()
        {
            return Picasa.LoadAlbums();
        }
    }
}
