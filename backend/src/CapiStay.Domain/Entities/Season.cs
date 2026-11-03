
using CapiStay.Domain.Common;

namespace CapiStay.Domain.Entities;

public class Season : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public bool IsActive { get; set; } = true;
}
