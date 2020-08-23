using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;
using System.Net.Http;

namespace Marketplace.Api.Acceptance.Tests.Brokers
{
    public partial class MarketplaceApiBroker
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private readonly HttpClient baseClient;
        private readonly IRESTFulApiFactoryClient apiFactoryClient;

        public MarketplaceApiBroker()
        {
            webApplicationFactory = new WebApplicationFactory<Startup>();
            baseClient = webApplicationFactory.CreateClient();
            apiFactoryClient = new RESTFulApiFactoryClient(baseClient);
        }
    }
}
