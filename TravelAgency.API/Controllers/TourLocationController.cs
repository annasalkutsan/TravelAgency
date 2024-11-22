using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.DTOs;
using TravelAgency.Application.Services;

namespace TravelAgency.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TourLocationController : ControllerBase
{
    private readonly TourLocationService _tourLocationService;

    public TourLocationController(TourLocationService tourLocationService)
    {
        _tourLocationService = tourLocationService;
    }

    [HttpGet("{tourId}/{locationId}")]
    public async Task<IActionResult> GetTourLocationById(Guid tourId, Guid locationId)
    {
        var tourLocation = await _tourLocationService.GetTourLocationByIdAsync(tourId, locationId);

        if (tourLocation == null)
            return NotFound($"TourLocation with TourId {tourId} and LocationId {locationId} not found.");

        return Ok(tourLocation);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllTourLocations()
    {
        var tourLocations = await _tourLocationService.GetAllTourLocationsAsync();
        return Ok(tourLocations);
    }

    [HttpPost]
    public async Task<IActionResult> AddTourLocation(TourLocationRequestDto tourLocationDto)
    {
        var createdTourLocation = await _tourLocationService.AddTourLocationAsync(tourLocationDto);
        return CreatedAtAction(nameof(GetAllTourLocations), new { }, createdTourLocation);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateVisitOrder(Guid tourId, Guid locationId, int newOrder)
    {
        var updatedTourLocation = await _tourLocationService.UpdateVisitOrderAsync(tourId, locationId, newOrder);
        return Ok(updatedTourLocation);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveTourLocation(Guid tourId, Guid locationId)
    {
        await _tourLocationService.RemoveTourLocationAsync(tourId, locationId);
        return NoContent();
    }
}