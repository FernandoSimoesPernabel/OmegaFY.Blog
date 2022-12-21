using Microsoft.AspNetCore.ResponseCompression;
using OmegaFY.Blog.Infra.IoC;
using System.IO.Compression;

namespace OmegaFY.Blog.WebAPI.IoC;

public class ApiResponseCompressionRegistration : IDependencyInjectionRegister
{
    public void Register(WebApplicationBuilder builder)
    {
        builder.Services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;

            options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
        });

        builder.Services.Configure<BrotliCompressionProviderOptions>(options => options.Level = CompressionLevel.SmallestSize);

        builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.SmallestSize);
    }
}