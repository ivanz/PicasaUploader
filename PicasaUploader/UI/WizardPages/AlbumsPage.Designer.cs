namespace PicasaUploader.UI.WizardPages
{
    partial class AlbumsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlbumsPage));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.albumsListView = new System.Windows.Forms.ListView();
            this.albumCoversImageList = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.newAlbumButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.albumsListView, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(765, 404);
            this.tableLayoutPanel3.TabIndex = 21;
            // 
            // albumsListView
            // 
            this.albumsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.albumsListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.albumsListView.LargeImageList = this.albumCoversImageList;
            this.albumsListView.Location = new System.Drawing.Point(4, 26);
            this.albumsListView.Margin = new System.Windows.Forms.Padding(4);
            this.albumsListView.Name = "albumsListView";
            this.albumsListView.Size = new System.Drawing.Size(757, 332);
            this.albumsListView.TabIndex = 18;
            this.albumsListView.UseCompatibleStateImageBehavior = false;
            this.albumsListView.SelectedIndexChanged += new System.EventHandler(this.albumsListView_SelectedIndexChanged);
            // 
            // albumCoversImageList
            // 
            this.albumCoversImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.albumCoversImageList.ImageSize = new System.Drawing.Size(64, 64);
            this.albumCoversImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.newAlbumButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 366);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(757, 34);
            this.panel3.TabIndex = 17;
            // 
            // newAlbumButton
            // 
            this.newAlbumButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newAlbumButton.Image = ((System.Drawing.Image)(resources.GetObject("newAlbumButton.Image")));
            this.newAlbumButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newAlbumButton.Location = new System.Drawing.Point(638, 2);
            this.newAlbumButton.Margin = new System.Windows.Forms.Padding(4);
            this.newAlbumButton.Name = "newAlbumButton";
            this.newAlbumButton.Size = new System.Drawing.Size(116, 28);
            this.newAlbumButton.TabIndex = 19;
            this.newAlbumButton.Text = "New Album";
            this.newAlbumButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.newAlbumButton.UseVisualStyleBackColor = true;
            this.newAlbumButton.Click += new System.EventHandler(this.newAlbumButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(212, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Step 2: Select an Album";
            // 
            // AlbumsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "AlbumsPage";
            this.Size = new System.Drawing.Size(765, 404);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ListView albumsListView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button newAlbumButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ImageList albumCoversImageList;

    }
}
