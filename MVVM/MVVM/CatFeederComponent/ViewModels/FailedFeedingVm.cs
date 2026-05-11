using System.Windows.Input;
using MVVM.Engine;

namespace MVVM.CatFeederComponent.ViewModels;

public class FailedFeedingVm : ViewModelBase, IFailedFeedingVm
{
    private readonly Func<ICatFeederVm> _catFeederVmFactory;
    private readonly ICommand _continueCommand;
    
    private readonly NextVmSinkPart _nextVmSinkPart = new();

    public FailedFeedingVm(Func<ICatFeederVm> catFeederVmFactory)
    {
        _catFeederVmFactory = catFeederVmFactory;

        _continueCommand = new ActionCommand(() =>
        {
            var nextVm = _catFeederVmFactory();
            _nextVmSinkPart.Proceed(nextVm);
        });
    }

    public ICommand Continue => _continueCommand;

    public string? Reason
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