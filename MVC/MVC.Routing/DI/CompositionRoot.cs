using Autofac;
using FeederDriver;
using MVC.Routing.CatFeederComponent.Controllers;
using MVC.Routing.CatFeederComponent.Models;
using MVC.Routing.CatFeederComponent.Routes;
using MVC.Routing.CatFeederComponent.Views;
using MVC.Routing.Engine;

namespace MVC.Routing.DI
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
            
            // register controllers
            builder.RegisterType<CatFeederController>()
                .As<ICatFeederController>()
                .Keyed<IController>(CatFeederRoutes.CatFeederRoute);
            builder.RegisterType<FailedFeedingController>()
                .As<IFailedFeedingController>()
                .Keyed<IController>(CatFeederRoutes.CatFeedingFailedRoute);
            builder.RegisterType<SuccessfulFeedingController>()
                .As<ISuccessfulFeedingController>()
                .Keyed<IController>(CatFeederRoutes.CatFedRoute);
            
            // register views
            builder.RegisterType<CatFeederView>()
                .As<ICatFeederView>()
                .Keyed<IView>(CatFeederRoutes.CatFeederRoute);
            builder.RegisterType<FailedFeedingView>()
                .As<IFailedFeedingView>()
                .Keyed<IView>(CatFeederRoutes.CatFeedingFailedRoute);
            builder.RegisterType<SuccessfulFeedingView>()
                .As<ISuccessfulFeedingView>()
                .Keyed<IView>(CatFeederRoutes.CatFedRoute);
            
            // register models
            builder.RegisterType<CatFeederService>().As<ICatFeederService>().SingleInstance();
            
            // register drivers
            builder.RegisterType<CatFeederDriver>().As<ICatFeederDriver>().SingleInstance();

            return builder.Build();
        }
    }
}