using System.ComponentModel;

namespace MVC.CatFeederComponent.Views
{
    partial class CatFeederView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

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
            this.btnFeedCat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFeedCat.Location = new System.Drawing.Point(0, 0);
            this.btnFeedCat.Name = "btnFeedCat";
            this.btnFeedCat.Size = new System.Drawing.Size(651, 296);
            this.btnFeedCat.TabIndex = 0;
            this.btnFeedCat.Text = "Feed the cat!";
            this.btnFeedCat.UseVisualStyleBackColor = false;
            this.btnFeedCat.Click += new System.EventHandler(this.btnFeedCat_Click);
            // 
            // CatFeederView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFeedCat);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "CatFeederView";
            this.Size = new System.Drawing.Size(651, 296);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnFeedCat;

        #endregion
    }
}