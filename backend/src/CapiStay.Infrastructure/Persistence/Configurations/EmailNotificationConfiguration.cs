using CapiStay.Domain.Enums;
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class EmailNotificationConfiguration : IEntityTypeConfiguration<EmailNotification>
{
    public void Configure(EntityTypeBuilder<EmailNotification> builder)
    {
        builder.ToTable("EmailNotifications");

        builder.HasKey(email => email.Id);

        builder.Property(email => email.UserId);

        builder.Property(email => email.RecipientEmail)
            .IsRequired()
            .HasMaxLength(254);

        builder.Property(email => email.Subject)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(email => email.Body)
            .IsRequired();

        builder.Property(email => email.Status)
            .IsRequired()
            .HasDefaultValue(EmailNotificationStatus.Pending)
            .HasSentinel(EmailNotificationStatus.Pending);

        builder.Property(email => email.Attempts)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(email => email.SentAt);

        builder.Property(email => email.LastAttemptAt);

        builder.Property(email => email.ErrorMessage)
            .HasMaxLength(2000);

        builder.Property(email => email.EventId)
            .HasMaxLength(150);

        builder.HasIndex(email => email.EventId)
            .IsUnique()
            .HasFilter("[EventId] IS NOT NULL");

        builder.HasIndex(email => new
        {
            email.Status,
            email.CreatedAt
        });

        builder.HasOne(email => email.User)
            .WithMany()
            .HasForeignKey(email => email.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
