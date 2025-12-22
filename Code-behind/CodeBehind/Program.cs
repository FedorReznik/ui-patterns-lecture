using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace CodeBehind
{
    [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
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
            
            // Change to any true to run the version w/o "artificial" bug
            var @fixed = true;
            
            Application.Run(@fixed ? (Form)new MainFixed() : new Main()); 
        }
    }
}