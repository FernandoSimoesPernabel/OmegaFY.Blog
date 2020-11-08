using System;
using System.Threading.Tasks;

namespace OmegaFY.Blog.Common.Extensions
{

    public static class TaskExtensions
    {

        public static async void SafeFireAndForget(this Task task, Action<Exception> exceptionHandler = null)
        {

            try
            {
                await task;
            }
            catch (Exception ex) when (exceptionHandler != null)
            {
                exceptionHandler(ex);
            }

        }

    }

}
