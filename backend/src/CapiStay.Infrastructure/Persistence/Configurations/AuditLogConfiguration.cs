
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("AuditLogs");

        builder.HasKey(log => log.Id);

        builder.Property(log => log.UserId);

        builder.Property(log => log.Action)
            .IsRequired();

        builder.Property(log => log.Module)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(log => log.EntityId);

        builder.Property(log => log.OldValues);

        builder.Property(log => log.NewValues);

        builder.Property(log => log.Reason)
            .HasMaxLength(1000);

        builder.Property(log => log.IpAddress)
            .HasMaxLength(45);

        builder.HasIndex(log => new
        {
            log.Module,
            log.CreatedAt
        });

        builder.HasIndex(log => new
        {
            log.UserId,
            log.CreatedAt
        });

        builder.HasOne(log => log.User)
            .WithMany()
            .HasForeignKey(log => log.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
