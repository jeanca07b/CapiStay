
using CapiStay.Domain.Common;
using CapiStay.Domain.Enums;

namespace CapiStay.Domain.Entities;

public class BookingModification : BaseEntity
{
    public Guid BookingId { get; set; }

    public Guid AdminUserId { get; set; }

    public DateOnly PreviousCheckInDate { get; set; }

    public DateOnly PreviousCheckOutDate { get; set; }

    public DateOnly NewCheckInDate { get; set; }

    public DateOnly NewCheckOutDate { get; set; }

    public decimal PreviousTotalAmount { get; set; }

    public decimal NewTotalAmount { get; set; }

    public decimal PriceDifference { get; set; }

    public string Reason { get; set; } = string.Empty;

    public BookingModificationStatus Status { get; set; } =
        BookingModificationStatus.Pending;

    public Booking Booking { get; set; } = null!;

    public User AdminUser { get; set; } = null!;
}
