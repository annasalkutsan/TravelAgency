using Microsoft.AspNetCore.Mvc;
using TravelAgency.Application.DTOs;
using TravelAgency.Application.Services;

namespace TravelAgency.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly ClientService _clientService;

    public ClientController(ClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClientById(Guid id)
    {
        var client = await _clientService.GetClientByIdAsync(id);
        return Ok(client);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllClients()
    {
        var clients = await _clientService.GetAllClientsAsync();
        return Ok(clients);
    }

    [HttpPost]
    public async Task<IActionResult> AddClient(ClientRequestDto clientDto)
    {
        var createdClient = await _clientService.AddClientAsync(clientDto);
        return CreatedAtAction(nameof(GetClientById), new { id = createdClient.Id }, createdClient);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClient(Guid id, ClientRequestDto clientDto)
    {
        var updatedClient = await _clientService.UpdateClientAsync(id, clientDto);
        return Ok(updatedClient);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveClient(Guid id)
    {
        await _clientService.RemoveClientAsync(id);
        return NoContent();
    }
}