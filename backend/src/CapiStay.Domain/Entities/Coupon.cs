
using CapiStay.Domain.Common;
using CapiStay.Domain.Enums;

namespace CapiStay.Domain.Entities;

public class Coupon : BaseEntity
{
    public string Code { get; set; } = string.Empty;

    public CouponType Type { get; set; }

    public decimal Value { get; set; }

    public DateTime StartsAt { get; set; }

    public DateTime ExpiresAt { get; set; }

    public int? MaxUses { get; set; }

    public int? MaxUsesPerUser { get; set; }

    public decimal? MinimumBookingAmount { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<CouponRoomType> AllowedRoomTypes { get; set; } = new List<CouponRoomType>();

    public ICollection<CouponRedemption> Redemptions { get; set; } = new List<CouponRedemption>();
}
