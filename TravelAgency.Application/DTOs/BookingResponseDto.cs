namespace TravelAgency.Application.DTOs;

public class BookingResponseDto
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public Guid TourId { get; set; }
    public DateTime BookingDate { get; set; }
}