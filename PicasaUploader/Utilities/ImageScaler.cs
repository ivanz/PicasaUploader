//
// Copyright (c) 2009 Ivan Zlatev <ivan@ivanz.com>
//
// Authors:
//	Ivan Zlatev <ivan@ivanz.com>
//
// License: MIT/X11 - See LICENSE.txt
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PicasaUploader
{
    static class ImageScaler
    {
        public static Stream ScaleDown(Stream imageStream, int newWidth, int newHeight, bool preserveAspect)
        {
            if (imageStream == null)
                throw new ArgumentNullException("imageStream", "imageStream is null.");
            if (newWidth <= 0)
                throw new ArgumentException("newWidth must be > 0");
            if (newHeight <= 0)
                throw new ArgumentException("newHeight must be > 0");

            Image image = Image.FromStream(imageStream);
            Image newImage = ScaleDown(image, newWidth, newHeight, preserveAspect);

            MemoryStream newImageStream = new MemoryStream();
            newImage.Save(newImageStream, image.RawFormat);
            newImageStream.Position = 0;

            image.Dispose();
            newImage.Dispose();

            return newImageStream;
        }

        public static Image ScaleDown(Image image, int newWidth, int newHeight, bool preserveAspect)
        {
            if (image == null)
                throw new ArgumentNullException("image", "image is null.");
            if (newWidth <= 0)
                throw new ArgumentException("newWidth must be > 0");
            if (newHeight <= 0)
                throw new ArgumentException("newHeight must be > 0");

            if (image.Height > newHeight || image.Width > newWidth)
                return ScaleCore(image, newWidth, newHeight, preserveAspect, InterpolationMode.HighQualityBicubic);

            return image;
        }

        public static Image ScaleToThumbnail(Image image, int newWidth, int newHeight, bool preserveAspect)
        {
            return ScaleCore(image, newWidth, newHeight, preserveAspect, InterpolationMode.Low);
        }

        private static Image ScaleCore(Image image, int newWidth, int newHeight, bool preserveAspect, InterpolationMode quality)
        {
            if (image == null)
                throw new ArgumentNullException("image", "image is null.");
            if (newWidth <= 0)
                throw new ArgumentException("newWidth must be > 0");
            if (newHeight <= 0)
                throw new ArgumentException("newHeight must be > 0");

            if (preserveAspect && image.Height > 0 && image.Width > 0) {
                float aspectRatio = (float)image.Width / (float)image.Height;
                newHeight = (int)Math.Round((float)newWidth / aspectRatio);
                if (newHeight == 0)
                    newHeight = 1;
            }

            Bitmap newImage = new Bitmap((int)newWidth, (int)newHeight);
            Graphics gfx = Graphics.FromImage(newImage);
            gfx.InterpolationMode = quality;
            gfx.DrawImage(image, 0, 0, newWidth, newHeight);
            gfx.Dispose();

            CopyExif(image, newImage);

            return newImage;
        }

        /// <summary>
        /// Copies the EXIF data into the new image and adjusts the Width and Height 
        /// accordingly.
        /// </summary>
        /// <param name="oldImage"></param>
        /// <param name="newImage"></param>
        private static void CopyExif(Image oldImage, Image newImage)
        {
            foreach (PropertyItem property in oldImage.PropertyItems) {
                if (property.Id == EXIF_HEIGHT_ID) {
                    byte[] newHeight = BitConverter.GetBytes(newImage.Height);
                    property.Value = newHeight;
                } else if (property.Id == EXIF_WIDTH_ID) {
                    byte[] newWidth = BitConverter.GetBytes(newImage.Width);
                    property.Value = newWidth;
                }

                newImage.SetPropertyItem(property);
            }
        }

        private const int EXIF_WIDTH_ID = 0x0100;
        private const int EXIF_HEIGHT_ID = 0x0101;
    }
}
