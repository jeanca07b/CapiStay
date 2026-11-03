
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class CouponRoomTypeConfiguration : IEntityTypeConfiguration<CouponRoomType>
{
    public void Configure(EntityTypeBuilder<CouponRoomType> builder)
    {
        builder.ToTable("CouponRoomTypes");

        builder.HasKey(couponRoomType => couponRoomType.Id);

        builder.Property(couponRoomType => couponRoomType.CouponId)
            .IsRequired();

        builder.Property(couponRoomType => couponRoomType.RoomTypeId)
            .IsRequired();

        builder.HasIndex(couponRoomType => new
        {
            couponRoomType.CouponId,
            couponRoomType.RoomTypeId
        }).IsUnique();

        builder.HasOne(couponRoomType => couponRoomType.Coupon)
            .WithMany(coupon => coupon.AllowedRoomTypes)
            .HasForeignKey(couponRoomType => couponRoomType.CouponId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(couponRoomType => couponRoomType.RoomType)
            .WithMany()
            .HasForeignKey(couponRoomType => couponRoomType.RoomTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
