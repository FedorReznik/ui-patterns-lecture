using MVC.Routing.CatFeederComponent.Controllers;
using MVC.Routing.Engine;

namespace MVC.Routing.CatFeederComponent.Views
{
    public interface ISuccessfulFeedingView : IView<ISuccessfulFeedingController>
    {
        void SetMessage(string message);
    }
}