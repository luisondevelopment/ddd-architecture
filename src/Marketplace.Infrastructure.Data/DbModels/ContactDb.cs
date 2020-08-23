using Marketplace.Domain.Core.Entities;

namespace Marketplace.Infrastructure.Data.DbModels
{
    public class ContactDb : DbEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int TruckId { get; set; }
        public TruckDb Truck { get; set; }
    }
}
