using EasyBus.Data.Contexts;
using EasyBus.Data.Models;
using EasyBus.Shared.Repository;
using EasyBus.Shared.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBus.Data.Repository
{
    public class BusRouteRepository : Repository<BusRoute>, IBusRouteRepository
    {
        public BusRouteRepository(ApplicationContext context) : base(context)
        {
        }

        new public BusRoute Get(int busRouteId)
        {
            var s = ApplicationContext.BusRoutes
                .Where(m => m.Id == busRouteId);
            return ApplicationContext.BusRoutes
                .Where(m => m.Id == busRouteId)
                .Include(m => m.Route)
                .Include(m => m.Bus)
                .Include(m => m.Route.DestStop)
                .Include(m => m.Route.SourceStop)
                .SingleOrDefault();
        }

        new public IEnumerable<BusRoute> GetAll()
        {
            return ApplicationContext.BusRoutes
                .Include(m => m.Route)
                .Include(m => m.Bus)
                .Include(m => m.Route.DestStop)
                .Include(m => m.Route.SourceStop)
                .ToList();
        }

        public IEnumerable<BusRoute> GetAll(BusSearchOption options)
        {
            DateTime? fromTime = options.FromTime, toTime = options.ToTime;
            int? destId = options.DestId, sourceId = options.SourceId;
            short? capacity = options.MinCapacity;
            var result = ApplicationContext.BusRoutes
                            .Where(m =>
                                (fromTime == null || fromTime >= m.ArrivalTime && m.ArrivalTime <= toTime)
                                && (toTime == null || fromTime >= m.DepartureTime && m.DepartureTime <= toTime)
                                && (destId == null || m.Route.DestStop.Id == destId)
                                && (sourceId == null || m.Route.SourceStop.Id == sourceId)
                                && (capacity == null || m.Bus.Capacity >= capacity)
                            )
                            .Include(bus => bus.Route)
                            .Include(bus => bus.Bus)
                            .Include(bus => bus.Route.SourceStop)
                            .Include(bus => bus.Route.DestStop)
                            ;

            return result;
        }

        public IEnumerable<BusRoute> GetAllBusWithRoute(int routeId)
        {
            List<BusRoute> result = ApplicationContext.BusRoutes
                                 .Where(busRoute => busRoute.Route.Id == routeId)
                                 .Include(bus => bus.Route)
                                 .Include(bus => bus.Bus)
                                 .Include(bus => bus.Route.SourceStop)
                                 .Include(bus => bus.Route.DestStop)
                                 .ToList();

            return result;
        }

        private bool CompareStop(int? expectedStopId, int? actualStopId)
        {
            return expectedStopId != null
                    && actualStopId != null
                    && expectedStopId == actualStopId;
        }

        private bool CompareTime(DateTime? expected, DateTime? actual)
        {
            return expected != null
                    && actual != null
                    && expected.Value.CompareTo(actual) < 0;
        }

        //private bool Comparator(BusRoute busRoute, BusSearchOption options)
        //{
        //    return (CompareStop(busRoute.Route.SourceStop.Id, options.SourceId)
        //        && CompareStop(busRoute.Route.DestStop.Id, options.DestId)
        //        && CompareTime(busRoute.ArrivalTime, options.)
        //        && CompareTime(busRoute.DepartureTime, options.DeptTime)
        //        );
        //}

        public IEnumerable<BusRoute> GetBusWithDestination(int destId)
        {
            return ApplicationContext.BusRoutes
                    .Where(m => m.Route.DestStop.Id == destId);
        }

        public IEnumerable<BusRoute> GetBusWithDestination(int destId, DateTime fromTime, DateTime toTime)
        {
            return ApplicationContext.BusRoutes
                    .Where(m => m.Route.DestStop.Id == destId
                            && m.DepartureTime > fromTime && m.DepartureTime <= toTime);
        }

        public IEnumerable<BusRoute> GetBusWithSource(int sourceId)
        {
            return ApplicationContext.BusRoutes
                    .Where(m => m.Route.SourceStop.Id == sourceId);
        }

        public IEnumerable<BusRoute> GetBusWithSource(int sourceId, DateTime fromTime, DateTime toTime)
        {
            return ApplicationContext.BusRoutes
                     .Where(m => m.Route.SourceStop.Id == sourceId
                             && m.DepartureTime > fromTime && m.DepartureTime <= toTime
                            );
        }

        public IEnumerable<BusRoute> GetBusWithDestination(int destId, DateTime fromTime, DateTime toTime, short capacity)
        {
            return ApplicationContext.BusRoutes
                   .Where(m => m.Route.DestStop.Id == destId
                           && m.DepartureTime > fromTime && m.DepartureTime <= toTime
                           && m.Bus.Capacity >= capacity
                          );
        }

        public IEnumerable<BusRoute> GetBusWithSource(int sourceId, DateTime fromTime, DateTime toTime, short capacity)
        {
            return ApplicationContext.BusRoutes
                   .Where(m => m.Route.SourceStop.Id == sourceId
                           && m.DepartureTime > fromTime && m.DepartureTime <= toTime
                           && m.Bus.Capacity >= capacity
                          );
        }
    }
}