namespace TravelAgency.Domain.Models;

public class Booking : BaseEntity
{
    public Guid ClientId { get; set; }
    public Client Client { get; set; } = null!;

    public Guid TourId { get; set; }
    public Tour Tour { get; set; } = null!;

    public DateTime BookingDate { get; set; }
}