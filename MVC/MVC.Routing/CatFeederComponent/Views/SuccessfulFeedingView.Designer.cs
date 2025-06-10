using System.ComponentModel;

namespace MVC.Routing.CatFeederComponent.Views
{
    partial class SuccessfulFeedingView
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnContinue.Location = new System.Drawing.Point(0, 241);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(308, 60);
            this.btnContinue.TabIndex = 0;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(308, 241);
            this.lblMessage.TabIndex = 1;
            // 
            // SuccessfulFeedingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnContinue);
            this.Name = "SuccessfulFeedingView";
            this.Size = new System.Drawing.Size(308, 301);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblMessage;

        private System.Windows.Forms.Button btnContinue;

        #endregion
    }
}