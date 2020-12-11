using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Application.PipelineBehaviors;
using OmegaFY.Blog.Domain.Core.Services;

namespace OmegaFY.Blog.Application.Extensions
{

    public static class MediatRServiceCollectionExtensions
    {

        public static IServiceCollection AddServiceBusMediatR(this IServiceCollection services)
        {
            services.AddScoped<IServiceBus, MediatorServiceBus>();

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationRequestBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

            services.AddMediatR(typeof(MediatRServiceCollectionExtensions).Assembly);

            return services;
        }

    }

}
