using TravelAgency.Domain.ValueObjects;

namespace TravelAgency.Domain.Models;

public class Client : BaseEntity
{
    public FullName Name { get; set; } 
    public string Phone { get; set; }
    public string? Email { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    
    public Client (){}   
}