namespace PicasaUploader
{
	partial class PicasaUploaderForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container ();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (PicasaUploaderForm));
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog ();
			this.tabControl1 = new System.Windows.Forms.TabControl ();
			this.loginTab = new System.Windows.Forms.TabPage ();
			this.rememberCheckBox = new System.Windows.Forms.CheckBox ();
			this.label6 = new System.Windows.Forms.Label ();
			this.label5 = new System.Windows.Forms.Label ();
			this.passwordTextBox = new System.Windows.Forms.TextBox ();
			this.usernameTextBox = new System.Windows.Forms.TextBox ();
			this.label3 = new System.Windows.Forms.Label ();
			this.albumsTab = new System.Windows.Forms.TabPage ();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel ();
			this.albumsListView = new System.Windows.Forms.ListView ();
			this.albumCoversImageList = new System.Windows.Forms.ImageList (this.components);
			this.panel3 = new System.Windows.Forms.Panel ();
			this.newAlbumButton = new System.Windows.Forms.Button ();
			this.label9 = new System.Windows.Forms.Label ();
			this.photosTab = new System.Windows.Forms.TabPage ();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel ();
			this.photosListView = new System.Windows.Forms.ListView ();
			this.photosImageList = new System.Windows.Forms.ImageList (this.components);
			this.label4 = new System.Windows.Forms.Label ();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer ();
			this.panel1 = new System.Windows.Forms.Panel ();
			this.photosToAddCountLabel = new System.Windows.Forms.Label ();
			this.label8 = new System.Windows.Forms.Label ();
			this.albumPhotosCountLabel = new System.Windows.Forms.Label ();
			this.photosLeftLabel = new System.Windows.Forms.Label ();
			this.removePhotosButton = new System.Windows.Forms.Button ();
			this.addPhotosButton = new System.Windows.Forms.Button ();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel ();
			this.imageSizeComboBox = new System.Windows.Forms.ComboBox ();
			this.imageSizeBindingSource = new System.Windows.Forms.BindingSource (this.components);
			this.label2 = new System.Windows.Forms.Label ();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel ();
			this.listView1 = new System.Windows.Forms.ListView ();
			this.panel2 = new System.Windows.Forms.Panel ();
			this.button1 = new System.Windows.Forms.Button ();
			this.button2 = new System.Windows.Forms.Button ();
			this.label1 = new System.Windows.Forms.Label ();
			this.progressBar2 = new System.Windows.Forms.ProgressBar ();
			this.label7 = new System.Windows.Forms.Label ();
			this.actionLabel = new System.Windows.Forms.Label ();
			this.progressBar = new System.Windows.Forms.ProgressBar ();
			this.aboutButton = new System.Windows.Forms.Button ();
			this.nextButton = new System.Windows.Forms.Button ();
			this.backButton = new System.Windows.Forms.Button ();
			this.tabControl1.SuspendLayout ();
			this.loginTab.SuspendLayout ();
			this.albumsTab.SuspendLayout ();
			this.tableLayoutPanel3.SuspendLayout ();
			this.panel3.SuspendLayout ();
			this.photosTab.SuspendLayout ();
			this.tableLayoutPanel1.SuspendLayout ();
			this.splitContainer1.Panel1.SuspendLayout ();
			this.splitContainer1.Panel2.SuspendLayout ();
			this.splitContainer1.SuspendLayout ();
			this.panel1.SuspendLayout ();
			this.tableLayoutPanel4.SuspendLayout ();
			((System.ComponentModel.ISupportInitialize)(this.imageSizeBindingSource)).BeginInit ();
			this.tableLayoutPanel2.SuspendLayout ();
			this.panel2.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Pictures|*.jpg;*.jpeg\'*.png;*.gif;*.bmp";
			this.openFileDialog.Multiselect = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
			this.tabControl1.Controls.Add (this.loginTab);
			this.tabControl1.Controls.Add (this.albumsTab);
			this.tabControl1.Controls.Add (this.photosTab);
			this.tabControl1.ItemSize = new System.Drawing.Size (0, 1);
			this.tabControl1.Location = new System.Drawing.Point (0, 0);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size (517, 346);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 9;
			// 
			// loginTab
			// 
			this.loginTab.Controls.Add (this.rememberCheckBox);
			this.loginTab.Controls.Add (this.label6);
			this.loginTab.Controls.Add (this.label5);
			this.loginTab.Controls.Add (this.passwordTextBox);
			this.loginTab.Controls.Add (this.usernameTextBox);
			this.loginTab.Controls.Add (this.label3);
			this.loginTab.Location = new System.Drawing.Point (4, 5);
			this.loginTab.Name = "loginTab";
			this.loginTab.Padding = new System.Windows.Forms.Padding (3);
			this.loginTab.Size = new System.Drawing.Size (509, 337);
			this.loginTab.TabIndex = 0;
			this.loginTab.Text = "Login";
			this.loginTab.UseVisualStyleBackColor = true;
			// 
			// rememberCheckBox
			// 
			this.rememberCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rememberCheckBox.AutoSize = true;
			this.rememberCheckBox.Location = new System.Drawing.Point (229, 180);
			this.rememberCheckBox.Name = "rememberCheckBox";
			this.rememberCheckBox.Size = new System.Drawing.Size (156, 17);
			this.rememberCheckBox.TabIndex = 3;
			this.rememberCheckBox.Text = "Remember login information";
			this.rememberCheckBox.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point (126, 157);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size (56, 13);
			this.label6.TabIndex = 19;
			this.label6.Text = "Password:";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point (124, 131);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size (58, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "Username:";
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.passwordTextBox.Location = new System.Drawing.Point (188, 154);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size (197, 20);
			this.passwordTextBox.TabIndex = 2;
			this.passwordTextBox.UseSystemPasswordChar = true;
			this.passwordTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler (this.passwordTextBox_KeyUp);
			// 
			// usernameTextBox
			// 
			this.usernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.usernameTextBox.Location = new System.Drawing.Point (188, 128);
			this.usernameTextBox.Name = "usernameTextBox";
			this.usernameTextBox.Size = new System.Drawing.Size (197, 20);
			this.usernameTextBox.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point (6, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size (98, 16);
			this.label3.TabIndex = 14;
			this.label3.Text = "Step 1: Login";
			// 
			// albumsTab
			// 
			this.albumsTab.Controls.Add (this.tableLayoutPanel3);
			this.albumsTab.Location = new System.Drawing.Point (4, 5);
			this.albumsTab.Name = "albumsTab";
			this.albumsTab.Padding = new System.Windows.Forms.Padding (3);
			this.albumsTab.Size = new System.Drawing.Size (509, 337);
			this.albumsTab.TabIndex = 1;
			this.albumsTab.Text = "Select Album";
			this.albumsTab.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle ());
			this.tableLayoutPanel3.Controls.Add (this.albumsListView, 0, 1);
			this.tableLayoutPanel3.Controls.Add (this.panel3, 0, 2);
			this.tableLayoutPanel3.Controls.Add (this.label9, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point (3, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 3;
			this.tableLayoutPanel3.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Absolute, 18F));
			this.tableLayoutPanel3.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Absolute, 34F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size (503, 331);
			this.tableLayoutPanel3.TabIndex = 20;
			// 
			// albumsListView
			// 
			this.albumsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.albumsListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.albumsListView.LargeImageList = this.albumCoversImageList;
			this.albumsListView.Location = new System.Drawing.Point (3, 21);
			this.albumsListView.Name = "albumsListView";
			this.albumsListView.Size = new System.Drawing.Size (498, 273);
			this.albumsListView.TabIndex = 18;
			this.albumsListView.UseCompatibleStateImageBehavior = false;
			// 
			// albumCoversImageList
			// 
			this.albumCoversImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.albumCoversImageList.ImageSize = new System.Drawing.Size (64, 64);
			this.albumCoversImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel3
			// 
			this.panel3.Controls.Add (this.newAlbumButton);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point (3, 300);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size (498, 28);
			this.panel3.TabIndex = 17;
			// 
			// newAlbumButton
			// 
			this.newAlbumButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.newAlbumButton.Image = ((System.Drawing.Image)(resources.GetObject ("newAlbumButton.Image")));
			this.newAlbumButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.newAlbumButton.Location = new System.Drawing.Point (409, 2);
			this.newAlbumButton.Name = "newAlbumButton";
			this.newAlbumButton.Size = new System.Drawing.Size (87, 23);
			this.newAlbumButton.TabIndex = 19;
			this.newAlbumButton.Text = "New Album";
			this.newAlbumButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.newAlbumButton.UseVisualStyleBackColor = true;
			this.newAlbumButton.Click += new System.EventHandler (this.newAlbumButton_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point (3, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size (172, 16);
			this.label9.TabIndex = 13;
			this.label9.Text = "Step 2: Select an Album";
			// 
			// photosTab
			// 
			this.photosTab.Controls.Add (this.tableLayoutPanel1);
			this.photosTab.Location = new System.Drawing.Point (4, 5);
			this.photosTab.Name = "photosTab";
			this.photosTab.Padding = new System.Windows.Forms.Padding (3);
			this.photosTab.Size = new System.Drawing.Size (509, 337);
			this.photosTab.TabIndex = 2;
			this.photosTab.Text = "Add Photos";
			this.photosTab.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle ());
			this.tableLayoutPanel1.Controls.Add (this.photosListView, 0, 1);
			this.tableLayoutPanel1.Controls.Add (this.label4, 0, 0);
			this.tableLayoutPanel1.Controls.Add (this.splitContainer1, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point (3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Absolute, 18F));
			this.tableLayoutPanel1.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Absolute, 64F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size (503, 331);
			this.tableLayoutPanel1.TabIndex = 19;
			// 
			// photosListView
			// 
			this.photosListView.AllowDrop = true;
			this.photosListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.photosListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.photosListView.LargeImageList = this.photosImageList;
			this.photosListView.Location = new System.Drawing.Point (3, 21);
			this.photosListView.Name = "photosListView";
			this.photosListView.Size = new System.Drawing.Size (498, 243);
			this.photosListView.TabIndex = 18;
			this.photosListView.UseCompatibleStateImageBehavior = false;
			this.photosListView.VirtualMode = true;
			this.photosListView.DragDrop += new System.Windows.Forms.DragEventHandler (this.photosListView_DragDrop);
			this.photosListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler (this.photosListView_RetrieveVirtualItem);
			this.photosListView.DragEnter += new System.Windows.Forms.DragEventHandler (this.photosListView_DragEnter);
			// 
			// photosImageList
			// 
			this.photosImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.photosImageList.ImageSize = new System.Drawing.Size (64, 64);
			this.photosImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point (3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size (181, 16);
			this.label4.TabIndex = 13;
			this.label4.Text = "Step 3: Select the Photos";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point (3, 270);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add (this.panel1);
			this.splitContainer1.Panel1MinSize = 29;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add (this.tableLayoutPanel4);
			this.splitContainer1.Size = new System.Drawing.Size (498, 58);
			this.splitContainer1.SplitterDistance = 29;
			this.splitContainer1.TabIndex = 19;
			// 
			// panel1
			// 
			this.panel1.Controls.Add (this.photosToAddCountLabel);
			this.panel1.Controls.Add (this.label8);
			this.panel1.Controls.Add (this.albumPhotosCountLabel);
			this.panel1.Controls.Add (this.photosLeftLabel);
			this.panel1.Controls.Add (this.removePhotosButton);
			this.panel1.Controls.Add (this.addPhotosButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point (0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size (498, 29);
			this.panel1.TabIndex = 18;
			// 
			// photosToAddCountLabel
			// 
			this.photosToAddCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.photosToAddCountLabel.AutoSize = true;
			this.photosToAddCountLabel.Location = new System.Drawing.Point (377, 7);
			this.photosToAddCountLabel.Name = "photosToAddCountLabel";
			this.photosToAddCountLabel.Size = new System.Drawing.Size (13, 13);
			this.photosToAddCountLabel.TabIndex = 24;
			this.photosToAddCountLabel.Text = "0";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point (294, 7);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size (77, 13);
			this.label8.TabIndex = 23;
			this.label8.Text = "Photos to Add:";
			// 
			// albumPhotosCountLabel
			// 
			this.albumPhotosCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)));
			this.albumPhotosCountLabel.AutoSize = true;
			this.albumPhotosCountLabel.Location = new System.Drawing.Point (237, 7);
			this.albumPhotosCountLabel.Name = "albumPhotosCountLabel";
			this.albumPhotosCountLabel.Size = new System.Drawing.Size (36, 13);
			this.albumPhotosCountLabel.TabIndex = 22;
			this.albumPhotosCountLabel.Text = "0/500";
			// 
			// photosLeftLabel
			// 
			this.photosLeftLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.photosLeftLabel.AutoSize = true;
			this.photosLeftLabel.Location = new System.Drawing.Point (134, 7);
			this.photosLeftLabel.Name = "photosLeftLabel";
			this.photosLeftLabel.Size = new System.Drawing.Size (106, 13);
			this.photosLeftLabel.TabIndex = 21;
			this.photosLeftLabel.Text = "Album Photos Count:";
			// 
			// removePhotosButton
			// 
			this.removePhotosButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.removePhotosButton.Image = ((System.Drawing.Image)(resources.GetObject ("removePhotosButton.Image")));
			this.removePhotosButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.removePhotosButton.Location = new System.Drawing.Point (3, 3);
			this.removePhotosButton.Name = "removePhotosButton";
			this.removePhotosButton.Size = new System.Drawing.Size (117, 23);
			this.removePhotosButton.TabIndex = 20;
			this.removePhotosButton.Text = "Remove Selected";
			this.removePhotosButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.removePhotosButton.UseVisualStyleBackColor = true;
			this.removePhotosButton.Click += new System.EventHandler (this.removePhotosButton_Click);
			// 
			// addPhotosButton
			// 
			this.addPhotosButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.addPhotosButton.Image = ((System.Drawing.Image)(resources.GetObject ("addPhotosButton.Image")));
			this.addPhotosButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.addPhotosButton.Location = new System.Drawing.Point (411, 3);
			this.addPhotosButton.Name = "addPhotosButton";
			this.addPhotosButton.Size = new System.Drawing.Size (84, 23);
			this.addPhotosButton.TabIndex = 19;
			this.addPhotosButton.Text = "Add Photos";
			this.addPhotosButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.addPhotosButton.UseVisualStyleBackColor = true;
			this.addPhotosButton.Click += new System.EventHandler (this.addPhotosButton_Click);
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle (System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle (System.Windows.Forms.SizeType.Absolute, 200F));
			this.tableLayoutPanel4.Controls.Add (this.imageSizeComboBox, 1, 0);
			this.tableLayoutPanel4.Controls.Add (this.label2, 0, 0);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point (0, 0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size (498, 25);
			this.tableLayoutPanel4.TabIndex = 2;
			// 
			// imageSizeComboBox
			// 
			this.imageSizeComboBox.DataSource = this.imageSizeBindingSource;
			this.imageSizeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imageSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.imageSizeComboBox.FormattingEnabled = true;
			this.imageSizeComboBox.Location = new System.Drawing.Point (301, 3);
			this.imageSizeComboBox.Name = "imageSizeComboBox";
			this.imageSizeComboBox.Size = new System.Drawing.Size (194, 21);
			this.imageSizeComboBox.TabIndex = 0;
			// 
			// imageSizeBindingSource
			// 
			this.imageSizeBindingSource.DataSource = typeof (PicasaUploader.ImageSize);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point (121, 7);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding (0, 0, 0, 5);
			this.label2.Size = new System.Drawing.Size (174, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Resize down to (aspect preserved):";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add (new System.Windows.Forms.ColumnStyle ());
			this.tableLayoutPanel2.Controls.Add (this.listView1, 0, 1);
			this.tableLayoutPanel2.Controls.Add (this.panel2, 0, 2);
			this.tableLayoutPanel2.Controls.Add (this.label7, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point (3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Absolute, 18F));
			this.tableLayoutPanel2.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add (new System.Windows.Forms.RowStyle (System.Windows.Forms.SizeType.Absolute, 34F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size (504, 242);
			this.tableLayoutPanel2.TabIndex = 19;
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Location = new System.Drawing.Point (3, 21);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size (498, 184);
			this.listView1.TabIndex = 18;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add (this.button1);
			this.panel2.Controls.Add (this.button2);
			this.panel2.Controls.Add (this.label1);
			this.panel2.Controls.Add (this.progressBar2);
			this.panel2.Location = new System.Drawing.Point (3, 211);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size (498, 28);
			this.panel2.TabIndex = 17;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point (3, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size (105, 23);
			this.button1.TabIndex = 20;
			this.button1.Text = "Remove Selected";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point (421, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size (75, 23);
			this.button2.TabIndex = 19;
			this.button2.Text = "Add Photos";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point (130, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size (51, 13);
			this.label1.TabIndex = 22;
			this.label1.Text = "Progress:";
			// 
			// progressBar2
			// 
			this.progressBar2.Location = new System.Drawing.Point (187, 2);
			this.progressBar2.Name = "progressBar2";
			this.progressBar2.Size = new System.Drawing.Size (208, 23);
			this.progressBar2.TabIndex = 21;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point (3, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size (181, 16);
			this.label7.TabIndex = 13;
			this.label7.Text = "Step 3: Select the Photos";
			// 
			// actionLabel
			// 
			this.actionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.actionLabel.AutoSize = true;
			this.actionLabel.Location = new System.Drawing.Point (39, 359);
			this.actionLabel.Name = "actionLabel";
			this.actionLabel.Size = new System.Drawing.Size (38, 13);
			this.actionLabel.TabIndex = 24;
			this.actionLabel.Text = "Ready";
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.progressBar.Location = new System.Drawing.Point (147, 354);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size (177, 23);
			this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar.TabIndex = 23;
			// 
			// aboutButton
			// 
			this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.aboutButton.Image = ((System.Drawing.Image)(resources.GetObject ("aboutButton.Image")));
			this.aboutButton.Location = new System.Drawing.Point (12, 354);
			this.aboutButton.Name = "aboutButton";
			this.aboutButton.Size = new System.Drawing.Size (21, 23);
			this.aboutButton.TabIndex = 25;
			this.aboutButton.UseVisualStyleBackColor = true;
			this.aboutButton.Click += new System.EventHandler (this.aboutButton_Click);
			// 
			// nextButton
			// 
			this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.nextButton.Image = ((System.Drawing.Image)(resources.GetObject ("nextButton.Image")));
			this.nextButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.nextButton.Location = new System.Drawing.Point (421, 354);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size (84, 23);
			this.nextButton.TabIndex = 4;
			this.nextButton.Text = "Next";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler (this.nextButton_Click);
			// 
			// backButton
			// 
			this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.backButton.Image = ((System.Drawing.Image)(resources.GetObject ("backButton.Image")));
			this.backButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.backButton.Location = new System.Drawing.Point (330, 354);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size (84, 23);
			this.backButton.TabIndex = 5;
			this.backButton.Text = "Back";
			this.backButton.UseVisualStyleBackColor = true;
			this.backButton.Visible = false;
			this.backButton.Click += new System.EventHandler (this.backButton_Click);
			// 
			// PicasaUploaderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (517, 386);
			this.Controls.Add (this.aboutButton);
			this.Controls.Add (this.actionLabel);
			this.Controls.Add (this.progressBar);
			this.Controls.Add (this.nextButton);
			this.Controls.Add (this.backButton);
			this.Controls.Add (this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject ("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size (525, 400);
			this.Name = "PicasaUploaderForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PicasaUploader";
			this.tabControl1.ResumeLayout (false);
			this.loginTab.ResumeLayout (false);
			this.loginTab.PerformLayout ();
			this.albumsTab.ResumeLayout (false);
			this.albumsTab.PerformLayout ();
			this.tableLayoutPanel3.ResumeLayout (false);
			this.tableLayoutPanel3.PerformLayout ();
			this.panel3.ResumeLayout (false);
			this.photosTab.ResumeLayout (false);
			this.photosTab.PerformLayout ();
			this.tableLayoutPanel1.ResumeLayout (false);
			this.tableLayoutPanel1.PerformLayout ();
			this.splitContainer1.Panel1.ResumeLayout (false);
			this.splitContainer1.Panel2.ResumeLayout (false);
			this.splitContainer1.ResumeLayout (false);
			this.panel1.ResumeLayout (false);
			this.panel1.PerformLayout ();
			this.tableLayoutPanel4.ResumeLayout (false);
			this.tableLayoutPanel4.PerformLayout ();
			((System.ComponentModel.ISupportInitialize)(this.imageSizeBindingSource)).EndInit ();
			this.tableLayoutPanel2.ResumeLayout (false);
			this.tableLayoutPanel2.PerformLayout ();
			this.panel2.ResumeLayout (false);
			this.panel2.PerformLayout ();
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage loginTab;
		private System.Windows.Forms.TabPage albumsTab;
		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabPage photosTab;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ImageList albumCoversImageList;
		private System.Windows.Forms.ImageList photosImageList;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.TextBox usernameTextBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ListView photosListView;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.ListView albumsListView;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button newAlbumButton;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar progressBar2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label actionLabel;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Button aboutButton;
		private System.Windows.Forms.CheckBox rememberCheckBox;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label photosToAddCountLabel;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label albumPhotosCountLabel;
		private System.Windows.Forms.Label photosLeftLabel;
		private System.Windows.Forms.Button removePhotosButton;
		private System.Windows.Forms.Button addPhotosButton;
		private System.Windows.Forms.ComboBox imageSizeComboBox;
		private System.Windows.Forms.BindingSource imageSizeBindingSource;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Label label2;
	}
}

