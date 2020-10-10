using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Application.Base;
using OmegaFY.Blog.Domain.Core.IoC;
using OmegaFY.Blog.Domain.Core.Services;

namespace OmegaFY.Blog.WebAPI.Configuration
{

    public class MediatorConfiguration : IDependencyInjectionRegister
    {

        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(System.AppDomain.CurrentDomain.Load("OmegaFY.Blog.Application"));
            services.AddTransient<IServiceBus, MediatorServiceBus>();

            return services.AddMediatR(typeof(Startup));
        }

    }

}
