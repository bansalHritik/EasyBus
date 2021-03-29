using AutoMapper;
using EasyBus.Data.Models;
using EasyBus.Shared.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBus.Shared.Functional.Profiles
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<BookingDTO, Booking>();
            CreateMap<Booking, BookingDTO>();
        }
    }
}
