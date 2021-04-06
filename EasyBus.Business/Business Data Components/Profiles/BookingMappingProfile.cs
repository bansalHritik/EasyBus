using AutoMapper;
using EasyBus.Data.Models;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.DTOs;

namespace EasyBus.Shared.Functional.Profiles
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<BookingDTO, Booking>()
                .ForMember(m => m.BusRoute, opts => opts.MapFrom(m => m.BusRoute));

            CreateMap<Booking, BookingDTO>()
           .ForMember(m => m.BusRoute, opts => opts.MapFrom(m => m.BusRoute));

            CreateMap<Booking, NewBookingModel>()
                .ForMember(m => m.BusRouteId, opts => opts.MapFrom(m => m.BusRoute.Id))
                .ReverseMap();
            CreateMap<BookingDTO, NewBookingModel>()
                .ForMember(m => m.BusRouteId, opts => opts.MapFrom(m => m.BusRoute))
                .ReverseMap();
        }
    }
}