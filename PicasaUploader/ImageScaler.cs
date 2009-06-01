using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PicasaUploader
{
	static class ImageScaler
	{
		public static Stream Scale (Stream imageStream, int newWidth, int newHeight, bool preserveAspect)
		{
			if (imageStream == null)
				throw new ArgumentNullException ("imageStream", "imageStream is null.");
			if (newWidth <= 0)
				throw new ArgumentException ("newWidth must be > 0");
			if (newHeight <= 0)
				throw new ArgumentException ("newHeight must be > 0");

			Image image = Image.FromStream (imageStream);
			Image newImage = Scale (image, newWidth, newHeight, preserveAspect);

			MemoryStream newImageStream = new MemoryStream ();
			newImage.Save (newImageStream, image.RawFormat);
			newImageStream.Position = 0;

			image.Dispose ();
			newImage.Dispose ();

			return newImageStream;
		}

		public static Image Scale (Image image, int newWidth, int newHeight, bool preserveAspect)
		{
			if (image == null)
				throw new ArgumentNullException ("image", "image is null.");
			if (newWidth <= 0)
				throw new ArgumentException ("newWidth must be > 0");
			if (newHeight <= 0)
				throw new ArgumentException ("newHeight must be > 0");

			if (preserveAspect && image.Height > 0 && image.Width > 0) {
				float aspectRatio = (float)image.Width / (float)image.Height;
				newHeight = (int)Math.Round ((float)newWidth / aspectRatio);
				if (newHeight == 0)
					newHeight = 1;
			}

			Bitmap newImage = new Bitmap ((int)newWidth, (int)newHeight);
			Graphics gfx = Graphics.FromImage (newImage);
			gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
			gfx.DrawImage (image, 0, 0, newWidth, newHeight);
			gfx.Dispose ();

			return newImage;
		}

	}
}
