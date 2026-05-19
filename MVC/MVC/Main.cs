using System;
using System.Linq;
using System.Windows.Forms;
using MVC.Engine;

namespace MVC
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public void AttachView(UserControl view)
        {
            // ReSharper disable once ConvertToLocalFunction
            Action uiMutation = () =>
            {
                var currentView = Controls
                    .Cast<UserControl>()
                    .FirstOrDefault();
                Controls.Clear();
                currentView?.Dispose();
                view.Dock = DockStyle.Fill;
                Controls.Add(view);
            };
            
            this.Guard(uiMutation);
        }
    }
}