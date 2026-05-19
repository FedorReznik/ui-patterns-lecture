using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using JetBrains.Annotations;

namespace MVC.Routing.Engine
{
    public partial class Main : Form, INavigationHost
    {
        public Main([NotNull] IUIContextHolder uiContextHolder)
        {
            if (uiContextHolder == null) throw new ArgumentNullException(nameof(uiContextHolder));
            
            InitializeComponent();
            
            uiContextHolder.SetContext(SynchronizationContext.Current);
        }
        
        public void ShowView(UserControl view)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));
            
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

        public event Action Initialized = () => {};

        public Form Host => this;

        private void Main_Load(object sender, EventArgs e)
        {
            Initialized();
        }
    }
}