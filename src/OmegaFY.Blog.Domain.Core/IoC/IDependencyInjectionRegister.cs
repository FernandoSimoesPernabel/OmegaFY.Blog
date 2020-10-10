using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OmegaFY.Blog.Domain.Core.IoC
{

    public interface IDependencyInjectionRegister
    {
        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration);
    }

}
