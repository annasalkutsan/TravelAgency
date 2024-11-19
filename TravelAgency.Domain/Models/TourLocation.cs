namespace TravelAgency.Domain.Models;

public class TourLocation
{
    public Guid TourId { get; set; }
    public Tour Tour { get; set; }
    public Guid LocationId { get; set; }
    public Location Location { get; set; }
    public int VisitOrder { get; set; }
    
    public TourLocation (){}   
}