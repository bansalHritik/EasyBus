using System;

namespace EasyBus.Shared.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBusRepository Buses { get; }
        IStopRepository Stops { get; }
        IBusStopRepository BusStops { get; }
        IBookingRepository Bookings { get; }
        int Complete();
    }
}
