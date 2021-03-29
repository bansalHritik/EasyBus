using EasyBus.Data.Contexts;
using EasyBus.Data.Repository;
using EasyBus.Shared.Repository;
using EasyBus.Shared.Repository.Core;

namespace EasyBus.Persistence
{
    /// <summary>
    /// Defines the <see cref="UnitOfWork" />.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Defines Application Context file.
        /// </summary>
        private readonly ApplicationContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="ApplicationContext"/>.</param>
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Buses = new BusRepository(_context);
            Stops = new StopRepository(_context);
            Routes = new RouteRepository(_context);
            BusRoutes = new BusRouteRepository(_context);
            Bookings = new BookingRepository(_context);
        }

        /// <summary>
        /// Gets or sets the Buses.
        /// </summary>
        public IBusRepository Buses { get; }

        /// <summary>
        /// Gets or sets the Stops.
        /// </summary>
        public IStopRepository Stops { get; }

        /// <summary>
        /// Gets or sets the BusStops.
        /// </summary>
        public IBusRouteRepository BusRoutes { get; }

        /// <summary>
        /// Gets or sets the Bookings.
        /// </summary>
        public IBookingRepository Bookings { get; }

        public IRouteRepository Routes { get; }

        /// <summary>
        /// The Complete.
        /// </summary>
        /// <returns>The <see cref="int"/>.</returns>
        public int Complete()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// The Dispose.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}