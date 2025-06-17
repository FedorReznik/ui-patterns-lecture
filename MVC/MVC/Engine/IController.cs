using System;

namespace MVC.Engine
{
    public interface IController : IDisposable
    {
        IView View();
    }
}