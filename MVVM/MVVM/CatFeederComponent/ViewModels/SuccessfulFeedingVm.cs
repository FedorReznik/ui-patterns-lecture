using System.Windows.Input;
using MVVM.Engine;
using MVVM.Engine.AppState;
using MVVM.Engine.Commands;

namespace MVVM.CatFeederComponent.ViewModels;

public class SuccessfulFeedingVm : ViewModelBase, ISuccessfulFeedingVm
{
    private readonly Func<ICatFeederVm> _catFeederVmFactory;
    private readonly ICommand _continueCommand;
    
    private readonly NextVmSinkPart _nextVmSinkPart = new();

    public SuccessfulFeedingVm(Func<ICatFeederVm> catFeederVmFactory)
    {
        _catFeederVmFactory = catFeederVmFactory;

        _continueCommand = new ActionCommand(() =>
        {
            var nextVm = _catFeederVmFactory();
            _nextVmSinkPart.Proceed(nextVm);
        });
    }

    public ICommand Continue => _continueCommand;

    public string? Message
    {
        get;
        set => SetField(ref field, value);
    }
    
    IObservable<IViewModel> INextVmSink.ProceedWith => _nextVmSinkPart.ProceedWith;

    protected override void DisposeCore()
    {
        _nextVmSinkPart.Dispose();
        
        base.DisposeCore();
    }
}