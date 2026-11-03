
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class BookingNightConfiguration : IEntityTypeConfiguration<BookingNight>
{
    public void Configure(EntityTypeBuilder<BookingNight> builder)
    {
        builder.ToTable("BookingNights");

        builder.HasKey(night => night.Id);

        builder.Property(night => night.BookingId)
            .IsRequired();

        builder.Property(night => night.SeasonId)
            .IsRequired();

        builder.Property(night => night.StayDate)
            .IsRequired();

        builder.Property(night => night.PricePerNight)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(night => night.Currency)
            .IsRequired()
            .HasMaxLength(3)
            .HasDefaultValue("USD");

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_BookingNights_PricePerNight",
                "[PricePerNight] > 0");
        });

        builder.HasIndex(night => new
        {
            night.BookingId,
            night.StayDate
        }).IsUnique();

        builder.HasOne(night => night.Season)
            .WithMany()
            .HasForeignKey(night => night.SeasonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
