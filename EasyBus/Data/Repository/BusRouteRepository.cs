using EasyBus.Data.Contexts;
using EasyBus.Data.Models;
using EasyBus.Shared.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EasyBus.Data.Repository
{
    public class BusRouteRepository: Repository<BusRoute>, IBusRouteRepository<BusRoute>
    {
        public BusRouteRepository(ApplicationContext context) : base(context) { }

        

        public IEnumerable<BusRoute> GetAllBusWithRoute(int routeId)
        {
            List<BusRoute> result = Context.Set<BusRoute>().ToList();
                                 //.Where(busRoute => busRoute.Route.Id == routeId)
                                 
                                 //.ToList();

            return result;
        }
    }
}
