using System.Reactive.Subjects;

namespace MVVM.Engine;

public interface INextVmSink : IDisposable
{
    IObservable<IViewModel> ProceedWith { get; }
}

public sealed class NextVmSinkPart : INextVmSink
{
    private readonly Subject<IViewModel> _proceedWith = new();
    
    public IObservable<IViewModel> ProceedWith => _proceedWith;
    
    public void Proceed(IViewModel withVm) => _proceedWith.OnNext(withVm);

    public void Dispose()
    {
        _proceedWith.OnCompleted();
    }
}