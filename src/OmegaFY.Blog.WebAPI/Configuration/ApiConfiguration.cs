using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            return services;
        }

    }

}
