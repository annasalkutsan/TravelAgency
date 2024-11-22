namespace TravelAgency.Application.DTOs;

public class LocationResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Country { get; set; } = null!;
}