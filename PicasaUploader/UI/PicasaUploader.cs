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

namespace PicasaUploader
{
	public partial class PicasaUploaderForm: Form
	{
		private static string READY_LABEL = "Ready";
		private static int DEFAULT_UPLOAD_RETRY_COUNT = 3;
		PicasaController _picasa;
		private List<string> _files;
		private Dictionary<string, ListViewItem> _filesListViewItemsCache;
		private AlbumInfo _selectedAlbum = null;
		private bool _sendToMode = true;
		private DuplicateActionDialog _duplicateActionDialog = null;

		public PicasaUploaderForm (string[] sendToFiles)
		{
			InitializeComponent ();

			LoadImageSizes ();

			_picasa = new PicasaController ();
			_filesListViewItemsCache = new Dictionary<string, ListViewItem> ();
			_files = new List<string> ();
			usernameTextBox.Select ();
			LoadUserCredentials ();
			openFileDialog.InitialDirectory = Environment.GetFolderPath (Environment.SpecialFolder.MyPictures);

			// If sendToFiles has files of format which we support then we are in Send To mode.
			if (sendToFiles != null && sendToFiles.Length > 0) {
				AddFiles (sendToFiles);
				if (_files.Count > 0)
					_sendToMode = true;
			}
		}

		public PicasaUploaderForm() : this (null)
		{
		}

		private void LoadImageSizes ()
		{
			imageSizeBindingSource.DataSource = new List<ImageSize> () {
				ImageSize.Empty,
				new ImageSize ("Small", 800, 600),
				new ImageSize ("Medium", 1024, 768),
				new ImageSize ("Large", 1280, 1024),
				new ImageSize ("Extra Large", 1400, 1050)
			};
		}

		private void LoadUserCredentials ()
		{
			if (Settings.Default.Username != string.Empty) {
				usernameTextBox.Text = CryptoStringUtil.DecryptString (Settings.Default.Username);
				rememberCheckBox.Checked = true;
			}

			if (Settings.Default.Password != string.Empty) {
				passwordTextBox.Text = CryptoStringUtil.DecryptString (Settings.Default.Password);
				rememberCheckBox.Checked = true;
			}
		}


		private void StoreUserCredentials ()
		{
			if (Settings.Default.Username == string.Empty)
				Settings.Default.Username = CryptoStringUtil.EncryptString (usernameTextBox.Text);

			if (Settings.Default.Password == string.Empty)
				Settings.Default.Password = CryptoStringUtil.EncryptString (passwordTextBox.Text);

			Settings.Default.Save ();
		}

		private void PurgeUserCredentials ()
		{
			Settings.Default.Username = string.Empty;
			Settings.Default.Password = string.Empty;
			Settings.Default.Save ();
		}


		private void SetFileDialogImagesFilter ()
		{
			StringBuilder sb = new StringBuilder ("Pictures|");
			foreach (string extension in PicasaController.SupportedPhotoFormats) {
				sb.Append (extension);
				sb.Append (";");
			}
			openFileDialog.Filter = sb.ToString ();
		}

		private void nextButton_Click (object sender, EventArgs e)
		{
			TryGoToNextPage ();
		}

		private void TryGoToNextPage ()
		{
			if (tabControl1.SelectedTab == loginTab)
				Login ();
			else if (tabControl1.SelectedTab == albumsTab)
				PreparePhotosTab ();
			else if (tabControl1.SelectedTab == photosTab)
				UploadFiles ();
		}

