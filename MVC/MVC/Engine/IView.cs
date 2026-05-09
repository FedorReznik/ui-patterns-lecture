using System.Windows.Forms;

namespace MVC.Engine
{
    public interface IView
    {
        UserControl Render();
    }
}