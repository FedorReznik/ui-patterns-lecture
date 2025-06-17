using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using MVC.Routing.CatFeederComponent.Controllers;
using MVC.Routing.Engine;

namespace MVC.Routing.CatFeederComponent.Views
{
    [SuppressMessage("ReSharper", "LocalizableElement")]
    public partial class FailedFeedingView : ViewBase<IFailedFeedingController>, IFailedFeedingView
    {
        public FailedFeedingView()
        {
            InitializeComponent();
        }

        public void SetReason(string reason)
        {
            this.Guard(() => lblError.Text = $"Feed error: {reason}");
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Controller?.Continue();
        }
    }
}