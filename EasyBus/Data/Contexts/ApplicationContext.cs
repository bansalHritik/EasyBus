using EasyBus.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyBus.Data.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Stop> Stops { get; set; }

        public DbSet<BusStop> BusStops { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}
