
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class BookingAuditLogConfiguration : IEntityTypeConfiguration<BookingAuditLog>
{
    public void Configure(EntityTypeBuilder<BookingAuditLog> builder)
    {
        builder.ToTable("BookingAuditLogs");

        builder.HasKey(log => log.Id);

        builder.Property(log => log.BookingId)
            .IsRequired();

        builder.Property(log => log.UserId);

        builder.Property(log => log.Action)
            .IsRequired();

        builder.Property(log => log.PreviousStatus)
            .HasMaxLength(50);

        builder.Property(log => log.NewStatus)
            .HasMaxLength(50);

        builder.Property(log => log.Description)
            .HasMaxLength(1000);

        builder.Property(log => log.Reason)
            .HasMaxLength(1000);

        builder.HasIndex(log => new
        {
            log.BookingId,
            log.CreatedAt
        });

        builder.HasOne(log => log.Booking)
            .WithMany()
            .HasForeignKey(log => log.BookingId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(log => log.User)
            .WithMany()
            .HasForeignKey(log => log.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
