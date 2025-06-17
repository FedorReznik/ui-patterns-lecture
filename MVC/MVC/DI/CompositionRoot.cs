using Autofac;
using FeederDriver;
using MVC.CatFeederComponent.Controllers;
using MVC.CatFeederComponent.Models;
using MVC.CatFeederComponent.Views;

namespace MVC.DI
{
    public static class CompositionRoot
    {
        public static IContainer Compose()
        {
            var builder = new ContainerBuilder();
            
            // register controllers
            builder.RegisterType<CatFeederController>().As<ICatFeederController>();
            
            // register views
            builder.RegisterType<CatFeederView>().As<ICatFeederView>();
            
            // register models
            builder.RegisterType<CatFeederService>().As<ICatFeederService>().SingleInstance();
            
            // register drivers
            builder.RegisterType<CatFeederDriver>().As<ICatFeederDriver>().SingleInstance();
            
            return builder.Build();
        }
    }
}