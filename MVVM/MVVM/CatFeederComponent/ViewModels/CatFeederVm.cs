using System.Windows;
using System.Windows.Input;
using MVVM.CatFeederComponent.Models;
using MVVM.Engine;
using MVVM.Engine.AppState;
using MVVM.Engine.Behaviors.Confirmation;
using MVVM.Engine.Commands;

namespace MVVM.CatFeederComponent.ViewModels;

public class CatFeederVm : ViewModelBase, ICatFeederVm
{
    private readonly ICatFeederService _catFeederService;
    private readonly Func<ISuccessfulFeedingVm> _successfulFeedingVmFactory;
    private readonly Func<IFailedFeedingVm> _failedFeedingVmFactory;

    private readonly ICommand _feedCommand;
    private readonly ICommand _aboutCommand;
    
    private readonly NextVmSinkPart _nextVmSinkPart = new();
    private readonly ConfirmationSinkPart _confirmationSinkPart = new();

    public CatFeederVm(
        ICatFeederService catFeederService,
        Func<ISuccessfulFeedingVm> successfulFeedingVmFactory,
        Func<IFailedFeedingVm> failedFeedingVmFactory)
    {
        _catFeederService = catFeederService;
        _successfulFeedingVmFactory = successfulFeedingVmFactory;
        _failedFeedingVmFactory = failedFeedingVmFactory;
        
        _feedCommand = new ActionCommand(FeedCore);
        _aboutCommand = new ActionCommand(AboutCore);
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

    Func<IConfirmationVm, MessageBoxResult>? IConfirmationSink.Confirm
    {
        set => _confirmationSinkPart.Confirm = value;
    }

    public ICommand About => _aboutCommand;
    
    private void AboutCore()
    {
        _confirmationSinkPart.AskConfirmation(new ConfirmationVm()
        {
            Caption = "Feeder App 4.0",
            Text = "This is app version 4.0",
            Icon = MessageBoxImage.Information,
            Buttons =  MessageBoxButton.OK
        });
    }
}