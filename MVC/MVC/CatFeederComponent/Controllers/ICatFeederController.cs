using MVC.Engine;

namespace MVC.CatFeederComponent.Controllers
{
    public interface ICatFeederController : IController
    {
        void Feed();
    }
}