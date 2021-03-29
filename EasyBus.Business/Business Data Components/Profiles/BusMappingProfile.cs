using AutoMapper;
using EasyBus.Data.Models;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.DTOs;

namespace EasyBus.Shared.Functional.Profiles
{
    public class BusMappingProfile : Profile
    {
        public BusMappingProfile()
        {
            CreateMap<Bus, BusDTO>()
                .ReverseMap();
            CreateMap<NewBusModel, BusDTO>()
                .ReverseMap();
        }
    }
}