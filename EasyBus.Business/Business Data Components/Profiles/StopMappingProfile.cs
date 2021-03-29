using AutoMapper;
using EasyBus.Data.Models;
using EasyBus.Shared.Infrastructure.DTOs;

namespace EasyBus.Shared.Functional.Profiles
{
    public class StopMappingProfile : Profile
    {
        public StopMappingProfile()
        {
            CreateMap<Stop, StopDTO>();

            CreateMap<StopDTO, Stop>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
                

        }
    }
}