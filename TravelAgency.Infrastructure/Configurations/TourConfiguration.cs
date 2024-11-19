using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Domain.Models;

namespace TravelAgency.Infrastructure.Configurations;

public class TourConfiguration : IEntityTypeConfiguration<Tour>
{
    public void Configure(EntityTypeBuilder<Tour> builder)
    {
        builder.ToTable("Tours");

        builder.Property(t => t.Id).HasColumnName("id");
        builder.Property(t => t.CreationDate).HasColumnName("creationDate");
        builder.Property(t => t.Name).HasColumnName("name").IsRequired();
        builder.Property(t => t.Description).HasColumnName("description").IsRequired();
        builder.Property(t => t.StartDate).HasColumnName("startDate");
        builder.Property(t => t.EndDate).HasColumnName("endDate");
        builder.Property(t => t.Price).HasColumnName("price");
        builder.Property(t => t.TransportId).HasColumnName("transportId");

        builder.HasOne(t => t.Transport)
            .WithMany(tr => tr.Tours)
            .HasForeignKey(t => t.TransportId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(t => t.TourLocations)
            .WithOne(tl => tl.Tour)
            .HasForeignKey(tl => tl.TourId);

        builder.HasMany(t => t.Bookings)
            .WithOne(b => b.Tour)
            .HasForeignKey(b => b.TourId);
    }
}