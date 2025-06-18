using Autofac;
using FeederDriver;
using MVP.CatFeederComponent.Models;
using MVP.CatFeederComponent.Presenters;
using MVP.CatFeederComponent.Views;
using MVP.Engine;

namespace MVP.DI
{
    public static class CompositionRoot
    {
        public static IContainer Compose()
        {
            var builder = new ContainerBuilder();
            
            // register engine
            builder.RegisterType<UIExecutor>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<Main>().As<INavigationHost>().SingleInstance();
            builder.RegisterType<Router>().As<IRouter>().SingleInstance();
            
            // register presenters
            builder.RegisterType<CatFeederPresenter>().As<ICatFeederPresenter>();
            
            // register views
            builder.RegisterType<CatFeederView>()
                .Keyed<IView>(typeof(ICatFeederPresenter));
            
            // register models
            builder.RegisterType<CatFeederService>().As<ICatFeederService>().SingleInstance();
            
            // register drivers
            builder.RegisterType<CatFeederDriver>().As<ICatFeederDriver>().SingleInstance();
            
            return builder.Build();
        }
    }
}