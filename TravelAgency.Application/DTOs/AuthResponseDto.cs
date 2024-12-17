namespace TravelAgency.Application.DTOs;

public class AuthResponseDto
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Token { get; set; }
}