using System;
using MVP.CatFeederComponent.Presenters;
using MVP.Engine;

namespace MVP.CatFeederComponent.Views
{
    public partial class CatFeederView : ViewBase, IView<ICatFeederPresenter>
    {
        private IDisposable _isBusySubscription;

        public CatFeederView()
        {
            InitializeComponent();

            Disposed += (sender, args) => UnSubscribePresenter();
        }

        private void btnFeedCat_Click(object sender, EventArgs e)
        {
            Presenter?.Feed();
        }

        protected override void OnPresenterAttached()
        {
            SubscribePresenter(); 
            base.OnPresenterAttached();
        }
        
        private void SubscribePresenter()
        {
            _isBusySubscription = Presenter.IsBusy.Subscribe(isBusy => 
                this.Guard(() => btnFeedCat.Enabled = !isBusy));
        }
        
        private void UnSubscribePresenter()
        {
            _isBusySubscription.Dispose();
        }

        public ICatFeederPresenter Presenter => (ICatFeederPresenter)AttachedPresenter;
    }
}