namespace MVVM.Engine.AppState;

public class MainVm : ViewModelBase, IMainVm
{
    private IViewModel? _currentVm;
    private IDisposable? _currentSubscription;

    public IViewModel? CurrentVm
    {
        get => _currentVm;
        set
        {
            if (Equals(value, _currentVm)) return;
            
            StopListeningToTransitions();
     
            var old = _currentVm;
            _currentVm = value;
            old?.Dispose();
            
            StartListeningToTransitions();
            
            OnPropertyChanged();
        }
    }

    private void StartListeningToTransitions()
    {
        if (_currentVm is INextVmSink nextVmSink)
        {
            _currentSubscription = nextVmSink
                .ProceedWith
                .Subscribe(next => CurrentVm = next);
        }
    }

    private void StopListeningToTransitions()
    {
        _currentSubscription?.Dispose();
    }

    protected override void DisposeCore()
    {
        var currentSubscription = Interlocked.Exchange(ref _currentSubscription, null);
        currentSubscription?.Dispose();
        
        var currentVm = Interlocked.Exchange(ref _currentVm, null);
        currentVm?.Dispose();
        
        base.DisposeCore();
    }
}