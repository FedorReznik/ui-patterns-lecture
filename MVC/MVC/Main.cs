using System;
using System.ComponentModel;
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
                Controls.Clear();
                view.Dock = DockStyle.Fill;
                Controls.Add(view);
            };
            
            this.Guard(uiMutation);
        }
    }
}