
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class RefundConfiguration : IEntityTypeConfiguration<Refund>
{
    public void Configure(EntityTypeBuilder<Refund> builder)
    {
        builder.ToTable("Refunds");

        builder.HasKey(refund => refund.Id);

        builder.Property(refund => refund.PaymentId)
            .IsRequired();

        builder.Property(refund => refund.Amount)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(refund => refund.Currency)
            .IsRequired()
            .HasMaxLength(3)
            .HasDefaultValue("USD");

        builder.Property(refund => refund.Status)
            .IsRequired();

        builder.Property(refund => refund.ProviderRefundId)
            .HasMaxLength(255);

        builder.Property(refund => refund.AdminUserId)
            .IsRequired();

        builder.Property(refund => refund.Reason)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(refund => refund.ProcessedAt);

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Refunds_Amount",
                "[Amount] > 0");
        });

        builder.HasIndex(refund => refund.ProviderRefundId)
            .IsUnique()
            .HasFilter("[ProviderRefundId] IS NOT NULL");

        builder.HasIndex(refund => new
        {
            refund.PaymentId,
            refund.CreatedAt
        });

        builder.HasOne(refund => refund.Payment)
            .WithMany()
            .HasForeignKey(refund => refund.PaymentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(refund => refund.AdminUser)
            .WithMany()
            .HasForeignKey(refund => refund.AdminUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
