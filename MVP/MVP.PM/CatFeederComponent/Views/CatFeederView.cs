using System;
using JetBrains.Annotations;
using MVP.CatFeederComponent.Presenters;
using MVP.Engine;

namespace MVP.CatFeederComponent.Views
{
    public partial class CatFeederView : ViewBase, IView<ICatFeederPresenter>
    {
        private readonly IRouter _router;
        private IDisposable _isBusySubscription;
        private IDisposable _failedFeedingSubscription;
        private IDisposable _successfulFeedingSubscription;

        public CatFeederView([NotNull] IRouter router)
        {
            InitializeComponent();
            
            _router = router ?? throw new ArgumentNullException(nameof(router));

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

            _successfulFeedingSubscription = Presenter.SuccessfulFeeding.Subscribe(sf => _router.NavigateTo(sf));
            _failedFeedingSubscription = Presenter.FailedFeeding.Subscribe(ff => _router.NavigateTo(ff));
        }
        
        private void UnSubscribePresenter()
        {
            _isBusySubscription.Dispose();
            
            _failedFeedingSubscription.Dispose();
            _successfulFeedingSubscription.Dispose();
        }

        public ICatFeederPresenter Presenter => (ICatFeederPresenter)AttachedPresenter;
    }
}