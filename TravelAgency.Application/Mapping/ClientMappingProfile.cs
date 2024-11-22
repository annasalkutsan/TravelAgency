using AutoMapper;
using TravelAgency.Application.DTOs;
using TravelAgency.Domain.Models;
using TravelAgency.Domain.ValueObjects;

namespace TravelAgency.Application.Mapping;

public class ClientMappingProfile: Profile
{
    public ClientMappingProfile()
    {
        // Mapping from Client to ClientResponseDto
        CreateMap<Client, ClientResponseDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FullName.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.FullName.LastName))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        // Mapping from ClientRequestDto to Client
        CreateMap<ClientRequestDto, Client>()
            .ForMember(dest => dest.FullName, 
                opt => opt.MapFrom(src => new FullName(src.FirstName, src.LastName)))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
    }
}