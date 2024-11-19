using TravelAgency.Domain.ValueObjects;

namespace TravelAgency.Domain.Models;

public class Client : BaseEntity
{
    public FullName FullName { get; set; } 
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    
    public Client (){}   
}