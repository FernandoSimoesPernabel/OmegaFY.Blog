using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Common.Constantes;
using OmegaFY.Blog.Domain.Core.IoC;
using OmegaFY.Blog.WebAPI.Filters;
using System.Text.Json.Serialization;

namespace OmegaFY.Blog.WebAPI.Configuration
{

    public class ApiConfiguration : IDependencyInjectionRegister
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

}
