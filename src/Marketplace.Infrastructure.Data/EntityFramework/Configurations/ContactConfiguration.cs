using Marketplace.Infrastructure.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infrastructure.Data.EntityFramework.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<ContactDb>
    {
        public void Configure(EntityTypeBuilder<ContactDb> builder)
        {
            builder
                .HasOne(x => x.Truck)
                .WithMany(x=> x.Contacts)
                .HasForeignKey(x=> x.TruckId);
        }
    }
}
