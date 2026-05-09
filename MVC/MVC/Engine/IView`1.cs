namespace MVC.Engine
{
    public interface IView<in TController> : IView
        where TController : IController
    {
        void AttachController(TController controller);
    }
}