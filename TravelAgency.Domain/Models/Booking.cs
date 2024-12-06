using FluentValidation;

namespace TravelAgency.Domain.Models;

public class Booking : BaseEntity
{
    public Guid ClientId { get; set; }
    public Client Client { get; set; } = null!;

    public Guid TourId { get; set; }
    public Tour Tour { get; set; } = null!;

    public DateTime BookingDate { get; set; }
    
    public Booking (){}
    public Booking(Guid clientId, Guid tourId, DateTime bookingDate, IValidator<Booking> validator)
    {
        ClientId = clientId;
        TourId = tourId;
        BookingDate = bookingDate;

        // Вызов валидации
        validator.ValidateAndThrow(this);
    }
}