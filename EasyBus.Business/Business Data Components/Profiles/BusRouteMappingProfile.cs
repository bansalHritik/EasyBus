using AutoMapper;
using EasyBus.Data.Models;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBus.Shared.Functional.Profiles
{
    public class BusRouteMappingProfile : Profile
    {
        public BusRouteMappingProfile()
        {
            CreateMap<NewBusRouteModel, BusRouteDTO>().ReverseMap();

            CreateMap<NewBusRouteModel, BusRoute>().ReverseMap();

            CreateMap<BusDetailDTO, BusRoute>()
                .ForMember(dest => dest.Bus, opns => opns.MapFrom(m => m.Bus))
                .ForMember(dest => dest.Route, opns => opns.MapFrom(m => m.Route))
                .ReverseMap();
            CreateMap<BusRouteDTO, BusRoute>()
                .ReverseMap();
        }
    }
}
