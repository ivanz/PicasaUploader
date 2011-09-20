using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PicasaUploader.UI.Controls;
using PicasaUploader.Aspects;
using System.Threading.Tasks;
using PicasaUploader.Services;
using PicasaUploader.ViewModels;
using System.Threading;

namespace PicasaUploader.UI.WizardPages
{
    public partial class AlbumsPage : WizardActionPage
    {
        private readonly ITaskProgressMonitor _progressMonitor;
        private readonly AlbumsViewModel _viewModel;

        public AlbumsPage()
        {
            InitializeComponent();
        }

        public AlbumsPage(AlbumsViewModel viewModel, ITaskProgressMonitor progressMonitor) : this()
        {
            _viewModel = viewModel;
            _progressMonitor = progressMonitor;
        }

        protected override Func<CancellationToken, bool> Action
        {
            get {
                return (cancellationToken) => {
                    if (ViewModel.SelectedAlbum == null) {
                        MessageBox.Show("Please, select an album first", "Album", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    return true;
                }; 
            }
        }

        private ITaskProgressMonitor ProgressMonitor
        {
            get { return _progressMonitor; }
        }

        private AlbumsViewModel ViewModel
        {
            get { return _viewModel; }
        }

        [ExecuteOnUIThread]
        public override void Initialize()
        {
            base.Initialize();

            ProgressMonitor.StartTask(1, "Loading albums");
            OnInitializationStarting();
            Task.Factory.StartNew(() => {
                LoadAlbums();
                ProgressMonitor.CompleteTask();
                OnInitializationComplete();
            });
        }

        [ExecuteOnUIThread]
        protected override void OnInitializationComplete()
        {
            newAlbumButton.Enabled = true;
            base.OnInitializationComplete();
        }

        [ExecuteOnUIThread]
        protected override void OnInitializationStarting()
        {
            newAlbumButton.Enabled = false;
            base.OnInitializationStarting();
        }

        private void LoadAlbums()
        {
            // This command blocks
            IAlbumInfo[] albums = ViewModel.LoadAlbumsCommand.LoadAlbums();
            LoadAlbumsIntoListView(albums);
        }
        
        [ExecuteOnUIThread]
        private void LoadAlbumsIntoListView(IAlbumInfo[] albums)
        {
            albumsListView.Clear();
            albumCoversImageList.Images.Clear();

            albumsListView.SuspendLayout();

            foreach (PicasaAlbumInfo album in albums) {
                string imageKey = album.Id;
                albumCoversImageList.Images.Add(imageKey, album.AlbumCover);
                albumsListView.Items.Add(new ListViewItem() { 
                    Tag = album, 
                    ImageKey = imageKey,
                    Text = album.Title
                });
            }

            albumsListView.ResumeLayout();
        }

        private void OnAlbumSelectionChanged()
        {
            if (albumsListView.SelectedItems.Count == 1) {
                ViewModel.SelectedAlbum = (IAlbumInfo)albumsListView.SelectedItems[0].Tag;
            } else {
                ViewModel.SelectedAlbum = null;
            }
        }

        public void CreateNewAlbum()
        {
            if (albumsListView.Items.Count >= ViewModel.AlbumsCountLimit) {
                MessageBox.Show(String.Format("Unfortunately you have reached limit of {0} albums allowed in PicasaWeb ", ViewModel.AlbumsCountLimit),
                         "Albums Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            NewAlbumEditModel newAlbumModel = new NewAlbumEditModel();
            using (NewAlbumDialog dialog = new NewAlbumDialog(newAlbumModel)) {
                if (dialog.ShowDialog(this) == DialogResult.OK) {
                    ProgressMonitor.StartTask(1, "Creating album");

                    Task.Factory.StartNew(() => {
                        ViewModel.CreateAlbumCommand.CreateAlbum(newAlbumModel);
                        ProgressMonitor.CompleteTask();
                        Initialize();
                    });
                }
            }
        }

        private void newAlbumButton_Click(object sender, EventArgs e)
        {
            CreateNewAlbum();
        }

        private void albumsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnAlbumSelectionChanged();
        }
    }
}
