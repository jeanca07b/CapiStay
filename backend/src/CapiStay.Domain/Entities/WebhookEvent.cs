
using CapiStay.Domain.Common;

namespace CapiStay.Domain.Entities;

public class WebhookEvent : BaseEntity
{
    public string Provider { get; set; } = "Stripe";

    public string ProviderEventId { get; set; } = string.Empty;

    public string EventType { get; set; } = string.Empty;

    public string Payload { get; set; } = string.Empty;

    public bool IsProcessed { get; set; }

    public DateTime? ProcessedAt { get; set; }

    public string? ErrorMessage { get; set; }
}
