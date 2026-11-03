
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");

        builder.HasKey(payment => payment.Id);

        builder.Property(payment => payment.BookingId)
            .IsRequired();

        builder.Property(payment => payment.Amount)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(payment => payment.Currency)
            .IsRequired()
            .HasMaxLength(3)
            .HasDefaultValue("USD");

        builder.Property(payment => payment.Status)
            .IsRequired();

        builder.Property(payment => payment.Provider)
            .IsRequired()
            .HasMaxLength(30)
            .HasDefaultValue("Stripe");

        builder.Property(payment => payment.ProviderPaymentId)
            .HasMaxLength(255);

        builder.Property(payment => payment.PaidAt);

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Payments_Amount",
                "[Amount] > 0");
        });

        builder.HasIndex(payment => payment.ProviderPaymentId)
            .IsUnique()
            .HasFilter("[ProviderPaymentId] IS NOT NULL");

        builder.HasIndex(payment => new
        {
            payment.BookingId,
            payment.CreatedAt
        });

        builder.HasOne(payment => payment.Booking)
            .WithMany(booking => booking.Payments)
            .HasForeignKey(payment => payment.BookingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
