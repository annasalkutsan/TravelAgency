using FluentValidation;
using TravelAgency.Domain.Models;

namespace TravelAgency.Domain.Validation;

public class TourLocationValidator : AbstractValidator<TourLocation>
{
    public TourLocationValidator()
    {
        RuleFor(x => x.TourId)
            .NotEmpty().WithMessage("Tour ID is required.");

        RuleFor(x => x.LocationId)
            .NotEmpty().WithMessage("Location ID is required.");

        RuleFor(x => x.VisitOrder)
            .GreaterThan(0).WithMessage("Visit order must be greater than 0.")
            .WithMessage("Visit order should start from 1 and above.");
    }
}