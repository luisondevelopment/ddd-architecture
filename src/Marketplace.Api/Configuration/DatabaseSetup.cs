using Marketplace.Infrastructure.Data.EntityFramework;
using Marketplace.Infrastructure.Data.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Api.Configuration
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MarketplaceContext>(options =>
            {
                if (!options.IsConfigured)
                    options.UseInMemoryDatabase("Marketplace");
            });

            DataGenerator.Initialize(services.BuildServiceProvider());
        }
    }
}
