using Autofac;
using FeederDriver;
using MVVM.CatFeederComponent.Models;
using MVVM.CatFeederComponent.ViewModels;
using MVVM.Engine;
using MVVM.Engine.AppState;

namespace MVVM.DI;

public static class CompositionRoot
{
    public static IContainer Compose()
    {
        var builder = new ContainerBuilder();
        
        // register engine
        builder.RegisterType<MainVm>().As<IMainVm>().SingleInstance();
        builder.RegisterType<MainWindow>().AsSelf().SingleInstance();
            
        // register ViewModels
        builder.RegisterType<CatFeederVm>().As<ICatFeederVm>();
        builder.RegisterType<SuccessfulFeedingVm>().As<ISuccessfulFeedingVm>();
        builder.RegisterType<FailedFeedingVm>().As<IFailedFeedingVm>();
            
        // register models
        builder.RegisterType<CatFeederService>().As<ICatFeederService>();
            
        // register drivers
        builder.RegisterType<CatFeederDriver>().As<ICatFeederDriver>().SingleInstance();
            
        return builder.Build();
    }
}