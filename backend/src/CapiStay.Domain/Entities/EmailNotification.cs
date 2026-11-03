
using CapiStay.Domain.Common;
using CapiStay.Domain.Enums;

namespace CapiStay.Domain.Entities;

public class EmailNotification : BaseEntity
{
    public Guid? UserId { get; set; }

    public string RecipientEmail { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public string Body { get; set; } = string.Empty;

    public EmailNotificationStatus Status { get; set; } =
        EmailNotificationStatus.Pending;

    public int Attempts { get; set; }

    public DateTime? SentAt { get; set; }

    public DateTime? LastAttemptAt { get; set; }

    public string? ErrorMessage { get; set; }

    public string? EventId { get; set; }

    public User? User { get; set; }
}
