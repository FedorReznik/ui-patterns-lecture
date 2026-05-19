using FeederDriver;

namespace MVVM.CatFeederComponent.Models;

public class CatFeederService(ICatFeederDriver catFeederDriver) : ICatFeederService
{
    private readonly ICatFeederDriver _catFeederDriver = catFeederDriver ?? throw new ArgumentNullException(nameof(catFeederDriver));
    private readonly CancellationTokenSource _rootTokenSource = new();

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

    public void Dispose() => 
        _rootTokenSource.Cancel();
}