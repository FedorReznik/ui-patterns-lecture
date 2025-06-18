using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MVP.CatFeederComponent.Models;

namespace MVP.CatFeederComponent.Presenters
{
    public class CatFeederPresenter : ICatFeederPresenter
    {
        [NotNull] 
        private readonly ICatFeederService _catFeederService;

        private readonly Func<ISuccessfulFeedingPresenter> _successfulFeedingPresenterFactory;
        private readonly Func<IFailedFeedingPresenter> _failedFeedingPresenterFactory;

        private readonly ReplaySubject<bool> _isBusy = new ReplaySubject<bool>(1);
        private readonly Subject<ISuccessfulFeedingPresenter> _successfulFeeding = new Subject<ISuccessfulFeedingPresenter>();
        private readonly Subject<IFailedFeedingPresenter> _failedFeeding = new Subject<IFailedFeedingPresenter>();

        public CatFeederPresenter(
            [NotNull] ICatFeederService catFeederService,
            [NotNull] Func<ISuccessfulFeedingPresenter> successfulFeedingPresenterFactory,
            [NotNull] Func<IFailedFeedingPresenter> failedFeedingPresenterFactory)
        {
            _catFeederService = catFeederService ?? throw new ArgumentNullException(nameof(catFeederService));
            _successfulFeedingPresenterFactory = successfulFeedingPresenterFactory ?? throw new ArgumentNullException(nameof(successfulFeedingPresenterFactory));
            _failedFeedingPresenterFactory = failedFeedingPresenterFactory ?? throw new ArgumentNullException(nameof(failedFeedingPresenterFactory));
        }

        public void Feed()
        {
            _isBusy.OnNext(true);
            Task.Run(async () =>
            {
                var result = await _catFeederService.Feed();
                _isBusy.OnNext(false);
                if (result.Successful)
                {
                    var successfulFeedingPresenter = _successfulFeedingPresenterFactory();
                    successfulFeedingPresenter.Message = result.Message;
                    _successfulFeeding.OnNext(successfulFeedingPresenter);
                }
                else
                {
                    var failedFeedingPresenter = _failedFeedingPresenterFactory();
                    failedFeedingPresenter.Reason = result.Message;
                    _failedFeeding.OnNext(failedFeedingPresenter);
                }
            });
        }

        public IObservable<bool> IsBusy => _isBusy;

        public IObservable<ISuccessfulFeedingPresenter> SuccessfulFeeding => _successfulFeeding;

        public IObservable<IFailedFeedingPresenter> FailedFeeding => _failedFeeding;

        public void Dispose()
        {
            _catFeederService.Dispose();
            
            _isBusy.OnCompleted();
            _successfulFeeding.OnCompleted();
            _failedFeeding.OnCompleted();
        }
    }
}