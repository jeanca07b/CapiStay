
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class WebhookEventConfiguration : IEntityTypeConfiguration<WebhookEvent>
{
    public void Configure(EntityTypeBuilder<WebhookEvent> builder)
    {
        builder.ToTable("WebhookEvents");

        builder.HasKey(webhookEvent => webhookEvent.Id);

        builder.Property(webhookEvent => webhookEvent.Provider)
            .IsRequired()
            .HasMaxLength(30)
            .HasDefaultValue("Stripe");

        builder.Property(webhookEvent => webhookEvent.ProviderEventId)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(webhookEvent => webhookEvent.EventType)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(webhookEvent => webhookEvent.Payload)
            .IsRequired();

        builder.Property(webhookEvent => webhookEvent.IsProcessed)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(webhookEvent => webhookEvent.ProcessedAt);

        builder.Property(webhookEvent => webhookEvent.ErrorMessage)
            .HasMaxLength(2000);

        builder.HasIndex(webhookEvent => new
        {
            webhookEvent.Provider,
            webhookEvent.ProviderEventId
        }).IsUnique();

        builder.HasIndex(webhookEvent => new
        {
            webhookEvent.IsProcessed,
            webhookEvent.CreatedAt
        });
    }
}
