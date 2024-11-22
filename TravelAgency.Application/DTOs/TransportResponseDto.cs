namespace TravelAgency.Application.DTOs;

public class TransportResponseDto
{
    public Guid Id { get; set; }
    public string Type { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Capacity { get; set; }
}