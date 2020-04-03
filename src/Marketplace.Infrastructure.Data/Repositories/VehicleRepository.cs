using Marketplace.Domain.Entities.Vehicles;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Infrastructure.Data.EntityFramework.Contexts;

namespace Marketplace.Infrastructure.Data.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private readonly MarketPlaceContext _context;

        public VehicleRepository(MarketPlaceContext context) : base(context)
        {
            _context = context;
        }
    }
}
