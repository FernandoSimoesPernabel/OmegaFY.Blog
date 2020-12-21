using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Common.Enums;
using OmegaFY.Blog.Domain.Core.IoC;
using OmegaFY.Blog.WebAPI.Configuration.Options;
using OmegaFY.Blog.WebAPI.Configuration.Strategy;
using OmegaFY.Blog.WebAPI.Extensions;
using System;

namespace OmegaFY.Blog.WebAPI.Configuration
{

    public class DatabaseConfiguration : IDependencyInjectionRegister
    {

        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            DatabaseConfigurationOptions databaseOptions = configuration.ReadDatabaseOptionsFromAppSettings();

            switch (databaseOptions.DatabaseAccessObjectStrategy)
            {
                case DatabaseAccessObjectStrategy.EntityFramework:

                    switch (databaseOptions.DatabaseStrategy)
                    {
                        case DatabaseStrategy.InMemoryDB:
                        case DatabaseStrategy.SqlServer:
                        case DatabaseStrategy.SQLite:
                            new EntityFrameworkStrategy().Register(services, configuration, databaseOptions);
                            break;

                        default:
                            throw new ArgumentException("Não foi possível recuperar a estratégia de qual banco de dados utilizar!");
                    }

                    break;

                case DatabaseAccessObjectStrategy.Dapper:

                    switch (databaseOptions.DatabaseStrategy)
                    {
                        case DatabaseStrategy.SqlServer:
                        case DatabaseStrategy.SQLite:
                            //new DapperStrategy().Register(services, configuration, databaseOptions);
                            break;

                        default:
                            throw new ArgumentException("Não foi possível recuperar a estratégia de qual banco de dados utilizar!");
                    }

                    break;

                case DatabaseAccessObjectStrategy.MongoDriver:

                    switch (databaseOptions.DatabaseStrategy)
                    {
                        case DatabaseStrategy.MongoDB:
                            //new MongoDriverStrategy().Register(services, configuration, databaseOptions);
                            break;

                        default:
                            throw new ArgumentException("Não foi possível recuperar a estratégia de qual banco de dados utilizar!");
                    }

                    break;

                default:
                    throw new ArgumentException("Não foi possível recuperar a estratégia de qual banco de dados utilizar!");
            }

            return services;
        }

    }

}
