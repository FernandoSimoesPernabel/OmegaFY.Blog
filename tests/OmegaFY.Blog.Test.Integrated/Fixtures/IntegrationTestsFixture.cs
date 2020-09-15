using OmegaFY.Blog.Test.Integrated.Config;
using System;
using System.Net.Http;

namespace OmegaFY.Blog.Test.Integrated.Fixtures
{

    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {

        public ApiFactory<TStartup> ApiFactory { get; }

        public HttpClient HttpClient { get; }

        public IntegrationTestsFixture(ApiFactory<TStartup> apiFactory, HttpClient httpClient)
        {
            //WebApplicationFactoryClientOptions factoryClientOptions = new WebApplicationFactoryClientOptions() { };

            ApiFactory = new ApiFactory<TStartup>();
            HttpClient = ApiFactory.CreateClient();
        }

        public void Dispose()
        {
            ApiFactory?.Dispose();
            HttpClient?.Dispose();
        }

    }

}
