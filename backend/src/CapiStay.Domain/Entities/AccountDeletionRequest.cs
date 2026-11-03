
using CapiStay.Domain.Common;
using CapiStay.Domain.Enums;

namespace CapiStay.Domain.Entities;

public class AccountDeletionRequest : BaseEntity
{
    public Guid UserId { get; set; }

    public AccountDeletionRequestStatus Status { get; set; } =
        AccountDeletionRequestStatus.Pending;

    public string? AdminNotes { get; set; }

    public Guid? ReviewedByAdminId { get; set; }

    public DateTime? ReviewedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public User User { get; set; } = null!;

    public User? ReviewedByAdmin { get; set; }
}
