using FluentValidation;

namespace TravelAgency.Domain.Models;

public class Transport : BaseEntity
{
    public string Type { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Capacity { get; set; }

    // Связь с турами
    public ICollection<Tour> Tours { get; set; } = new List<Tour>();
    public Transport (){}
    
    public Transport(string type, string description, int capacity, IValidator<Transport> validator)
    {
        Type = type;
        Description = description;
        Capacity = capacity;

        // Вызов валидации через FluentValidation
        validator.ValidateAndThrow(this);
    }
}