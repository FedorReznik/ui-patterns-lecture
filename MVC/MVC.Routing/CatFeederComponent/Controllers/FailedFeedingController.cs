using System;
using JetBrains.Annotations;
using MVC.Routing.CatFeederComponent.Routes;
using MVC.Routing.CatFeederComponent.Views;
using MVC.Routing.Engine;

namespace MVC.Routing.CatFeederComponent.Controllers
{
    public class FailedFeedingController : ControllerBase<IFailedFeedingView>, IFailedFeedingController
    {
        private readonly IRouter _router;

        public FailedFeedingController([NotNull] IRouter router)
        {
            _router = router ?? throw new ArgumentNullException(nameof(router));
        }

        public void Continue()
        {
            _router.NavigateTo<IController>(CatFeederRoutes.CatFeederRoute);
        }

        public void Reason(string reason)
        {
            View?.SetReason(reason);
        }

        public override void Dispose()
        {
            // intentionally left blank
        }
    }
}