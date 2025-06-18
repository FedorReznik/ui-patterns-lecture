using System;
using JetBrains.Annotations;
using MVP.CatFeederComponent.Presenters;
using MVP.Engine;

namespace MVP.CatFeederComponent.Views
{
    public partial class FailedFeedingView : ViewBase, IView<IFailedFeedingPresenter>
    {
        private readonly IRouter _router;

        public FailedFeedingView(
            [NotNull] IRouter router)
        {
            InitializeComponent();
            
            _router = router ?? throw new ArgumentNullException(nameof(router));
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            _router.NavigateTo(Presenter.Continue());
        }

        protected override void OnPresenterAttached()
        {
            this.Guard(() => lblError.Text = Presenter.Reason);
            base.OnPresenterAttached();
        }

        public IFailedFeedingPresenter Presenter => (IFailedFeedingPresenter)AttachedPresenter;
    }
}