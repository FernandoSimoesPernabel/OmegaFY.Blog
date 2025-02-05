using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Infra.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjectionRegister(typeof(Program).Assembly, builder);

WebApplication app = builder.Build();

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