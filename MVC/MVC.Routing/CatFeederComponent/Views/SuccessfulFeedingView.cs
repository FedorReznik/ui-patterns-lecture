using System;
using System.Windows.Forms;
using MVC.Routing.CatFeederComponent.Controllers;
using MVC.Routing.Engine;

namespace MVC.Routing.CatFeederComponent.Views
{
    public partial class SuccessfulFeedingView : ViewBase<ISuccessfulFeedingController>, ISuccessfulFeedingView
    {
        public SuccessfulFeedingView()
        {
            InitializeComponent();
        }

        public void SetMessage(string message)
        {
            this.Guard(() => lblMessage.Text = message);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Controller?.Continue();
        }
    }
}