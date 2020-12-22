using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Application.Queries.Interfaces;
using OmegaFY.Blog.Data.EF.Queries;
using OmegaFY.Blog.Data.EF.Repositories;
using OmegaFY.Blog.Data.EF.UoW;
using OmegaFY.Blog.Domain.Core.Repositories;
using OmegaFY.Blog.Domain.Repositories;

namespace OmegaFY.Blog.Data.EF.Extensions
{

    public static class EFServiceCollectionExtensions
    {

        public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPostagemRepository, PostagemRepository>();
            services.AddScoped<IPostagemQuery, PostagemQuery>();
            return services;
        }

    }

}
