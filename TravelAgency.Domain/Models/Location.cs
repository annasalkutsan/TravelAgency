using FluentValidation;

namespace TravelAgency.Domain.Models;

public class Location : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Country { get; set; } = null!;

    // Связь с турами через TourLocation
    public ICollection<TourLocation> TourLocations { get; set; } = new List<TourLocation>();
    
    public Location () {}
    public Location(string name, string description, string country, IValidator<Location> validator)
    {
        Name = name;
        Description = description;
        Country = country;

        // Вызов валидации
        validator.ValidateAndThrow(this);
    }
}