using EasyBus.Data.Models;
using System;

namespace EasyBus.Shared.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBusRepository<Bus> Buses { get; }
        IStopRepository<Stop> Stops { get; }
        IRouteRepository<Route> Routes { get; }
        IBusRouteRepository<BusRoute> BusRoutes { get; }
        IBookingRepository<Booking> Bookings { get; }
        int Complete();
    }
}
