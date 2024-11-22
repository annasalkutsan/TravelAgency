using AutoMapper;
using TravelAgency.Application.DTOs;
using TravelAgency.Domain.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.Application.Services;

public class TransportService
{
    private readonly IRepository<Transport> _transportRepository;
    private readonly IMapper _mapper;

    public TransportService(IRepository<Transport> transportRepository, IMapper mapper)
    {
        _transportRepository = transportRepository;
        _mapper = mapper;
    }

    public async Task<TransportResponseDto> GetTransportByIdAsync(Guid id)
    {
        var transport = await _transportRepository.GetByIdAsync(id);

        if (transport == null)
            throw new KeyNotFoundException($"Transport with ID {id} not found.");

        return _mapper.Map<TransportResponseDto>(transport);
    }

    public async Task<ICollection<TransportResponseDto>> GetAllTransportsAsync()
    {
        var transports = await _transportRepository.GetAllAsync();
        return _mapper.Map<ICollection<TransportResponseDto>>(transports);
    }

    public async Task<TransportResponseDto> AddTransportAsync(TransportRequestDto transportDto)
    {
        var transport = _mapper.Map<Transport>(transportDto);
        await _transportRepository.AddAsync(transport);
        return _mapper.Map<TransportResponseDto>(transport);
    }

    public async Task<TransportResponseDto> UpdateTransportAsync(Guid id, TransportRequestDto transportDto)
    {
        var existingTransport = await _transportRepository.GetByIdAsync(id);

        if (existingTransport == null)
            throw new KeyNotFoundException($"Transport with ID {id} not found.");

        _mapper.Map(transportDto, existingTransport);
        await _transportRepository.UpdateAsync(existingTransport);
        return _mapper.Map<TransportResponseDto>(existingTransport);
    }

    public async Task RemoveTransportAsync(Guid id)
    {
        var transport = await _transportRepository.GetByIdAsync(id);

        if (transport == null)
            throw new KeyNotFoundException($"Transport with ID {id} not found.");

        await _transportRepository.RemoveAsync(transport);
    }
}