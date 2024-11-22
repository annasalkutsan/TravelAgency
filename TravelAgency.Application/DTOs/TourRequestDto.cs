namespace TravelAgency.Application.DTOs;

public class TourRequestDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public Guid? TransportId { get; set; }
}