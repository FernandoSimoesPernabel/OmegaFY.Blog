namespace OmegaFY.Blog.WebAPI.Middlewares.Base;

public abstract class MiddlewareBase
{
    protected readonly RequestDelegate _next;

    public MiddlewareBase(RequestDelegate next) => _next = next;

    public abstract Task InvokeAsync(HttpContext httpContext);
}
