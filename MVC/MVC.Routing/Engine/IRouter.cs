using System.Threading.Tasks;

namespace MVC.Routing.Engine
{
    public interface IRouter
    {
        Task<TController> NavigateTo<TController>(string url);
        
        Task NavigateTo(string url);
    }
}