using System.Threading;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Domain.Core.Services
{

    public interface ICacheServices
    {

        public Task<string> GetStringAsync(string key, CancellationToken token);

        public Task SetStringAsync(string key, string value, CancellationToken token);

    }

}
