using System;
using System.Threading.Tasks;

namespace MVP.CatFeederComponent.Models
{
    public interface ICatFeederService : IDisposable
    {
        Task<FeedingResult> Feed();
    }
}