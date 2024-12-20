﻿using FluentValidation;

namespace TravelAgency.Domain.Models;

public class TourLocation
{
    public Guid TourId { get; set; }
    public Tour Tour { get; set; } = null!;

    public Guid LocationId { get; set; }
    public Location Location { get; set; } = null!;

    public int VisitOrder { get; set; } // Порядок посещения
    
    public TourLocation (){}
    public TourLocation(Guid tourId, Guid locationId, int visitOrder, IValidator<TourLocation> validator)
    {
        TourId = tourId;
        LocationId = locationId;
        VisitOrder = visitOrder;

        // Вызов валидации
        validator.ValidateAndThrow(this);
    }
}