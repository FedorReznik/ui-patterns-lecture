using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FeederDriver
{
    [PublicAPI]
    public interface IFeederDriver1
    {
        Task Feed();
    }
}