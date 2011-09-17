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
        private readonly IMediaUploadService _controller;
        
        public AlbumsViewModel(IMediaUploadService uploadService, IAlbumContext albumContext)
        {
            if (albumContext == null)
                throw new ArgumentNullException("albumContext", "albumContext is null.");

            _controller = uploadService;
            CreateAlbumCommand = new CreateAlbumCommand(uploadService);
            LoadAlbumsCommand = new LoadAlbumsCommand(uploadService);
            _albumContext = albumContext;
        }

        public LoadAlbumsCommand LoadAlbumsCommand { get; private set; }
        public CreateAlbumCommand CreateAlbumCommand { get; private set; }

        private IAlbumContext AlbumContext
        {
            get { return _albumContext; }
        }

        protected IMediaUploadService UploadService
        {
            get { return _controller; }
        }

        public IAlbumInfo SelectedAlbum
        {
            get { return AlbumContext.Album; }
            set { AlbumContext.Album = value; }
        }

        public int AlbumsCountLimit {
            get { return UploadService.AlbumsCountLimit; }
        }
    }
}
