﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Application.Extensions;
using OmegaFY.Blog.Domain.Core.IoC;

namespace OmegaFY.Blog.WebAPI.Configuration
{

    public class MediatorConfiguration : IDependencyInjectionRegister
    {

        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            return services.AddServiceBusMediatR();
        }

    }

}
