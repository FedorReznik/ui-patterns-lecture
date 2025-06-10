using System;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using JetBrains.Annotations;

namespace MVC.Routing.Engine
{
    public interface IRouter
    {
        Task<TController> NavigateTo<TController>(string url);
    }

    public sealed class Router : IRouter
    {
        private readonly IIndex<string, Func<IController>> _controllerFactoriesMap;
        private readonly IIndex<string, Func<IView>> _viewFactoriesMap;
        private readonly INavigationHost _navigationHost;
        private readonly IUIExecutor _uiExecutor;

        public Router(
            [NotNull] IIndex<string, Func<IController>> controllerFactoriesMap,
            [NotNull] IIndex<string, Func<IView>> viewFactoriesMap,
            [NotNull] INavigationHost navigationHost,
            [NotNull] IUIExecutor uiExecutor)
        {
            _controllerFactoriesMap = controllerFactoriesMap ?? throw new ArgumentNullException(nameof(controllerFactoriesMap));
            _viewFactoriesMap = viewFactoriesMap ?? throw new ArgumentNullException(nameof(viewFactoriesMap));
            _navigationHost = navigationHost ?? throw new ArgumentNullException(nameof(navigationHost));
            _uiExecutor = uiExecutor ?? throw new ArgumentNullException(nameof(uiExecutor));
        }

        public async Task<TController> NavigateTo<TController>(string url)
        {
            if(!_controllerFactoriesMap.TryGetValue(url, out var controllerFactory))
                throw new InvalidOperationException($"Url '{url}' does not mapped to any controller");
            
            if(!_viewFactoriesMap.TryGetValue(url, out var viewFactory))
                throw new InvalidOperationException($"View '{url}' does not mapped to any view");

            var controller = controllerFactory();
            var view = await _uiExecutor.Execute(() => viewFactory());
            
            controller.AttachView(view);
            view.AttachController(controller);
            
            _navigationHost.ShowView(view.Render());
            
            return (TController)controller;
        }
    }
}