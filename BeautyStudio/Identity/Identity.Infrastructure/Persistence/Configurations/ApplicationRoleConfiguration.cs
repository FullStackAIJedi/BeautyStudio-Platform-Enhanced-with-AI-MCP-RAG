namespace Identity.Infrastructure.Persistence.Configurations
{
    using Identity.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(r => r.Name).IsUnique();

            builder.Property(r => r.RoleLevel).IsRequired();
            builder.HasIndex(r => r.RoleLevel).IsUnique();
        }
    }
}
