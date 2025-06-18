using System;
using JetBrains.Annotations;

namespace MVP.CatFeederComponent.Presenters
{
    public class SuccessfulFeedingPresenter : ISuccessfulFeedingPresenter
    {
        private readonly Func<ICatFeederPresenter> _catFeederPresenterFactory;

        public SuccessfulFeedingPresenter([NotNull] Func<ICatFeederPresenter> catFeederPresenterFactory)
        {
            _catFeederPresenterFactory = catFeederPresenterFactory ?? throw new ArgumentNullException(nameof(catFeederPresenterFactory));
        }

        public ICatFeederPresenter Continue()
        {
            return _catFeederPresenterFactory();
        }

        public string Message { get; set; }

        public void Dispose()
        {
            //intentionally left blank
        }
    }
}