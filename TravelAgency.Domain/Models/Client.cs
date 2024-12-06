using FluentValidation;
using TravelAgency.Domain.ValueObjects;

namespace TravelAgency.Domain.Models;

public class Client : BaseEntity
{
    public FullName FullName { get; set; } 
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    
    public Client (){}   
    public Client(FullName fullName, string phoneNumber, string? email, IValidator<Client> validator)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;

        // Вызов валидации через FluentValidation
        validator.ValidateAndThrow(this);
    }
}