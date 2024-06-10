using MediatR;
using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Infra.OpenTelemetry.Constants;
using System.Diagnostics;

namespace OmegaFY.Blog.Application.Extensions;

internal static class ActivityExtensions
{
    public static void SetCurrentRequestTracingInformation(this Activity activity, IRequest<GenericResult> request, GenericResult result)
    {
        activity.SetTag(OpenTelemetryConstants.REQUEST_CONTENT_KEY, request.ToString());
        activity.SetTag(OpenTelemetryConstants.RESULT_CONTENT_KEY, result.ToString());

        activity.SetStatus(result);
    }

    public static void SetStatus(this Activity activity, GenericResult result)
    {
        if (result.Succeeded())
        {
            activity.SetStatus(ActivityStatusCode.Ok);
            return;
        };

        activity.SetStatus(ActivityStatusCode.Error, result.GetErrorsAsStringSeparatedByNewLine());
    }
}