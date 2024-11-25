using FluentValidation;
using TravelAgency.Application.DTOs;

namespace TravelAgency.Application.Validation;

public class LocationRequestValidator:AbstractValidator<LocationRequestDto>
{
    public LocationRequestValidator()
    {
        RuleFor(l => l.Name).MaximumLength(400);
        RuleFor(l => l.Description).MaximumLength(1000);
        RuleFor(l => l.Country).MaximumLength(150);
    }
}