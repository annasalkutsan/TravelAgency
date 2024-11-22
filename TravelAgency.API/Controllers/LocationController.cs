using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.DTOs;
using TravelAgency.Application.Services;

namespace TravelAgency.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly LocationService _locationService;

    public LocationController(LocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLocationById(Guid id)
    {
        var location = await _locationService.GetLocationByIdAsync(id);
        return Ok(location);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLocations()
    {
        var locations = await _locationService.GetAllLocationsAsync();
        return Ok(locations);
    }

    [HttpPost]
    public async Task<IActionResult> AddLocation(LocationRequestDto locationDto)
    {
        var createdLocation = await _locationService.AddLocationAsync(locationDto);
        return CreatedAtAction(nameof(GetLocationById), new { id = createdLocation.Id }, createdLocation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLocation(Guid id, LocationRequestDto locationDto)
    {
        var updatedLocation = await _locationService.UpdateLocationAsync(id, locationDto);
        return Ok(updatedLocation);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveLocation(Guid id)
    {
        await _locationService.RemoveLocationAsync(id);
        return NoContent();
    }
}