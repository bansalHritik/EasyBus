using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.DTOs;
using System.Collections.Generic;

namespace EasyBus.Shared.Infrastructure.Business
{
    public interface IBookingBDC
    {
        OperationResult AddBooking(NewBookingModel booking, string userId);

        OperationResult CancelBooking(int bookingId);

        OperationResult UpdateBooking(int bookingId, NewBookingModel booking);

        public OperationResult<BookingDTO> Get(int bookingId);


        public OperationResult<IEnumerable<BookingDTO>> GetAllBookingByUser(string userId);

        public OperationResult<IEnumerable<BookingDTO>> GetAll();
    }
}