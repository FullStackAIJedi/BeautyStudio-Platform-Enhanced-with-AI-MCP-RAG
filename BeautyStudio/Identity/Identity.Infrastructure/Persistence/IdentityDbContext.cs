namespace Identity.Infrastructure.Persistence
{
    using Identity.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class IdentityDbContext : DbContext, IIdentityDbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options) { }

        public DbSet<ApplicationUser> Users { get; set; } = default!;
        public DbSet<ApplicationRole> Roles { get; set; } = default!;
        public DbSet<UserRole> UserRoles { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
