namespace TravelAgency.Domain.Models;

public class Location : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Country { get; set; }
    public ICollection<TourLocation> TourLocations { get; set; } = new List<TourLocation>();
    
    public Location (){}   
}