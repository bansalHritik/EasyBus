using EasyBus.Data.Contexts;
using EasyBus.Data.Models;
using EasyBus.Shared.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EasyBus.Data.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationContext context) : base(context)
        {
        }

        public new Booking Get(int bookingId)
        {
            return ApplicationContext.Bookings
                .Include(m => m.BusRoute)
                .Include(m => m.BusRoute.Route)
                .Include(m => m.BusRoute.Route.DestStop)
                .Include(m => m.BusRoute.Route.SourceStop)
                .Include(m => m.BusRoute.Bus)
                .Where(m => m.Id == bookingId)

                .FirstOrDefault();
        }

        public new IEnumerable<Booking> GetAll()
        {
            return ApplicationContext.Bookings
                .Include(m => m.BusRoute)
                .Include(m => m.BusRoute.Route)
                .Include(m => m.BusRoute.Route.DestStop)
                .Include(m => m.BusRoute.Route.SourceStop)
                .Include(m => m.BusRoute.Bus)
                .ToList();
        }

        //TODO: Implement CancelBooking
    }
}