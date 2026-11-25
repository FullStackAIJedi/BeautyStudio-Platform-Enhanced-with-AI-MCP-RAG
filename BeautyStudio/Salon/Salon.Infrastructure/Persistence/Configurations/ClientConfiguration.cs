namespace Salon.Infrastructure.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Salon.Domain.Models.Clients;

    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Email)
                .HasMaxLength(100);

            builder.Property(c => c.Phone)
                .HasMaxLength(20);

            builder.Property(c => c.Notes)
                .HasMaxLength(2000);

            builder.Property(c => c.HairType)
                .HasMaxLength(50);

            builder.Property(c => c.Allergies)
                .HasMaxLength(500);

            builder.HasIndex(c => c.UserId).IsUnique();
            builder.HasIndex(c => c.Email);
        }
    }
}
