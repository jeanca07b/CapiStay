
using CapiStay.Domain.Common;

namespace CapiStay.Domain.Entities;

public class HotelService : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsFree { get; set; }

    public decimal? Price { get; set; }

    public string Currency { get; set; } = "USD";

    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; } = true;

    public int DisplayOrder { get; set; }
}
