using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Common.Enums;
using OmegaFY.Blog.Data.EF.Context;

namespace OmegaFY.Blog.WebAPI.Configuration.Strategy
{

    public class EntityFrameworkStrategy
    {

        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration, DatabaseStrategy databaseStrategy)
        {
            return services.AddDbContext<ApplicationContext>(options =>
            {
                if (databaseStrategy == DatabaseStrategy.InMemoryDB)
                    options.UseInMemoryDatabase(nameof(DatabaseStrategy.InMemoryDB));
                else
                    options.UseSqlServer(configuration.GetConnectionString("BlogDatabase"), sqlConfig => sqlConfig.MaxBatchSize(1));
            });
        }

    }

}
