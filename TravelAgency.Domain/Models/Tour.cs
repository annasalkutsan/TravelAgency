namespace TravelAgency.Domain.Models;

public class Tour : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public ICollection<TourLocation> TourLocations { get; set; } = new List<TourLocation>();
    public ICollection<Transport> Transports { get; set; } = new List<Transport>();
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    
    public Tour (){}   
}