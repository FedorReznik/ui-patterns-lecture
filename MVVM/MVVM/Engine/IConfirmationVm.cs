using System.Windows;

namespace MVVM.Engine;

public interface IConfirmationVm : IViewModel
{
    public string? Caption { get; set; }
    
    public string? Text { get; set; }
    
    public MessageBoxButton Buttons { get; set; }
    
    public MessageBoxImage Icon { get; set; }
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