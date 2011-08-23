namespace PicasaUploader.UI.WizardPages
{
    partial class PhotosPage
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
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotosPage));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.filesListView = new System.Windows.Forms.ListView();
            this.photosImageList = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.filesToAddCountLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.albumPhotosCountLabel = new System.Windows.Forms.Label();
            this.photosLeftLabel = new System.Windows.Forms.Label();
            this.removePhotosButton = new System.Windows.Forms.Button();
            this.addFilesButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.imageSizeComboBox = new System.Windows.Forms.ComboBox();
            this.imageSizeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSizeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.filesListView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(765, 404);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // filesListView
            // 
            this.filesListView.AllowDrop = true;
            this.filesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filesListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filesListView.LargeImageList = this.photosImageList;
            this.filesListView.Location = new System.Drawing.Point(4, 26);
            this.filesListView.Margin = new System.Windows.Forms.Padding(4);
            this.filesListView.Name = "filesListView";
            this.filesListView.Size = new System.Drawing.Size(757, 295);
            this.filesListView.TabIndex = 18;
            this.filesListView.UseCompatibleStateImageBehavior = false;
            this.filesListView.VirtualMode = true;
            this.filesListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.filesListView_RetrieveVirtualItem);
            this.filesListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.filesListView_DragDrop);
            this.filesListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.filesListView_DragEnter);
            // 
            // photosImageList
            // 
            this.photosImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.photosImageList.ImageSize = new System.Drawing.Size(64, 64);
            this.photosImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Step 3: Select the Files";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(4, 329);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1MinSize = 29;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel4);
            this.splitContainer1.Size = new System.Drawing.Size(757, 71);
            this.splitContainer1.SplitterDistance = 35;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.filesToAddCountLabel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.albumPhotosCountLabel);
            this.panel1.Controls.Add(this.photosLeftLabel);
            this.panel1.Controls.Add(this.removePhotosButton);
            this.panel1.Controls.Add(this.addFilesButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(757, 35);
            this.panel1.TabIndex = 18;
            // 
            // filesToAddCountLabel
            // 
            this.filesToAddCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filesToAddCountLabel.AutoSize = true;
            this.filesToAddCountLabel.Location = new System.Drawing.Point(595, 9);
            this.filesToAddCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.filesToAddCountLabel.Name = "filesToAddCountLabel";
            this.filesToAddCountLabel.Size = new System.Drawing.Size(16, 17);
            this.filesToAddCountLabel.TabIndex = 24;
            this.filesToAddCountLabel.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(485, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Files to Add:";
            // 
            // albumPhotosCountLabel
            // 
            this.albumPhotosCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.albumPhotosCountLabel.AutoSize = true;
            this.albumPhotosCountLabel.Location = new System.Drawing.Point(316, 9);
            this.albumPhotosCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.albumPhotosCountLabel.Name = "albumPhotosCountLabel";
            this.albumPhotosCountLabel.Size = new System.Drawing.Size(44, 17);
            this.albumPhotosCountLabel.TabIndex = 22;
            this.albumPhotosCountLabel.Text = "0/500";
            // 
            // photosLeftLabel
            // 
            this.photosLeftLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.photosLeftLabel.AutoSize = true;
            this.photosLeftLabel.Location = new System.Drawing.Point(179, 9);
            this.photosLeftLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.photosLeftLabel.Name = "photosLeftLabel";
            this.photosLeftLabel.Size = new System.Drawing.Size(118, 17);
            this.photosLeftLabel.TabIndex = 21;
            this.photosLeftLabel.Text = "Album File Count:";
            // 
            // removePhotosButton
            // 
            this.removePhotosButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removePhotosButton.Image = ((System.Drawing.Image)(resources.GetObject("removePhotosButton.Image")));
            this.removePhotosButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removePhotosButton.Location = new System.Drawing.Point(4, 3);
            this.removePhotosButton.Margin = new System.Windows.Forms.Padding(4);
            this.removePhotosButton.Name = "removePhotosButton";
            this.removePhotosButton.Size = new System.Drawing.Size(156, 28);
            this.removePhotosButton.TabIndex = 20;
            this.removePhotosButton.Text = "Remove Selected";
            this.removePhotosButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.removePhotosButton.UseVisualStyleBackColor = true;
            this.removePhotosButton.Click += new System.EventHandler(this.removePhotosButton_Click);
            // 
            // addFilesButton
            // 
            this.addFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addFilesButton.Image = ((System.Drawing.Image)(resources.GetObject("addFilesButton.Image")));
            this.addFilesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addFilesButton.Location = new System.Drawing.Point(641, 3);
            this.addFilesButton.Margin = new System.Windows.Forms.Padding(4);
            this.addFilesButton.Name = "addFilesButton";
            this.addFilesButton.Size = new System.Drawing.Size(112, 28);
            this.addFilesButton.TabIndex = 19;
            this.addFilesButton.Text = "Add Files";
            this.addFilesButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addFilesButton.UseVisualStyleBackColor = true;
            this.addFilesButton.Click += new System.EventHandler(this.addFilesButton_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel4.Controls.Add(this.imageSizeComboBox, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(757, 31);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // imageSizeComboBox
            // 
            this.imageSizeComboBox.DataSource = this.imageSizeBindingSource;
            this.imageSizeComboBox.DisplayMember = "Label";
            this.imageSizeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageSizeComboBox.FormattingEnabled = true;
            this.imageSizeComboBox.Location = new System.Drawing.Point(494, 4);
            this.imageSizeComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.imageSizeComboBox.Name = "imageSizeComboBox";
            this.imageSizeComboBox.Size = new System.Drawing.Size(259, 24);
            this.imageSizeComboBox.TabIndex = 0;
            // 
            // imageSizeBindingSource
            // 
            this.imageSizeBindingSource.DataSource = typeof(PicasaUploader.ImageSize);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.label2.Size = new System.Drawing.Size(271, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Scale photos down to (aspect preserved):";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All Supported|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.avi;*.wmv;*.mpg;*.mpeg;*.mp4;*.mov" +
    ";*.asf;*.3gp|Photos|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Videos|*.avi;*.wmv;*.mpg;*.mp" +
    "eg;*.mp4;*.mov;*.asf;*.3gp";
            this.openFileDialog.Multiselect = true;
            // 
            // PhotosPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PhotosPage";
            this.Size = new System.Drawing.Size(765, 404);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageSizeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView filesListView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label filesToAddCountLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label albumPhotosCountLabel;
        private System.Windows.Forms.Label photosLeftLabel;
        private System.Windows.Forms.Button removePhotosButton;
        private System.Windows.Forms.Button addFilesButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ComboBox imageSizeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList photosImageList;
        private System.Windows.Forms.BindingSource imageSizeBindingSource;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
