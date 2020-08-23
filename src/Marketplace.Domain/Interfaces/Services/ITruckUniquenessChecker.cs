namespace Marketplace.Domain.Interfaces.Services
{
    public interface ITruckUniquenessChecker : IUniquenessChecker
    {
        bool IsLicensePlateUnique(string licensePlace);
    }
}
