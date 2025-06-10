using System;
using System.Threading.Tasks;
using MVC.CatFeederComponent.Views;
using MVC.Engine;

namespace MVC.CatFeederComponent.Controllers
{
    public class CatFeederController : ICatFeederController
    {
        private readonly ICatFeederView _view;

        public CatFeederController(ICatFeederView view)
        {
            _view = view;
            _view.AttachController(this);
        }

        public IView View()
        {
            return _view;
        }

        public void Feed()
        {
            _view.Block();
            Task.Run(async () => await Task.Delay(TimeSpan.FromSeconds(5)))
                .ContinueWith(t =>
                {
                    t.Wait();
                    _view.UnBlock();
                });
        }

        public void Dispose()
        {
            // TODO: [FR] dispose model services.
        }
    }
}