using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Domain.Constantes;
using OmegaFY.Blog.Infra.IoC;
using OmegaFY.Blog.WebAPI.FIlters;
using System.Text.Json.Serialization;

namespace OmegaFY.Blog.WebAPI.IoC;

public class WebApiConfiguration : IDependencyInjectionRegister
{
    public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddControllers(controllerOptions =>
            {
                controllerOptions.Filters.Add(new ApiResponseActionFilter());
                controllerOptions.Filters.Add(new ErrorHandlerExceptionFilter());
                controllerOptions.SuppressAsyncSuffixInActionNames = false;
            })
            .AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
                jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = ApiVersion.Default;
            options.ApiVersionReader = new MediaTypeApiVersionReader(HttpHeadersConstantes.HTTP_API_VERSION_HEADER);
            options.ReportApiVersions = true;
        });

        return services;
    }
}