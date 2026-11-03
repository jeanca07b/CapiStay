
using CapiStay.Domain.Common;

namespace CapiStay.Domain.Entities;

public class RoomTypeAmenity : BaseEntity
{
    public Guid RoomTypeId { get; set; }

    public Guid AmenityId { get; set; }

    public RoomType RoomType { get; set; } = null!;

    public Amenity Amenity { get; set; } = null!;
}
