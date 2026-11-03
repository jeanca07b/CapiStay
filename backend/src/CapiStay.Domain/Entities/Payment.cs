
using CapiStay.Domain.Common;
using CapiStay.Domain.Enums;

namespace CapiStay.Domain.Entities;

public class Payment : BaseEntity
{
    public Guid BookingId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = "USD";

    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

    public string Provider { get; set; } = "Stripe";

    public string? ProviderPaymentId { get; set; }

    public DateTime? PaidAt { get; set; }

    public Booking Booking { get; set; } = null!;
}
