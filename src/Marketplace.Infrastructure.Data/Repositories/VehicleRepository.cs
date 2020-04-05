using Marketplace.Domain.Entities.Vehicles;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Infrastructure.Data.EntityFramework.Contexts;

namespace Marketplace.Infrastructure.Data.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private readonly MarketplaceContext _context;

        public VehicleRepository(MarketplaceContext context) : base(context)
        {
            _context = context;
        }
    }
}
