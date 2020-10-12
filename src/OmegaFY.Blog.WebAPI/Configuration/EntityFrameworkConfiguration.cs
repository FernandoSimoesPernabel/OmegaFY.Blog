using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmegaFY.Blog.Data.EF.Context;
using OmegaFY.Blog.Domain.Core.IoC;

namespace OmegaFY.Blog.WebAPI.Configuration
{

    public class EntityFrameworkConfiguration : IDependencyInjectionRegister
    {

        public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<ApplicationContext>(options =>
            {
                //options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlConfig => sqlConfig.MaxBatchSize(1));
                options.UseInMemoryDatabase("InMemoryDatabase");
            });
        }

    }

}
