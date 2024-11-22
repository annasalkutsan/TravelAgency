using AutoMapper;
using TravelAgency.Application.DTOs;
using TravelAgency.Domain.Models;

namespace TravelAgency.Application.Mapping;

public class TourLocationMappingProfile : Profile
{
    public TourLocationMappingProfile()
    {
        // Mapping from TourLocation to TourLocationResponseDto
        CreateMap<TourLocation, TourLocationResponseDto>()
            .ForMember(dest => dest.TourId, opt => opt.MapFrom(src => src.TourId))
            .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.LocationId))
            .ForMember(dest => dest.VisitOrder, opt => opt.MapFrom(src => src.VisitOrder));

        // Mapping from TourLocationRequestDto to TourLocation
        CreateMap<TourLocationRequestDto, TourLocation>()
            .ForMember(dest => dest.TourId, opt => opt.MapFrom(src => src.TourId))
            .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.LocationId))
            .ForMember(dest => dest.VisitOrder, opt => opt.MapFrom(src => src.VisitOrder));
    }
}