namespace Identity.Infrastructure.Persistence
{  
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Identity.Domain.Models;

    public interface IIdentityDbContext
    {
        DbSet<ApplicationUser> Users { get; }
        DbSet<ApplicationRole> Roles { get; }
        DbSet<UserRole> UserRoles { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
