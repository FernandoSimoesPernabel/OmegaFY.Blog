using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Common.Enums;
using OmegaFY.Blog.Domain.Core.IoC;
using OmegaFY.Blog.WebAPI.Configuration.Strategy;
using System;

namespace OmegaFY.Blog.WebAPI.Configuration
{

    public class DatabaseConfiguration : IDependencyInjectionRegister
    {

        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            DatabaseStrategy databaseStrategy = DatabaseStrategy.SqlServer;

            switch (databaseStrategy)
            {
                case DatabaseStrategy.InMemoryDB:
                case DatabaseStrategy.SqlServer:
                    new EntityFrameworkStrategy().Register(services, configuration, databaseStrategy);
                    break;
                case DatabaseStrategy.MongoDB:
                    break;
                case DatabaseStrategy.SQLite:
                    break;
                default:
                    throw new ArgumentException("Não foi possível recuperar a estratégia de qual banco de dados utilizar!");
            }

            return services;
        }

    }

}
