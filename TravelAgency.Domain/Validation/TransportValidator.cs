using FluentValidation;
using TravelAgency.Domain.Models;

namespace TravelAgency.Domain.Validation;

public class TransportValidator : AbstractValidator<Transport>
{
    public TransportValidator()
    {
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Transport type is required.")
            .MaximumLength(50).WithMessage("Transport type must not exceed 50 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.Capacity)
            .GreaterThan(0).WithMessage("Capacity must be greater than 0.")
            .LessThanOrEqualTo(1000).WithMessage("Capacity must not exceed 1000.");
    }
}