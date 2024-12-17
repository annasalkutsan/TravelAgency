using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.DTOs;
using TravelAgency.Application.Services;

namespace TravelAgency.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly BookingService _bookingService;

    public BookingController(BookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingById(Guid id)
    {
        var booking = await _bookingService.GetBookingByIdAsync(id);
        return Ok(booking);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBookings()
    {
        var bookings = await _bookingService.GetAllBookingsAsync();
        return Ok(bookings);
    }

    [HttpPost]
    public async Task<IActionResult> AddBooking(BookingRequestDto bookingDto)
    {
        var createdBooking = await _bookingService.AddBookingAsync(bookingDto);
        return CreatedAtAction(nameof(GetBookingById), new { id = createdBooking.Id }, createdBooking);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBooking(Guid id, BookingRequestDto bookingDto)
    {
        var updatedBooking = await _bookingService.UpdateBookingAsync(id, bookingDto);
        return Ok(updatedBooking);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveBooking(Guid id)
    {
        await _bookingService.RemoveBookingAsync(id);
        return NoContent();
    }
}