using System.Windows.Input;
using JetBrains.Annotations;

#pragma warning disable CS8612 // Nullability of reference types in type doesn't match implicitly implemented member.

namespace MVVM.Engine.Commands;

[PublicAPI]
public class ActionCommand(Action<object?> execute, Func<object?, bool> canExecute) : ICommand
{
    public ActionCommand(Action execute) : this(_ => execute(), _ => true) { }

    public void Execute(object? parameter)
    {
        execute(parameter);
    }
    
    public bool CanExecute(object? parameter) => canExecute(parameter);

    public void RaiseCanExecuteChanged() => CanExecuteChanged.Invoke(this, EventArgs.Empty);

    public event EventHandler CanExecuteChanged = (_, _) => {};
}