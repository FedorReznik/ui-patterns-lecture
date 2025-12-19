using MVP.Engine;

namespace MVP.CatFeederComponent.Presenters
{
    public interface IFailedFeedingPresenter : IPresenter
    {
        ICatFeederPresenter Continue();
        
        string Reason { get; set; }
    }
}