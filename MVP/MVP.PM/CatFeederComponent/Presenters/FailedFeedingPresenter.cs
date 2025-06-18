namespace MVP.CatFeederComponent.Presenters
{
    public class FailedFeedingPresenter : IFailedFeedingPresenter
    {
        public void Continue()
        {
            throw new System.NotImplementedException();
        }

        public string Reason { get; set; }
        
        public void Dispose()
        {
            // intentionally left blank
        }
    }
}