namespace Salon.Infrastructure.Persistence.Common
{
    using Microsoft.EntityFrameworkCore; 
    using SharedKernel.Models;

    internal abstract class DataRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(TDbContext db) => this.Data = db;

        protected TDbContext Data { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public async Task Save(TEntity entity, CancellationToken cancellationToken = default)
        {
            this.Data.Update(entity);
            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
