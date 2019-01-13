using Xunit;

namespace SriSloka.Api.Tests
{
	[CollectionDefinition("Integration test collection")]
    public class IntegrationTestCollection : ICollectionFixture<TestSetup>
    {
    }
}
