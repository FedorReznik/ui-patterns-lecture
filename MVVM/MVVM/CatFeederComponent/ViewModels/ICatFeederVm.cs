using System.Windows.Input;
using MVVM.Engine;

namespace MVVM.CatFeederComponent.ViewModels;

public interface ICatFeederVm : IViewModel, INextVmSink, IConfirmationSink
{
    ICommand Feed { get; }
        
    bool IsBusy { get; }
    
    ICommand About { get; }
}