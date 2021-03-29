using EasyBus.Data.Models;
using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Infrastructure.DTOs;
using EasyBus.Shared.Repository.Core;
using System;

namespace EasyBus.Business
{
    public class BookingBDC : BDC, IBookingBDC
    {
        public BookingBDC(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public OperationResult CancelBooking(int bookingId)
        {
            OperationResult result = new OperationResult();
            try
            {
                // Get booking from database. 
                Booking bookingInDb = UnitOfWork.Bookings.Get(bookingId);

                // booking exists with given id.
                if (bookingInDb != null) 
                {
                    short numOfSeatsBooked = bookingInDb.NumberOfSeats;
                    int busId = bookingInDb.BusRoute.Bus.Id;

                    bookingInDb.Status = BookingStatusType.Cancelled;
                    UnitOfWork.Buses.ChangeSeatBookedCount(busId, numOfSeatsBooked);
                    UnitOfWork.Complete();

                    result.SetSuccessResult();
                }
                else
                {
                    result.SetFailureResult("No Booking with given id exist");
                }
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult AddBooking(BookingDTO booking)
        {
            try
            {
                //TODO: Automapper
                Booking bookingModel = new Booking();
                

                UnitOfWork.Bookings.Add(bookingModel);
                return SucessResult(true);
            }
            catch (Exception e)
            {
                return ExceptionResult(e.StackTrace);
            }
        }

        public OperationResult UpdateBooking(int bookingId, BookingDTO booking)
        {
            OperationResult result = new OperationResult();
            Booking bookingInDB = UnitOfWork.Bookings.Get(bookingId);

            if(bookingInDB != null)
            {
                // bookingInDB.BusRoute = booking.
            }
            else
            {
                result.SetFailureResult("No Booking exist with this id");
            }

            // TODO: Automapper
            //bookingInDB.ArrivalStop.Id = booking.ArrivalStopId;
            //bookingInDB.DepartureStop.Id = booking.DepartureStopId;
            //bookingInDB.DateAndTime = booking.DateAndTime;
            //bookingInDB.Fare = booking.Fare;

            UnitOfWork.Buses.ChangeSeatBookedCount(booking.BusId, booking.NumberOfSeats);

            UnitOfWork.Complete();

            return result;
        }
    }
}