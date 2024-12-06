using FluentValidation;
using TravelAgency.Domain.Models;

namespace TravelAgency.Domain.Validation;

public class TourValidator : AbstractValidator<Tour>
{
    public TourValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Tour name is required.")
            .MaximumLength(100).WithMessage("Tour name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start date is required.")
            .LessThan(x => x.EndDate).WithMessage("Start date must be before the end date.");

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("End date is required.")
            .GreaterThan(x => x.StartDate).WithMessage("End date must be after the start date.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}