using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Application.Bus;
using OmegaFY.Blog.Application.PipelineBehaviors;

namespace OmegaFY.Blog.Application.Extensions;

public static class MediatRServiceCollectionExtensions
{
    public static IServiceCollection AddServiceBusMediatR(this IServiceCollection services)
    {
        services.AddScoped<IServiceBus, MediatorServiceBus>();

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(OpenTelemetryInstrumentationBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationRequestBehavior<,>));

        services.AddMediatR(typeof(MediatRServiceCollectionExtensions).Assembly);

        services.AddValidatorsFromAssembly(typeof(MediatRServiceCollectionExtensions).Assembly);

        return services;
    }
}