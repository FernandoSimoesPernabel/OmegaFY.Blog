using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Domain.Core.IoC;
using System;
using System.Linq;
using System.Reflection;

namespace OmegaFY.Blog.WebAPI.Extensions
{

    public static class DependencyInjectionExtensions
    {

        public static void AddDependencyInjectionRegister(this IServiceCollection services, Assembly assembly, IConfiguration configuration)
        {
            assembly?
                .ExportedTypes
                .Where(t => typeof(IDependencyInjectionRegister).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IDependencyInjectionRegister>()
                .ToList()
                .ForEach(iocRegister => iocRegister.Register(services, configuration));
        }

    }

}
