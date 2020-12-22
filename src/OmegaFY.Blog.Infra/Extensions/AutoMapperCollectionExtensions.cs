using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Domain.Core.Services;
using OmegaFY.Blog.Infra.Services;

namespace OmegaFY.Blog.Infra.Extensions
{

    public static class AutoMapperCollectionExtensions
    {

        public static IServiceCollection AddAutoMapperMapperServices(this IServiceCollection services)
        {
            services.AddScoped<IMapperServices, MapperServicesAutoMapper>();
            services.AddAutoMapper(typeof(AutoMapperCollectionExtensions));

            return services;
        }

    }

}
