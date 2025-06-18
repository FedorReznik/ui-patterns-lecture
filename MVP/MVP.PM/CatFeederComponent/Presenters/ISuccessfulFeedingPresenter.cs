using System;
using MVP.Engine;

namespace MVP.CatFeederComponent.Presenters
{
    public interface ISuccessfulFeedingPresenter : IPresenter
    {
        void Continue();
        
        string Message { get; set; }
    }
}