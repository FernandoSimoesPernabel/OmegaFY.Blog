using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Common.Enums;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.WebAPI.Configuration.Options;

namespace OmegaFY.Blog.WebAPI.Configuration.Strategy
{

    public class EntityFrameworkStrategy
    {

        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration, DatabaseConfigurationOptions databaseOptions)
        {
            return services.AddDbContext<ApplicationContext>(options =>
            {
                if (databaseOptions.DatabaseStrategy == DatabaseStrategy.InMemoryDB)
                    options.UseInMemoryDatabase(databaseOptions.DatabaseName);
                else
                    options.UseSqlServer(configuration.GetConnectionString(databaseOptions.SqlServerConnectionStringName),
                                         sqlConfig => sqlConfig.MaxBatchSize(5));
            });
        }

    }

}
