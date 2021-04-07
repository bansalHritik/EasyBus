using AutoMapper;
using EasyBus.Data.Contexts;
using EasyBus.Shared.Infrastructure.DTOs;

namespace EasyBus.Shared.Functional.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}