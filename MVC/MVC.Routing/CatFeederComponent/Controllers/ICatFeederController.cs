using MVC.Routing.CatFeederComponent.Views;
using MVC.Routing.Engine;

namespace MVC.Routing.CatFeederComponent.Controllers
{
    public interface ICatFeederController : IController<ICatFeederView>
    {
        void Feed();
    }
}