using System.Windows.Input;
#pragma warning disable CS8612 // Nullability of reference types in type doesn't match implicitly implemented member.

namespace MVVM.Engine;

public class ActionCommand(Action<object> execute, Func<object, bool> canExecute) : ICommand
{
    
    private readonly Action<object> _execute = execute;
    private readonly Func<object, bool> _canExecute = canExecute;

    public ActionCommand(Action execute) : this(_ => execute(), _ => true) { }

    public bool CanExecute(object? parameter)
    {
        throw new NotImplementedException();
    }

    public void Execute(object? parameter)
    {
        throw new NotImplementedException();
    }
    
    public void RaiseCanExecuteChanged() => 
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    public event EventHandler CanExecuteChanged = (_, _) => {};
}