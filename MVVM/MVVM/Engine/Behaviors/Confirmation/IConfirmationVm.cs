using System.Windows;
using MVVM.Engine.AppState;

namespace MVVM.Engine.Behaviors.Confirmation;

public interface IConfirmationVm : IViewModel
{
    public string? Caption { get; }
    
    public string? Text { get; }
    
    public MessageBoxButton Buttons { get; }
    
    public MessageBoxImage Icon { get; }
}

public class ConfirmationVm : ViewModelBase, IConfirmationVm
{
    public string? Caption
    {
        get;
        set => SetField(ref field, value);
    }

    public string? Text
    {
        get;
        set => SetField(ref field, value);
    }

    public MessageBoxButton Buttons
    {
        get;
        set => SetField(ref field, value);
    }

    public MessageBoxImage Icon
    {
        get;
        set => SetField(ref field, value);
    }
}