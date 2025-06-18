using MVP.Engine;

namespace MVP.CatFeederComponent.Presenters
{
    public interface IFailedFeedingPresenter : IPresenter
    {
        void Continue();
        
        string Reason { get; set; }
    }
}