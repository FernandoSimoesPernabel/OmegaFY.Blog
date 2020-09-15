using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.Configuration
{

    public class MediatorConfiguration : IDependencyInjectionRegister
    {

        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            return services.AddMediatR(typeof(Startup));
        }

    }

}
