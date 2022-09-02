using MediatR;
using OmegaFY.Blog.Application.Request;
using OmegaFY.Blog.Application.Result;
using OmegaFY.Blog.Infra.OpenTelemetry.Constants;
using System.Diagnostics;

namespace OmegaFY.Blog.Application.Extensions;

internal static class ActivityExtensions
{
    public static Activity SetCurrentRequestTracingInformation(this Activity activity, IRequest<GenericResult> request, GenericResult result)
    {
        activity.SetTag(OpenTelemetryConstants.REQUEST_TYPE_KEY, request.ToString());
        activity.SetTag(OpenTelemetryConstants.RESULT_TYPE_KEY, result.ToString());

        activity.SetStatus(result);

        return activity;
    }

    public static Activity SetStatus(this Activity activity, GenericResult result)
        => result.Succeeded() ? activity.SetStatus(ActivityStatusCode.Ok) : activity.SetStatus(ActivityStatusCode.Error, result.GetErrorsAsStringSeparatedByNewLine());
}