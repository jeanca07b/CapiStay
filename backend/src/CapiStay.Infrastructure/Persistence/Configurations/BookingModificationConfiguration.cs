
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class BookingModificationConfiguration : IEntityTypeConfiguration<BookingModification>
{
    public void Configure(EntityTypeBuilder<BookingModification> builder)
    {
        builder.ToTable("BookingModifications");

        builder.HasKey(modification => modification.Id);

        builder.Property(modification => modification.BookingId)
            .IsRequired();

        builder.Property(modification => modification.AdminUserId)
            .IsRequired();

        builder.Property(modification => modification.PreviousCheckInDate)
            .IsRequired();

        builder.Property(modification => modification.PreviousCheckOutDate)
            .IsRequired();

        builder.Property(modification => modification.NewCheckInDate)
            .IsRequired();

        builder.Property(modification => modification.NewCheckOutDate)
            .IsRequired();

        builder.Property(modification => modification.PreviousTotalAmount)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(modification => modification.NewTotalAmount)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(modification => modification.PriceDifference)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(modification => modification.Reason)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(modification => modification.Status)
            .IsRequired();

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_BookingModifications_PreviousDates",
                "[PreviousCheckOutDate] > [PreviousCheckInDate]");

            table.HasCheckConstraint(
                "CK_BookingModifications_NewDates",
                "[NewCheckOutDate] > [NewCheckInDate]");

            table.HasCheckConstraint(
            "CK_BookingModifications_Amounts",
            "[PreviousTotalAmount] >= 0 AND [NewTotalAmount] >= 0");
        });

        builder.HasIndex(modification => new
        {
            modification.BookingId,
            modification.CreatedAt
        });

        builder.HasOne(modification => modification.Booking)
            .WithMany()
            .HasForeignKey(modification => modification.BookingId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(modification => modification.AdminUser)
            .WithMany()
            .HasForeignKey(modification => modification.AdminUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
