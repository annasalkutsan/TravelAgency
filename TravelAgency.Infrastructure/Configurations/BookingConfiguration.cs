using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Domain.Models;

namespace TravelAgency.Infrastructure.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");

        builder.Property(b => b.Id).HasColumnName("id");
        builder.Property(b => b.CreationDate).HasColumnName("creationDate");
        builder.Property(b => b.ClientId).HasColumnName("clientId");
        builder.Property(b => b.TourId).HasColumnName("tourId");
        builder.Property(b => b.BookingDate).HasColumnName("bookingDate").IsRequired();

        builder.HasOne(b => b.Client)
            .WithMany(c => c.Bookings)
            .HasForeignKey(b => b.ClientId);

        builder.HasOne(b => b.Tour)
            .WithMany(t => t.Bookings)
            .HasForeignKey(b => b.TourId);
    }
}