using System;
using System.Threading.Tasks;

namespace MVC.Routing.CatFeederComponent.Models
{
    public interface ICatFeederService : IDisposable
    {
        Task<FeedingResult> Feed();
    }
}