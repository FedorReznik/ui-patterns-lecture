using System;
using JetBrains.Annotations;
using MVC.Routing.CatFeederComponent.Routes;
using MVC.Routing.CatFeederComponent.Views;
using MVC.Routing.Engine;

namespace MVC.Routing.CatFeederComponent.Controllers
{
    public class SuccessfulFeedingController : ControllerBase<ISuccessfulFeedingView>, ISuccessfulFeedingController
    {
        private readonly IRouter _router;

        public SuccessfulFeedingController([NotNull] IRouter router)
        {
            _router = router ?? throw new ArgumentNullException(nameof(router));
        }

        public void Continue()
        {
            _router.NavigateTo<IController>(CatFeederRoutes.CatFeederRoute);
        }

        public void Message(string message)
        {
            View?.SetMessage(message);
        }
        
        public override void Dispose()
        {
            // intentionally left blank
        }
    }
}