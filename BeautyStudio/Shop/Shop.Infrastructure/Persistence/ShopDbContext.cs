namespace Shop.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;

    using Shop.Domain.Models.Carts;
    using Shop.Domain.Models.Orders;
    using Shop.Domain.Models.Payments;
    using Shop.Domain.Models.Products;

    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Cart> Carts { get; set; } = default!;
        public DbSet<CartItem> CartItems { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<Payment> Payments { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
