using FluentValidation;
using TravelAgency.Application.DTOs;

namespace TravelAgency.Application.Validation;

public class TourRequestValidator : AbstractValidator<TourRequestDto>
{
    public TourRequestValidator()
    {
        RuleFor(t => t.Name).MaximumLength(300);
        RuleFor(t => t.Description).MaximumLength(1000);
        RuleFor(t => t.Price).GreaterThan(0);
    }
}