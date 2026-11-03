
using CapiStay.Domain.Common;

namespace CapiStay.Domain.Entities;

public class Promotion : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string? ImageUrl { get; set; }

    public string? LinkUrl { get; set; }

    public DateTime StartsAt { get; set; }

    public DateTime ExpiresAt { get; set; }

    public bool IsActive { get; set; } = true;

    public int DisplayOrder { get; set; }
}
