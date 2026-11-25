namespace Shop.Infrastructure.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Shop.Domain.Models.Payments;

    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Amount).HasPrecision(18, 2);
            builder.Property(p => p.IdempotencyKey).IsRequired().HasMaxLength(100);
            builder.HasIndex(p => p.IdempotencyKey).IsUnique();
            builder.HasIndex(p => p.CartId);
        }
    }
}
