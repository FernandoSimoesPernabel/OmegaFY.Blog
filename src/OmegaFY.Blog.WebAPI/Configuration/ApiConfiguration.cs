using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.Configuration
{

    public class ApiConfiguration : IDependencyInjectionRegister
    {

        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            return services;
        }

    }

}
