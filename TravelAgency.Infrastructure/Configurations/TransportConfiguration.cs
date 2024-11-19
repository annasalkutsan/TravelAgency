using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Domain.Models;

namespace TravelAgency.Infrastructure.Configurations;

public class TransportConfiguration : IEntityTypeConfiguration<Transport>
{
    public void Configure(EntityTypeBuilder<Transport> builder)
    {
        builder.ToTable("Transports");

        builder.Property(t => t.Id).HasColumnName("id");
        builder.Property(t => t.CreationDate).HasColumnName("creationDate");
        builder.Property(t => t.Type).HasColumnName("type").IsRequired();
        builder.Property(t => t.Description).HasColumnName("description");
        builder.Property(t => t.Capacity).HasColumnName("capacity").IsRequired();

        builder.HasMany(t => t.Tours)
            .WithOne(t => t.Transport)
            .HasForeignKey(t => t.TransportId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}