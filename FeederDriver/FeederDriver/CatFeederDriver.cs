using System;
using System.IO;
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
            
            // Feeder cannot execute feeding concurrently
            if(detectedLevelOfConcurrency > 1)
                throw new InvalidOperationException("Cannot feed concurrently!");

            try
            {
                await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken);
            }
            catch (TaskCanceledException)
            {
                // NOTE: As this sample code is artificial we are trying to model the absence of memory leak during shut down
                // by expecting the log entry in case the task was canceled
                using (var file = new FileStream("feeder.log", FileMode.Append))
                using (var writer = new StreamWriter(file))
                {
                    await writer.WriteLineAsync($"{DateTime.UtcNow:s}: Feeding cancelled gracefully - no memory leak");
                }
            }
            
            Interlocked.Exchange(ref _concurrencyLevel, 0);
        }
    }
}