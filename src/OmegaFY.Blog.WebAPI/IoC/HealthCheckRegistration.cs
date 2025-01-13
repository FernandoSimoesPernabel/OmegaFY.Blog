using OmegaFY.Blog.Common.Configs;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Data.EF.Extensions;
using OmegaFY.Blog.Data.MongoDB.Extensions;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class HealthCheckRegistration : IDependencyInjectionRegister
{
    public void Register(WebApplicationBuilder builder)
    {
        DatabaseOptions database = builder.Configuration.GetDatabaseConfig();

        builder.Services.AddHealthChecks()
            .AddSqliteHealthCheck(builder.Configuration)
            .AddSqlServerHealthCheck(builder.Configuration);

        builder.Services.AddHealthChecksUI(options =>
        {
            options.SetEvaluationTimeInSeconds(600);
            options.SetMinimumSecondsBetweenFailureNotifications(30);

            options.AddHealthCheckEndpoint(ApplicationInfoConstants.APPLICATION_NAME, HealthCheckConstants.API_ENDPOINT);
        }).AddInMemoryStorage();
    }
}