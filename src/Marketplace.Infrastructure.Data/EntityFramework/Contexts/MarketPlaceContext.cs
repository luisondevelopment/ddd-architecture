using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Data.EntityFramework.Contexts
{
    public class MarketPlaceContext : DbContext
    {
        public MarketPlaceContext(DbContextOptions<MarketPlaceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
