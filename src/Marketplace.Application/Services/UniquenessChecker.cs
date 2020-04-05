using Marketplace.Domain.Interfaces.Services;
using Marketplace.Infrastructure.Data.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Application.Services
{
    public class UniquenessChecker<TEntity> : IUniquenessChecker where TEntity : class
    {
        protected readonly MarketplaceContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public UniquenessChecker(MarketplaceContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public bool IsUnique<T>(T entity)
        {
            return DbSet.Find(entity) != null;
        }
    }
}
