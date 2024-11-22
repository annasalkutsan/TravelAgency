namespace TravelAgency.Application.DTOs;

public class TourLocationResponseDto
{
    public Guid Id { get; set; }
    public Guid TourId { get; set; }
    public Guid LocationId { get; set; }
    public int VisitOrder { get; set; } // Порядок посещения
}