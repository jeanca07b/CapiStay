
using CapiStay.Domain.Common;

namespace CapiStay.Domain.Entities;

public class CouponRoomType : BaseEntity
{
    public Guid CouponId { get; set; }

    public Guid RoomTypeId { get; set; }

    public Coupon Coupon { get; set; } = null!;

    public RoomType RoomType { get; set; } = null!;
}
