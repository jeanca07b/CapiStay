
using CapiStay.Domain.Common;

namespace CapiStay.Domain.Entities;

public class RoomTypeImage : BaseEntity
{
    public Guid RoomTypeId { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    public string AltText { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public bool IsPrimary { get; set; }

    public RoomType RoomType { get; set; } = null!;
}
