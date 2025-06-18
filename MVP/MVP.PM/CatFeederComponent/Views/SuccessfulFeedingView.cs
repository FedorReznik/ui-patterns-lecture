using System;
using JetBrains.Annotations;
using MVP.CatFeederComponent.Presenters;
using MVP.Engine;

namespace MVP.CatFeederComponent.Views
{
    public partial class SuccessfulFeedingView : ViewBase, IView<ISuccessfulFeedingPresenter>
    {
        private readonly IRouter _router;

        public SuccessfulFeedingView(
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
            this.Guard(() =>  lblMessage.Text = Presenter.Message);
            base.OnPresenterAttached();
        }
        
        public ISuccessfulFeedingPresenter Presenter => (ISuccessfulFeedingPresenter)AttachedPresenter;
    }
}