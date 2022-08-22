using OmegaFY.Blog.Application.Result;
using System.Diagnostics;

namespace OmegaFY.Blog.Application.Extensions;

internal static class ActivityExtensions
{
    public static Activity SetGenericResultTracingInformation(this Activity activity, GenericResult result)
    {
        activity.SetStatus(result);

        return activity;
    }

    public static Activity SetStatus(this Activity activity, GenericResult result)
        => result.Succeeded() ? activity.SetStatus(ActivityStatusCode.Ok) : activity.SetStatus(ActivityStatusCode.Error);
}