using Marketplace.Infrastructure.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infrastructure.Data.EntityFramework.Configurations
{
    public class OffersConfiguration : IEntityTypeConfiguration<OfferDb>
    {
        public void Configure(EntityTypeBuilder<OfferDb> builder)
        {
            builder
                .HasOne(x => x.Truck)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.TruckId);
        }
    }
}
