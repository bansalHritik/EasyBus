using AutoMapper;
using EasyBus.Data.Models;
using EasyBus.Shared.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBus.Shared.Functional.Profiles
{
    public class RouteMappingProfile: Profile
    {

        public RouteMappingProfile()
        {
            CreateMap<Route, RouteDTO>()
                .ForMember(m => m.DestinationStop, opt => opt.MapFrom(m => m.DestStop))
                ;
            CreateMap<RouteDTO, Route>()
                .ForMember(m => m.DestStop, opt => opt.MapFrom(m => m.DestinationStop))
                ;
        }
    }
}
