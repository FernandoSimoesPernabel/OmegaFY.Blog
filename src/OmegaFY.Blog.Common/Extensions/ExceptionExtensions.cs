namespace OmegaFY.Blog.Common.Extensions;

public static class ExceptionExtensions
{
    public static string GetErrorsMessagesFromInnerExceptions(this Exception ex)
    {
        if (ex.InnerException is null)
            return ex.Message;

        return $"{ex.Message}{Environment.NewLine}{ex.InnerException.GetErrorsMessagesFromInnerExceptions()}";
    }
}