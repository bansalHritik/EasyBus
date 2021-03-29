using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.DTOs;

namespace EasyBus.Shared.Infrastructure.Business
{
    public interface IBookingBDC
    {
        OperationResult AddBooking(BookingDTO booking);

        OperationResult CancelBooking(int bookingId);

        OperationResult UpdateBooking(int bookingId, BookingDTO booking);
    }
}