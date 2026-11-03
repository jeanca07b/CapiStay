
namespace CapiStay.Domain.Enums;

public enum BookingAuditAction
{
    Created = 1,
    PaymentInitiated = 2,
    PaymentConfirmed = 3,
    PaymentFailed = 4,
    Cancelled = 5,
    Expired = 6,
    Modified = 7,
    ModificationRequested = 8,
    ModificationApproved = 9,
    ModificationRejected = 10,
    RefundRequested = 11,
    RefundCompleted = 12,
    RefundFailed = 13,
    CouponApplied = 14,
    CouponReleased = 15
}
