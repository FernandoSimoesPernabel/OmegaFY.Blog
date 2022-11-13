using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Data.EF.Extensions;
using OmegaFY.Blog.Infra.Extensions;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class HealthCheckRegistration : IDependencyInjectionRegister
{
    public void Register(WebApplicationBuilder builder)
    {
        //TODO .NET 7 parou de funcionar

        //builder.Services.AddHealthChecks().AddSqlLiteHealthCheck(builder.Configuration);

        //builder.Services.AddHealthChecksUI(options =>
        //{
        //    options.SetEvaluationTimeInSeconds(10);
        //    options.SetMinimumSecondsBetweenFailureNotifications(20);

        //    options.AddHealthCheckEndpoint(ApplicationInfoConstants.APPLICATION_NAME, HealthCheckConstants.API_ENDPOINT);
        //}).AddInMemoryStorage();
    }
}