
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.ToTable("Coupons");

        builder.HasKey(coupon => coupon.Id);

        builder.Property(coupon => coupon.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(coupon => coupon.Code)
            .IsUnique();

        builder.Property(coupon => coupon.Type)
            .IsRequired();

        builder.Property(coupon => coupon.Value)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(coupon => coupon.StartsAt)
            .IsRequired();

        builder.Property(coupon => coupon.ExpiresAt)
            .IsRequired();

        builder.Property(coupon => coupon.MinimumBookingAmount)
            .HasPrecision(10, 2);

        builder.Property(coupon => coupon.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Coupons_Value",
                "[Value] > 0");

            table.HasCheckConstraint(
                "CK_Coupons_DateRange",
                "[ExpiresAt] > [StartsAt]");

            table.HasCheckConstraint(
                "CK_Coupons_MaxUses",
                "[MaxUses] IS NULL OR [MaxUses] > 0");

            table.HasCheckConstraint(
                "CK_Coupons_MaxUsesPerUser",
                "[MaxUsesPerUser] IS NULL OR [MaxUsesPerUser] > 0");

            table.HasCheckConstraint(
                "CK_Coupons_MinimumBookingAmount",
                "[MinimumBookingAmount] IS NULL OR [MinimumBookingAmount] >= 0");
        });

        builder.HasMany(coupon => coupon.AllowedRoomTypes)
            .WithOne(couponRoomType => couponRoomType.Coupon)
            .HasForeignKey(couponRoomType => couponRoomType.CouponId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(coupon => coupon.Redemptions)
            .WithOne(redemption => redemption.Coupon)
            .HasForeignKey(redemption => redemption.CouponId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
