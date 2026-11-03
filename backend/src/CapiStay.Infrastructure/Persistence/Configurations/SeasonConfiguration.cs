
using CapiStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapiStay.Infrastructure.Persistence.Configurations;

public class SeasonConfiguration : IEntityTypeConfiguration<Season>
{
    public void Configure(EntityTypeBuilder<Season> builder)
    {
        builder.ToTable("Seasons");

        builder.HasKey(season => season.Id);

        builder.Property(season => season.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(season => season.StartDate)
            .IsRequired();

        builder.Property(season => season.EndDate)
            .IsRequired();

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Seasons_DateRange",
                "[EndDate] > [StartDate]");
        });

        builder.Property(season => season.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasIndex(season => new
        {
            season.StartDate,
            season.EndDate
        });
    }
}
