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
using System.Text;
using System.Drawing;

namespace PicasaUploader
{
	public class ImageSize
	{
		public static ImageSize Original = new ImageSize ("Original Size", 0, 0);

		public ImageSize (string label, int width, int height)
		{
			if (String.IsNullOrEmpty (label))
				throw new ArgumentException ("label is null or empty.", "label");

			Label = label;
			Height = height;
			Width = width;
		}

		public int Width { get; set; }
		public int Height { get; set; }
		public string Label { get; set; }

		public override string ToString ()
		{
			if (this == Original)
				return Original.Label;
			return String.Format ("{0} ({1}x{2})", Label, Width, Height);
		}

		public override bool Equals (object obj)
		{
			ImageSize size = obj as ImageSize;
			if (size != null)
				return size.Height == this.Height && size.Width == this.Width && size.Label == this.Label;

			return base.Equals (obj);
		}

		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}
	}
}
