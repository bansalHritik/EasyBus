using EasyBus.Data.Contexts;
using EasyBus.Data.Models;
using EasyBus.Shared.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EasyBus.Data.Repository
{
    /// <summary>
    /// Defines the <see cref="RouteRepository" />.
    /// </summary>
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteRepository"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="ApplicationContext"/>.</param>
        public RouteRepository(ApplicationContext context) : base(context)
        {
        }

        new public IEnumerable<Route> GetAll()
        {
            return ApplicationContext.Routes
                        .Include(m => m.DestStop)
                        .Include(m => m.SourceStop)
                        .ToList();
        }

        new public Route Get(int routeId)
        {
            var res = ApplicationContext.Routes
                          .Where(m => m.Id == routeId)
                          .Include(m => m.SourceStop)
                          .Include(m => m.DestStop)
                          .SingleOrDefault();
            return res;
        }

        /// <summary>
        /// The Find.
        /// </summary>
        /// <param name="sourceStopId">The sourceStopId<see cref="long"/>.</param>
        /// <param name="destStopId">The destStopId<see cref="long"/>.</param>
        /// <returns>The <see cref="Route"/>.</returns>
        public Route Find(int sourceStopId, int destStopId)
        {
            var res = Context.Set<Route>()
                   .Where(m => m.SourceStop.Id == sourceStopId && m.DestStop.Id == destStopId)
                   .Include(m => m.SourceStop)
                   .Include(m => m.DestStop)
                   .SingleOrDefault();
            return res;
        }

        public Route Find(string sourceName, string destName)
        {
            var result = ApplicationContext.Routes
                              .Where(route => route.SourceStop.Name.Equals(sourceName)
                                              && route.DestStop.Name.Equals(destName))
                              .Include(route => route.SourceStop)
                              .Include(route => route.DestStop)
                              .SingleOrDefault();
            return result;
        }

        public IEnumerable<Route> GetAllRoutesFromSource(int sourceId)
        {
            var result = ApplicationContext.Routes
                            .Where(route => route.SourceStop.Id == sourceId)
                            .Include(route => route.SourceStop)
                            .Include(route => route.DestStop)
                            .ToList();
            return result;
        }

        public IEnumerable<Route> GetAllRoutesFromSource(string sourceName)
        {
            var result = ApplicationContext.Routes
                            .Where(route => route.SourceStop.Name.Equals(sourceName))
                            .Include(route => route.SourceStop)
                            .Include(route => route.DestStop)
                            .ToList();
            return result;
        }

        public IEnumerable<Route> GetAllRoutesToDest(int destId)
        {
            var result = ApplicationContext.Routes
                            .Where(route => route.DestStop.Id == destId)
                            .Include(route => route.SourceStop)
                            .Include(route => route.DestStop)
                            .ToList();
            return result;
        }

        public IEnumerable<Route> GetAllRoutesToDest(string destName)
        {
            var result = ApplicationContext.Routes
                            .Where(route => route.DestStop.Name == destName)
                            .Include(route => route.SourceStop)
                            .Include(route => route.DestStop)
                            .ToList();
            return result;
        }
    }
}