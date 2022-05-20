using OmegaFY.Blog.Domain.Authentication;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class IdentityUserConfiguration : IDependencyInjectionRegister
{
    public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
    {
        return services.AddScoped<IUserInformation, HttpRequestUserInformation>();
    }
}

public class HttpRequestUserInformation : IUserInformation
{
    public System.Guid CurrentRequestUserId { get; set; } = System.Guid.NewGuid();
}
