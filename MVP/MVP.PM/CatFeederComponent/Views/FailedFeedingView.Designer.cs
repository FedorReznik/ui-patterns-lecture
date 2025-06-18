using System.ComponentModel;

namespace MVP.CatFeederComponent.Views
{
    partial class FailedFeedingView
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
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnContinue.Location = new System.Drawing.Point(0, 448);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(0);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(675, 92);
            this.btnContinue.TabIndex = 0;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblError
            // 
            this.lblError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblError.Location = new System.Drawing.Point(0, 0);
            this.lblError.Margin = new System.Windows.Forms.Padding(0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(675, 448);
            this.lblError.TabIndex = 1;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // FailedFeedingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnContinue);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FailedFeedingView";
            this.Size = new System.Drawing.Size(675, 540);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblError;

        private System.Windows.Forms.Button btnContinue;

        #endregion
    }
}