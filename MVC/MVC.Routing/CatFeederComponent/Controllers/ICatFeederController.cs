using MVC.Routing.Engine;

namespace MVC.Routing.CatFeederComponent.Controllers
{
    public interface ICatFeederController : IController
    {
        void Feed();
    }
}