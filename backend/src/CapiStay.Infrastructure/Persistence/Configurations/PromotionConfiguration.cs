
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> builder)
    {
        builder.ToTable("Promotions");

        builder.HasKey(promotion => promotion.Id);

        builder.Property(promotion => promotion.Title)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(promotion => promotion.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(promotion => promotion.ImageUrl)
            .HasMaxLength(2048);

        builder.Property(promotion => promotion.LinkUrl)
            .HasMaxLength(2048);

        builder.Property(promotion => promotion.StartsAt)
            .IsRequired();

        builder.Property(promotion => promotion.ExpiresAt)
            .IsRequired();

        builder.Property(promotion => promotion.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(promotion => promotion.DisplayOrder)
            .IsRequired();

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Promotions_DateRange",
                "[ExpiresAt] > [StartsAt]");

            table.HasCheckConstraint(
                "CK_Promotions_DisplayOrder",
                "[DisplayOrder] >= 0");
        });

        builder.HasIndex(promotion => new
        {
            promotion.IsActive,
            promotion.StartsAt,
            promotion.ExpiresAt
        });
    }
}
