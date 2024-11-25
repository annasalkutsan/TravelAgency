using FluentValidation;
using TravelAgency.Application.DTOs;

namespace TravelAgency.Application.Validation;

public class TransportRequestValidator:AbstractValidator<TransportRequestDto>
{
    public TransportRequestValidator()
    {
        RuleFor(t => t.Description).MaximumLength(1000);
        RuleFor(t => t.Capacity).GreaterThan(0);
    }
}