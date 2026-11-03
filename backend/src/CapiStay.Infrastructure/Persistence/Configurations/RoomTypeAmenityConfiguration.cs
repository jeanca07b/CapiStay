
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class RoomTypeAmenityConfiguration : IEntityTypeConfiguration<RoomTypeAmenity>
{
    public void Configure(EntityTypeBuilder<RoomTypeAmenity> builder)
    {
        builder.ToTable("RoomTypeAmenities");

        builder.HasKey(roomTypeAmenity => roomTypeAmenity.Id);

        builder.Property(roomTypeAmenity => roomTypeAmenity.RoomTypeId)
            .IsRequired();

        builder.Property(roomTypeAmenity => roomTypeAmenity.AmenityId)
            .IsRequired();

        builder.HasIndex(roomTypeAmenity => new
        {
            roomTypeAmenity.RoomTypeId,
            roomTypeAmenity.AmenityId
        }).IsUnique();

        builder.HasOne(roomTypeAmenity => roomTypeAmenity.RoomType)
            .WithMany()
            .HasForeignKey(roomTypeAmenity => roomTypeAmenity.RoomTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(roomTypeAmenity => roomTypeAmenity.Amenity)
            .WithMany(amenity => amenity.RoomTypeAmenities)
            .HasForeignKey(roomTypeAmenity => roomTypeAmenity.AmenityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
