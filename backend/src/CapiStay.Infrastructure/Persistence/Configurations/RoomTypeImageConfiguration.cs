
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class RoomTypeImageConfiguration : IEntityTypeConfiguration<RoomTypeImage>
{
    public void Configure(EntityTypeBuilder<RoomTypeImage> builder)
    {
        builder.ToTable("RoomTypeImages");

        builder.HasKey(image => image.Id);

        builder.Property(image => image.RoomTypeId)
            .IsRequired();

        builder.Property(image => image.ImageUrl)
            .IsRequired()
            .HasMaxLength(2048);

        builder.Property(image => image.AltText)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(image => image.DisplayOrder)
            .IsRequired();

        builder.Property(image => image.IsPrimary)
            .IsRequired()
            .HasDefaultValue(false);

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_RoomTypeImages_DisplayOrder",
                "[DisplayOrder] >= 0");
        });

        builder.HasIndex(image => new
        {
            image.RoomTypeId,
            image.DisplayOrder
        });

        builder.HasIndex(image => image.RoomTypeId)
            .IsUnique()
            .HasFilter("[IsPrimary] = 1");

        builder.HasOne(image => image.RoomType)
            .WithMany()
            .HasForeignKey(image => image.RoomTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
