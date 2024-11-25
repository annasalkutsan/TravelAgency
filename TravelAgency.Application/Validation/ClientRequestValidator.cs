using FluentValidation;
using TravelAgency.Application.DTOs;

namespace TravelAgency.Application.Validation;

public class ClientRequestValidator:AbstractValidator<ClientRequestDto>
{
    public ClientRequestValidator()
    {
        RuleFor(c => c.FirstName).MaximumLength(200);
        RuleFor(c => c.LastName).MaximumLength(200);
        RuleFor(c => c.PhoneNumber).Matches(@"^\+373\d{8}$");
        RuleFor(c => c.Email).Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    }
}