
namespace CapiStay.Domain.Enums;

public enum AuditAction
{
    Created = 1,
    Updated = 2,
    Deleted = 3,
    Activated = 4,
    Deactivated = 5,
    Cancelled = 6,
    Approved = 7,
    Rejected = 8,
    PaymentProcessed = 9,
    RefundProcessed = 10,
    StatusChanged = 11,
    AccountAnonymized = 12
}
