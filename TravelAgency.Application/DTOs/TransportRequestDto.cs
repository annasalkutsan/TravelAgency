namespace TravelAgency.Application.DTOs;

public class TransportRequestDto
{
    public string Type { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Capacity { get; set; }
}