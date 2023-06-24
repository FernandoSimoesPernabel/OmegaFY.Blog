using HealthChecks.UI.Client;
using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Infra.Extensions;
using OmegaFY.Blog.Infra.Logs.KissLog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependencyInjectionRegister(typeof(Program).Assembly, builder);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseKissLogMiddleware(options =>
{
    Application kissLogApplication = new Application(builder.Configuration["KissLog.OrganizationId"], builder.Configuration["KissLog.ApplicationId"]);

    RequestLogsApiListener logListener = new RequestLogsApiListener(kissLogApplication)
    {
        ApiUrl = builder.Configuration["KissLog.ApiUrl"],
        Interceptor = new CustomLogListenerInterceptor(),
        ObfuscationService = new CustomObfuscationService()
    };

    options.Listeners.Add(logListener);
});

app.UseSwagger();

app.UseSwaggerUI();

app.UseHealthChecks(HealthCheckConstants.API_ENDPOINT, new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHealthChecksUI(options => options.UIPath = HealthCheckConstants.UI_ENDPOINT);

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.UseRateLimiter();

app.MapControllers();

app.Run();