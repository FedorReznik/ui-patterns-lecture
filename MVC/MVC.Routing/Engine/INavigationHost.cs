using System.Windows.Forms;

namespace MVC.Routing.Engine
{
    public interface INavigationHost
    {
        void NavigateTo(UserControl view);
        
        Form Host { get; }
    }
}