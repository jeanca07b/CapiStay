
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");

        builder.HasKey(booking => booking.Id);

        builder.Property(booking => booking.BookingNumber)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasIndex(booking => booking.BookingNumber)
            .IsUnique();

        builder.Property(booking => booking.UserId)
            .IsRequired();

        builder.Property(booking => booking.RoomId)
            .IsRequired();

        builder.Property(booking => booking.CheckInDate)
            .IsRequired();

        builder.Property(booking => booking.CheckOutDate)
            .IsRequired();

        builder.Property(booking => booking.GuestCount)
            .IsRequired();

        builder.Property(booking => booking.Subtotal)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(booking => booking.DiscountAmount)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(booking => booking.TotalAmount)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(booking => booking.Currency)
            .IsRequired()
            .HasMaxLength(3)
            .HasDefaultValue("USD");

        builder.Property(booking => booking.Status)
            .IsRequired();

        builder.Property(booking => booking.ExpiresAt);

        builder.Property(booking => booking.ConfirmedAt);

        builder.Property(booking => booking.CancelledAt);

        builder.Property(booking => booking.CancellationReason)
            .HasMaxLength(1000);

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Bookings_DateRange",
                "[CheckOutDate] > [CheckInDate]");

            table.HasCheckConstraint(
                "CK_Bookings_GuestCount",
                "[GuestCount] > 0");

            table.HasCheckConstraint(
                "CK_Bookings_Amounts",
                "[Subtotal] >= 0 AND [DiscountAmount] >= 0 AND [TotalAmount] >= 0");
        });

        builder.HasIndex(booking => new
        {
            booking.RoomId,
            booking.CheckInDate,
            booking.CheckOutDate
        });

        builder.HasIndex(booking => new
        {
            booking.UserId,
            booking.CreatedAt
        });

        builder.HasOne(booking => booking.User)
            .WithMany(user => user.Bookings)
            .HasForeignKey(booking => booking.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(booking => booking.Room)
            .WithMany()
            .HasForeignKey(booking => booking.RoomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(booking => booking.Nights)
            .WithOne(night => night.Booking)
            .HasForeignKey(night => night.BookingId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(booking => booking.Payments)
            .WithOne(payment => payment.Booking)
            .HasForeignKey(payment => payment.BookingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
