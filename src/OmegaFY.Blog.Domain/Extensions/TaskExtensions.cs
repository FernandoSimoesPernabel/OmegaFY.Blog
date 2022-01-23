namespace OmegaFY.Blog.Domain.Extensions;

public static class TaskExtensions
{
    public static async void SafeFireAndForget(this Task task, Action<Exception> exceptionHandler = null)
    {
        try
        {
            await task;
        }
        catch (Exception ex) when (exceptionHandler is not null)
        {
            exceptionHandler(ex);
        }
    }
}
