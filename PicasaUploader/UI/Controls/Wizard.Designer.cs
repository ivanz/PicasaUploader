namespace PicasaUploader.UI.Controls
{
    partial class Wizard
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
            this.pagesTabs = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // pagesTabs
            // 
            this.pagesTabs.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.pagesTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagesTabs.ItemSize = new System.Drawing.Size(0, 1);
            this.pagesTabs.Location = new System.Drawing.Point(0, 0);
            this.pagesTabs.Margin = new System.Windows.Forms.Padding(4);
            this.pagesTabs.Multiline = true;
            this.pagesTabs.Name = "pagesTabs";
            this.pagesTabs.SelectedIndex = 0;
            this.pagesTabs.Size = new System.Drawing.Size(560, 297);
            this.pagesTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.pagesTabs.TabIndex = 10;
            // 
            // Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pagesTabs);
            this.Name = "Wizard";
            this.Size = new System.Drawing.Size(560, 297);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl pagesTabs;

    }
}
