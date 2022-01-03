using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Data.EF.UoW;
using OmegaFY.Blog.Domain.Repositories;

namespace OmegaFY.Blog.Data.EF.Extensions;

public static class EFServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
