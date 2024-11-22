using AutoMapper;
using TravelAgency.Application.DTOs;
using TravelAgency.Domain.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.Application.Services;

public class BookingService
{
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IMapper _mapper;

    public BookingService(IRepository<Booking> bookingRepository, IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
    }

    public async Task<BookingResponseDto> GetBookingByIdAsync(Guid id)
    {
        var booking = await _bookingRepository.GetByIdAsync(id);
        if (booking == null)
            throw new KeyNotFoundException($"Booking with ID {id} not found.");

        return _mapper.Map<BookingResponseDto>(booking);
    }

    public async Task<ICollection<BookingResponseDto>> GetAllBookingsAsync()
    {
        var bookings = await _bookingRepository.GetAllAsync();
        return _mapper.Map<ICollection<BookingResponseDto>>(bookings);
    }

    public async Task<BookingResponseDto> AddBookingAsync(BookingRequestDto bookingDto)
    {
        var booking = _mapper.Map<Booking>(bookingDto);
        booking.Id = Guid.NewGuid();
        await _bookingRepository.AddAsync(booking);
        return _mapper.Map<BookingResponseDto>(booking);
    }

    public async Task<BookingResponseDto> UpdateBookingAsync(Guid id, BookingRequestDto bookingDto)
    {
        var existingBooking = await _bookingRepository.GetByIdAsync(id);
        if (existingBooking == null)
            throw new KeyNotFoundException($"Booking with ID {id} not found.");

        _mapper.Map(bookingDto, existingBooking);
        await _bookingRepository.UpdateAsync(existingBooking);
        return _mapper.Map<BookingResponseDto>(existingBooking);
    }

    public async Task RemoveBookingAsync(Guid id)
    {
        var booking = await _bookingRepository.GetByIdAsync(id);
        if (booking == null)
            throw new KeyNotFoundException($"Booking with ID {id} not found.");

        await _bookingRepository.RemoveAsync(booking);
    }
}