using System;
using MVP.Engine;

namespace MVP.CatFeederComponent.Presenters
{
    public interface ISuccessfulFeedingPresenter : IPresenter
    {
        ICatFeederPresenter Continue();
        
        string Message { get; set; }
    }
}