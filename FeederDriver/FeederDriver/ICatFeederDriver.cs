using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FeederDriver
{
    [PublicAPI]
    public interface ICatFeederDriver
    {
        Task Feed(CancellationToken cancellationToken);
    }
}