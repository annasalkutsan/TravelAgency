namespace TravelAgency.Application.DTOs;

public class ClientRequestDto
{
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
}