
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class RoomBlockConfiguration : IEntityTypeConfiguration<RoomBlock>
{
    public void Configure(EntityTypeBuilder<RoomBlock> builder)
    {
        builder.ToTable("RoomBlocks");

        builder.HasKey(block => block.Id);

        builder.Property(block => block.RoomId)
            .IsRequired();

        builder.Property(block => block.StartDate)
            .IsRequired();

        builder.Property(block => block.EndDate)
            .IsRequired();

        builder.Property(block => block.ReasonType)
            .IsRequired();

        builder.Property(block => block.Reason)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(block => block.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_RoomBlocks_DateRange",
                "[EndDate] > [StartDate]");
        });

        builder.HasIndex(block => new
        {
            block.RoomId,
            block.StartDate,
            block.EndDate
        });

        builder.HasOne(block => block.Room)
            .WithMany()
            .HasForeignKey(block => block.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
