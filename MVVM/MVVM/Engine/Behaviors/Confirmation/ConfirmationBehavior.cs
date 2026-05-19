using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace MVVM.Engine.Behaviors.Confirmation;

public class ConfirmationBehavior : Behavior<FrameworkElement>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        
        if (AssociatedObject.DataContext is IConfirmationSink confirmationSink)
        {
            confirmationSink.Confirm = vm => MessageBox.Show(GetWindow(), vm.Text, vm.Caption, vm.Buttons, vm.Icon);
        }
    }

    private Window GetWindow()
    {
        // Warning won't work before Loaded event as well as for popups and ContextMenus, skipping the implementation for simplicity
        return Window.GetWindow(AssociatedObject)!;
    }
}