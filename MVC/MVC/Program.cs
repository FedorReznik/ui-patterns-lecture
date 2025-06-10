using System;
using System.Windows.Forms;
using MVC.CatFeederComponent.Views;

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
            var main = new Main();
            main.AttachView(new CatFeederView());
            Application.Run(main);
        }
    }
}