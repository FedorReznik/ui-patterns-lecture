using System;
using System.Windows.Forms;
using MVC.CatFeederComponent.Controllers;
using MVC.Engine;

namespace MVC.CatFeederComponent.Views
{
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
        
        public void Block()
        {
            this.Guard(() => btnFeedCat.Enabled = false);
        }

        public void UnBlock()
        {
            this.Guard(() => btnFeedCat.Enabled = true);
        }

        public void AttachController(ICatFeederController controller)
        {
            if(_controller != null)
                throw new InvalidOperationException($"Controller is already attached for {nameof(CatFeederView)}");
            
            _controller = controller;
        }

        public UserControl Render()
        {
            return this;
        }
    }
}