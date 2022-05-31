using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OmegaFY.Blog.Infra.Authentication;
using OmegaFY.Blog.Infra.Authentication.Configs;
using OmegaFY.Blog.Infra.Authentication.Token;
using OmegaFY.Blog.Infra.Authentication.Users;
using OmegaFY.Blog.Infra.IoC;
using System.Reflection;
using System.Text;

namespace OmegaFY.Blog.Infra.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDependencyInjectionRegister(this IServiceCollection services, Assembly assembly, IConfiguration configuration)
    {
        assembly?
            .ExportedTypes
            .Where(t => typeof(IDependencyInjectionRegister).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IDependencyInjectionRegister>()
            .ToList()
            .ForEach(iocRegister => iocRegister.Register(services, configuration));

        return services;
    }

    public static IServiceCollection AddIdentityUserConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddHttpContextAccessor();
        services.AddScoped<IUserInformation, HttpContextAccessorUserInformation>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IJwtProvider, JwtSecurityTokenProvider>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configuration["JwtSettings:ValidAudience"],
                ValidIssuer = configuration["JwtSettings:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtSettings:Secret"]))
            };
        });

        return services;
    }

    public static IdentityBuilder AddIdentity(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 10;
            options.Password.RequiredUniqueChars = 1;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            options.Lockout.MaxFailedAccessAttempts = 3;

            options.User.RequireUniqueEmail = true;

            //options.SignIn.RequireConfirmedEmail = true;
            //options.SignIn.RequireConfirmedAccount = true;
        });

        return services.AddIdentity<IdentityUser, IdentityRole>();
    }

    public static IServiceCollection AddDistributedCache(this IServiceCollection services)
    {
        return services.AddDistributedMemoryCache();
    }
}