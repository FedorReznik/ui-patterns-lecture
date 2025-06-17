using MVC.Routing.CatFeederComponent.Controllers;
using MVC.Routing.Engine;

namespace MVC.Routing.CatFeederComponent.Views
{
    public interface IFailedFeedingView : IView<IFailedFeedingController>
    {
        void SetReason(string reason);
    }
}