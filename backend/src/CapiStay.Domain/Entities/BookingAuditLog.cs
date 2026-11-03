
using CapiStay.Domain.Common;
using CapiStay.Domain.Enums;

namespace CapiStay.Domain.Entities;

public class BookingAuditLog : BaseEntity
{
    public Guid BookingId { get; set; }

    public Guid? UserId { get; set; }

    public BookingAuditAction Action { get; set; }

    public string? PreviousStatus { get; set; }

    public string? NewStatus { get; set; }

    public string? Description { get; set; }

    public string? Reason { get; set; }

    public Booking Booking { get; set; } = null!;

    public User? User { get; set; }
}
