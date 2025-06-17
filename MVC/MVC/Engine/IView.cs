using System;
using System.Windows.Forms;

namespace MVC.Engine
{
    public interface IView
    {
        UserControl Render();
    }
    
    public interface IView<in TController> : IView
        where TController : IController
    {
        void AttachController(TController controller);
    }
}