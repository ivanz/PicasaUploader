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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicasaUploader
{
	public partial class NewAlbumDialog : Form
	{
		public NewAlbumDialog ()
		{
			InitializeComponent ();
			dateTimePicker.Value = DateTime.Today;
		}

		private void cancelButton_Click (object sender, EventArgs e)
		{
			Close ();
		}

		private void okButton_Click (object sender, EventArgs e)
		{
			Close ();
		}

		public string AlbumTitle
		{
			get { return titleTextBox.Text; }
		}

		public string AlbumLocation
		{
			get { return locationTextBox.Text; }
		}

		public bool AlbumPublic
		{
			get { return publicCheckBox.Checked; }
		}

		public string AlbumDescription
		{
			get { return descriptionTextBox.Text; }
		}

		public DateTime AlbumDate
		{
			get { return dateTimePicker.Value; }
		}
	}
}
