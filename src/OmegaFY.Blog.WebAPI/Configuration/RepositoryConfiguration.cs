using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Data.EF.Extensions;
using OmegaFY.Blog.Domain.Core.IoC;

namespace OmegaFY.Blog.WebAPI.Configuration
{

    public class RepositoryConfiguration : IDependencyInjectionRegister
    {

        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            return services.AddEntityFrameworkRepositories();
        }

    }

}
