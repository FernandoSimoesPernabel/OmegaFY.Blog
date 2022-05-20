using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class SwaggerOpenAPIConfiguration : IDependencyInjectionRegister
{
    public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
