
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class AccountDeletionRequestConfiguration : IEntityTypeConfiguration<AccountDeletionRequest>
{
    public void Configure(EntityTypeBuilder<AccountDeletionRequest> builder)
    {
        builder.ToTable("AccountDeletionRequests");

        builder.HasKey(request => request.Id);

        builder.Property(request => request.UserId)
            .IsRequired();

        builder.Property(request => request.Status)
            .IsRequired();

        builder.Property(request => request.AdminNotes)
            .HasMaxLength(2000);

        builder.Property(request => request.ReviewedByAdminId);

        builder.Property(request => request.ReviewedAt);

        builder.Property(request => request.CompletedAt);

        builder.HasIndex(request => new
        {
            request.UserId,
            request.CreatedAt
        });

        builder.HasOne(request => request.User)
            .WithMany()
            .HasForeignKey(request => request.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(request => request.ReviewedByAdmin)
            .WithMany()
            .HasForeignKey(request => request.ReviewedByAdminId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
