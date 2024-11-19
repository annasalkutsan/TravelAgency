using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Domain.Models;

namespace TravelAgency.Infrastructure.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");

        builder.Property(l => l.Id).HasColumnName("id");
        builder.Property(l => l.CreationDate).HasColumnName("creationDate");
        builder.Property(l => l.Name).HasColumnName("name").IsRequired();
        builder.Property(l => l.Description).HasColumnName("description");
        builder.Property(l => l.Country).HasColumnName("country").IsRequired();

        builder.HasMany(l => l.TourLocations)
            .WithOne(tl => tl.Location)
            .HasForeignKey(tl => tl.LocationId);
    }
}