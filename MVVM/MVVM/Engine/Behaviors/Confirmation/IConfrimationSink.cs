using System.Windows;
using JetBrains.Annotations;

namespace MVVM.Engine.Behaviors.Confirmation;

public interface IConfirmationSink
{
    Func<IConfirmationVm, MessageBoxResult>? Confirm { set; }
}

[PublicAPI]
public class ConfirmationSinkPart : IConfirmationSink
{
    private Func<IConfirmationVm, MessageBoxResult>? _confirm;

    public Func<IConfirmationVm, MessageBoxResult>? Confirm
    {
        private get => _confirm;
        set => _confirm = value;
    }

    public MessageBoxResult AskConfirmation(IConfirmationVm vm)
    {
        ArgumentNullException.ThrowIfNull(Confirm);
        ArgumentNullException.ThrowIfNull(vm);
        
        return Confirm(vm);
    }
}