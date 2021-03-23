using EasyBus.EntityDataModels.Models;
using EasyBus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBus.EntityDataModels.Contexts
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
