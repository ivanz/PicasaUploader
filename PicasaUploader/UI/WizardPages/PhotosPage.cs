using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PicasaUploader.UI.Controls;
using PicasaUploader.Services;
using PicasaUploader.ViewModels;
using PicasaUploader.Properties;
using System.IO;

namespace PicasaUploader.UI.WizardPages
{
    public partial class PhotosPage : WizardActionPage
    {
        private readonly ITaskProgressMonitor _progressMonitor;
        private readonly UploadPhotosViewModel _viewModel;
        private readonly Dictionary<string, ListViewItem> _listViewItemsCache = new Dictionary<string, ListViewItem>();
        private bool _doNotPromptForDuplicateAction;
        private DuplicateAction _duplicateAction = DuplicateAction.Cancel;

        /// <summary>
        /// Do not use - only present, because a parameterless ctor is required by 
        /// the winforms designer surface.
        /// </summary>
        public PhotosPage()
        {
            InitializeComponent();
            PopulateImageSizes();
        }

        public PhotosPage(UploadPhotosViewModel viewModel, ITaskProgressMonitor progressMonitor) : this()
        {
            if (viewModel == null)
                throw new ArgumentNullException("viewModel", "viewModel is null.");
            if (progressMonitor == null)
                throw new ArgumentNullException("progressMonitor", "progressMonitor is null.");

            _progressMonitor = progressMonitor;
            _viewModel = viewModel;
        }

        public override string ActionText
        {
            get { return "Upload"; }
        }

        public override void Initialize()
        {
            base.OnInitializationStarting();

            ResetDuplicateActionPrompt();
            SyncUIWithViewModel();

            base.OnInitializationComplete();
        }

        private void ResetDuplicateActionPrompt()
        {
            _doNotPromptForDuplicateAction = false;
            _duplicateAction = DuplicateAction.Cancel;
        }

        public void PopulateImageSizes()
        {
            imageSizeBindingSource.DataSource = new List<ImageSize> () {
                ImageSize.Original,
                new ImageSize ("Small", 800, 600),
                new ImageSize ("Medium", 1024, 768),
                new ImageSize ("Large", 1280, 1024),
                new ImageSize ("Extra Large", 1400, 1050)
            };
        }

        private void SyncUIWithViewModel()
        {
            _listViewItemsCache.Clear();

            foreach (Image image in photosImageList.Images) {
                image.Dispose();
            }
            photosImageList.Images.Clear();
            filesListView.VirtualListSize = ViewModel.Files.Count;

            this.albumPhotosCountLabel.Text = String.Format("{0}/{1}", ViewModel.SelectedAlbum.NumPhotos, ViewModel.AlbumPhotosLeftCount);
            this.filesToAddCountLabel.Text = ViewModel.Files.Count.ToString();
        }

        protected override Func<bool> Action
        {
            get { return () => { return DoUploadWithRetry(3); }; }
        }

        private bool PromptToRetryAgain(string file)
        {
            return MessageBox.Show("There is a problem uploading " + Path.GetFileName(file) +
                        Environment.NewLine + "Some possible causes can be: " + Environment.NewLine +
                        "\t - PicasaWeb doesn't support this photo type or video encoding." + Environment.NewLine +
                        "\t - Temporary Internet connection issues." + Environment.NewLine +
                        "\t - Temporary PicasaWeb service disruption." + Environment.NewLine +
                        "\t - You have exceeded your PicasaWeb quota." + Environment.NewLine +
                        "\t - Can't open the file." + Environment.NewLine +
                        Environment.NewLine +
                        "Would you like to retry?", "Upload Error", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error) == DialogResult.Yes;
        }

        private bool DoUploadWithRetry(int times)
        {
            ProgressMonitor.StartTask(ViewModel.Files.Count, String.Format("Starting photo upload", ViewModel.Files.Count));

            bool uploadFinishedSuccessfully = true;

            for (int i = 0; i < ViewModel.Files.Count; i++) {
                ProgressMonitor.Step(String.Format("Uploading photo {0}/{1}", i + 1, ViewModel.Files.Count));
                string currentFile = ViewModel.Files[i];

                int retryCounter = times;
                do {
                    try {
                        ViewModel.UploadCommand.UploadPhoto(currentFile, ViewModel.SelectedAlbum, SelectedImageSize, HandleDuplicateFileDuringUpload);
                        retryCounter = 0;
                    } catch {
                        retryCounter--;
                        if (retryCounter == 0) {
                            if (PromptToRetryAgain(currentFile))
                                retryCounter = times;
                            else
                                uploadFinishedSuccessfully = false;
                        }
                    }
                } while (retryCounter > 0);
            }

            ProgressMonitor.CompleteTask();
            ResetDuplicateActionPrompt();

            return uploadFinishedSuccessfully;
        }

