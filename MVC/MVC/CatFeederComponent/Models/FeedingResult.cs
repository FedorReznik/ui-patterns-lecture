namespace MVC.CatFeederComponent.Models
{
    public struct FeedingResult
    {
        public FeedingResult(string message, bool successful)
        {
            Message = message;
            Successful = successful;
        }
        
        public string Message { get; }
        public bool Successful { get; }
    }
}