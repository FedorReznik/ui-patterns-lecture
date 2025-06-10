using MVC.CatFeederComponent.Controllers;
using MVC.Engine;

namespace MVC.CatFeederComponent.Views
{
    public interface ICatFeederView : IView<ICatFeederController>
    {
        void Block();
        void UnBlock();
    }
}