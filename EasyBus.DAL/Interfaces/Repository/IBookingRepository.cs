using EasyBus.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EasyBus.Shared.Repository
{
    public interface IBookingRepository : IRepository<Booking>
    {
        new Booking Get(int bookingId);

        new IEnumerable<Booking> GetAll();

        new IEnumerable<Booking> Find(Expression<Func<Booking, bool>> predicate);
    }
}