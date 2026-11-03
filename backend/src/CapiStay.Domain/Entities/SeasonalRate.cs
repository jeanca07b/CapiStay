
using CapiStay.Domain.Common;

namespace CapiStay.Domain.Entities;

public class SeasonalRate : BaseEntity
{
    public Guid SeasonId { get; set; }

    public Guid RoomTypeId { get; set; }

    public decimal PricePerNight { get; set; }

    public string Currency { get; set; } = "USD";

    public Season Season { get; set; } = null!;

    public RoomType RoomType { get; set; } = null!;
}
