namespace MVVM.CatFeederComponent.Models;

public interface ICatFeederService : IDisposable
{
    Task<FeedingResult> Feed();
}