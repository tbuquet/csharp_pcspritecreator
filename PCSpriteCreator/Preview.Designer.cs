namespace PCSpriteCreator
{
    partial class Preview
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
            this.AnimPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AnimPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // AnimPreview
            // 
            this.AnimPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnimPreview.Location = new System.Drawing.Point(0, 0);
            this.AnimPreview.Name = "AnimPreview";
            this.AnimPreview.Size = new System.Drawing.Size(672, 515);
            this.AnimPreview.TabIndex = 1;
            this.AnimPreview.TabStop = false;
            this.AnimPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.AnimPreview_Paint);
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 515);
            this.Controls.Add(this.AnimPreview);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Preview";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Preview";
            ((System.ComponentModel.ISupportInitialize)(this.AnimPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox AnimPreview;
    }
}