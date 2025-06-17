using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MVC.Routing.CatFeederComponent.Models;
using MVC.Routing.CatFeederComponent.Routes;
using MVC.Routing.CatFeederComponent.Views;
using MVC.Routing.Engine;

namespace MVC.Routing.CatFeederComponent.Controllers
{
    public class CatFeederController : ControllerBase<ICatFeederView>, ICatFeederController
    {
        private readonly ICatFeederService _catFeederService;
        private readonly IRouter _router;

        public CatFeederController(
            [NotNull] ICatFeederService catFeederService,
            [NotNull] IRouter router)
        {
            _catFeederService = catFeederService ?? throw new ArgumentNullException(nameof(catFeederService));
            _router = router ?? throw new ArgumentNullException(nameof(router));
        }

        public void Feed()
        {
            View?.Block();
            Task.Run(async () =>
            {
                var result = await _catFeederService.Feed();
                View?.UnBlock();
                if (result.Successful)
                {
                    var successfulController = await _router.NavigateTo<ISuccessfulFeedingController>(CatFeederRoutes.CatFedRoute);
                    successfulController.Message(result.Message);
                }
                else
                {
                    var failedFeedingController = await _router.NavigateTo<IFailedFeedingController>(CatFeederRoutes.CatFeedingFailedRoute);
                    failedFeedingController.Reason(result.Message);
                }
            });
        }
        
        public override void Dispose()
        {
            _catFeederService.Dispose();
        }
    }
}