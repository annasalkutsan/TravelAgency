namespace TravelAgency.Domain.Models;

public class Booking : BaseEntity
{
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    public Guid TourId { get; set; }
    public Tour Tour { get; set; }
    public DateTime BookingDate { get; set; }
    public int Seats { get; set; }
    
    public Booking (){}   
}