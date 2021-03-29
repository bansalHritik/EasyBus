using EasyBus.Data.Contexts;
using EasyBus.Data.Models;
using EasyBus.Shared.Repository;

namespace EasyBus.Data.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationContext context) : base(context)
        {
        }

        //TODO: Implement CancelBooking
    }
}