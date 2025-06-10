using System;
using System.Threading;
using System.Windows.Forms;

namespace MVC.Routing.Engine
{
    public partial class Main : Form, INavigationHost
    {
        public Main(IUIContextHolder uiContextHolder)
        {
            InitializeComponent();
            
            uiContextHolder.SetContext(SynchronizationContext.Current);
        }
        
        public void ShowView(UserControl view)
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

        public event Action Initialized = () => {};

        public Form Host => this;

        private void Main_Load(object sender, EventArgs e)
        {
            Initialized();
        }
    }
}