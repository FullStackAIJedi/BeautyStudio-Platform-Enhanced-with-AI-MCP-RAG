namespace Salon.Infrastructure.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Salon.Domain.Models.Appointments;

    internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Notes)
                .HasMaxLength(1000);

            builder.Property(a => a.LocationId).IsRequired();
            builder.HasIndex(a => a.LocationId);
            builder.HasIndex(a => new { a.LocationId, a.StartAt });

            builder.HasIndex(a => a.ClientId);
            builder.HasIndex(a => a.EmployeeId);
            builder.HasIndex(a => a.StartAt);
            builder.HasIndex(a => new { a.EmployeeId, a.StartAt });
        }
    }
}
