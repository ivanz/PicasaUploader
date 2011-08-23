
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicasaUploader.Commands;
using PicasaUploader.Services;
using System.IO;

namespace PicasaUploader.ViewModels
{
    public class UploadPhotosViewModel
    {
        private readonly IAlbumContext _albumContext;

        public UploadPhotosViewModel(UploadPhotoCommand uploadCommand, IAlbumContext albumContext)
        {
            if (uploadCommand == null)
                throw new ArgumentNullException("uploadCommand", "uploadCommand is null.");
            if (albumContext == null)
                throw new ArgumentNullException("albumContext", "albumContext is null.");

            _albumContext = albumContext;
            Files = new List<string>();
            UploadCommand = uploadCommand;
        }


        public AlbumInfo SelectedAlbum
        {
            get { return _albumContext.Album; }
            set { _albumContext.Album = value; }
        }

        public IList<string> Files { get; private set; }
        public UploadPhotoCommand UploadCommand { get; private set; }

        public int AlbumPhotosLeftCount
        {
            get { return PicasaController.AlbumFilesCountLimit - (SelectedAlbum.NumPhotos + Files.Count); }
        }

        public void AddFiles(string[] files)
        {
            // TODO: add more exceptions:
            //  - unsupported file type
            //  - file over size limit

            bool filesExcluded = false;

            foreach (string fileName in files) {
                if (!IsSupported(fileName) || !IsInSizeLimits(fileName)) {
                    filesExcluded = true;
                    continue;
                }

                Files.Add(fileName);
            }

            if (filesExcluded) {
                throw new AddPhotosException(
                    String.Format("Some files weren't added because they exceed either the maximum video file size limit of {0}MB or the maximum photo file size limit  of {1}MB",
                                   PicasaController.VideoFileSizeLimit,
                                   PicasaController.PhotoFileSizeLimit));
            }
        }

        public void RemoveFiles(string[] files)
        {
            foreach (string file in files) {
                Files.Remove(file);
            }
        }

        private bool IsSupported(string fileName) {
            return IsPhotoFile(fileName) || IsVideoFile(fileName);
        }

        private bool IsInSizeLimits(string fileName)
        {
            if (IsVideoFile(fileName)) {
                if (new FileInfo(fileName).Length / Math.Pow(1024, 2) >= (float)PicasaController.VideoFileSizeLimit) {
                    return false;
                }
            } else if (IsPhotoFile(fileName)) {
                if (new FileInfo(fileName).Length / Math.Pow(1024, 2) >= (float)PicasaController.PhotoFileSizeLimit) {
                    return false;
                }
            }

            return true;
        }

        public bool IsPhotoFile(string fileName)
        {
            return PicasaController.SupportedPhotoFormats.Contains(Path.GetExtension(fileName).ToLowerInvariant());
        }

        public bool IsVideoFile(string fileName)
        {
            return PicasaController.SupportedVideoFormats.Contains(Path.GetExtension(fileName).ToLowerInvariant());
        }
    }
}
