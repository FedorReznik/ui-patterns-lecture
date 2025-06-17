using System;
using MVC.Routing.CatFeederComponent.Controllers;
using MVC.Routing.Engine;

namespace MVC.Routing.CatFeederComponent.Views
{
    public partial class CatFeederView : ViewBase<ICatFeederController>, ICatFeederView
    {
        public CatFeederView()
        {
            InitializeComponent();
        }
        
        private void btnFeedCat_Click(object sender, EventArgs e)
        {
            Controller?.Feed();
        }
        
        public void Block()
        {
            this.Guard(() => btnFeedCat.Enabled = false);
        }

        public void UnBlock()
        {
            this.Guard(() => btnFeedCat.Enabled = true);
        }
    }
}