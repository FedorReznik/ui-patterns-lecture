using System.ComponentModel;

namespace MVC.Routing.CatFeederComponent.Views
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
            this.btnContinue.Location = new System.Drawing.Point(0, 291);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(0);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(450, 60);
            this.btnContinue.TabIndex = 0;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            this.lblError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblError.Location = new System.Drawing.Point(0, 0);
            this.lblError.Margin = new System.Windows.Forms.Padding(0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(450, 291);
            this.lblError.TabIndex = 1;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FailedFeedingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnContinue);
            this.Name = "FailedFeedingView";
            this.Size = new System.Drawing.Size(450, 351);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblError;

        private System.Windows.Forms.Button btnContinue;

        #endregion
    }
}