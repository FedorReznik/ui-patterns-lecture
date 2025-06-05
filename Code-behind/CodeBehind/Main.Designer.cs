namespace CodeBehind
{
    partial class Main
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
            this.btnFeedCat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFeedCat
            // 
            this.btnFeedCat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFeedCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFeedCat.Location = new System.Drawing.Point(12, 12);
            this.btnFeedCat.Name = "btnFeedCat";
            this.btnFeedCat.Size = new System.Drawing.Size(871, 529);
            this.btnFeedCat.TabIndex = 0;
            this.btnFeedCat.Text = "Feed the cat!";
            this.btnFeedCat.UseVisualStyleBackColor = true;
            this.btnFeedCat.Click += new System.EventHandler(this.btnFeedCatOnClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 563);
            this.Controls.Add(this.btnFeedCat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feeder App 1.0";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnFeedCat;

        #endregion
    }
}