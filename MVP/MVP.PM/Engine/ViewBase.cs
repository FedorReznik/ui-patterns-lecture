using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace MVP.Engine
{
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    public class ViewBase : UserControl, IView
    {
        private IPresenter _attachedPresenter;

        // Required to be public for WinForms designer to work
        public ViewBase()
        {
            Disposed += (sender, args) => AttachedPresenter?.Dispose();
        }
        
        public void AttachPresenter(IPresenter presenter)
        {
            if(AttachedPresenter != null)
                throw new InvalidOperationException($"Presenter is already attached for {GetType()}");

            AttachedPresenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
        }

        protected IPresenter AttachedPresenter
        {
            get => _attachedPresenter;
            private set
            {
                _attachedPresenter = value;
                OnPresenterAttached();
            }
        }

        protected virtual void OnPresenterAttached()
        {
            // intentionally left blank
        }

        public UserControl Render()
        {
            return this;
        }
    }
}