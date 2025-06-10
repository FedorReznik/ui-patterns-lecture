using System;
using System.Threading;
using System.Windows.Forms;
using Autofac;
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
            
            var container = CompositionRoot.Compose(SynchronizationContext.Current);
            var host = container.Resolve<INavigationHost>();
            
            Application.Run(host.Host);
        }
    }
}