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
        
        private readonly ReplaySubject<bool> _isBusy = new ReplaySubject<bool>(1);

        public CatFeederPresenter(
            [NotNull] ICatFeederService catFeederService)
        {
            _catFeederService = catFeederService ?? throw new ArgumentNullException(nameof(catFeederService));
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
                    // TODO: impl
                    /*var successfulController = await _router.NavigateTo<ISuccessfulFeedingController>(CatFeederRoutes.CatFedRoute);
                    successfulController.Message(result.Message);*/
                }
                else
                {
                    // TODO: impl
                    /*var failedFeedingController = await _router.NavigateTo<IFailedFeedingController>(CatFeederRoutes.CatFeedingFailedRoute);
                    failedFeedingController.Reason(result.Message);*/
                }
            });
        }

        public IObservable<bool> IsBusy => _isBusy;

        public void Dispose()
        {
            _catFeederService.Dispose();
        }
    }
}