using System;
using System.Windows.Forms;

namespace MVC.Routing.Engine
{
    public partial class Main : Form, INavigationHost
    {
        public Main()
        {
            InitializeComponent();
        }
        
        public void NavigateTo(UserControl view)
        {
            // ReSharper disable once ConvertToLocalFunction
            Action uiMutation = () =>
            {
                Controls.Clear();
                view.Dock = DockStyle.Fill;
                Controls.Add(view);
            };
            
            this.Guard(uiMutation);
        }

        public Form Host => this;
    }
}