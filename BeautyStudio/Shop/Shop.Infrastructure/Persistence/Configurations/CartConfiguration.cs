namespace Shop.Infrastructure.Persistence.Configurations
{ 
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Shop.Domain.Models.Carts;

    internal class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Status).IsRequired();
            builder.Property(c => c.CreatedAt).IsRequired();
            builder.Property(c => c.CheckedOutAt);

            builder.HasIndex(c => new { c.UserId, c.Status });
             
            builder.Metadata
                .FindNavigation(nameof(Cart.Items))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(c => c.Items)
                .WithOne()
                .HasForeignKey(i => i.CartId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
