
using CapiStay.Domain.Common;
using CapiStay.Domain.Enums;

namespace CapiStay.Domain.Entities;

public class RoomBlock : BaseEntity
{
    public Guid RoomId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public RoomBlockReason ReasonType { get; set; }

    public string Reason { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public Room Room { get; set; } = null!;
}
