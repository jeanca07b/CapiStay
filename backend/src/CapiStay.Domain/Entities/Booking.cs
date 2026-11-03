
using CapiStay.Domain.Common;
using CapiStay.Domain.Enums;

namespace CapiStay.Domain.Entities;

public class Booking : BaseEntity
{
    public string BookingNumber { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public Guid RoomId { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public int GuestCount { get; set; }

    public decimal Subtotal { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public string Currency { get; set; } = "USD";

    public BookingStatus Status { get; set; } = BookingStatus.PendingPayment;

    public DateTime ExpiresAt { get; set; }

    public DateTime? ConfirmedAt { get; set; }

    public DateTime? CancelledAt { get; set; }

    public string? CancellationReason { get; set; }

    public User User { get; set; } = null!;

    public Room Room { get; set; } = null!;

    public ICollection<BookingNight> Nights { get; set; } = new List<BookingNight>();

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
