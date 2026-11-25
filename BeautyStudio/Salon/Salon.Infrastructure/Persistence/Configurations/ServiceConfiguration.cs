namespace Salon.Infrastructure.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Salon.Domain.Models;
    using Salon.Domain.Models.Services;

    internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(ModelConstants.Service.MaxNameLength);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(ModelConstants.Service.MaxDescriptionLength);

            builder.Property(s => s.Price)
                .HasPrecision(18, 2);

            builder.Property(s => s.IsActive)
                .IsRequired();

            builder.HasIndex(s => s.Name);
            builder.HasIndex(s => s.CategoryId);
        }
    }
}
