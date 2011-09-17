
using System;
using System.Collections.Generic;
using System.Linq;
using PicasaUploader.Services;
using PicasaUploader.ViewModels;

namespace PicasaUploader.Commands
{
    public class CreateAlbumCommand
    {
        public CreateAlbumCommand(IMediaUploadService uploadService)
        {
            UploadService = uploadService;
        }

        private IMediaUploadService UploadService { get; set; }

        /// <summary>
        /// This method is blocking.
        /// </summary>
        public void CreateAlbum(NewAlbumEditModel model)
        {
            UploadService.CreateAlbum(model.Title, model.Description, model.Location, model.Date, model.Public);
        }
    }
}
