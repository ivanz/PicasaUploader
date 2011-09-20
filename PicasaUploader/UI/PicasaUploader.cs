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
            PicasaUploadService picasaController = new PicasaUploadService();
            LoginViewModel loginViewModel = new LoginViewModel(picasaController);
            LoginPage loginPage = new LoginPage(loginViewModel, progressMonitor);

            this.wizard.AddPage(loginPage);

            IAlbumContext albumContext = new AlbumContext();
            AlbumsViewModel albumsViewModel = new AlbumsViewModel(picasaController, albumContext);
            AlbumsPage albumsPage = new AlbumsPage(albumsViewModel, ProgressMonitor);

            this.wizard.AddPage(albumsPage);

            UploadPhotosViewModel photosViewModel = new UploadPhotosViewModel(picasaController, albumContext);
            PhotosPage photosPage = new PhotosPage(photosViewModel, ProgressMonitor);

            this.wizard.AddPage(photosPage);

            // FIXME: There is a temporal coupling here (pages must be set before the actionbar is initialized
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

        protected override void OnClosing(CancelEventArgs e)
        {
            if (ProgressMonitor.IsTaskRunning) {
                if (MessageBox.Show(this, "An action is currently in progress. Are you sure you want to quit?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.No) {
                    e.Cancel = true;
                }
            }

            base.OnClosing(e);
        }
    }
}
