using System;
using System.Windows.Forms;

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
                Controls.Clear();
                view.Dock = DockStyle.Fill;
                Controls.Add(view);
            };
            Guard(uiMutation);
        }

        private void Guard(Action uiMutation)
        {
            if (InvokeRequired)
                BeginInvoke(uiMutation);
            else
                uiMutation();
        }
    }
}