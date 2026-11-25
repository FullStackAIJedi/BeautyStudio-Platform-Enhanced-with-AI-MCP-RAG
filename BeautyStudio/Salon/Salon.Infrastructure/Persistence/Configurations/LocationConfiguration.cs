namespace Salon.Infrastructure.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Salon.Domain.Models;
    using Salon.Domain.Models.Locations;

    internal class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(ModelConstants.Location.MaxNameLength);

            builder.Property(l => l.Address)
                .IsRequired()
                .HasMaxLength(ModelConstants.Location.MaxAddressLength);

            builder.Property(l => l.City)
                .IsRequired()
                .HasMaxLength(ModelConstants.Location.MaxCityLength);

            builder.Property(l => l.Country)
                .IsRequired()
                .HasMaxLength(ModelConstants.Location.MaxCountryLength);

            builder.Property(l => l.Phone)
                .IsRequired()
                .HasMaxLength(ModelConstants.Location.MaxPhoneLength);

            builder.Property(l => l.TimeZone)
                .IsRequired()
                .HasMaxLength(ModelConstants.Location.MaxTimeZoneLength);

            builder.Property(l => l.WorkingHours)
                .IsRequired();

            builder.HasIndex(l => l.City);
            builder.HasIndex(l => l.Country);
            builder.HasIndex(l => l.IsAvailable);
            builder.HasIndex(l => new { l.City, l.Country });
        }
    }
}
