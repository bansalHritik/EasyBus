using EasyBus.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace EasyBus.Shared.Repository
{
    public interface IBookingRepository : IRepository<Booking>
    {
        new Booking Get(int bookingId);

        new IEnumerable<Booking> GetAll();

        
    }
}