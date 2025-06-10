using Autofac;
using FeederDriver;
using MVC.Routing.CatFeederComponent.Models;

namespace MVC.Routing.DI
{
    public static class CompositionRoot
    {
        public static IContainer Compose()
        {
            var builder = new ContainerBuilder();
            // register controllers
            
            // register views
            
            // register models
            builder.RegisterType<CatFeederService>().As<ICatFeederService>().SingleInstance();
            
            // register drivers
            builder.RegisterType<CatFeederDriver>().As<ICatFeederDriver>().SingleInstance();

            return builder.Build();
        }
    }
}