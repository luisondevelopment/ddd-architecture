using FluentAssertions;
using Marketplace.Api.Acceptance.Tests.Brokers;
using Marketplace.Api.Acceptance.Tests.Models;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using Xunit;

namespace Marketplace.Api.Acceptance.Tests.APIs.Trucks
{
    [Collection(nameof(ApiTestCollection))]
    public class TrucksApiRests
    {
        private readonly MarketplaceApiBroker marketplaceApiBroker;

        public TrucksApiRests(MarketplaceApiBroker marketplaceApiBroker) =>
            this.marketplaceApiBroker = marketplaceApiBroker;

        private Truck CreateRandomTruck() => 
            new Filler<Truck>().Create();

        [Fact]
        public async Task ShouldPostTruckAsync()
        {
            // given
            var randomTruck = CreateRandomTruck();
            var inputTruck = randomTruck;

            // when
            var actualTruck = await marketplaceApiBroker.PostTruckAsync(inputTruck);

            // then
            actualTruck.Id.Should().BeGreaterThan(0);

            await marketplaceApiBroker.DeleteTruckByIdAsync(actualTruck.Id);
        }
    }
}
