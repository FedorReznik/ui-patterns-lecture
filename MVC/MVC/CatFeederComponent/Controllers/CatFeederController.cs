using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MVC.CatFeederComponent.Models;
using MVC.CatFeederComponent.Views;
using MVC.Engine;

namespace MVC.CatFeederComponent.Controllers
{
    public class CatFeederController : ICatFeederController
    {
        private readonly ICatFeederService _catFeederService;
        private readonly ICatFeederView _view;

        public CatFeederController(
            [NotNull] ICatFeederService catFeederService,
            [NotNull] ICatFeederView view)
        {
            _catFeederService = catFeederService ?? throw new ArgumentNullException(nameof(catFeederService));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            
            _view.AttachController(this);
        }

        public void Feed()
        {
            _view.Block();
            Task.Run(async () => await _catFeederService.Feed())
                .ContinueWith(t =>
                {
                    var feedingResult = t.Result;
                    _view.UnBlock();
                    _view.ProcessFeedingResult(feedingResult);
                });
        }
        
        public IView View()
        {
            return _view;
        }

        public void Dispose()
        {
            _catFeederService.Dispose();
        }
    }
}