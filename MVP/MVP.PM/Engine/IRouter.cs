using System;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using JetBrains.Annotations;

namespace MVP.Engine
{
    public interface IRouter
    {
        Task NavigateTo<T>([NotNull] T presenter) where T : IPresenter;
    }

    public sealed class Router : IRouter
    {
        private readonly IIndex<Type, Func<IView>> _viewFactoriesMap;
        private readonly IUIExecutor _uiExecutor;
        private readonly INavigationHost _navigationHost;

        public Router(
            [NotNull] IIndex<Type, Func<IView>> viewFactoriesMap,
            [NotNull] IUIExecutor uiExecutor,
            [NotNull] INavigationHost navigationHost)
        {
            _viewFactoriesMap = viewFactoriesMap ?? throw new ArgumentNullException(nameof(viewFactoriesMap));
            _uiExecutor = uiExecutor ?? throw new ArgumentNullException(nameof(uiExecutor));
            _navigationHost = navigationHost ?? throw new ArgumentNullException(nameof(navigationHost));
        }

        public async Task NavigateTo<T>(T presenter) where T : IPresenter
        {
            if (presenter == null) throw new ArgumentNullException(nameof(presenter));
            
            if(!_viewFactoriesMap.TryGetValue(typeof(T), out var viewFactory))
                throw new InvalidOperationException($"Presenter '{typeof(T)}' does not mapped to any view");
            
            var view = await _uiExecutor.Execute(() => viewFactory());
            
            view.AttachPresenter(presenter);
            
            _navigationHost.ShowView(view.Render());
        }
    }
}