using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OmegaFY.Blog.Infra.IoC
{

    public interface IDependencyInjectionRegister
    {
        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration);
    }

}
