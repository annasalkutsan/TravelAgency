using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.DTOs;
using TravelAgency.Application.Services;

namespace TravelAgency.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(ClientRegisterDto registerDto)
    {
        var authResponse = await _authService.RegisterAsync(registerDto);
        return Ok(authResponse);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(ClientLoginDto loginDto)
    {
        var authResponse = await _authService.LoginAsync(loginDto);
        return Ok(authResponse);
    }
}