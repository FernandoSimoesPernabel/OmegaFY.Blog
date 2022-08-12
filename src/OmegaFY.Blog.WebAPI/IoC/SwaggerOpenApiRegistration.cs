using Microsoft.OpenApi.Models;
using OmegaFY.Blog.Infra.IoC;

namespace OmegaFY.Blog.WebAPI.IoC;

public class SwaggerOpenApiRegistration : IDependencyInjectionRegister
{
    public IServiceCollection Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            Version version = System.Reflection.Assembly.GetAssembly(typeof(Program)).GetName().Version;

            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Contact = new OpenApiContact()
                {
                    Name = "Fernando Simões Pernabel",
                    Url = new Uri("https://github.com/FernandoSimoesPernabel/OmegaFY.Blog"),
                    Email = "f_pernabel@hotmail.com"
                },
                Description = "For more information access https://github.com/FernandoSimoesPernabel/OmegaFY.Blog",
                Title = "OmegaFY Blog WebAPI",
                License = new OpenApiLicense()
                {
                    Name = "GNU General Public License version 3",
                    Url = new Uri("https://www.gnu.org/licenses/gpl-3.0.html")
                },
                Version = $"{version.Major}.{version.Minor}.{version.Revision}.{version.Build}"
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. Example: Authorization: Bearer {token}",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}