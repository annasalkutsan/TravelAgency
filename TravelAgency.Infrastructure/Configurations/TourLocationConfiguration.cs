using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Domain.Models;

namespace TravelAgency.Infrastructure.Configurations;

public class TourLocationConfiguration : IEntityTypeConfiguration<TourLocation>
{
    public void Configure(EntityTypeBuilder<TourLocation> builder)
    {
        builder.ToTable("TourLocations");

        builder.HasKey(tl => new { tl.TourId, tl.LocationId });

        builder.Property(tl => tl.TourId).HasColumnName("tourId");
        builder.Property(tl => tl.LocationId).HasColumnName("locationId");
        builder.Property(tl => tl.VisitOrder).HasColumnName("visitOrder").IsRequired();

        builder.HasOne(tl => tl.Tour)
            .WithMany(t => t.TourLocations)
            .HasForeignKey(tl => tl.TourId);

        builder.HasOne(tl => tl.Location)
            .WithMany(l => l.TourLocations)
            .HasForeignKey(tl => tl.LocationId);
    }
}