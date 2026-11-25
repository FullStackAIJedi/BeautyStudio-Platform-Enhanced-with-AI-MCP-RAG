namespace Salon.Infrastructure.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Salon.Domain.Models.Portfolio;
    using Salon.Domain.Models;

    internal class PortfolioItemConfiguration : IEntityTypeConfiguration<PortfolioItem>
    {
        public void Configure(EntityTypeBuilder<PortfolioItem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(ModelConstants.Portfolio.MaxTitleLength);

            builder.Property(p => p.Description)
                .HasMaxLength(ModelConstants.Portfolio.MaxDescriptionLength);

            builder.Property(p => p.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.ThumbnailUrl)
                .HasMaxLength(500);

            builder.Property(p => p.LocationId).IsRequired();
            builder.HasIndex(p => p.LocationId);

            builder.HasIndex(p => p.EmployeeId);
            builder.HasIndex(p => p.ServiceId);
            builder.HasIndex(p => p.ServiceDate);
            builder.HasIndex(p => p.IsPublished);
        }
    }
}
