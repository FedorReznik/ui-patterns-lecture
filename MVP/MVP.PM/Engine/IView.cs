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

    public interface IView<T> : IView
        where T : IPresenter
    {
        [UsedImplicitly]
        T Presenter { get; }
    }
}