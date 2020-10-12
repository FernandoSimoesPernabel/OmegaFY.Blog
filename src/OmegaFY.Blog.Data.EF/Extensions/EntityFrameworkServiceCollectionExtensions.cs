using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Data.EF.Repositories.Postagens;
using OmegaFY.Blog.Domain.Repositories;

namespace OmegaFY.Blog.Data.EF.Extensions
{

    public static class EFServiceCollectionExtensions
    {

        public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPostagemRepository, PostagemRepository>();
            return services;
        }

    }

}
