using MediatR;
using OmegaFY.Blog.Application.Extensions;
using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Infra.OpenTelemetry;
using System.Diagnostics;

namespace OmegaFY.Blog.Application.PipelineBehaviors;

public class OpenTelemetryInstrumentationBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult> where TRequest : IRequest<TResult> where TResult : GenericResult
{
    private readonly IOpenTelemetryRegisterProvider _openTelemetryRegisterProvider;

    public OpenTelemetryInstrumentationBehavior(IOpenTelemetryRegisterProvider openTelemetryRegisterProvider)
        => _openTelemetryRegisterProvider = openTelemetryRegisterProvider;

    public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResult> next)
    {
        using Activity activity = _openTelemetryRegisterProvider.StartActivity("ApplicationHandlers");
        
        TResult result = await next();

        activity.SetGenericResultTracingInformation(result);

        return result;
    }
}