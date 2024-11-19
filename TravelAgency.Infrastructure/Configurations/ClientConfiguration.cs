﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Domain.Models;

namespace TravelAgency.Infrastructure.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");

        builder.Property(c => c.Id).HasColumnName("id");
        builder.Property(c => c.CreationDate).HasColumnName("creationDate");
        builder.Property(c => c.FullName.FirstName).HasColumnName("firstName").IsRequired();
        builder.Property(c => c.FullName.LastName).HasColumnName("lastName").IsRequired();
        builder.Property(c => c.Email).HasColumnName("email").IsRequired();
        builder.Property(c => c.PhoneNumber).HasColumnName("phoneNumber").IsRequired();

        builder.HasMany(c => c.Bookings)
            .WithOne(b => b.Client)
            .HasForeignKey(b => b.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}