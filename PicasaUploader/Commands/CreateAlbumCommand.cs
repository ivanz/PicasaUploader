
using System;
using System.Collections.Generic;
using System.Linq;
using PicasaUploader.Services;
using PicasaUploader.ViewModels;

namespace PicasaUploader.Commands
{
    public class CreateAlbumCommand
    {
        public CreateAlbumCommand(PicasaController picasa)
        {
            Picasa = picasa;
        }

        private PicasaController Picasa { get; set; }

        /// <summary>
        /// This method is blocking.
        /// </summary>
        public void CreateAlbum(NewAlbumEditModel model)
        {
            Picasa.CreateAlbum(model.Title, model.Description, model.Location, model.Date, model.Public);
        }
    }
}
