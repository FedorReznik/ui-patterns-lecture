using System.Windows.Input;
using MVVM.Engine;

namespace MVVM.CatFeederComponent.ViewModels;

public interface ICatFeederVm : IViewModel
{
    ICommand Feed { get; }
        
    IObservable<bool> IsBusy { get; }
}

public class CatFeederVm : ViewModelBase, ICatFeederVm
{
}