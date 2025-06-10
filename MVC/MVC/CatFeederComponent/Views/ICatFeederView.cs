using MVC.CatFeederComponent.Controllers;
using MVC.Engine;

namespace MVC.CatFeederComponent.Views
{
    public interface ICatFeederView : IView<ICatFeederController>
    {
        void NotifyFeedingCompleted(string message);
        void NotifyError(string error);
        void Block();
        void UnBlock();
    }
}