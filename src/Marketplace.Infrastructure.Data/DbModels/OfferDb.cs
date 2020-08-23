using Marketplace.Domain.Core.Entities;

namespace Marketplace.Infrastructure.Data.DbModels
{
    public class OfferDb : DbEntity
    {
        public decimal Value { get; set; }
        public int TruckId { get; set; }
        public TruckDb Truck { get; set; }
    }
}
