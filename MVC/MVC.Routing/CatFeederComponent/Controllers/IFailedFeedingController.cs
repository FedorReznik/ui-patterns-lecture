using MVC.Routing.CatFeederComponent.Views;
using MVC.Routing.Engine;

namespace MVC.Routing.CatFeederComponent.Controllers
{
    public interface IFailedFeedingController : IController<IFailedFeedingView>
    {
        void Continue();
        
        void Reason(string reason);
    }
}