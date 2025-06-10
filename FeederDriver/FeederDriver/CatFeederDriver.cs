using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FeederDriver
{
    [PublicAPI]
    public class CatFeederDriver : ICatFeederDriver
    {
        private int _concurrencyLevel;
        
        public async Task Feed(CancellationToken cancellationToken)
        {
            var detectedLevelOfConcurrency = Interlocked.Increment(ref _concurrencyLevel);
            
            if(detectedLevelOfConcurrency > 1)
                throw new InvalidOperationException("Cannot feed concurrently!");

            try
            {
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
            catch (TaskCanceledException)
            {
                Debug.Print("Feeding is cancelled");
            }
            
            Interlocked.Exchange(ref _concurrencyLevel, 0);
        }
    }
}