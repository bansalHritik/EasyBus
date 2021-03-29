using System;

namespace EasyBus.Shared.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBusRepository Buses { get; }
        IStopRepository Stops { get; }
        IRouteRepository Routes { get; }
        IBusRouteRepository BusRoutes { get; }
        IBookingRepository Bookings { get; }

        int Complete();
    }
}