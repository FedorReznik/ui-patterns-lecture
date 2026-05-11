using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
#pragma warning disable CS8612 // Nullability of reference types in type doesn't match implicitly implemented member.

namespace MVVM.Engine;

public interface IViewModel : INotifyPropertyChanged, IDisposable
{
}

public abstract class ViewModelBase : IViewModel
{
    public event PropertyChangedEventHandler PropertyChanged = (_, _) => {} ;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    [UsedImplicitly]
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) 
            return false;
            
        field = value;
            
        OnPropertyChanged(propertyName);
            
        return true;
    }

    protected virtual void DisposeCore()
    {
    }

    public void Dispose() => 
        DisposeCore();
}