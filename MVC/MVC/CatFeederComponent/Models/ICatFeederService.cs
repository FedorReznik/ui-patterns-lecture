using System;
using System.Threading.Tasks;

namespace MVC.CatFeederComponent.Models
{
    public interface ICatFeederService : IDisposable
    {
        Task<FeedingResult> Feed();
    }
}