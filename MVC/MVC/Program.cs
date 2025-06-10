using System;
using System.Windows.Forms;
using Autofac;
using MVC.CatFeederComponent.Controllers;
using MVC.CatFeederComponent.Views;
using MVC.DI;

namespace MVC
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
            
            var main = new Main();
            
            var controller = container.Resolve<ICatFeederController>();
            
            main.AttachView(controller.View().Render());
            
            Application.Run(main);
        }
    }
}