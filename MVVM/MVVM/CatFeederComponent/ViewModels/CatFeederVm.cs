using System.Windows.Input;
using MVVM.CatFeederComponent.Models;
using MVVM.Engine;

namespace MVVM.CatFeederComponent.ViewModels;

public class CatFeederVm : ViewModelBase, ICatFeederVm
{
    private readonly ICatFeederService _catFeederService;
    private readonly Func<ISuccessfulFeedingVm> _successfulFeedingVmFactory;
    private readonly Func<IFailedFeedingVm> _failedFeedingVmFactory;

    private readonly ICommand _feedCommand;
    
    private readonly NextVmSinkPart _nextVmSinkPart = new();

    public CatFeederVm(
        ICatFeederService catFeederService,
        Func<ISuccessfulFeedingVm> successfulFeedingVmFactory,
        Func<IFailedFeedingVm> failedFeedingVmFactory)
    {
        _catFeederService = catFeederService;
        _successfulFeedingVmFactory = successfulFeedingVmFactory;
        _failedFeedingVmFactory = failedFeedingVmFactory;
        
        _feedCommand = new ActionCommand(FeedCore);
    }

    public ICommand Feed => _feedCommand;

    public bool IsBusy
    {
        get;
        private set => SetField(ref field, value);
    }

    private void FeedCore()
    {
        IsBusy = true;
        
        Task.Run(async () =>
        {
            try
            {
                var result = await _catFeederService.Feed();
                    
                switch (result.Successful)
                {
                    case true:
                    {
                        var successfulFeedingVm = _successfulFeedingVmFactory();
                        successfulFeedingVm.Message = result.Message;
                        _nextVmSinkPart.Proceed(successfulFeedingVm);
                        break;
                    }
                    default:
                    {
                        var failedFeedingVm = _failedFeedingVmFactory();
                        failedFeedingVm.Reason = result.Message;
                        _nextVmSinkPart.Proceed(failedFeedingVm);
                        break;
                    }
                }
            }
            finally
            {
                IsBusy = false;
            }
        });
    }

    IObservable<IViewModel> INextVmSink.ProceedWith => _nextVmSinkPart.ProceedWith;

    protected override void DisposeCore()
    {
        _catFeederService.Dispose();
        _nextVmSinkPart.Dispose();
        
        base.DisposeCore();
    }
}