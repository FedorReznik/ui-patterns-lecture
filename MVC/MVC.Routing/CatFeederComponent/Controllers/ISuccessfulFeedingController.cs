using MVC.Routing.CatFeederComponent.Views;
using MVC.Routing.Engine;

namespace MVC.Routing.CatFeederComponent.Controllers
{
    public interface ISuccessfulFeedingController : IController<ISuccessfulFeedingView>
    {
        void Continue();
        
        void Message(string message);
    }
}