﻿using FluentValidation;

namespace TravelAgency.Domain.Models;

public class Tour : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }

    // Связь с транспортом
    public Guid? TransportId { get; set; }
    public Transport? Transport { get; set; }

    // Связь с локациями через TourLocation
    public ICollection<TourLocation> TourLocations { get; set; } = new List<TourLocation>();

    // Связь с бронированиями
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public Tour (){}
    public Tour(
        string name,
        string description,
        DateTime startDate,
        DateTime endDate,
        decimal price,
        IValidator<Tour> validator)
    {
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        Price = price;

        // Вызов валидации
        validator.ValidateAndThrow(this);
    }
}