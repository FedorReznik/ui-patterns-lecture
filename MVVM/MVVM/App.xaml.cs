using System.Windows;
using Autofac;
using MVVM.CatFeederComponent.ViewModels;
using MVVM.DI;
using MVVM.Engine;

namespace MVVM;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IMainVm? _mainVm;
    
    protected override void OnStartup(StartupEventArgs e)
    {
        var container = CompositionRoot.Compose();

        var feederVm = container.Resolve<ICatFeederVm>();
        _mainVm = container.Resolve<IMainVm>();
        _mainVm.CurrentVm = feederVm;
        
        var mainWindow = container.Resolve<MainWindow>();
        mainWindow.DataContext = _mainVm;
        mainWindow.Show();
        
        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _mainVm?.Dispose();
        
        base.OnExit(e);
    }
}