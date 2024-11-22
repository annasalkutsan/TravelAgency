using AutoMapper;
using TravelAgency.Application.DTOs;
using TravelAgency.Domain.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.Application.Services;

public class LocationService
{
    private readonly IRepository<Location> _locationRepository;
    private readonly IMapper _mapper;

    public LocationService(IRepository<Location> locationRepository, IMapper mapper)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    public async Task<LocationResponseDto> GetLocationByIdAsync(Guid id)
    {
        var location = await _locationRepository.GetByIdAsync(id);

        if (location == null)
            throw new KeyNotFoundException($"Location with ID {id} not found.");

        return _mapper.Map<LocationResponseDto>(location);
    }

    public async Task<ICollection<LocationResponseDto>> GetAllLocationsAsync()
    {
        var locations = await _locationRepository.GetAllAsync();
        return _mapper.Map<ICollection<LocationResponseDto>>(locations);
    }

    public async Task<LocationResponseDto> AddLocationAsync(LocationRequestDto locationDto)
    {
        var location = _mapper.Map<Location>(locationDto);
        await _locationRepository.AddAsync(location);
        return _mapper.Map<LocationResponseDto>(location);
    }

    public async Task<LocationResponseDto> UpdateLocationAsync(Guid id, LocationRequestDto locationDto)
    {
        var existingLocation = await _locationRepository.GetByIdAsync(id);

        if (existingLocation == null)
            throw new KeyNotFoundException($"Location with ID {id} not found.");

        _mapper.Map(locationDto, existingLocation);
        await _locationRepository.UpdateAsync(existingLocation);
        return _mapper.Map<LocationResponseDto>(existingLocation);
    }

    public async Task RemoveLocationAsync(Guid id)
    {
        var location = await _locationRepository.GetByIdAsync(id);

        if (location == null)
            throw new KeyNotFoundException($"Location with ID {id} not found.");

        await _locationRepository.RemoveAsync(location);
    }
}