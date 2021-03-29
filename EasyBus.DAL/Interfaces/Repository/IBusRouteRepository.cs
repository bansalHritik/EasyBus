using EasyBus.Data.Models;
using EasyBus.Shared.Repository.Models;
using System;
using System.Collections.Generic;

namespace EasyBus.Shared.Repository
{
    public interface IBusRouteRepository : IRepository<BusRoute>
    {
        new BusRoute Get(int id);

        new IEnumerable<BusRoute> GetAll();

        IEnumerable<BusRoute> GetAllBusWithRoute(int routeId);

        IEnumerable<BusRoute> GetAll(BusSearchOption option);

        IEnumerable<BusRoute> GetBusWithDestination(int destId);

        IEnumerable<BusRoute> GetBusWithDestination(int destId, DateTime fromTime, DateTime toTime);

        IEnumerable<BusRoute> GetBusWithDestination(int destId, DateTime fromTime, DateTime toTime, short capacity);

        IEnumerable<BusRoute> GetBusWithSource(int sourceId);

        IEnumerable<BusRoute> GetBusWithSource(int destId, DateTime fromTime, DateTime toTime);

        IEnumerable<BusRoute> GetBusWithSource(int destId, DateTime fromTime, DateTime toTime, short capacity);
    }
}