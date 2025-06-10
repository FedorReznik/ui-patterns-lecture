using MVC.Routing.CatFeederComponent.Controllers;
using MVC.Routing.Engine;

namespace MVC.Routing.CatFeederComponent.Views
{
    public interface ICatFeederView : IView<ICatFeederController>
    {
        void Block();
        void UnBlock();
    }
}