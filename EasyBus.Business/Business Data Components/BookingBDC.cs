using AutoMapper;
using EasyBus.Data.Models;
using EasyBus.Shared.Functional;
using EasyBus.Shared.Infrastructure.Business;
using EasyBus.Shared.Infrastructure.Business.Models;
using EasyBus.Shared.Infrastructure.DTOs;
using EasyBus.Shared.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBus.Business
{
    public class BookingBDC : BDC, IBookingBDC
    {
        public BookingBDC(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
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
                    short numOfSeatsBooked = -1;
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

        public OperationResult AddBooking(NewBookingModel newBooking)
        {
            OperationResult result = new();
            try
            {
                BusRoute busRoute = UnitOfWork.BusRoutes.Get(newBooking.BusRouteId);

                if (busRoute != null)
                {
                    Booking booking = Mapper.Map<NewBookingModel, Booking>(newBooking);
                    booking.BusRoute = busRoute;

                    UnitOfWork.Bookings.Add(booking);

                    bool numOfSeatsChanged = UnitOfWork.Buses
                        .ChangeSeatBookedCount(busRoute.Bus.Id, 1);

                    if (numOfSeatsChanged)
                    {
                        UnitOfWork.Complete();
                        result.SetSuccessResult();
                    }
                    else result.SetFailureResult("Bus is already fully booked");
                    
                }
                else
                {
                    result.SetFailureResult("No Bus route with this id");
                }
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult UpdateBooking(int bookingId, NewBookingModel booking)
        {
            OperationResult result = new OperationResult();
            try
            {
                Booking bookingInDB = UnitOfWork.Bookings.Get(bookingId);

                if (bookingInDB != null)
                {
                    Mapper.Map<NewBookingModel, Booking>(booking, bookingInDB);
                    UnitOfWork.Complete();
                    result.SetSuccessResult();
                }
                else
                {
                    result.SetFailureResult("No Booking exist with this id");
                }
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }

            return result;
        }

        public OperationResult<BookingDTO> Get(int bookingId)
        {
            OperationResult<BookingDTO> result = new();
            try
            {
                Booking bookingInDB = UnitOfWork.Bookings.Get(bookingId);
                if (bookingInDB != null)
                {
                    result.SetSuccessResult(Mapper.Map<Booking, BookingDTO>(bookingInDB));
                }
                else result.SetFailureResult("No Booking found with this id");
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        //TODO: 
        public OperationResult<IEnumerable<BookingDTO>> GetAllBookingByUser()
        {
            OperationResult<IEnumerable<BookingDTO>> result = new();
            try
            {
                var bookings = UnitOfWork.Bookings.GetAll()
                    .Select(m => Mapper.Map<Booking, BookingDTO>(m));
                result.SetSuccessResult(bookings);
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }

        public OperationResult<IEnumerable<BookingDTO>> GetAll()
        {
            OperationResult<IEnumerable<BookingDTO>> result = new();
            try
            {
                var bookings = UnitOfWork.Bookings.GetAll()
                    .Select(m => Mapper.Map<Booking, BookingDTO>(m));
                result.SetSuccessResult(bookings);
            }
            catch (Exception e)
            {
                result.SetExceptionResult(e.StackTrace);
            }
            return result;
        }
    }
}