﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Domain.Core.IoC;
using OmegaFY.Blog.Infra.Extensions;

namespace OmegaFY.Blog.WebAPI.Configuration
{

    public class CacheConfiguration : IDependencyInjectionRegister
    {

        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDistributedMemoryCacheServices(configuration);
        }

    }

}
