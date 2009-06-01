namespace PicasaUploader
{
	partial class NewAlbumDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (NewAlbumDialog));
			this.cancelButton = new System.Windows.Forms.Button ();
			this.okButton = new System.Windows.Forms.Button ();
			this.label1 = new System.Windows.Forms.Label ();
			this.label2 = new System.Windows.Forms.Label ();
			this.publicCheckBox = new System.Windows.Forms.CheckBox ();
			this.titleTextBox = new System.Windows.Forms.TextBox ();
			this.descriptionTextBox = new System.Windows.Forms.TextBox ();
			this.label4 = new System.Windows.Forms.Label ();
			this.locationTextBox = new System.Windows.Forms.TextBox ();
			this.label3 = new System.Windows.Forms.Label ();
			this.dateTimePicker = new System.Windows.Forms.DateTimePicker ();
			this.label5 = new System.Windows.Forms.Label ();
			this.label6 = new System.Windows.Forms.Label ();
			this.SuspendLayout ();
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point (133, 257);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size (75, 23);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler (this.cancelButton_Click);
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point (214, 257);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size (75, 23);
			this.okButton.TabIndex = 5;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler (this.okButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point (12, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size (30, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Title:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point (12, 120);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size (63, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Description:";
			// 
			// publicCheckBox
			// 
			this.publicCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.publicCheckBox.AutoSize = true;
			this.publicCheckBox.Checked = true;
			this.publicCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.publicCheckBox.Location = new System.Drawing.Point (81, 228);
			this.publicCheckBox.Name = "publicCheckBox";
			this.publicCheckBox.Size = new System.Drawing.Size (54, 17);
			this.publicCheckBox.TabIndex = 4;
			this.publicCheckBox.Text = "public";
			this.publicCheckBox.UseVisualStyleBackColor = true;
			// 
			// titleTextBox
			// 
			this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.titleTextBox.Location = new System.Drawing.Point (81, 40);
			this.titleTextBox.Name = "titleTextBox";
			this.titleTextBox.Size = new System.Drawing.Size (208, 20);
			this.titleTextBox.TabIndex = 1;
			// 
			// descriptionTextBox
			// 
			this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.descriptionTextBox.Location = new System.Drawing.Point (81, 117);
			this.descriptionTextBox.Multiline = true;
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.Size = new System.Drawing.Size (208, 105);
			this.descriptionTextBox.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point (12, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size (148, 16);
			this.label4.TabIndex = 14;
			this.label4.Text = "Create a New Album";
			// 
			// locationTextBox
			// 
			this.locationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
			this.locationTextBox.Location = new System.Drawing.Point (81, 65);
			this.locationTextBox.Name = "locationTextBox";
			this.locationTextBox.Size = new System.Drawing.Size (208, 20);
			this.locationTextBox.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point (12, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size (51, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Location:";
			// 
			// dateTimePicker
			// 
			this.dateTimePicker.Location = new System.Drawing.Point (81, 91);
			this.dateTimePicker.Name = "dateTimePicker";
			this.dateTimePicker.Size = new System.Drawing.Size (208, 20);
			this.dateTimePicker.TabIndex = 17;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point (12, 95);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size (33, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "Date:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point (12, 229);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size (45, 13);
			this.label6.TabIndex = 19;
			this.label6.Text = "Access:";
			// 
			// NewAlbumDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (292, 283);
			this.Controls.Add (this.label6);
			this.Controls.Add (this.label5);
			this.Controls.Add (this.dateTimePicker);
			this.Controls.Add (this.label3);
			this.Controls.Add (this.locationTextBox);
			this.Controls.Add (this.label4);
			this.Controls.Add (this.descriptionTextBox);
			this.Controls.Add (this.titleTextBox);
			this.Controls.Add (this.publicCheckBox);
			this.Controls.Add (this.label2);
			this.Controls.Add (this.label1);
			this.Controls.Add (this.okButton);
			this.Controls.Add (this.cancelButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject ("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size (300, 270);
			this.Name = "NewAlbumDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Album";
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox publicCheckBox;
		private System.Windows.Forms.TextBox titleTextBox;
		private System.Windows.Forms.TextBox descriptionTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox locationTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
	}
}