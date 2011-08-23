using System;
using System.Collections.Generic;
using System.Linq;
using PicasaUploader.Commands;
using PicasaUploader.Services;

namespace PicasaUploader.ViewModels
{
    public class AlbumsViewModel
    {
        private readonly IAlbumContext _albumContext;

        public AlbumsViewModel(CreateAlbumCommand createAlbumCommand, LoadAlbumsCommand loadAlbumsCommand, IAlbumContext albumContext)
        {
            if (createAlbumCommand == null)
                throw new ArgumentNullException("createAlbumCommand", "createAlbumCommand is null.");
            if (loadAlbumsCommand == null)
                throw new ArgumentNullException("loadAlbumsCommand", "loadAlbumsCommand is null.");
            if (albumContext == null)
                throw new ArgumentNullException("albumContext", "albumContext is null.");

            _albumContext = albumContext;
            LoadAlbumsCommand = loadAlbumsCommand;
            CreateAlbumCommand = createAlbumCommand;
        }

        public LoadAlbumsCommand LoadAlbumsCommand { get; private set; }
        public CreateAlbumCommand CreateAlbumCommand { get; private set; }

        private IAlbumContext AlbumContext
        {
            get { return _albumContext; }
        }

        public AlbumInfo SelectedAlbum
        {
            get { return AlbumContext.Album; }
            set { AlbumContext.Album = value; }
        }

        public int AlbumsCountLimit {
            get { return PicasaController.AlbumsCountLimit; }
        }
    }
}
