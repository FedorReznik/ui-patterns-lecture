using System.Windows.Input;
using MVVM.Engine;

namespace MVVM.CatFeederComponent.ViewModels;

public class SuccessfulFeedingVm : ViewModelBase, ISuccessfulFeedingVm
{
    private readonly Func<ICatFeederVm> _catFeederVmFactory;
    private readonly ICommand _continueCommand;

    public SuccessfulFeedingVm(Func<ICatFeederVm> catFeederVmFactory)
    {
        _catFeederVmFactory = catFeederVmFactory;

        _continueCommand = new ActionCommand(() =>
        {
            var nextVm = _catFeederVmFactory();
            
            // TODO: call next transition
        });
    }

    public ICommand Continue => _continueCommand;

    public string? Message
    {
        get;
        set => SetField(ref field, value);
    }
}