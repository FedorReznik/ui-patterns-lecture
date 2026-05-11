using System.Windows.Input;
using MVVM.Engine;

namespace MVVM.CatFeederComponent.ViewModels;

public interface ICatFeederVm : IViewModel, INextVmSink
{
    ICommand Feed { get; }
        
    IObservable<bool> IsBusy { get; }
}