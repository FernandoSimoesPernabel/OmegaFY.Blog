using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OmegaFY.Blog.Infra.IoC;

public interface IDependencyInjectionRegister
{
    public void Register(WebApplicationBuilder builder);
}