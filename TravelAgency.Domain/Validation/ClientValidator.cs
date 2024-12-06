using FluentValidation;
using TravelAgency.Domain.Models;

namespace TravelAgency.Domain.Validation;

public class ClientValidator : AbstractValidator<Client>
{
    public ClientValidator()
    {
        RuleFor(x => x.FullName)
            .NotNull().WithMessage("Full name is required.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Length(10, 15).WithMessage("Phone number must be between 10 and 15 characters.");

        RuleFor(x => x.Email)
            .EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email))
            .WithMessage("Invalid email format.");
    }
}