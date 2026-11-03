
using CapiStay.Domain.Common;

namespace CapiStay.Domain.Entities;

public class Room : BaseEntity
{
    public string RoomNumber { get; set; } = string.Empty;

    public int? Floor { get; set; }

    public Guid RoomTypeId { get; set; }

    public bool IsActive { get; set; } = true;

    public RoomType RoomType { get; set; } = null!;
}
