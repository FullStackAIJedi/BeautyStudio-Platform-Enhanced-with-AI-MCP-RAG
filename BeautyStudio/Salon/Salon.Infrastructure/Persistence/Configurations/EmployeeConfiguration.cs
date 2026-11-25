namespace Salon.Infrastructure.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Salon.Domain.Models.Employees;
    using Salon.Domain.Models;

    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(ModelConstants.Employee.MaxNameLength);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(ModelConstants.Employee.MaxNameLength);

            builder.Property(e => e.Bio)
                .HasMaxLength(1000);

            builder.Property(e => e.ProfilePhotoUrl)
                .HasMaxLength(500);

            builder.Property(e => e.LocationId).IsRequired();
            builder.HasIndex(e => e.LocationId); 
 
            builder.HasIndex(e => e.UserId).IsUnique();
            builder.HasIndex(e => e.RoleId);
            builder.HasIndex(e => e.IsVisibleInBooking);

            builder
            .HasMany(e => e.Skills)
            .WithOne()
            .HasForeignKey(s => s.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
             
            builder
                .HasMany(e => e.Certifications)
                .WithOne()
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
