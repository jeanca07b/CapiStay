
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms");

        builder.HasKey(room => room.Id);

        builder.Property(room => room.RoomNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasIndex(room => room.RoomNumber)
            .IsUnique();

        builder.Property(room => room.Floor);

        builder.Property(room => room.RoomTypeId)
            .IsRequired();

        builder.Property(room => room.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasOne(room => room.RoomType)
            .WithMany(roomType => roomType.Rooms)
            .HasForeignKey(room => room.RoomTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
