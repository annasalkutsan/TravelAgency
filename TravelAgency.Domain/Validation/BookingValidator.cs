using FluentValidation;
using TravelAgency.Domain.Models;

namespace TravelAgency.Domain.Validation;

public class BookingValidator : AbstractValidator<Booking>
{
    public BookingValidator()
    {
        RuleFor(x => x.ClientId)
            .NotEmpty().WithMessage("Client ID is required.");

        RuleFor(x => x.TourId)
            .NotEmpty().WithMessage("Tour ID is required.");

        RuleFor(x => x.BookingDate)
            .NotEmpty().WithMessage("Booking date is required.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Booking date cannot be in the future.");
    }
}