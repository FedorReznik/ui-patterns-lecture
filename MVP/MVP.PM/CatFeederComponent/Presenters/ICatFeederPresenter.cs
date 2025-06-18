using System;
using MVP.Engine;

namespace MVP.CatFeederComponent.Presenters
{
    public interface ICatFeederPresenter : IPresenter
    {
        void Feed();
        
        IObservable<bool> IsBusy { get; }
        
        IObservable<ISuccessfulFeedingPresenter> SuccessfulFeeding { get; }
        
        IObservable<IFailedFeedingPresenter> FailedFeeding { get; }
    }
}