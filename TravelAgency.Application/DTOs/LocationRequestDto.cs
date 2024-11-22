namespace TravelAgency.Application.DTOs;

public class LocationRequestDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Country { get; set; } = null!;
}