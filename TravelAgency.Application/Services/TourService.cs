using AutoMapper;
using TravelAgency.Application.DTOs;
using TravelAgency.Domain.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.Application.Services;

public class TourService
{
    private readonly IRepository<Tour> _tourRepository;
    private readonly IMapper _mapper;

    public TourService(IRepository<Tour> tourRepository, IMapper mapper)
    {
        _tourRepository = tourRepository;
        _mapper = mapper;
    }

    public async Task<TourResponseDto> GetTourByIdAsync(Guid id)
    {
        var tour = await _tourRepository.GetByIdAsync(id);

        if (tour == null)
            throw new KeyNotFoundException($"Tour with ID {id} not found.");

        return _mapper.Map<TourResponseDto>(tour);
    }

    public async Task<PagedResultDto<TourResponseDto>> GetAllToursAsync(int pageNumber, int pageSize)
    {
        // Получаем все туры
        var allTours = await _tourRepository.GetAllAsync();

        // Применяем пагинацию
        var pagedTours = allTours
            .Skip((pageNumber - 1) * pageSize) // Пропуск старых записей
            .Take(pageSize) // Берем только нужное количество
            .ToList();

        // Маппим данные в DTO
        var toursDto = _mapper.Map<ICollection<TourResponseDto>>(pagedTours);

        // Получаем общее количество туров для вычисления общего числа страниц
        var totalItems = allTours.Count;

        return new PagedResultDto<TourResponseDto>
        {
            Items = toursDto,
            TotalItems = totalItems,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling((double)totalItems / pageSize) // Рассчитываем общее количество страниц
        };
    }

    public async Task<TourResponseDto> AddTourAsync(TourRequestDto tourDto)
    {
        var tour = _mapper.Map<Tour>(tourDto);
        await _tourRepository.AddAsync(tour);
        return _mapper.Map<TourResponseDto>(tour);
    }

    public async Task<TourResponseDto> UpdateTourAsync(Guid id, TourRequestDto tourDto)
    {
        var existingTour = await _tourRepository.GetByIdAsync(id);

        if (existingTour == null)
            throw new KeyNotFoundException($"Tour with ID {id} not found.");

        _mapper.Map(tourDto, existingTour);
        await _tourRepository.UpdateAsync(existingTour);
        return _mapper.Map<TourResponseDto>(existingTour);
    }

    public async Task RemoveTourAsync(Guid id)
    {
        var tour = await _tourRepository.GetByIdAsync(id);

        if (tour == null)
            throw new KeyNotFoundException($"Tour with ID {id} not found.");

        await _tourRepository.RemoveAsync(tour);
    }
}