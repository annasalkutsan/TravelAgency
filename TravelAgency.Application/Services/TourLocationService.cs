using AutoMapper;
using TravelAgency.Application.DTOs;
using TravelAgency.Domain.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.Application.Services;

public class TourLocationService
{
    private readonly IRepository<TourLocation> _tourLocationRepository;
    private readonly IMapper _mapper;

    public TourLocationService(IRepository<TourLocation> tourLocationRepository, IMapper mapper)
    {
        _tourLocationRepository = tourLocationRepository;
        _mapper = mapper;
    }

    public async Task<TourLocationResponseDto?> GetTourLocationByIdAsync(Guid tourId, Guid locationId)
    {
        var tourLocation = await _tourLocationRepository.FindAsync(tl => tl.TourId == tourId && tl.LocationId == locationId);

        if (tourLocation == null || !tourLocation.Any())
            return null;

        return _mapper.Map<TourLocationResponseDto>(tourLocation.First());
    }
    
    public async Task<ICollection<TourLocationResponseDto>> GetAllTourLocationsAsync()
    {
        var tourLocations = await _tourLocationRepository.GetAllAsync();
        return _mapper.Map<ICollection<TourLocationResponseDto>>(tourLocations);
    }

    public async Task<TourLocationResponseDto> AddTourLocationAsync(TourLocationRequestDto tourLocationDto)
    {
        var tourLocation = _mapper.Map<TourLocation>(tourLocationDto);
        await _tourLocationRepository.AddAsync(tourLocation);
        return _mapper.Map<TourLocationResponseDto>(tourLocation);
    }

    public async Task<TourLocationResponseDto> UpdateVisitOrderAsync(Guid tourId, Guid locationId, int newOrder)
    {
        var tourLocation = await _tourLocationRepository.FindAsync(tl => tl.TourId == tourId && tl.LocationId == locationId);

        if (tourLocation == null || !tourLocation.Any())
            throw new KeyNotFoundException($"TourLocation with TourId {tourId} and LocationId {locationId} not found.");

        var existingTourLocation = tourLocation.First();
        existingTourLocation.VisitOrder = newOrder;

        await _tourLocationRepository.UpdateAsync(existingTourLocation);

        return _mapper.Map<TourLocationResponseDto>(existingTourLocation);
    }

    public async Task RemoveTourLocationAsync(Guid tourId, Guid locationId)
    {
        var tourLocation = await _tourLocationRepository.FindAsync(tl => tl.TourId == tourId && tl.LocationId == locationId);

        if (tourLocation == null || !tourLocation.Any())
            throw new KeyNotFoundException($"TourLocation with TourId {tourId} and LocationId {locationId} not found.");

        await _tourLocationRepository.RemoveAsync(tourLocation.First());
    }
}