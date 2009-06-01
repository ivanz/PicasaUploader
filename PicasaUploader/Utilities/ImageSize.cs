//
// Copyright (c) 2009 Ivan N. Zlatev <contact@i-nz.net>
//
// Authors:
//	Ivan N. Zlatev <contact@i-nz.net>
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
	class ImageSize
	{
		public static ImageSize Empty = new ImageSize ("Keep Size", 0, 0);

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
			if (this == Empty)
				return Empty.Label;
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
