using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Domain.Models;

namespace TravelAgency.Infrastructure;

public class TravelAgencyDbContext : DbContext
{
    public TravelAgencyDbContext(DbContextOptions<TravelAgencyDbContext> options) 
        : base(options) { }
    
    public TravelAgencyDbContext() { }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<TourLocation> TourLocations { get; set; }
    public DbSet<Transport> Transports { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=12345;Database=postgres;");
        }
    }
}