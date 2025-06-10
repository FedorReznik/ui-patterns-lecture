using System;
using System.Windows.Forms;
using Autofac;
using MVC.Routing.CatFeederComponent.Routes;
using MVC.Routing.DI;
using MVC.Routing.Engine;

namespace MVC.Routing
{
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
            hostOnInitialized = () =>
            {
                var router = container.Resolve<IRouter>();
                router.NavigateTo(CatFeederRoutes.CatFeederRoute);
                host.Initialized -= hostOnInitialized;
            };
            
            host.Initialized += hostOnInitialized;
            
            Application.Run(host.Host);
        }
    }
}