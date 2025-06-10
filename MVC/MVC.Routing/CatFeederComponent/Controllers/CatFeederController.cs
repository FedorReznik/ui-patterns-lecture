using System;
using JetBrains.Annotations;
using MVC.Routing.CatFeederComponent.Models;
using MVC.Routing.CatFeederComponent.Views;
using MVC.Routing.Engine;

namespace MVC.Routing.CatFeederComponent.Controllers
{
    public class CatFeederController : ControllerBase<ICatFeederView>, ICatFeederController
    {
        private readonly ICatFeederService _catFeederService;

        public CatFeederController([NotNull] ICatFeederService catFeederService)
        {
            _catFeederService = catFeederService ?? throw new ArgumentNullException(nameof(catFeederService));
        }

        public void Feed()
        {
            throw new NotImplementedException();
        }
        
        public override void Dispose()
        {
            _catFeederService.Dispose();
        }
    }
}