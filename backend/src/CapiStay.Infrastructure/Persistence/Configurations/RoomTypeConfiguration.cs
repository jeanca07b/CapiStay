
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.ToTable("RoomTypes");

        builder.HasKey(roomType => roomType.Id);

        builder.Property(roomType => roomType.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(roomType => roomType.Name)
            .IsUnique();

        builder.Property(roomType => roomType.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(roomType => roomType.MaxCapacity)
            .IsRequired();

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_RoomTypes_MaxCapacity",
                "[MaxCapacity] > 0");
        });

        builder.Property(roomType => roomType.IsActive)
            .IsRequired()
            .HasDefaultValue(true);
    }
}
