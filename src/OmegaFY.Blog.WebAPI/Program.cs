using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependencyInjectionRegister(typeof(Program).Assembly, builder);

var app = builder.Build();

// Configure the HTTP request pipeline.

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

app.MapControllers();

app.Run();