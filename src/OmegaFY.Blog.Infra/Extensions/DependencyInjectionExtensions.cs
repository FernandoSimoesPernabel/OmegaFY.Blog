using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

        services.AddAuthorization(auth =>
        {
            auth.AddBearerJwtPolicy();
        });

        JwtSettings jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();

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
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = jwtSettings.ValidAudience,
                ValidIssuer = jwtSettings.ValidIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret))
            };
        });

        return services;
    }

    public static IdentityBuilder AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        AuthenticationSettings authSettings = configuration.GetSection(nameof(AuthenticationSettings)).Get<AuthenticationSettings>();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = authSettings.PasswordRequireDigit;
            options.Password.RequireLowercase = authSettings.PasswordRequireLowercase;
            options.Password.RequireNonAlphanumeric = authSettings.PasswordRequireNonAlphanumeric;
            options.Password.RequireUppercase = authSettings.PasswordRequireUppercase;
            options.Password.RequiredLength = authSettings.PasswordMinRequiredLength;
            options.Password.RequiredUniqueChars = authSettings.PasswordRequiredUniqueChars;

            options.Lockout.DefaultLockoutTimeSpan = authSettings.DefaultLockoutTimeSpan;
            options.Lockout.MaxFailedAccessAttempts = authSettings.MaxFailedAccessAttempts;

            options.User.RequireUniqueEmail = authSettings.RequireUniqueEmail;

            options.SignIn.RequireConfirmedEmail = authSettings.RequireConfirmedEmail;
            options.SignIn.RequireConfirmedAccount = authSettings.RequireConfirmedAccount;
        });

        return services.AddIdentity<IdentityUser, IdentityRole>();
    }

    public static IServiceCollection AddDistributedCache(this IServiceCollection services)
    {
        return services.AddDistributedMemoryCache();
    }
}