
using CapiStay.Domain.Common;

namespace CapiStay.Domain.Entities;

public class BookingNight : BaseEntity
{
    public Guid BookingId { get; set; }

    public Guid SeasonId { get; set; }

    public DateOnly StayDate { get; set; }

    public decimal PricePerNight { get; set; }

    public string Currency { get; set; } = "USD";

    public Booking Booking { get; set; } = null!;

    public Season Season { get; set; } = null!;
}
