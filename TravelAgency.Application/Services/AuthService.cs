using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TravelAgency.Application.DTOs;
using TravelAgency.Domain.Interfaces;
using TravelAgency.Domain.Models;
using TravelAgency.Domain.ValueObjects;

namespace TravelAgency.Application.Services;

public class AuthService
{
    private readonly IRepository<Client> _clientRepository;
    private readonly IConfiguration _configuration;
    private readonly IValidator<Client> _clientValidator;
    private readonly IMapper _mapper;

    public AuthService(IRepository<Client> clientRepository, IConfiguration configuration, IValidator<Client> clientValidator, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _configuration = configuration;
        _clientValidator = clientValidator;
        _mapper = mapper;
    }
    
    public async Task<AuthResponseDto> RegisterAsync(ClientRegisterDto registerDto)
    {
        // Проверка существования клиента
        var existingClient = (await _clientRepository.FindAsync(c => c.Email == registerDto.Email)).FirstOrDefault();
        if (existingClient != null)
            throw new InvalidOperationException("Email already exists");

        // Хэширование пароля
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

        // Создание клиента
        var client = new Client(
            new FullName(registerDto.FirstName, registerDto.LastName),
            registerDto.PhoneNumber, 
            registerDto.Email,
            _clientValidator  
        )
        {
            PasswordHash = passwordHash
        };

        await _clientRepository.AddAsync(client);

        // Генерация JWT токена
        var token = GenerateJwtToken(client);

        // Маппинг для ответа
        var authResponseDto = new AuthResponseDto
        {
            Email = client.Email,
            PasswordHash = client.PasswordHash,  // Здесь, вероятно, следует хранить только хэш пароля для безопасности
            Token = token
        };

        return authResponseDto;
    }

    public async Task<AuthResponseDto> LoginAsync(ClientLoginDto loginDto)
    {
        var client = (await _clientRepository.FindAsync(c => c.Email == loginDto.Email)).FirstOrDefault();
        if (client == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, client.PasswordHash))
            throw new UnauthorizedAccessException("Invalid email or password");

        // Генерация JWT токена
        var token = GenerateJwtToken(client);

        // Маппинг для ответа
        var authResponseDto = new AuthResponseDto
        {
            Email = client.Email,
            PasswordHash = client.PasswordHash,
            Token = token
        };

        return authResponseDto;
    }

    private string GenerateJwtToken(Client client)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[] 
        {
            new Claim(ClaimTypes.NameIdentifier, client.Id.ToString()),
            new Claim(ClaimTypes.Email, client.Email)
        };

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}