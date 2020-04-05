using Marketplace.Domain.Entities.Vehicles;

namespace Marketplace.Domain.Interfaces.Services
{
    public interface ITruckUniquenessChecker : IUniquenessChecker
    {
        bool IsLicensePlateUnique(string licensePlace);
    }
}