        protected override void OnActionCompleted(SuccessEventArgs args)
        {
            base.OnActionCompleted(args);

            this.removePhotosButton.Enabled = this.addFilesButton.Enabled = imageSizeComboBox.Enabled = true;

            if (args.Success)
                PromptToUploadMorePhotos();
        }

        protected override void OnActionStarting()
        {
            base.OnActionStarting();
            this.removePhotosButton.Enabled = this.addFilesButton.Enabled = imageSizeComboBox.Enabled = false;
        }

        public void PromptToUploadMorePhotos()
        {
            if (MessageBox.Show("Would you like to upload more photos?", "Upload more?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Wizard.GoTo<AlbumsPage>();
            else
                Application.Exit();
        }

        private DuplicateAction HandleDuplicateFileDuringUpload(string fileName)
        {
            if (_doNotPromptForDuplicateAction)
                return _duplicateAction;

            using (DuplicateActionDialog duplicateActionDialog = new DuplicateActionDialog()) {
                duplicateActionDialog.ShowDialog(fileName, ViewModel.SelectedAlbum.Title);
                DuplicateAction action = duplicateActionDialog.DuplicateAction;

                // If "All" action is selected we do not want to prompt each time
                if (action == DuplicateAction.ReplaceAll ||
                    action == DuplicateAction.SkipAll ||
                    action == DuplicateAction.UploadAll) {

                    _doNotPromptForDuplicateAction = true;
                    _duplicateAction = action;
                }
                
                return duplicateActionDialog.DuplicateAction;
            }
        }

        private UploadPhotosViewModel ViewModel
        {
            get { return _viewModel; }
        }

        public ITaskProgressMonitor ProgressMonitor
        {
            get { return _progressMonitor; }
        }

        private ImageSize SelectedImageSize {
            get { return (ImageSize)imageSizeBindingSource.Current; }
        }

        private void addFilesButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                int newPlusOldFilesCount = ViewModel.Files.Count + openFileDialog.FileNames.Length;
                int exceedsCapacityBy = newPlusOldFilesCount - ViewModel.SelectedAlbum.RemainingPhotos;
                if (exceedsCapacityBy > 0) {
                    MessageBox.Show(String.Format("By adding the selected {0} files you are going to exceed the maximum number " + 
                                                    "of files per album by {1}.{2}Please, select less files",
                                                    openFileDialog.FileNames.Length,
                                                    exceedsCapacityBy,
                                                    Environment.NewLine),
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AddFiles(openFileDialog.FileNames);
            }
        }

        private void AddFiles(string[] files)
        {
            if (!CheckAlbumLimits())
                return;

            try {
                ViewModel.AddFiles(files);
            } catch (AddPhotosException exception) {
                MessageBox.Show(this, exception.Message, "Unable to add", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            SyncUIWithViewModel();
        }

        private bool CheckAlbumLimits()
        {
            if (ViewModel.Files.Count >= ViewModel.SelectedAlbum.RemainingPhotos) {
                MessageBox.Show("You have exceeded the maximum number of photos you can upload to this album.",
                                 "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void removePhotosButton_Click(object sender, EventArgs e)
        {
            for (int i = filesListView.SelectedIndices.Count - 1; i >= 0; i--) {
                ViewModel.Files.RemoveAt(filesListView.SelectedIndices[i]);
            }
            SyncUIWithViewModel();
        }

        private void filesListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void filesListView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                AddFiles(files);
            }
        }

        private void filesListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            string fileName = ViewModel.Files[e.ItemIndex];

            if (_listViewItemsCache.ContainsKey(fileName)) {
                e.Item = _listViewItemsCache[fileName];
            } else {
                int itemImageIndex = CreateListViewThumbnail(fileName);
                string itemLabel = Path.GetFileName(fileName);
                ListViewItem listViewItem = new ListViewItem(itemLabel, itemImageIndex);

                _listViewItemsCache.Add(fileName, listViewItem);
                e.Item = listViewItem;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Image index</returns>
        private int CreateListViewThumbnail(string fileName)
        {
            Image thumbnail = null;

            if (ViewModel.IsVideoFile(fileName)) {
                thumbnail = Resources.VideoIcon;
            } else if (ViewModel.IsPhotoFile(fileName)) {
                Image originalImage = Image.FromFile(fileName);
                thumbnail = ImageScaler.ScaleToThumbnail(originalImage, photosImageList.ImageSize.Width,
                                         photosImageList.ImageSize.Height, true);
                originalImage.Dispose();
            } else {
                throw new NotSupportedException("Unsupported file type: " + fileName);
            }

            photosImageList.Images.Add(fileName, thumbnail);

            return photosImageList.Images.IndexOfKey(fileName);
        }
    }
}
