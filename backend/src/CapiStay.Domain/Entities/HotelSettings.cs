
using CapiStay.Domain.Common;

namespace CapiStay.Domain.Entities;

public class HotelSettings : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Website { get; set; }

    public string? LogoUrl { get; set; }

    public string? FacebookUrl { get; set; }

    public string? InstagramUrl { get; set; }

    public TimeOnly CheckInTime { get; set; } = new(15, 0);

    public TimeOnly CheckOutTime { get; set; } = new(11, 0);
}