		private void PreparePhotosTab ()
		{
			if (albumsListView.SelectedItems.Count == 0) {
				MessageBox.Show ("Please, select an album first", "Album",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			} else {
				_selectedAlbum = (AlbumInfo)albumsListView.SelectedItems[0].Tag;
				if (!_sendToMode) {
					_files.Clear ();
				}
				_filesListViewItemsCache.Clear ();
				filesListView.VirtualListSize = _files.Count;
				photosImageList.Images.Clear ();
				tabControl1.SelectedTab = photosTab;
				backButton.Enabled = true;
				nextButton.Text = "Upload";
				filesToAddCountLabel.Text = _files.Count.ToString ();
				albumPhotosCountLabel.Text = SelectedAlbum.Album.NumPhotos + "/"
						       + PicasaController.AlbumFilesCountLimit;
				addFilesButton.Select ();
			}
		}

		private AlbumInfo SelectedAlbum
		{
			get { return _selectedAlbum; }
		}

		private void UploadFiles ()
		{
			// Set lables/button text
			nextButton.Enabled = backButton.Enabled = false;
			addFilesButton.Enabled = removePhotosButton.Enabled = false;
			imageSizeComboBox.Enabled = false;
			progressBar.Step = 1;
			progressBar.Maximum = _files.Count;
			actionLabel.Text = "Preparing upload";

			AlbumInfo album = (AlbumInfo)albumsListView.SelectedItems[0].Tag;

			ThreadPool.QueueUserWorkItem (delegate {
				for (int i = 0; i < _files.Count; i++) {
					this.Invoke ((MethodInvoker)delegate {
						progressBar.PerformStep ();
						actionLabel.Text = String.Format("Uploading {0}/{1}", (i+1), _files.Count);
					});

					int retryCount = DEFAULT_UPLOAD_RETRY_COUNT;
					do {
						try {
							DoUpload (_files[i]);
							retryCount = 0;
						} catch {
							retryCount--;
							if (retryCount == 0) {
								// Retry?
								bool retry = MessageBox.Show ("There is a problem uploading " + Path.GetFileName (_files[i]) +
									Environment.NewLine + "Some possible causes can be: " + Environment.NewLine +
									"\t - PicasaWeb rejected the file." + Environment.NewLine + 
									"\t - Temporary Internet connection issues." + Environment.NewLine + 
									"\t - Temporary PicasaWeb service disruption." + Environment.NewLine +
									"\t - You have exceeded your PicasaWeb Quota." + Environment.NewLine +
									"\t - No read access to the file." + Environment.NewLine +
									Environment.NewLine +
									"Would you like to retry?", "Upload Error", MessageBoxButtons.YesNo,
									MessageBoxIcon.Error) == DialogResult.Yes;
								if (retry) {
									// A very ugly hack because of random exceptions
									_picasa = new PicasaController ();
									_picasa.Login (usernameTextBox.Text, passwordTextBox.Text);
									retryCount = DEFAULT_UPLOAD_RETRY_COUNT;
								}
							}
						}
                                        } while (retryCount != 0);
				}

				_sendToMode = false;

				this.Invoke ((MethodInvoker)delegate {
					albumPhotosCountLabel.Text = (SelectedAlbum.Album.NumPhotos + _files.Count) + "/"
							       + PicasaController.AlbumFilesCountLimit;
				});

				// Set labels/buttons back to normal
				this.Invoke ((MethodInvoker)delegate {
					nextButton.Enabled = backButton.Enabled = true;
					addFilesButton.Enabled = removePhotosButton.Enabled = true;
					imageSizeComboBox.Enabled = true;
					actionLabel.Text = READY_LABEL;
					progressBar.Value = 0;
					// Upload more photos?
					if (MessageBox.Show ("Would you like to upload more photos?", "Upload more?", 
					    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						GoBack ();
					else
						Application.Exit ();
				});
			});
		}

		private bool IsPhotoFile (string fileName)
		{
			return PicasaController.SupportedPhotoFormats.Contains (Path.GetExtension (fileName).ToLowerInvariant ());
		}

		private bool IsVideoFile (string fileName)
		{
			return PicasaController.SupportedVideoFormats.Contains (Path.GetExtension (fileName).ToLowerInvariant ());
		}

		private void DoUpload (string fileName)
		{
			Stream fileStream = null;

			if (IsPhotoFile (fileName))
				fileStream = ScaleImageDown (fileName);
			else
				fileStream = File.Open (fileName, FileMode.Open);

			try {
				string title = Path.GetFileName (fileName);
				string mimeType = PicasaController.GetMimeType (fileName);

				// Handle duplicate files
				if (SelectedAlbum.IsFileDuplicate (fileName)) {
					if (_duplicateActionDialog == null)
						_duplicateActionDialog = new DuplicateActionDialog ();

					if (_duplicateActionDialog.Action == DuplicateAction.ReplaceAll)
						SelectedAlbum.ReplaceFile (fileStream, title, mimeType);
					else if (_duplicateActionDialog.Action == DuplicateAction.UploadAll)
						SelectedAlbum.UploadFile (fileStream, title, mimeType);
					else if (_duplicateActionDialog.Action == DuplicateAction.SkipAll) {
						// do nothing - skip;
					} else {
						this.Invoke ((MethodInvoker)delegate {
							_duplicateActionDialog.ShowDialog (this, title,
											   SelectedAlbum.Album.AlbumTitle);
						});

						if (_duplicateActionDialog.Action == DuplicateAction.Replace ||
						    _duplicateActionDialog.Action == DuplicateAction.ReplaceAll)
							SelectedAlbum.ReplaceFile (fileStream, title, mimeType);
						else if (_duplicateActionDialog.Action == DuplicateAction.Upload ||
							 _duplicateActionDialog.Action == DuplicateAction.UploadAll)
							SelectedAlbum.UploadFile (fileStream, title, mimeType);
						else if (_duplicateActionDialog.Action == DuplicateAction.Skip ||
							 _duplicateActionDialog.Action == DuplicateAction.SkipAll) {
							// do nothing;
						}
					}
				} else {
					SelectedAlbum.UploadFile (fileStream, title, mimeType);
				}
			} finally {
				fileStream.Dispose ();
			}
		}

		private Stream ScaleImageDown (string file)
		{
			Image image = Image.FromFile (file);
			Stream imageFile = File.OpenRead (file);

			ImageSize selectedSize = imageSizeBindingSource.Current as ImageSize;
			if (selectedSize != null && selectedSize != ImageSize.Empty &&
			    (image.Height > selectedSize.Height || image.Width > selectedSize.Width)) {
				Stream newImage = ImageScaler.Scale (imageFile, selectedSize.Width, 
								     selectedSize.Height, true);
				imageFile.Dispose ();
				image.Dispose ();
				
				return newImage;
			}

			image.Dispose ();
			return imageFile;
		}

		private void LoadAlbums ()
		{
			_selectedAlbum = null;
			albumsListView.Clear ();
			albumCoversImageList.Images.Clear ();
			nextButton.Enabled = newAlbumButton.Enabled = false;
			actionLabel.Text = "Loading albums";
			ThreadPool.QueueUserWorkItem (delegate {
				foreach (AlbumInfo album in _picasa.Albums) {
					this.Invoke ((MethodInvoker)delegate {
						albumCoversImageList.Images.Add (album.Album.Id, album.AlbumCover);
						ListViewItem item = new ListViewItem (album.Album.AlbumTitle);
						item.Tag = album;
						item.ImageKey = album.Album.Id;
					});
				}
				this.Invoke ((MethodInvoker)delegate {
					nextButton.Enabled = newAlbumButton.Enabled = true;
					actionLabel.Text = READY_LABEL;
				});
			});
		}

		private void Login ()
		{
			this.Invoke ((MethodInvoker)delegate {
				nextButton.Enabled = false;
				actionLabel.Text = "Logging in";
			});

			if (!rememberCheckBox.Checked)
				PurgeUserCredentials ();


			ThreadPool.QueueUserWorkItem (delegate {
				if (!_picasa.Login (usernameTextBox.Text, passwordTextBox.Text)) {
					this.Invoke ((MethodInvoker)delegate {
						nextButton.Enabled = true;
						actionLabel.Text = READY_LABEL;
						MessageBox.Show ("Invalid username/password or no Internet connection.", "Login Failed",
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					});
				} else {
					if (rememberCheckBox.Checked)
						StoreUserCredentials ();
					this.Invoke ((MethodInvoker)delegate {
						nextButton.Enabled = true;
						actionLabel.Text = READY_LABEL;
						tabControl1.SelectedTab = albumsTab;
						LoadAlbums ();
					});
				}
			});
		}

		private void addFilesButton_Click (object sender, EventArgs e)
		{
			if (_files.Count == SelectedAlbum.Album.NumPhotosRemaining) {
				MessageBox.Show ("You have exceeded the maximum number of photos you can upload to this album.",
					"Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (openFileDialog.ShowDialog () == DialogResult.OK) {
				if (_files.Count + openFileDialog.FileNames.Length > SelectedAlbum.Album.NumPhotosRemaining) {
					MessageBox.Show (String.Format ("By adding the selected {0} files you are going to exceed the maximum number of files per album by {1}{2}Please, select less files", 
                                                                        openFileDialog.FileNames.Length, 
                                                                        (SelectedAlbum.Album.NumPhotosRemaining - (_files.Count + openFileDialog.FileNames.Length)), 
                                                                        Environment.NewLine),
						"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				AddFiles (openFileDialog.FileNames);
			}
		}

		private void AddFiles (string[] files)
		{
			IEnumerable<string> supportedExtensions = PicasaController.SupportedPhotoFormats.Union (PicasaController.SupportedVideoFormats);
			var supportedFiles = files.Where (filePath => File.Exists (filePath) &&
							  supportedExtensions.Contains (Path.GetExtension (filePath).ToLowerInvariant ()));

			bool filesExcluded = false;

			foreach (string fileName in files) {
				if (_files.Contains (fileName))
					continue;

				if (IsVideoFile (fileName)) {
					if (new FileInfo (fileName).Length / Math.Pow (1024,2) >= (float)PicasaController.VideoFileSizeLimit) {
						filesExcluded = true;
						continue;
					}
				} else if (IsPhotoFile (fileName)) {
					if (new FileInfo (fileName).Length / Math.Pow (1024, 2) >= (float)PicasaController.PhotoFileSizeLimit) {
						filesExcluded = true;
						continue;
					}
				} 

				_files.Add (fileName);
			}

			if (filesExcluded) {
				MessageBox.Show (String.Format ("Some files weren't added because they exceed either the maximum video file size limit of {0}MB or the maximum photo file size limit  of {1}MB",
								PicasaController.VideoFileSizeLimit,
								PicasaController.PhotoFileSizeLimit),
						"Large Files Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			filesListView.VirtualListSize = _files.Count;
			filesToAddCountLabel.Text = _files.Count.ToString ();
		}

		private void removeFilesButton_Click(object sender, EventArgs e)
		{
			for (int i = filesListView.SelectedIndices.Count - 1; i >= 0; i--) {
				_files.RemoveAt (filesListView.SelectedIndices[i]);
				filesListView.VirtualListSize = filesListView.VirtualListSize - 1;
			}
		}

		private void filesListView_RetrieveVirtualItem (object sender, RetrieveVirtualItemEventArgs e)
		{
			string fileName = _files[e.ItemIndex];

			if (_filesListViewItemsCache.ContainsKey (fileName)) {
				e.Item = _filesListViewItemsCache[fileName];
			}  else {
				string key = fileName;
				Image thumbnail = null;

				if (IsVideoFile (fileName)) {
					thumbnail = Resources.VideoIcon;
				} else if (IsPhotoFile (fileName)) {
					Image originalImage = Image.FromFile (fileName);
					thumbnail = ImageScaler.ScaleToThumbnail (originalImage, photosImageList.ImageSize.Width,
										     photosImageList.ImageSize.Height, true);
					originalImage.Dispose ();
				} else {
					throw new NotSupportedException ("Unsupported file type: " + fileName);
				}

				photosImageList.Images.Add (fileName, thumbnail);
				ListViewItem item = new ListViewItem (Path.GetFileName (fileName),
									photosImageList.Images.IndexOfKey (fileName));
				e.Item = item;
				_filesListViewItemsCache.Add (key, item);
			}
		}

		private void backButton_Click (object sender, EventArgs e)
		{
			GoBack ();
		}

		private void GoBack ()
		{		
			if (tabControl1.SelectedTab == photosTab) {
				albumsListView.SelectedIndices.Clear ();
				tabControl1.SelectedTab = albumsTab;
				backButton.Enabled = false;
				nextButton.Text = "Next";
			}
		}

		private void newAlbumButton_Click (object sender, EventArgs e)
		{
			if (_picasa.Albums.Length >= PicasaController.AlbumsCountLimit) {
				MessageBox.Show (String.Format ("Unfortunately you have reached limit of {0} albums allowed in PicasaWeb ", PicasaController.AlbumsCountLimit),
						 "Albums Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			using (NewAlbumDialog dialog = new NewAlbumDialog ()) {
				if (dialog.ShowDialog (this) == DialogResult.OK) {
					nextButton.Enabled = newAlbumButton.Enabled = false;
					actionLabel.Text = "Creating album";
					ThreadPool.QueueUserWorkItem (delegate {
						_picasa.CreateAlbum (dialog.AlbumTitle, dialog.AlbumDescription, dialog.AlbumLocation, dialog.AlbumDate, dialog.AlbumPublic);
						this.Invoke ((MethodInvoker)delegate {
							nextButton.Enabled = newAlbumButton.Enabled = true;
							actionLabel.Text = READY_LABEL;
							LoadAlbums ();
						});
					});
				}
			}
		}

		private void passwordTextBox_KeyUp (object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return) {
				Login ();
				e.Handled = true;
			}
			e.Handled = false;
		}

		private void aboutButton_Click (object sender, EventArgs e)
		{
			new AboutBox ().ShowDialog ();
		}

		private void filesListView_DragDrop (object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent (DataFormats.FileDrop)) {
				string[] files = (string[]) e.Data.GetData (DataFormats.FileDrop);
				AddFiles (files);
			}
		}

		private void filesListView_DragEnter (object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent (DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
		}
	}
}
