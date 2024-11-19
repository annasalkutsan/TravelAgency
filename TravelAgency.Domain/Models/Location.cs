namespace TravelAgency.Domain.Models;

public class Location : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Country { get; set; } = null!;

    // Связь с турами через TourLocation
    public ICollection<TourLocation> TourLocations { get; set; } = new List<TourLocation>();
}