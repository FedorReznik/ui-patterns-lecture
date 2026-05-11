using System.Windows.Input;
using MVVM.Engine;

namespace MVVM.CatFeederComponent.ViewModels;

public interface IFailedFeedingVm
{
    ICommand Continue { get; }
        
    string? Reason { get; set; }
}

public class FailedFeedingVm : ViewModelBase, IFailedFeedingVm
{
    private readonly Func<ICatFeederVm> _catFeederVmFactory;
    private readonly ICommand _continueCommand;

    public FailedFeedingVm(Func<ICatFeederVm> catFeederVmFactory)
    {
        _catFeederVmFactory = catFeederVmFactory;

        _continueCommand = new ActionCommand(() =>
        {
            var nextVm = _catFeederVmFactory();
            
            // TODO: call next transition
        });
    }

    public ICommand Continue => _continueCommand;

    public string? Reason
    {
        get;
        set => SetField(ref field, value);
    }
}