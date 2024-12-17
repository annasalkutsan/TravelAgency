using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.DTOs;
using TravelAgency.Application.Services;

namespace TravelAgency.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TransportController : ControllerBase
{
    private readonly TransportService _transportService;

    public TransportController(TransportService transportService)
    {
        _transportService = transportService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTransportById(Guid id)
    {
        var transport = await _transportService.GetTransportByIdAsync(id);
        return Ok(transport);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTransports()
    {
        var transports = await _transportService.GetAllTransportsAsync();
        return Ok(transports);
    }

    [HttpPost]
    public async Task<IActionResult> AddTransport(TransportRequestDto transportDto)
    {
        var createdTransport = await _transportService.AddTransportAsync(transportDto);
        return CreatedAtAction(nameof(GetTransportById), new { id = createdTransport.Id }, createdTransport);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTransport(Guid id, TransportRequestDto transportDto)
    {
        var updatedTransport = await _transportService.UpdateTransportAsync(id, transportDto);
        return Ok(updatedTransport);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveTransport(Guid id)
    {
        await _transportService.RemoveTransportAsync(id);
        return NoContent();
    }
}