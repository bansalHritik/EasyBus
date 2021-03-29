using EasyBus.Data.Contexts;
using EasyBus.Data.Models;
using EasyBus.Shared.Repository;
using System.Linq;

namespace EasyBus.Data.Repository
{
    public class BusRepository : Repository<Bus>, IBusRepository
    {
        public BusRepository(ApplicationContext context) : base(context)
        {
        }

        public Bus Get(string vechileNumber)
        {
            var result = ApplicationContext.Buses
                            .Where(bus => bus.VehicleNumber.Equals(vechileNumber))
                            .SingleOrDefault();
            return result;
        }

        public bool ChangeSeatBookedCount(int busId, short count)
        {
            bool result = false;
            Bus bus = Get(busId);
            short updatedCapacity = (short)(bus.SeatsBooked + count);
            if (updatedCapacity <= bus.Capacity && updatedCapacity >= 0)
            {
                bus.SeatsBooked += count;
                ApplicationContext.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}