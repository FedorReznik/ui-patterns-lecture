using System;
using JetBrains.Annotations;
// ReSharper disable UnusedTypeParameter

namespace MVC.Routing.Engine
{
    public interface IController : IDisposable
    {
        void AttachView(IView view);
    }

    public interface IController<TView> : IController
        where TView : IView
    {
    }

    public abstract class ControllerBase<TView> : IController<TView>
        where TView : IView
    {
        [CanBeNull] 
        protected TView View { get; private set; }
        
        public void AttachView(IView view)
        {
            if(View != null)
                throw new InvalidOperationException($"Controller is already attached for {GetType()}");

            if (view == null)
                throw new ArgumentNullException(nameof(view));
                    
            var typedView = (TView)view;
            
            View = typedView;
        }

        public abstract void Dispose();
    }
}