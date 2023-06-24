namespace OmegaFY.Blog.Infra.OpenTelemetry.Constants;

public class OpenTelemetryConstants
{
    public const string ACTIVITY_APPLICATION_HANDLER_NAME = "ApplicationHandlers";

    public const string ACTIVITY_BASE_NAME = "omegafy";

    public const string REQUEST_TYPE_KEY = $"{ACTIVITY_BASE_NAME}.request_type";

    public const string RESULT_TYPE_KEY = $"{ACTIVITY_BASE_NAME}.result_type";

    public const string API_ROUTE = "api/";
}