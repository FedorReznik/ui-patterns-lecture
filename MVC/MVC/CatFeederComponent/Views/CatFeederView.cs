using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using JetBrains.Annotations;
using MVC.CatFeederComponent.Controllers;
using MVC.CatFeederComponent.Models;
using MVC.Engine;

namespace MVC.CatFeederComponent.Views
{
    [SuppressMessage("ReSharper", "LocalizableElement")]
    public partial class CatFeederView : UserControl, ICatFeederView
    {
        private ICatFeederController _controller;

        public CatFeederView()
        {
            InitializeComponent();

            Disposed += (sender, args) => _controller?.Dispose();
        }

        private void btnFeedCat_Click(object sender, EventArgs e)
        {
            _controller?.Feed();
        }

        public void ProcessFeedingResult(FeedingResult result)
        {
            if(result.Successful)
                NotifyFeedingCompleted(result.Message);
            else
                NotifyError(result.Message);
        }

        private void NotifyFeedingCompleted(string message)
        {
            this.Guard(() => 
                MessageBox.Show(this, message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information));
        }

        private void NotifyError(string error)
        {
            this.Guard(() => 
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error));
        }

        public void Block()
        {
            // For example, we also can show progress bar - it's up to view how to render the states
            this.Guard(() => btnFeedCat.Enabled = false);
        }

        public void UnBlock()
        {
            this.Guard(() => btnFeedCat.Enabled = true);
        }

        public void AttachController([NotNull] ICatFeederController controller)
        {
            if(_controller != null)
                throw new InvalidOperationException($"Controller is already attached for {nameof(CatFeederView)}");
            
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
        }

        public UserControl Render()
        {
            return this;
        }
    }
}