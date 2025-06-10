using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using JetBrains.Annotations;
// ReSharper disable UnusedTypeParameter

namespace MVC.Routing.Engine
{
    public interface IView
    {
        void AttachController(IController controller);
    }

    public interface IView<in TController> : IView 
        where TController : IController
    {
    }

    [SuppressMessage("ReSharper", "PublicConstructorInAbstractClass")]
    public abstract class ViewBase<TController> : UserControl, IView<TController> 
        where TController : IController
    {
        // Required to be public for WinForms designer to work
        public ViewBase()
        {
            Disposed += (sender, args) => Controller?.Dispose();
        }

        [CanBeNull] 
        protected TController Controller { get; private set; }

        public void AttachController(IController controller)
        {
            if(Controller != null)
                throw new InvalidOperationException($"Controller is already attached for {GetType()}");

            if (controller == null)
                throw new ArgumentNullException(nameof(controller));
                    
            var typedController = (TController)controller;
            
            Controller = typedController;
        }
    }
}