using System.Windows.Forms;

namespace MVC.Routing.Engine
{
    public interface INavigationHost
    {
        void ShowView(UserControl view);
        
        Form Host { get; }
    }
}