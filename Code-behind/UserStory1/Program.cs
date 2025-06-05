using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace UserStory1
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
            
            var @fixed = 0;
            
            Application.Run(@fixed == 0 ? (Form)new MainFixed() : new Main()); 
        }
    }
}