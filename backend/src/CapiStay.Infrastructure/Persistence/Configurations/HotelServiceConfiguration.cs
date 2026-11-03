
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class HotelServiceConfiguration : IEntityTypeConfiguration<HotelService>
{
    public void Configure(EntityTypeBuilder<HotelService> builder)
    {
        builder.ToTable("HotelServices");

        builder.HasKey(service => service.Id);

        builder.Property(service => service.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(service => service.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(service => service.IsFree)
            .IsRequired();

        builder.Property(service => service.Price)
            .HasPrecision(10, 2);

        builder.Property(service => service.Currency)
            .IsRequired()
            .HasMaxLength(3)
            .HasDefaultValue("USD");

        builder.Property(service => service.ImageUrl)
            .HasMaxLength(2048);

        builder.Property(service => service.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(service => service.DisplayOrder)
            .IsRequired();

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_HotelServices_Price",
                "[Price] IS NULL OR [Price] >= 0");

            table.HasCheckConstraint(
                "CK_HotelServices_DisplayOrder",
                "[DisplayOrder] >= 0");
        });

        builder.HasIndex(service => new
        {
            service.IsActive,
            service.DisplayOrder
        });
    }
}
