using OmegaFY.Blog.WebAPI;
using Xunit;

namespace OmegaFY.Blog.Test.Integrated.Fixtures
{

    [CollectionDefinition(nameof(IntegrationTestsFixtureCollection))]
    public class IntegrationTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<Startup>>
    {
    }

}
