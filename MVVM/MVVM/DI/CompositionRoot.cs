using Autofac;
using FeederDriver;
using MVVM.CatFeederComponent.Models;
using MVVM.CatFeederComponent.ViewModels;

namespace MVVM.DI;

public static class CompositionRoot
{
    public static IContainer Compose()
    {
        var builder = new ContainerBuilder();
            
        // register ViewModels
        builder.RegisterType<CatFeederVm>().As<ICatFeederVm>();
        builder.RegisterType<SuccessfulFeedingVm>().As<ISuccessfulFeedingVm>();
        builder.RegisterType<FailedFeedingVm>().As<IFailedFeedingVm>();
            
        // register models
        builder.RegisterType<CatFeederService>().As<ICatFeederService>().SingleInstance();
            
        // register drivers
        builder.RegisterType<CatFeederDriver>().As<ICatFeederDriver>().SingleInstance();
            
        return builder.Build();
    }
}