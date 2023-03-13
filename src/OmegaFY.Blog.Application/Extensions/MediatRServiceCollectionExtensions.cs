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

        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(typeof(MediatRServiceCollectionExtensions).Assembly);

            options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(OpenTelemetryInstrumentationBehavior<,>));
            options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationRequestBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(MediatRServiceCollectionExtensions).Assembly);

        return services;
    }
}