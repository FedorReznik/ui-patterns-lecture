using System.Windows.Input;
using MVVM.Engine;

namespace MVVM.CatFeederComponent.ViewModels;

public interface IFailedFeedingVm : IViewModel, INextVmSink
{
    ICommand Continue { get; }
        
    string? Reason { get; set; }
}