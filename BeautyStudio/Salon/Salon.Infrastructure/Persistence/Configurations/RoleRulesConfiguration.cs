namespace Salon.Infrastructure.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Salon.Domain.Models.Roles;

    internal class RoleRulesConfiguration : IEntityTypeConfiguration<RoleRule>
    {
        public void Configure(EntityTypeBuilder<RoleRule> builder)
        {
            builder.HasKey(r => new { r.RoleId, r.Type, r.Code });

            builder.Property(r => r.RoleId)
                .IsRequired();

            builder.Property(r => r.Type)
                .IsRequired();

            builder.Property(r => r.Code)
                .IsRequired();

            // CHECK constraints
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CK_RoleRules_RoleId", "[RoleId] BETWEEN 0 AND 10");
                t.HasCheckConstraint("CK_RoleRules_Type", "[Type] IN (1, 2)");
            });

            builder.HasIndex(r => new { r.RoleId, r.Type, r.Code });
        }
    }
}
