using System;
using System.Collections.Generic;
using System.Linq;
using PicasaUploader.Services;

namespace PicasaUploader.Commands
{
    public class LoadAlbumsCommand
    {
        public LoadAlbumsCommand(IMediaUploadService uploadService)
        {
            UploadService = uploadService;
        }

        private IMediaUploadService UploadService { get; set; }

        /// <summary>
        /// This method is blocking.
        /// </summary>
        public IAlbumInfo[] LoadAlbums()
        {
            return UploadService.LoadAlbums();
        }
    }
}
