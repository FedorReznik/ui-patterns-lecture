using System;
using System.Threading;
using System.Threading.Tasks;
using FeederDriver;
using JetBrains.Annotations;

namespace MVP.CatFeederComponent.Models
{
    public class CatFeederService : ICatFeederService
    {
        private readonly ICatFeederDriver _catFeederDriver;
        private readonly CancellationTokenSource _rootTokenSource = new CancellationTokenSource();

        public CatFeederService([NotNull] ICatFeederDriver catFeederDriver)
        {
            _catFeederDriver = catFeederDriver ?? throw new ArgumentNullException(nameof(catFeederDriver));
        }

        public async Task<FeedingResult> Feed()
        {
            var cancellationToken = CancellationTokenSource
                .CreateLinkedTokenSource(_rootTokenSource.Token)
                .Token;

            try
            {
                await _catFeederDriver.Feed(cancellationToken);
                return new FeedingResult("The cat is successfully fed!", true);
            }
            catch (OperationCanceledException)
            {
                return new FeedingResult("Feeding canceled", false);
            }
            catch (Exception e)
            {
                return new FeedingResult(e.Message, false);
            }
        }

        public void Dispose()
        {
            _rootTokenSource.Cancel();
        }
    }
}