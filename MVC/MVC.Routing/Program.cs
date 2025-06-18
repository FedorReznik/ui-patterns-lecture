using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Autofac;
using MVC.Routing.CatFeederComponent.Routes;
using MVC.Routing.DI;
using MVC.Routing.Engine;

namespace MVC.Routing
{
    [SuppressMessage("ReSharper", "AsyncVoidLambda")]
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = CompositionRoot.Compose();
            
            var host = container.Resolve<INavigationHost>();
            Action hostOnInitialized = null;
            hostOnInitialized = async () =>
            {
                var router = container.Resolve<IRouter>();
                await router.NavigateTo(CatFeederRoutes.CatFeederRoute);
                host.Initialized -= hostOnInitialized;
            };
            host.Initialized += hostOnInitialized;
            
            Application.Run(host.Host);
        }
    }
}