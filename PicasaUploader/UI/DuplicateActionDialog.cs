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
	public partial class DuplicateActionDialog : Form
	{
		public DuplicateActionDialog ()
		{
			InitializeComponent ();
			_formatString = textLabel.Text;
			_action = DuplicateAction.None;
		}

		private DuplicateAction _action;
		private string _formatString = null;

		public void ShowDialog (IWin32Window owner, string photoTitle, string albumTitle)
		{
			textLabel.Text = String.Format (_formatString, photoTitle, albumTitle);
			_action = DuplicateAction.None;
			base.ShowDialog (owner);
		}

		public DuplicateAction Action
		{
			get { return _action; }
		}

		private void uploadAllButton_Click (object sender, EventArgs e)
		{
			_action = DuplicateAction.UploadAll;
			this.Close ();
		}

		private void uploadButton_Click (object sender, EventArgs e)
		{
			_action = DuplicateAction.Upload;
			this.Close ();
		}

		private void skipAllButton_Click (object sender, EventArgs e)
		{
			_action = DuplicateAction.SkipAll;
			this.Close ();
		}

		private void skipButton_Click (object sender, EventArgs e)
		{
			_action = DuplicateAction.Skip;
			this.Close ();
		}

		private void replaceAllButton_Click (object sender, EventArgs e)
		{
			_action = DuplicateAction.ReplaceAll;
			this.Close ();
		}

		private void replaceButton_Click (object sender, EventArgs e)
		{
			_action = DuplicateAction.Replace;
			this.Close ();
		}
	}
}
