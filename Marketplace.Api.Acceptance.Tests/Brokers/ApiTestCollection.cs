using Xunit;

namespace Marketplace.Api.Acceptance.Tests.Brokers
{
    [CollectionDefinition(nameof(ApiTestCollection))]
    public class ApiTestCollection : ICollectionFixture<MarketplaceApiBroker>
    {

    }
}
