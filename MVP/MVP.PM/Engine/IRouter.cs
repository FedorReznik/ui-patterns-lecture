using System.Threading.Tasks;

namespace MVP.Engine
{
    public interface IRouter
    {
        Task NavigateTo<T>(T presenter) where T : IPresenter;
    }

    public sealed class Router : IRouter
    {
        public Task NavigateTo<T>(T presenter) where T : IPresenter
        {
            throw new System.NotImplementedException();
        }
    }
}