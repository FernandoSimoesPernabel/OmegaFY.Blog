using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OmegaFY.Blog.Common.Configs;
using OmegaFY.Blog.Infra.Authentication;
using OmegaFY.Blog.Infra.Authentication.Configs;
using OmegaFY.Blog.Infra.Authentication.Events;
using OmegaFY.Blog.Infra.Authentication.Token;
using OmegaFY.Blog.Infra.Authentication.Users;
using OmegaFY.Blog.Infra.IoC;
using OmegaFY.Blog.Infra.Notifications;
using OmegaFY.Blog.Infra.Notifications.Configs;
using OmegaFY.Blog.Infra.Notifications.Emails;
using OmegaFY.Blog.Infra.Notifications.Sms;
using OmegaFY.Blog.Infra.OpenTelemetry;
using OmegaFY.Blog.Infra.OpenTelemetry.Configs;
using OmegaFY.Blog.Infra.OpenTelemetry.Providers;
using OmegaFY.Blog.Infra.RateLimiter.Configs;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using SendGrid.Extensions.DependencyInjection;
using SendGrid.Helpers.Mail;
using System.Reflection;
using System.Text;
using System.Threading.RateLimiting;

namespace OmegaFY.Blog.Infra.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDependencyInjectionRegister(this IServiceCollection services, Assembly assembly, WebApplicationBuilder builder)
    {
        assembly?.ExportedTypes
            .Where(t => typeof(IDependencyInjectionRegister).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IDependencyInjectionRegister>()
            .ToList()
            .ForEach(iocRegister => iocRegister.Register(builder));

        return services;
    }

    public static IServiceCollection AddIdentityUserConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));

        services.AddScoped<CustomJwtBearerEvents>();

        services.AddHttpContextAccessor();
        services.AddScoped<IUserInformation, HttpContextAccessorUserInformation>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IJwtProvider, JwtSecurityTokenProvider>();

        JwtSettings jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();

        TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
        {
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            RequireAudience = true,
            RequireExpirationTime = true,
            RequireSignedTokens = true,
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = jwtSettings.Audience,
            ValidIssuer = jwtSettings.Issuer
        };

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = true;
            options.TokenValidationParameters = tokenValidationParameters;
            options.EventsType = typeof(CustomJwtBearerEvents);
        });

        services.AddAuthorization(auth => auth.AddBearerJwtPolicy());

        services.AddSingleton(tokenValidationParameters);

        return services;
    }

    public static IdentityBuilder AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthenticationSettings>(configuration.GetSection(nameof(AuthenticationSettings)));

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

        return services.AddIdentity<IdentityUser<string>, IdentityRole<string>>();
    }

    public static IServiceCollection AddDistributedCache(this IServiceCollection services)
    {
        return services.AddDistributedMemoryCache();
    }

    public static IServiceCollection AddOpenTelemetry(this IServiceCollection services, IConfiguration configuration)
    {
        OpenTelemetrySettings openTelemetrySettings = configuration.GetSection(nameof(OpenTelemetrySettings)).Get<OpenTelemetrySettings>();

        services.Configure<OpenTelemetrySettings>(configuration.GetSection(nameof(OpenTelemetrySettings)));

        services.AddSingleton<IOpenTelemetryRegisterProvider, OpenTelemetryActivitySourceProvider>();

        ResourceBuilder resourceBuilder = ResourceBuilder.CreateDefault().AddService(openTelemetrySettings.ServiceName, serviceVersion: ProjectVersion.Instance.ToString());

        services.AddOpenTelemetry().WithTracing(builder =>
        {
            builder.AddSource(openTelemetrySettings.ServiceName)
                .SetResourceBuilder(resourceBuilder)
                .AddAspNetCoreInstrumentation(aspnetOptions => aspnetOptions.Filter = (context) => context.Request.Path.Value.ShouldMonitorRoute())
                .AddHttpClientInstrumentation(httpClientOptions =>
                {
                    httpClientOptions.FilterHttpWebRequest = (context) => context.RequestUri.AbsolutePath.ShouldMonitorRoute();
                    httpClientOptions.FilterHttpRequestMessage = (context) => context.RequestUri.AbsolutePath.ShouldMonitorRoute();
                })
                .AddEntityFrameworkCoreInstrumentation(efOptions => efOptions.SetDbStatementForText = true)
                .AddHoneycomb(honeycombOptions =>
                {
                    honeycombOptions.ServiceName = openTelemetrySettings.ServiceName;
                    honeycombOptions.ApiKey = openTelemetrySettings.HoneycombApiKey;
                    honeycombOptions.ServiceVersion = ProjectVersion.Instance.ToString();
                });
        });

        //TODO
        //services.AddLogging(loggingBuilder => loggingBuilder.AddOpenTelemetry(openTelemetryBuilder =>
        //{
        //    openTelemetryBuilder.SetResourceBuilder(resourceBuilder);
        //    openTelemetryBuilder.AddOtlpExporter(otlpOptions =>
        //    {
        //        otlpOptions.Endpoint = new Uri(openTelemetrySettings.HoneycombUrl);
        //        otlpOptions.Headers = openTelemetrySettings.HoneycombApiKeyHeader;
        //    });
        //}));

        return services;
    }

    public static IServiceCollection AddMultipleNotificationProviders(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMultipleNotificationProvidersHandler, MultipleNotificationProvidersHandler>();

        services.AddSendGridEmailNotificationProvider(configuration);

        services.AddSmsNotificationProvider();

        return services;
    }

    public static IServiceCollection AddSendGridEmailNotificationProvider(this IServiceCollection services, IConfiguration configuration)
    {
        SendGridSettings sendGridSettings = configuration.GetSection(nameof(SendGridSettings)).Get<SendGridSettings>();

        services.AddSingleton(new EmailAddress(sendGridSettings.FromEmail, sendGridSettings.FromEmailDisplayName));
        services.AddScoped<IEmailNotificationProvider, SendGridEmailNotificationProvider>();
        services.AddScoped<INotificationProvider, SendGridEmailNotificationProvider>();
        services.AddSendGrid(options => options.ApiKey = sendGridSettings.ApiKey);

        return services;
    }

    public static IServiceCollection AddSmsNotificationProvider(this IServiceCollection services)
    {
        services.AddScoped<ISmsNotificationProvider, SmsNotificationProvider>();
        services.AddScoped<INotificationProvider, SmsNotificationProvider>();

        return services;
    }

    public static IServiceCollection AddWebApiRateLimiter(this IServiceCollection services, IConfiguration configuration)
    {
        IpOrUserTokenBucketPolicySettings ipOrUserTokenPolicySettings = configuration.GetSection(nameof(IpOrUserTokenBucketPolicySettings)).Get<IpOrUserTokenBucketPolicySettings>();

        services.AddRateLimiter(limiterOptions =>
        {
            limiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            limiterOptions.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
            {
                TokenBucketRateLimiterOptions tokenBucketOptions = new TokenBucketRateLimiterOptions()
                {
                    AutoReplenishment = true,
                    QueueLimit = 0,
                    QueueProcessingOrder = QueueProcessingOrder.NewestFirst,
                    ReplenishmentPeriod = ipOrUserTokenPolicySettings.ReplenishmentPeriod,
                    TokenLimit = ipOrUserTokenPolicySettings.TokenLimit,
                    TokensPerPeriod = ipOrUserTokenPolicySettings.TokensPerPeriod
                };

                string userEmail = null;

                if (context.User.IsAuthenticated())
                    userEmail = context.User.TryGetEmailFromClaims();

                return userEmail is not null
                    ? RateLimitPartition.GetTokenBucketLimiter(userEmail, _ => tokenBucketOptions)
                    : RateLimitPartition.GetTokenBucketLimiter(context.Connection.RemoteIpAddress.ToString(), _ => tokenBucketOptions);
            });
        });

        return services;
    }
}