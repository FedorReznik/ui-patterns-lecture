using System;
using JetBrains.Annotations;
using MVP.Engine;

namespace MVP.CatFeederComponent.Presenters
{
    public class FailedFeedingPresenter : PresenterBase, IFailedFeedingPresenter
    {
        private readonly Func<ICatFeederPresenter> _catFeederPresenterFactory;

        public FailedFeedingPresenter([NotNull] Func<ICatFeederPresenter> catFeederPresenterFactory)
        {
            _catFeederPresenterFactory = catFeederPresenterFactory ?? throw new ArgumentNullException(nameof(catFeederPresenterFactory));
        }

        public ICatFeederPresenter Continue()
        {
            return _catFeederPresenterFactory();
        }

        public string Reason { get; set; }
    }
}