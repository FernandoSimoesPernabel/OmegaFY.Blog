using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Domain.Core.Authentication;
using OmegaFY.Blog.Domain.Core.IoC;

namespace OmegaFY.Blog.WebAPI.Configuration
{

    public class IdentityUserConfiguration : IDependencyInjectionRegister
    {

        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            return services.AddScoped<IUserInformation, User>();
        }

    }

    public class User : IUserInformation
    {
        public System.Guid CurrentRequestUserId { get; set; } = System.Guid.NewGuid();
    }

}
