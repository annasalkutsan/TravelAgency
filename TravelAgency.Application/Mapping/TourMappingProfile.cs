using AutoMapper;
using TravelAgency.Application.DTOs;
using TravelAgency.Domain.Models;

namespace TravelAgency.Application.Mapping;

public class TourMappingProfile : Profile
{
    public TourMappingProfile()
    {
        // Mapping from Tour to TourResponseDto
        CreateMap<Tour, TourResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.TransportId, opt => opt.MapFrom(src => src.TransportId));

        // Mapping from TourRequestDto to Tour
        CreateMap<TourRequestDto, Tour>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.TransportId, opt => opt.MapFrom(src => src.TransportId));
    }
}