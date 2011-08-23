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
using System.IO;
using System.Threading;

using Google.GData.Photos;
using Google.GData.Client;
using PicasaUploader.Properties;
using PicasaUploader.Services;
using PicasaUploader.ViewModels;
using PicasaUploader.UI.WizardPages;
using PicasaUploader.Commands;

namespace PicasaUploader
{
    public partial class PicasaUploaderForm: Form, IUIDispatcher
    {
        private AboutDialog _aboutDialog = new AboutDialog();

        public PicasaUploaderForm (string[] sendToFiles)
        {
            InitializeComponent ();

            OrchestrateSystem();
        }

        internal PicasaUploaderForm() : this(null)
        {
        }

        public void OrchestrateSystem()
        {
            PicasaController picasaController = new PicasaController();
            LoginCommand loginCommand = new LoginCommand(picasaController);
            LoginViewModel loginViewModel = new LoginViewModel(loginCommand);
            LoginPage loginPage = new LoginPage(loginViewModel, progressMonitor);

            this.wizard.AddPage(loginPage);

            IAlbumContext albumContext = new AlbumContext();
            CreateAlbumCommand createAlbumCommand = new CreateAlbumCommand(picasaController);
            LoadAlbumsCommand loadAlbumsCommand = new LoadAlbumsCommand(picasaController);
            AlbumsViewModel albumsViewModel = new AlbumsViewModel(createAlbumCommand, loadAlbumsCommand, albumContext);
            AlbumsPage albumsPage = new AlbumsPage(albumsViewModel, ProgressMonitor);

            this.wizard.AddPage(albumsPage);

            UploadPhotoCommand uploadPhotoCommand = new UploadPhotoCommand(picasaController);
            UploadPhotosViewModel photosViewModel = new UploadPhotosViewModel(uploadPhotoCommand, albumContext);
            PhotosPage photosPage = new PhotosPage(photosViewModel, ProgressMonitor);

            this.wizard.AddPage(photosPage);

            // FIXME: There is a temporal coupling here
            wizardActionBar.Wizard = this.wizard;
        }

        private AboutDialog AboutDialog
        {
            get { return _aboutDialog; }
        }

        private ITaskProgressMonitor ProgressMonitor
        {
            get { return (ITaskProgressMonitor)this.progressMonitor; }
        }

        #region IUIDispatcher Members

        public void InvokeOnUIThread(Action action)
        {
            this.Invoke(action);
        }

        #endregion

        private void aboutButton_Click(object sender, EventArgs e)
        {
            AboutDialog.ShowDialog();
        }
    }
}
