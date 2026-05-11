using System.Windows.Input;

namespace MVVM.CatFeederComponent.ViewModels;

public interface ISuccessfulFeedingVm
{
    ICommand Continue { get; }
    
    string? Message { get; set; }
}