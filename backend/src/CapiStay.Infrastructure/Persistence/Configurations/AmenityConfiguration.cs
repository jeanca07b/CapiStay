
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
{
    public void Configure(EntityTypeBuilder<Amenity> builder)
    {
        builder.ToTable("Amenities");

        builder.HasKey(amenity => amenity.Id);

        builder.Property(amenity => amenity.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(amenity => amenity.Name)
            .IsUnique();

        builder.Property(amenity => amenity.Description)
            .HasMaxLength(500);

        builder.Property(amenity => amenity.Icon)
            .HasMaxLength(100);

        builder.Property(amenity => amenity.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasMany(amenity => amenity.RoomTypeAmenities)
            .WithOne(roomTypeAmenity => roomTypeAmenity.Amenity)
            .HasForeignKey(roomTypeAmenity => roomTypeAmenity.AmenityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
