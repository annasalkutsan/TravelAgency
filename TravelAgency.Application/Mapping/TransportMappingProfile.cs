using AutoMapper;
using TravelAgency.Application.DTOs;
using TravelAgency.Domain.Models;

namespace TravelAgency.Application.Mapping;

public class TransportMappingProfile : Profile
{
    public TransportMappingProfile()
    {
        // Mapping from Transport to TransportResponseDto
        CreateMap<Transport, TransportResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity));

        // Mapping from TransportRequestDto to Transport
        CreateMap<TransportRequestDto, Transport>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity));
    }
}