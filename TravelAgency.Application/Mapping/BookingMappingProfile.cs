using AutoMapper;
using TravelAgency.Application.DTOs;
using TravelAgency.Domain.Models;

namespace TravelAgency.Application.Mapping;

public class BookingMappingProfile : Profile
{
    public BookingMappingProfile()
    {
        // Mapping from Booking to BookingResponseDto
        CreateMap<Booking, BookingResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
            .ForMember(dest => dest.TourId, opt => opt.MapFrom(src => src.TourId))
            .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => src.BookingDate));

        // Mapping from BookingRequestDto to Booking
        CreateMap<BookingRequestDto, Booking>()
            .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
            .ForMember(dest => dest.TourId, opt => opt.MapFrom(src => src.TourId))
            .ForMember(dest => dest.BookingDate, opt => opt.MapFrom(src => src.BookingDate));
    }
}