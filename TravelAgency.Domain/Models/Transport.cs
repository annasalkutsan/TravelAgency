namespace TravelAgency.Domain.Models;

public class Transport : BaseEntity
{
    public string Type { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Capacity { get; set; }

    // Связь с турами
    public ICollection<Tour> Tours { get; set; } = new List<Tour>();
}