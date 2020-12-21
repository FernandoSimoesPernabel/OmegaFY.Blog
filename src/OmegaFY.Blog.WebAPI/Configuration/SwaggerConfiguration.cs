using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OmegaFY.Blog.Domain.Core.IoC;

namespace OmegaFY.Blog.WebAPI.Configuration
{

    public class SwaggerConfiguration : IDependencyInjectionRegister
    {

        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen();

            return services;
        }

    }

}
