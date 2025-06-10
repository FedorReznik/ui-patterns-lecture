using MVC.CatFeederComponent.Controllers;
using MVC.CatFeederComponent.Models;
using MVC.Engine;

namespace MVC.CatFeederComponent.Views
{
    public interface ICatFeederView : IView<ICatFeederController>
    {
        void ProcessFeedingResult(FeedingResult result);
        void Block();
        void UnBlock();
    }
}