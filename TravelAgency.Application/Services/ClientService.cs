using AutoMapper;
using TravelAgency.Application.DTOs;
using TravelAgency.Domain.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.Application.Services;

public class ClientService
{
    private readonly IRepository<Client> _clientRepository;
    private readonly IMapper _mapper;

    public ClientService(IRepository<Client> clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить клиента по ID
    /// </summary>
    public async Task<ClientResponseDto> GetClientByIdAsync(Guid id)
    {
        var client = await _clientRepository.GetByIdAsync(id);

        if (client == null)
            throw new KeyNotFoundException($"Client with ID {id} not found.");

        return _mapper.Map<ClientResponseDto>(client);
    }

    /// <summary>
    /// Получить всех клиентов
    /// </summary>
    public async Task<ICollection<ClientResponseDto>> GetAllClientsAsync()
    {
        var clients = await _clientRepository.GetAllAsync();
        return _mapper.Map<ICollection<ClientResponseDto>>(clients);
    }

    /// <summary>
    /// Найти клиентов по условию (номер телефона)
    /// </summary>
    public async Task<ICollection<ClientResponseDto>> FindClientsAsync(string phoneNumber)
    {
        var clients = await _clientRepository.FindAsync(c => c.PhoneNumber.Contains(phoneNumber));
        return _mapper.Map<ICollection<ClientResponseDto>>(clients);
    }

    /// <summary>
    /// Добавить нового клиента
    /// </summary>
    public async Task<ClientResponseDto> AddClientAsync(ClientRequestDto clientDto)
    {
        var client = _mapper.Map<Client>(clientDto);
        await _clientRepository.AddAsync(client);
        return _mapper.Map<ClientResponseDto>(client);
    }

    /// <summary>
    /// Обновить информацию о клиенте
    /// </summary>
    public async Task<ClientResponseDto> UpdateClientAsync(Guid id, ClientRequestDto clientDto)
    {
        var existingClient = await _clientRepository.GetByIdAsync(id);

        if (existingClient == null)
            throw new KeyNotFoundException($"Client with ID {id} not found.");

        _mapper.Map(clientDto, existingClient);
        await _clientRepository.UpdateAsync(existingClient);
        return _mapper.Map<ClientResponseDto>(existingClient);
    }

    /// <summary>
    /// Удалить клиента
    /// </summary>
    public async Task RemoveClientAsync(Guid id)
    {
        var client = await _clientRepository.GetByIdAsync(id);

        if (client == null)
            throw new KeyNotFoundException($"Client with ID {id} not found.");

        await _clientRepository.RemoveAsync(client);
    }
}