using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Autofac;
using MVP.CatFeederComponent.Presenters;
using MVP.DI;
using MVP.Engine;

namespace MVP
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
                await router.NavigateTo(container.Resolve<ICatFeederPresenter>());
                host.Initialized -= hostOnInitialized;
            };
            host.Initialized += hostOnInitialized;
            
            Application.Run(host.Host);
        }
    }
}