namespace TravelAgency.Application.DTOs;

public class TourLocationRequestDto
{
    public Guid TourId { get; set; }
    public Guid LocationId { get; set; }
    public int VisitOrder { get; set; } // Порядок посещения
}