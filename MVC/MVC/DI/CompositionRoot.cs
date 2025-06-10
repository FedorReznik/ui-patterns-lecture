using Autofac;
using MVC.CatFeederComponent.Controllers;
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
            
            return builder.Build();
        }
    }
}