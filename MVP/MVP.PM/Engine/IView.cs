using System;
using System.Windows.Forms;
using JetBrains.Annotations;

namespace MVP.Engine
{
    public interface IView
    {
        void AttachPresenter([NotNull] IPresenter presenter);
        
        [NotNull]
        UserControl Render();
    }

    public class ViewBase : UserControl, IView
    {
        public ViewBase()
        {
            Disposed += (sender, args) => Presenter?.Dispose();
        }
        
        public void AttachPresenter(IPresenter presenter)
        {
            if(Presenter != null)
                throw new InvalidOperationException($"Presenter is already attached for {GetType()}");

            Presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        }
        
        protected IPresenter Presenter { get; private set; }

        public UserControl Render()
        {
            return this;
        }
    }
}