using System.Windows.Input;
using MVVM.Engine;
using MVVM.Engine.AppState;

namespace MVVM.CatFeederComponent.ViewModels;

public interface ISuccessfulFeedingVm : IViewModel, INextVmSink
{
    ICommand Continue { get; }
    
    string? Message { get; set; }
}