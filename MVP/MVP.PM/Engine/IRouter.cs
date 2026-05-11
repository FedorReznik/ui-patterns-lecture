using System.Threading.Tasks;
using JetBrains.Annotations;

namespace MVP.Engine
{
    public interface IRouter
    {
        Task NavigateTo<T>([NotNull] T presenter) where T : IPresenter;
    }
}