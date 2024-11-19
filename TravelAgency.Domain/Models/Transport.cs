namespace TravelAgency.Domain.Models;

public class Transport : BaseEntity
{
    public string Type { get; set; }
    public int Capacity { get; set; }
    public Guid TourId { get; set; }
    public Tour Tour { get; set; }
    
    public Transport (){}   
}