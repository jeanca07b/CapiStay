
using CapiStay.Domain.Common;

namespace CapiStay.Domain.Entities;

public class RoomType : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int MaxCapacity { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}
