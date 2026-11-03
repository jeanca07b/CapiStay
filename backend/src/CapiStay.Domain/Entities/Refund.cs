
using CapiStay.Domain.Common;
using CapiStay.Domain.Enums;

namespace CapiStay.Domain.Entities;

public class Refund : BaseEntity
{
    public Guid PaymentId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = "USD";

    public RefundStatus Status { get; set; } = RefundStatus.Pending;

    public string? ProviderRefundId { get; set; }

    public Guid AdminUserId { get; set; }

    public string Reason { get; set; } = string.Empty;

    public DateTime? ProcessedAt { get; set; }

    public Payment Payment { get; set; } = null!;

    public User AdminUser { get; set; } = null!;
}
