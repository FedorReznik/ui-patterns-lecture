using Autofac;
using FeederDriver;
using MVC.Routing.CatFeederComponent.Controllers;
using MVC.Routing.CatFeederComponent.Models;
using MVC.Routing.Engine;

namespace MVC.Routing.DI
{
    public static class CompositionRoot
    {
        public static IContainer Compose()
        {
            var builder = new ContainerBuilder();
            
            // register engine
            builder.RegisterType<Main>().As<INavigationHost>().SingleInstance();
            
            // register controllers
            builder.RegisterType<CatFeederController>().As<ICatFeederController>();
            
            // register views
            
            // register models
            builder.RegisterType<CatFeederService>().As<ICatFeederService>().SingleInstance();
            
            // register drivers
            builder.RegisterType<CatFeederDriver>().As<ICatFeederDriver>().SingleInstance();

            return builder.Build();
        }
    }
}