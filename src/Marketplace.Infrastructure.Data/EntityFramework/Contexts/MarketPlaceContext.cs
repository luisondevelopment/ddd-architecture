using Marketplace.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Data.EntityFramework.Contexts
{
    public class MarketPlaceContext : DbContext
    {
        public MarketPlaceContext(DbContextOptions<MarketPlaceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
