
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class CouponRedemptionConfiguration : IEntityTypeConfiguration<CouponRedemption>
{
    public void Configure(EntityTypeBuilder<CouponRedemption> builder)
    {
        builder.ToTable("CouponRedemptions");

        builder.HasKey(redemption => redemption.Id);

        builder.Property(redemption => redemption.CouponId)
            .IsRequired();

        builder.Property(redemption => redemption.UserId)
            .IsRequired();

        builder.Property(redemption => redemption.BookingId)
            .IsRequired();

        builder.Property(redemption => redemption.DiscountAmount)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(redemption => redemption.Status)
            .IsRequired();

        builder.Property(redemption => redemption.ExpiresAt)
            .IsRequired();

        builder.Property(redemption => redemption.ConsumedAt);

        builder.Property(redemption => redemption.ReleasedAt);

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_CouponRedemptions_DiscountAmount",
                "[DiscountAmount] >= 0");
        });

        builder.HasIndex(redemption => redemption.BookingId)
            .IsUnique();

        builder.HasIndex(redemption => new
        {
            redemption.CouponId,
            redemption.UserId,
            redemption.Status
        });

        builder.HasOne(redemption => redemption.User)
            .WithMany()
            .HasForeignKey(redemption => redemption.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(redemption => redemption.Booking)
            .WithMany()
            .HasForeignKey(redemption => redemption.BookingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
