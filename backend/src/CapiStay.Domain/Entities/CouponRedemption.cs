
using CapiStay.Domain.Common;
using CapiStay.Domain.Enums;

namespace CapiStay.Domain.Entities;

public class CouponRedemption : BaseEntity
{
    public Guid CouponId { get; set; }

    public Guid UserId { get; set; }

    public Guid BookingId { get; set; }

    public decimal DiscountAmount { get; set; }

    public CouponRedemptionStatus Status { get; set; } =
        CouponRedemptionStatus.Reserved;

    public DateTime ExpiresAt { get; set; }

    public DateTime? ConsumedAt { get; set; }

    public DateTime? ReleasedAt { get; set; }

    public Coupon Coupon { get; set; } = null!;

    public User User { get; set; } = null!;

    public Booking Booking { get; set; } = null!;
}
