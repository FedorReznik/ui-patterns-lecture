using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FeederDriver
{
    [PublicAPI]
    public class FeederDriverImpl : IFeederDriver1
    {
        private int _concurrencyLevel;
        
        public async Task Feed()
        {
            var detectedLevelOfConcurrency = Interlocked.Increment(ref _concurrencyLevel);
            
            if(detectedLevelOfConcurrency > 1)
                throw new InvalidOperationException("Cannot feed concurrently!");
            
            await Task.Delay(TimeSpan.FromSeconds(5));
            
            Interlocked.Exchange(ref _concurrencyLevel, 0);
        }
    }
}