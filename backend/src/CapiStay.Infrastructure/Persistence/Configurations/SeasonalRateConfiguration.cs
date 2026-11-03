
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class SeasonalRateConfiguration : IEntityTypeConfiguration<SeasonalRate>
{
    public void Configure(EntityTypeBuilder<SeasonalRate> builder)
    {
        builder.ToTable("SeasonalRates");

        builder.HasKey(rate => rate.Id);

        builder.Property(rate => rate.SeasonId)
            .IsRequired();

        builder.Property(rate => rate.RoomTypeId)
            .IsRequired();

        builder.Property(rate => rate.PricePerNight)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(rate => rate.Currency)
            .IsRequired()
            .HasMaxLength(3)
            .HasDefaultValue("USD");

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_SeasonalRates_PricePerNight",
                "[PricePerNight] > 0");
        });

        builder.HasIndex(rate => new
        {
            rate.SeasonId,
            rate.RoomTypeId
        }).IsUnique();

        builder.HasOne(rate => rate.Season)
            .WithMany()
            .HasForeignKey(rate => rate.SeasonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(rate => rate.RoomType)
            .WithMany()
            .HasForeignKey(rate => rate.RoomTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
