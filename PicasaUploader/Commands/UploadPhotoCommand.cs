using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace PicasaUploader.Commands
{
    public class UploadPhotoCommand
    {
        public UploadPhotoCommand(PicasaController picasa)
        {
            Picasa = picasa;
        }

        private PicasaController Picasa { get; set; }

        public void UploadPhoto(string file,
                                 AlbumInfo album,
                                 ImageSize size,
                                 Func<string /* file */ , DuplicateAction> duplicateHandlerQuery)
        {
            using (Stream scaledFileStream = ScaleImageDown(file, size)) {
                string mimeType = PicasaController.GetMimeType(file);

                if (album.IsFileDuplicate(file)) {
                    DuplicateAction duplicateAction = duplicateHandlerQuery(file);
                    if (duplicateAction == DuplicateAction.Replace || duplicateAction == DuplicateAction.ReplaceAll)
                        album.ReplaceFile(scaledFileStream, Path.GetFileName(file), mimeType);
                    else
                        if (duplicateAction == DuplicateAction.Upload || duplicateAction == DuplicateAction.UploadAll)
                            album.UploadFile(scaledFileStream, Path.GetFileName(file), mimeType);
                        else
                            if (duplicateAction == DuplicateAction.Cancel)
                                return;
                } else {
                    album.UploadFile(scaledFileStream, Path.GetFileName(file), mimeType);
                }
            }
        }

        private Stream ScaleImageDown(string file, ImageSize imageSize)
        {
            if (String.IsNullOrEmpty(file))
                throw new ArgumentException("file is null or empty.", "file");
            if (imageSize == null)
                throw new ArgumentNullException("imageSize", "imageSize is null.");

            using (Stream imageStream = File.OpenRead(file)) {
                if (imageSize != null && imageSize != ImageSize.Original)
                    return ImageScaler.ScaleDown(imageStream, imageSize.Width, imageSize.Height, true);

                return imageStream;
            }
        }
    }
}
