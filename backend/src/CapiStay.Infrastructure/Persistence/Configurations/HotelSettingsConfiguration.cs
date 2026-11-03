
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class HotelSettingsConfiguration : IEntityTypeConfiguration<HotelSettings>
{
    public void Configure(EntityTypeBuilder<HotelSettings> builder)
    {
        builder.ToTable("HotelSettings");

        builder.HasKey(settings => settings.Id);

        builder.Property(settings => settings.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(settings => settings.Description)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(settings => settings.Address)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(settings => settings.Phone)
            .HasMaxLength(30);

        builder.Property(settings => settings.Email)
            .HasMaxLength(254);

        builder.Property(settings => settings.Website)
            .HasMaxLength(2048);

        builder.Property(settings => settings.LogoUrl)
            .HasMaxLength(2048);

        builder.Property(settings => settings.FacebookUrl)
            .HasMaxLength(2048);

        builder.Property(settings => settings.InstagramUrl)
            .HasMaxLength(2048);

        builder.Property(settings => settings.CheckInTime)
            .IsRequired()
            .HasDefaultValue(new TimeOnly(15, 0));

        builder.Property(settings => settings.CheckOutTime)
            .IsRequired()
            .HasDefaultValue(new TimeOnly(11, 0));
    }
}
