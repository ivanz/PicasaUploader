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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PicasaUploader.ViewModels;

namespace PicasaUploader
{
    public partial class NewAlbumDialog : Form
    {
        private readonly NewAlbumEditModel _editModel;


        internal NewAlbumDialog()
        {
            InitializeComponent();
            dateTimePicker.Value = DateTime.Today;
        }

        public NewAlbumDialog(NewAlbumEditModel editModel) : this()
        {
            if (editModel == null)
                throw new ArgumentNullException("editModel", "editModel is null.");

            _editModel = editModel;
            newAlbumEditModelBindingSource.DataSource = _editModel;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            //SyncModel();
        }

        //private void SyncModel()
        //{
        //    EditModel.Title = titleTextBox.Text;
        //    EditModel.Public = publicCheckBox.Checked;
        //    EditModel.Location = locationTextBox.Text;
        //    EditModel.Description = descriptionTextBox.Text;
        //    EditModel.Date = dateTimePicker.Value;
        //}

        private NewAlbumEditModel EditModel
        {
            get { return _editModel; }
        }
    }
}
