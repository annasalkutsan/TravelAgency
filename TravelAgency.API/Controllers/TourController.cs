using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.DTOs;
using TravelAgency.Application.Services;

namespace TravelAgency.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TourController : ControllerBase
{
    private readonly TourService _tourService;

    public TourController(TourService tourService)
    {
        _tourService = tourService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTourById(Guid id)
    {
        var tour = await _tourService.GetTourByIdAsync(id);
        return Ok(tour);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResultDto<TourResponseDto>>> GetAllToursAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        if (pageNumber < 1) pageNumber = 1; // Обработка некорректного номера страницы
        if (pageSize < 1) pageSize = 10; // Обработка некорректного размера страницы

        var result = await _tourService.GetAllToursAsync(pageNumber, pageSize);
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddTour(TourRequestDto tourDto)
    {
        var createdTour = await _tourService.AddTourAsync(tourDto);
        return CreatedAtAction(nameof(GetTourById), new { id = createdTour.Id }, createdTour);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTour(Guid id, TourRequestDto tourDto)
    {
        var updatedTour = await _tourService.UpdateTourAsync(id, tourDto);
        return Ok(updatedTour);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveTour(Guid id)
    {
        await _tourService.RemoveTourAsync(id);
        return NoContent();
    }
}