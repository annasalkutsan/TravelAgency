namespace TravelAgency.Application.DTOs;

public class BookingRequestDto
{
    public Guid ClientId { get; set; }
    public Guid TourId { get; set; }
    public DateTime BookingDate { get; set; }
}