namespace Marketplace.Domain.Interfaces.Services
{
    public interface IUniquenessChecker
    {
        bool IsUnique<T>(T entity);
    }
}
