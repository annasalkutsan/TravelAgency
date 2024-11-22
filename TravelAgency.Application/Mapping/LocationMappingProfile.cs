using AutoMapper;
using TravelAgency.Application.DTOs;
using TravelAgency.Domain.Models;

namespace TravelAgency.Application.Mapping;

public class LocationMappingProfile : Profile
{
    public LocationMappingProfile()
    {
        // Mapping from Location to LocationResponseDto
        CreateMap<Location, LocationResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));

        // Mapping from LocationRequestDto to Location
        CreateMap<LocationRequestDto, Location>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));
    }
}