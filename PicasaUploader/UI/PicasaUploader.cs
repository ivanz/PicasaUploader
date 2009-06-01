﻿//
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
		private List<string> _photos;
		private Dictionary<string, ListViewItem> _photosCache;
		private AlbumInfo _selectedAlbum = null;
		private bool _sendToMode = true;
		private DuplicateActionDialog _duplicateActionDialog = null;

		public PicasaUploaderForm (string[] sendToFiles)
		{
			InitializeComponent ();

			LoadImageSizes ();

			_picasa = new PicasaController ();
			_photosCache = new Dictionary<string, ListViewItem> ();
			_photos = new List<string> ();
			usernameTextBox.Select ();
			LoadUserCredentials ();
			openFileDialog.InitialDirectory = Environment.GetFolderPath (Environment.SpecialFolder.MyPictures);

			// If sendToFiles has files of format which we support then we are in Send To mode.
			if (sendToFiles != null && sendToFiles.Length > 0) {
				_photos.AddRange (sendToFiles.Where (filePath => File.Exists (filePath) && 
										PicasaController.SupportedPhotoFormats.Contains (Path.GetExtension (filePath))));
				if (_photos.Count > 0)
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
				UploadPhotos ();
		}

		private void PreparePhotosTab ()
		{
			if (albumsListView.SelectedItems.Count == 0) {
				MessageBox.Show ("Please, select an album first", "Album",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			} else {
				_selectedAlbum = (AlbumInfo)albumsListView.SelectedItems[0].Tag;
				if (!_sendToMode) {
					_photos.Clear ();
				}
				_photosCache.Clear ();
				photosListView.VirtualListSize = _photos.Count;
				photosImageList.Images.Clear ();
				tabControl1.SelectedTab = photosTab;
				backButton.Visible = true;
				nextButton.Text = "Upload";
				photosToAddCountLabel.Text = _photos.Count.ToString ();
				albumPhotosCountLabel.Text = SelectedAlbum.Album.NumPhotos + "/"
						       + SelectedAlbum.MaxPhotosCount;
				addPhotosButton.Select ();
			}
		}

		private AlbumInfo SelectedAlbum
		{
			get { return _selectedAlbum; }
		}

		private void UploadPhotos ()
		{
			// Set lables/button textx
			nextButton.Enabled = backButton.Enabled = false;
			addPhotosButton.Enabled = removePhotosButton.Enabled = false;
			imageSizeComboBox.Enabled = false;
			progressBar.Step = 1;
			progressBar.Maximum = _photos.Count;
			actionLabel.Text = "Uploading 1/" + _photos.Count;

			AlbumInfo album = (AlbumInfo)albumsListView.SelectedItems[0].Tag;

			ThreadPool.QueueUserWorkItem (delegate {
				for (int i = 0; i < _photos.Count; i++) {
					this.Invoke ((MethodInvoker)delegate {
						progressBar.PerformStep ();
						actionLabel.Text = "Uploading " + (i+1) + "/" + _photos.Count;
					});

					int retryCount = DEFAULT_UPLOAD_RETRY_COUNT;
					do {
						try {
							DoUpload (_photos[i]);
							retryCount = 0;
						} catch {
							retryCount--;
							if (retryCount == 0) {
								// Retry?
								bool retry = MessageBox.Show ("There is a problem uploading: " + Path.GetFileName (_photos[i]) +
									Environment.NewLine + "Possible reasons are: " + Environment.NewLine +
									"\t - No available Internet connection or temporary Picasas service interruption." + Environment.NewLine +
									"\t - You have exceeded your PicasaWeb Quota." + Environment.NewLine +
									"\t - You have exceeded the photo count per album." + Environment.NewLine +
									"\t - No read access to the photo file." + Environment.NewLine +
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
					albumPhotosCountLabel.Text = (SelectedAlbum.Album.NumPhotos + _photos.Count) + "/"
							       + SelectedAlbum.MaxPhotosCount;
				});

				// Set labels/buttons back to normal
				this.Invoke ((MethodInvoker)delegate {
					nextButton.Enabled = backButton.Enabled = true;
					addPhotosButton.Enabled = removePhotosButton.Enabled = true;
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

		private void DoUpload (string file)
		{
			Stream image = ScaleImageDown (file);
			string title = Path.GetFileName (file);
			string mimeType = PicasaController.GetMimeType (file);

			// Handle duplicate photos
			if (SelectedAlbum.IsPhotoDupliate (file)) {
				if (_duplicateActionDialog == null)
					_duplicateActionDialog = new DuplicateActionDialog ();

				if (_duplicateActionDialog.Action == DuplicateAction.ReplaceAll)
					SelectedAlbum.ReplacePhoto (image, title, mimeType);
				else if (_duplicateActionDialog.Action == DuplicateAction.UploadAll)
					SelectedAlbum.UploadPhoto (image, title, mimeType);
				else if (_duplicateActionDialog.Action == DuplicateAction.SkipAll) {
					// do nothing;
				} else {
					this.Invoke ((MethodInvoker)delegate {
						_duplicateActionDialog.ShowDialog (this, title,
										   SelectedAlbum.Album.AlbumTitle);
					});

					if (_duplicateActionDialog.Action == DuplicateAction.Replace ||
					    _duplicateActionDialog.Action == DuplicateAction.ReplaceAll)
						SelectedAlbum.ReplacePhoto (image, title, mimeType);
					else if (_duplicateActionDialog.Action == DuplicateAction.Upload ||
						 _duplicateActionDialog.Action == DuplicateAction.UploadAll)
						SelectedAlbum.UploadPhoto (image, title, mimeType);
					else if (_duplicateActionDialog.Action == DuplicateAction.Skip ||
						 _duplicateActionDialog.Action == DuplicateAction.SkipAll) {
						// do nothing;
					}
				}
			} else {
				SelectedAlbum.UploadPhoto (image, title, mimeType);
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
					});
					ListViewItem item = new ListViewItem (album.Album.AlbumTitle);
					item.Tag = album;
					item.ImageKey = album.Album.Id;
					this.Invoke ((MethodInvoker)delegate {
						albumsListView.Items.Add (item);
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

		private void addPhotosButton_Click (object sender, EventArgs e)
		{
			if (_photos.Count == SelectedAlbum.Album.NumPhotosRemaining) {
				MessageBox.Show ("You have exceeded the maxmimum number of photos you can upload to this album.",
					"Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (openFileDialog.ShowDialog () == DialogResult.OK) {
				if (_photos.Count + openFileDialog.FileNames.Length >
					SelectedAlbum.Album.NumPhotosRemaining) {
					MessageBox.Show ("By adding the selected " + openFileDialog.FileNames.Length + " photos " +
						"you are going to exceeding the maximum number of photos per album by " + 
						(SelectedAlbum.Album.NumPhotosRemaining - (_photos.Count + openFileDialog.FileNames.Length)) +
						Environment.NewLine + "Please, select less photos", 
						"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				foreach (string fileName in openFileDialog.FileNames) {
					if (!_photos.Contains (fileName))
						_photos.Add (fileName);
				}

				photosListView.VirtualListSize = _photos.Count;
				photosToAddCountLabel.Text = _photos.Count.ToString ();
			}
		}

		private void removePhotosButton_Click(object sender, EventArgs e)
		{
			for (int i = photosListView.SelectedIndices.Count - 1; i >= 0; i--) {
				_photos.RemoveAt (photosListView.SelectedIndices[i]);
				photosListView.VirtualListSize = photosListView.VirtualListSize - 1;
			}
		}

		private void photosListView_RetrieveVirtualItem (object sender, RetrieveVirtualItemEventArgs e)
		{
			string fileName = _photos[e.ItemIndex];
			if (_photosCache.ContainsKey (fileName))
				e.Item = _photosCache[fileName];
			else {
				string key = fileName;

				Image originalImage = Image.FromFile (fileName);
				Image scaled = ImageScaler.ScaleToThumbnail (originalImage, photosImageList.ImageSize.Width, 
									     photosImageList.ImageSize.Height, true);
				photosImageList.Images.Add (fileName, scaled);
				originalImage.Dispose ();

				ListViewItem item = new ListViewItem (Path.GetFileName (fileName), 
									photosImageList.Images.IndexOfKey (fileName));
				item.Tag = key;
				e.Item = item;
				_photosCache.Add (key, item);
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
				backButton.Visible = false;
				nextButton.Text = "Next";
			}
		}

		private void newAlbumButton_Click (object sender, EventArgs e)
		{
			NewAlbumDialog dialog = new NewAlbumDialog ();
			if (dialog.ShowDialog (this) == DialogResult.OK) {
				nextButton.Enabled = newAlbumButton.Enabled = false;
				actionLabel.Text = "Creating album";

				ThreadPool.QueueUserWorkItem (delegate {
					_picasa.CreateAlbum (dialog.AlbumTitle, dialog.AlbumDescription, 
							     dialog.AlbumLocation, dialog.AlbumDate, 
							     dialog.AlbumPublic);
					this.Invoke ((MethodInvoker)delegate {
						nextButton.Enabled = newAlbumButton.Enabled = true;
						actionLabel.Text = READY_LABEL;
						LoadAlbums ();
					});
				});
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
	}
}